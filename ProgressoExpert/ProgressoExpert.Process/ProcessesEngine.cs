using ProgressoExpert.Common.Const;
using ProgressoExpert.Common.Enums;
using ProgressoExpert.DataAccess;
using ProgressoExpert.Models.Entities;
using ProgressoExpert.Models.Models;
using ProgressoExpert.Models.Models.BusinessAnalysis;
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

        public static LiveStreamModel GetLiveStream(DateTime startDate, DateTime endDate)
        {
            var MainModel = new MainModel();
            var model = new LiveStreamModel();

            var tmSpan = MainAccessor.GetTimeSpan();
            //TODO поставить текущую дату
            var stTodayDate = new DateTime(4013, 02, 01);
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
            MainModel.BusinessResults = Accessors.GetBusinessResults(MainModel); 

            model.DebtOfCustomers = Math.Round(MainModel.BusinessResults.DebtsOfCustomersAndOverpaymentsEnd, 2);            
            model.GoodsBalance = Math.Round(MainModel.BusinessResults.GoodsEnd, 2);            
            model.PayblesToSupplier = Math.Round(MainModel.BusinessResults.PayablesToSuppliersShortTermDebtsEnd, 2);
            
            model.CycleMoneyDiagram = new Dictionary<string, decimal>();
            model.CycleMoneyDiagram.Add("Деньги в кассе", Math.Round(MainModel.BusinessResults.CashInCashBoxEnd, 2));
            model.CycleMoneyDiagram.Add("Деньги на счетах", Math.Round(MainModel.BusinessResults.MoneyInTheBankAccountsEnd, 2));

            model.CoveringCurrentDebtMoney = Math.Round((MainModel.BusinessResults.CashInCashBoxEnd + MainModel.BusinessResults.MoneyInTheBankAccountsEnd
               + MainModel.BusinessResults.DepositsEnd) / (MainModel.BusinessResults.CurrentDebtEnd != 0 ? MainModel.BusinessResults.CurrentDebtEnd : 1), 2) * 100;
            
            model.CoveringCurrentDebtMoneyAndCustomerDebt = Math.Round((MainModel.BusinessResults.CashInCashBoxEnd + MainModel.BusinessResults.MoneyInTheBankAccountsEnd
                + MainModel.BusinessResults.DepositsEnd + MainModel.BusinessResults.DebtsOfCustomersAndOverpaymentsEnd)
                / (MainModel.BusinessResults.CurrentDebtEnd != 0 ? MainModel.BusinessResults.CurrentDebtEnd : 1), 2) * 100;

            model.CoveringCurrentDebtOfCurrentAssets = Math.Round(MainModel.BusinessResults.CirculatingAssetsEnd
                / (MainModel.BusinessResults.CurrentDebtEnd != 0 ? MainModel.BusinessResults.CurrentDebtEnd : 1), 2) * 100;

            // Текущий месяц            
            sales = Accessors.GetSales(MainModel.StartDate, MainModel.EndDate);
            model.SalesMonth = Math.Round(sales.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS)).Sum(), 2);
            model.GrossProfitMonth = Math.Round(model.SalesMonth - sales.Select(i => i.Sales.Sum(j => j.CostPrise)).Sum(), 2);
            model.ProfitabilityMonth = Math.Round(model.SalesMonth != 0
                    ? (model.GrossProfitMonth / model.SalesMonth) * 100
                    : 0, 2);

            MainModel.ADDSTranz = Accessors.GetAddsTranz(MainModel.StartDate, MainModel.EndDate, MainModel.RegGroups ?? new List<RefGroupsEnt>(), new List<string> { "000000002" });
            model.PaymentCustomersMonth = MainModel.ADDSTranz.Sum(_ => _.Money);
            model.LastMonthDiagram = new Dictionary<string, decimal>();
            model.LastMonthDiagram.Add("Продажи", model.SalesMonth);
            model.LastMonthDiagram.Add("Валовая прибыль", model.GrossProfitMonth);
            model.LastMonthDiagram.Add("Оплата покупателя", model.PaymentCustomersMonth);

            // Прошлый месяц
            sales = Accessors.GetSales(MainModel.StartDate.Month != 1 ?
                                        new DateTime(MainModel.StartDate.Year, MainModel.StartDate.Month - 1, 01) :
                                        new DateTime(MainModel.StartDate.Year - 1, 12, 01)
                                        , MainModel.StartDate);
            model.SalesPastMonth = Math.Round(sales.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS)).Sum(), 2);
            model.GrossProfitPastMonth = Math.Round(model.SalesPastMonth - sales.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS - j.CostPrise)).Sum(), 2);
           
            MainModel.ADDSTranz = Accessors.GetAddsTranz(MainModel.StartDate.Month != 1 ?
                                                            new DateTime(MainModel.StartDate.Year, MainModel.StartDate.Month - 1, 01) :
                                                            new DateTime(MainModel.StartDate.Year - 1, 12, 01)
                                                            , MainModel.StartDate, MainModel.RegGroups ?? new List<RefGroupsEnt>(), new List<string> { "000000002" });
            model.PaymentCustomersPastMonth = MainModel.ADDSTranz.Sum(_ => _.Money);

            model.CurrentMonthDiagram = new Dictionary<string, decimal>();
            model.CurrentMonthDiagram.Add("Продажи", model.SalesPastMonth);
            model.CurrentMonthDiagram.Add("Валовая прибыль", model.GrossProfitPastMonth);
            model.CurrentMonthDiagram.Add("Оплата покупателя", model.PaymentCustomersPastMonth);

            model.AverageGrossProfit = Math.Round(model.GrossProfitPastMonth - model.GrossProfitMonth , 2);
            model.AverageSales = Math.Round(model.SalesPastMonth - model.SalesMonth, 2);
            model.AveragePayment = Math.Round(model.PaymentCustomersPastMonth - model.PaymentCustomersMonth, 2);
            
            model.CountDaysToEndOfMonth = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) - DateTime.Today.Day + 1;

            return model;
        }

        public static void GetGeneralBusinessAnalysis(DateTime startDate, DateTime endDate, MainModel MainModel)
        {
            var tmSpan = MainAccessor.GetTimeSpan();
            var stTodayDate = MainModel.StartDate;
            var endTodayDate = MainModel.EndDate;
            
            var model = new GeneralBusinessAnalysis();
            
            model.Sales = Math.Round(MainModel.Sales.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS)).Sum(), 2);

            
            model.CostPrice = Math.Round(MainModel.Sales.Select(i => i.Sales.Sum(j => j.CostPrise)).Sum(), 2);
            model.GrossProfit = Math.Round(MainModel.Sales.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS - j.CostPrise)).Sum(), 2);            
            model.Cost = MainModel.ReportProfitAndLoss.Costs.Sum();
            
            #region Прошлые периоды
            DateTime newStTodayDate = new DateTime();
            DateTime newEndTodayDate = new DateTime();
            var dif = (endTodayDate.Year - stTodayDate.Year) * 12 + (endTodayDate.Month - stTodayDate.Month);
            if (dif <= 12)
            {
                decimal tmp = decimal.Zero;
                newStTodayDate = stTodayDate.AddMonths(-dif);
                newEndTodayDate = stTodayDate.AddMonths(1);
                var salesFirst = Accessors.GetSales(newStTodayDate, newEndTodayDate);

                MainModel tmMain = new MainModel();
                decimal RPALF = decimal.Zero;
                if (model.Cost > 0)
                {
                    tmMain.StartDate = newStTodayDate;
                    tmMain.EndDate = newEndTodayDate;
                    tmMain.StartTranz = MainAccessor.GetAllTrans(MainModel.StartDate, null); 
                    tmMain.EndTranz = MainAccessor.GetAllTrans(MainModel.StartDate, MainModel.EndDate);
                    tmMain.ReportProfitAndLoss = Accessors.GetReportProfitAndLoss(MainModel);
                    RPALF = tmMain.ReportProfitAndLoss.Costs.Sum();
                    tmp = Math.Round(RPALF / model.Cost * 100, 2);
                    model.CostAnFirst = (tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";
                }

                newStTodayDate = stTodayDate.AddYears(-1);
                newEndTodayDate = endTodayDate.AddYears(-1);
                var salesSecond = Accessors.GetSales(newStTodayDate, newEndTodayDate);

                decimal RPALS = decimal.Zero;
                if (model.Cost > 0)
                {
                    tmMain.StartDate = newStTodayDate;
                    tmMain.EndDate = newEndTodayDate;
                    tmMain.StartTranz = MainAccessor.GetAllTrans(MainModel.StartDate, null); 
                    tmMain.EndTranz = MainAccessor.GetAllTrans(MainModel.StartDate, MainModel.EndDate);
                    tmMain.ReportProfitAndLoss = Accessors.GetReportProfitAndLoss(MainModel);
                    RPALS = tmMain.ReportProfitAndLoss.Costs.Sum();
                    tmp = Math.Round(RPALS / model.Cost * 100, 2);
                    model.CostAnSecond = (tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";
                }

                tmp = Math.Round(salesFirst.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS)).Sum() / model.Sales * 100, 2);
                model.SalesAnFirst = (tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";

                tmp = Math.Round(salesSecond.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS)).Sum() / model.Sales * 100, 2);
                model.SalesAnSecond = (tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";

                tmp = Math.Round(salesFirst.Select(i => i.Sales.Sum(j => j.CostPrise)).Sum() / model.CostPrice * 100, 2);
                model.CostPriceAnFirst = (tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";

                tmp = Math.Round(salesSecond.Select(i => i.Sales.Sum(j => j.CostPrise)).Sum() / model.CostPrice * 100, 2);
                model.CostPriceAnSecond = (tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";

                var GPFtmp = salesFirst.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS - j.CostPrise)).Sum();
                tmp = Math.Round(GPFtmp / model.CostPrice * 100, 2);                
                model.GrossProfitAnFirst = (GPFtmp > 1 ? (GPFtmp - 1).ToString() : (1 - GPFtmp).ToString()) + "%";

                var GPStmp = salesSecond.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS - j.CostPrise)).Sum();
                tmp  = Math.Round(GPStmp / model.CostPrice * 100, 2);
                model.GrossProfitAnSecond = (GPStmp > 1 ? (GPStmp - 1).ToString() : (1 - GPStmp).ToString()) + "%";

                model.NetProfit = Math.Round(model.GrossProfit - model.Cost, 2);
                tmp = Math.Round((GPFtmp - RPALF) / model.NetProfit * 100, 2);
                model.NetProfitAnFirst = (tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";
                tmp = Math.Round((GPStmp - RPALS) / model.NetProfit * 100, 2);
                model.NetProfitAnSecond= (tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";
            }
            else
            {
                model.SalesAnFirst = 
                model.SalesAnSecond =
                model.CostPriceAnSecond =
                model.GrossProfitAnFirst =
                model.GrossProfitAnSecond =
                model.NetProfitAnFirst =
                model.NetProfitAnSecond =
                model.CostAnFirst =
                model.CostAnSecond =
                model.CostPriceAnFirst = "-";
            }
            #endregion

            model.SalesDiagram.Add("Оборотные активы", MainModel.BusinessResults.CirculatingAssetsEnd);
            model.SalesDiagram.Add("Долгосрочные активы", MainModel.BusinessResults.LongTermAssetsEnd);
            model.SalesDiagram.Add("Текущая задолженность", MainModel.BusinessResults.CurrentDebtEnd);
            model.SalesDiagram.Add("Долгосрочная задолженность", MainModel.BusinessResults.LongTermDebtEnd);
            model.SalesDiagram.Add("Собственный капитал", MainModel.BusinessResults.OwnCapitalEnd);

            //Dictionary<string, decimal> allGoods = new Dictionary<string, decimal>() { };
            //foreach (var monthSales in MainModel.Sales)
            //{

            //};
            //model.ProfitabilityDiagram.Add()


        }

        private static void FillPercentForAllProperty(ref string First, ref string Second, DateTime stTodayDate, DateTime endTodayDate, GeneralBusinessAnalysis model
            , List<SalesModel> salesFirst, List<SalesModel> salesSecond, int dif)
        {
            
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
