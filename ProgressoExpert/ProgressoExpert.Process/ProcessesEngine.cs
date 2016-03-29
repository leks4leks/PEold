using ProgressoExpert.Common.Const;
using ProgressoExpert.DataAccess;
using ProgressoExpert.Models.Entities;
using ProgressoExpert.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Process
{
    public class ProcessesEngine
    {
        public static MainModel GetResult(DateTime startDate, DateTime endDate)
        {
            var model = new MainModel();

            model.LiveStreamModel = GetLiveStream(startDate, endDate);
            return model;

            model.TimeSpan = MainAccessor.GetTimeSpan();// и счета

            model.StartDate = startDate.AddYears(model.TimeSpan);
            model.EndDate = endDate.AddYears(model.TimeSpan).AddHours(23).AddMinutes(59).AddSeconds(59);

            model.StartTranz = MainAccessor.GetAllTrans(model.StartDate, null); // Вытащим сразу все транзакции, отдельным запросом
            model.EndTranz = MainAccessor.GetAllTrans(model.StartDate, model.EndDate);
            
            model.BusinessResults = Accessors.GetBusinessResults(model); //Баланс
            model.ReportProfitAndLoss = Accessors.GetReportProfitAndLoss(model); //Отчет о прибылях и убытках

			model.RegGroups = MainAccessor.GetAllGroups();// группы
            model.ADDSTranz = Accessors.GetAddsTranz(model.StartDate, model.EndDate, model.RegGroups ?? new List<RefGroupsEnt>(), new List<string> { });
            
            model.Sales = Accessors.GetSales(model.StartDate, model.EndDate);

            model.RatiosIndicatorsResult = CalculateRatiosIndicators(startDate, endDate, model.BusinessResults, model.ReportProfitAndLoss);

            return model;
        }

        private static LiveStreamModel GetLiveStream(DateTime startDate, DateTime endDate)
        {
            var MainModel = new MainModel();
            var model = new LiveStreamModel();

            var tmSpan = MainAccessor.GetTimeSpan();
            //TODO поставить текущую дату
            var stTodayDate = new DateTime(4013, 01, 01);
            var endTodayDate = DateTime.Today.AddYears(tmSpan);

            MainModel.StartDate = new DateTime(stTodayDate.Year, stTodayDate.Month, 01);
            MainModel.EndDate = new DateTime(stTodayDate.Month != 12 ? stTodayDate.Year : stTodayDate.Year + 1, stTodayDate.Month != 12 ? stTodayDate.Month + 1 : 01, 01);
            // Сегодня

            var sales = Accessors.GetSales(stTodayDate, endTodayDate);
            model.SalesToday = Math.Round(sales.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS)).Sum(), 2);
            model.GrossProfitToday = Math.Round(model.SalesToday - sales.Select(i => i.Sales.Sum(j => j.CostPrise)).Sum(), 2);
            model.ProfitabilityToday = Math.Round(model.SalesToday != 0 
                    ? (model.GrossProfitToday / model.SalesToday) * 100
                    : 0, 2);

            MainModel.RegGroups = MainAccessor.GetAllGroups();// группы
            MainModel.ADDSTranz = Accessors.GetAddsTranz(stTodayDate, endTodayDate, MainModel.RegGroups ?? new List<RefGroupsEnt>(), new List<string> { "000000002" });
            model.PaymentCustomersToday = MainModel.ADDSTranz.Sum(_ => _.Money);

            MainModel.StartTranz = MainAccessor.GetAllTrans(stTodayDate, null); // Вытащим сразу все транзакции, отдельным запросом
            MainModel.EndTranz = MainAccessor.GetAllTrans(stTodayDate, endTodayDate);
            MainModel.BusinessResults = Accessors.GetBusinessResults(MainModel, true); //Баланс
            model.CycleMoneyDiagram = new Dictionary<string, decimal>();
            model.CycleMoneyDiagram.Add("Деньги в кассе", Math.Round(MainModel.BusinessResults.CashInCashBoxEnd, 2));
            model.CycleMoneyDiagram.Add("Деньги на счетах", Math.Round(MainModel.BusinessResults.MoneyInTheBankAccountsEnd, 2));

            // Текущий месяц
            sales = Accessors.GetSales(MainModel.StartDate, MainModel.EndDate);
            model.SalesMonth = Math.Round(sales.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS)).Sum(), 2);
            model.GrossProfitMonth = Math.Round(model.SalesMonth - sales.Select(i => i.Sales.Sum(j => j.CostPrise)).Sum(), 2);
            model.ProfitabilityMonth = Math.Round(model.SalesMonth != 0
                    ? (model.GrossProfitMonth / model.SalesMonth) * 100
                    : 0, 2);

            MainModel.ADDSTranz = Accessors.GetAddsTranz(MainModel.StartDate, MainModel.EndDate, MainModel.RegGroups ?? new List<RefGroupsEnt>(), new List<string> { "000000002" });
            model.PaymentCustomersMonth = MainModel.ADDSTranz.Sum(_ => _.Money);

            return model;
        }

        private static RatiosIndicatorsResult CalculateRatiosIndicators(DateTime startDate, DateTime endDate, BusinessResults businessResults, ReportProfitAndLoss reportProfitAndLoss)
        {
            var model = new RatiosIndicatorsResult();

            model.EndDate = endDate;
            model.StartDate = startDate;

            #region Первый блок

            #region Вест сайд

            model.CoveringCurrentDebtMoneyStart = Math.Round((businessResults.CashInCashBoxStart + businessResults.MoneyInTheBankAccountsStart 
                + businessResults.DepositsStart) / (businessResults.CurrentDebtStart != 0 ? businessResults.CurrentDebtStart : 1), 2);
            model.CoveringCurrentDebtMoneyEnd = Math.Round((businessResults.CashInCashBoxEnd + businessResults.MoneyInTheBankAccountsEnd
                + businessResults.DepositsEnd) / (businessResults.CurrentDebtEnd != 0 ? businessResults.CurrentDebtEnd : 1), 2);

            model.CoveringCurrentDebtMoneyAndCustomerDebtsStart = Math.Round((businessResults.CashInCashBoxStart + businessResults.MoneyInTheBankAccountsStart
                + businessResults.DepositsStart + businessResults.DebtsOfCustomersAndOverpaymentsStart)
                / (businessResults.CurrentDebtStart != 0 ? businessResults.CurrentDebtStart : 1), 2);
            model.CoveringCurrentDebtMoneyAndCustomerDebtsEnd = Math.Round((businessResults.CashInCashBoxEnd + businessResults.MoneyInTheBankAccountsEnd
                + businessResults.DepositsEnd + businessResults.DebtsOfCustomersAndOverpaymentsEnd)
                / (businessResults.CurrentDebtEnd != 0 ? businessResults.CurrentDebtEnd : 1), 2);

            model.CoveringCurrentDebtOfCurrentAssetsStart = Math.Round(businessResults.CirculatingAssetsStart 
                / (businessResults.CurrentDebtStart != 0 ? businessResults.CurrentDebtStart : 1), 2);
            model.CoveringCurrentDebtOfCurrentAssetsEnd = Math.Round(businessResults.CirculatingAssetsEnd 
                / (businessResults.CurrentDebtEnd != 0 ? businessResults.CurrentDebtEnd : 1), 2);

            #endregion

            #region Ист сайд

            model.DebtPartInTheCompanyAssetsStart = Math.Round((businessResults.CurrentDebtStart + businessResults.LongTermDebtStart)
                / (businessResults.TotalLiabilitiesStart != 0 ? businessResults.TotalLiabilitiesStart : 1), 2);
            model.DebtPartInTheCompanyAssetsEnd = Math.Round((businessResults.CurrentDebtEnd + businessResults.LongTermDebtEnd)
                / (businessResults.TotalLiabilitiesEnd != 0 ? businessResults.TotalLiabilitiesEnd : 1), 2);

            model.PartOfEquityInTheCompanyAssetsStart = Math.Round(businessResults.OwnCapitalStart + businessResults.TotalLiabilitiesStart, 2);
            model.PartOfEquityInTheCompanyAssetsEnd = Math.Round(businessResults.OwnCapitalEnd + businessResults.TotalLiabilitiesEnd, 2);

            model.CoveringLoansByEquityStart = Math.Round((businessResults.CreditsForOneYearStart + businessResults.CreditsForLongerThanOneYearStart) 
                / (businessResults.OwnCapitalStart != 0 ? businessResults.OwnCapitalStart : 1), 2);
            model.CoveringLoansByEquityEnd = Math.Round((businessResults.CreditsForOneYearEnd + businessResults.CreditsForLongerThanOneYearEnd)
                / (businessResults.OwnCapitalEnd != 0 ? businessResults.OwnCapitalEnd : 1), 2);

            #endregion

            #endregion

            #region Второй блок

            #region Вест сайд

            model.SpeedOfTurnover = 1;

            model.TermOfCirculationOfClientsDebt = 1;

            #endregion

            #region Ист сайд

            model.TermOfCirculationOfDebtToSuppliers = 1;

            #endregion

            #endregion

            //#region Ликвидность

            //model.AbsoluteLiquidityRatio = businessResults.DebtsBanksEnd != 0
            //    ? Math.Round((businessResults.CashInCashBoxEnd / businessResults.DebtsBanksEnd), 2)
            //    : 0;
            //model.QuickLiquidityRatio = businessResults.DebtsBanksEnd != 0
            //    ? Math.Round(((businessResults.CashInCashBoxEnd + businessResults.DebtsOfCustomersAndOverpaymentsEnd) / businessResults.DebtsBanksEnd), 2)
            //    : 0;
            //model.CurrentLiquidityRatio = businessResults.DebtsBanksEnd != 0
            //    ? Math.Round((businessResults.TotalCurrentAssetsEnd / businessResults.DebtsBanksEnd), 2)
            //    : 0;

            //#endregion

            //#region Показатели деловой активности

            //model.InventoryTurnoverRatio = businessResults.InventoriesEnd != 0
            //    ? Math.Round(reportProfitAndLoss.TotalCostPrice.Last() / businessResults.InventoriesEnd, 2)
            //    : 0;
            //model.RateOfTurnover = reportProfitAndLoss.TotalCostPrice.Last() != 0 
            //    ? Math.Round(businessResults.InventoriesEnd * ProcessesEngineConsts.Days / reportProfitAndLoss.TotalCostPrice.Last(), 2)
            //    : 0;
            //model.AccountsReceivableTurnoverRatio = businessResults.DebtsOfCustomersAndOverpaymentsEnd != 0
            //    ? Math.Round(reportProfitAndLoss.TotalIncome.Last() / businessResults.DebtsOfCustomersAndOverpaymentsEnd, 2)
            //    : 0;
            //model.TermOfReceivablesTurnover = reportProfitAndLoss.TotalCostPrice.Last() != 0
            //    ? Math.Round(businessResults.DebtsOfCustomersAndOverpaymentsEnd * ProcessesEngineConsts.Days / reportProfitAndLoss.TotalCostPrice.Last(), 2)
            //    : 0;
            //model.AccountsPayableTurnoverRatio = businessResults.DebtsSupplierBuyersEnd != 0
            //    ? Math.Round(reportProfitAndLoss.TotalIncome.Last() / businessResults.DebtsSupplierBuyersEnd, 2)
            //    : 0;
            //model.TermOfPayablesTurnover = reportProfitAndLoss.TotalIncome.Last() != 0
            //    ? Math.Round(businessResults.DebtsSupplierBuyersEnd * ProcessesEngineConsts.Days / reportProfitAndLoss.TotalIncome.Last(), 2)
            //    : 0;

            //#endregion

            //#region Показатели финансовой устойчивости

            //model.CoefficientOfAutonomy = businessResults.TotalBalanceCurrencyEnd != 0
            //    ? Math.Round(businessResults.OwnCapitalEnd / businessResults.TotalBalanceCurrencyEnd, 2)
            //    : 0;
            //model.CoefficientOfFinancialDependence = businessResults.OwnCapitalEnd != 0
            //    ? Math.Round(businessResults.TotalAccountsPayableEnd / businessResults.OwnCapitalEnd, 2)
            //    : 0;

            //#endregion

            //#region Показатели рентабельности

            //model.CoefficientOfProfabilityPrimaryActivity = reportProfitAndLoss.TotalIncome.Last() != 0
            //    ? Math.Round(reportProfitAndLoss.Ebitda.Last() / reportProfitAndLoss.TotalIncome.Last(), 2)
            //    : 0;
            //model.CoefficientOfGrossMargin = reportProfitAndLoss.TotalIncome.Last() != 0
            //    ? Math.Round(reportProfitAndLoss.GrossProfit.Last() / reportProfitAndLoss.TotalIncome.Last(), 2)
            //    : 0;

            //#endregion

            return model;
        }
    }
}
