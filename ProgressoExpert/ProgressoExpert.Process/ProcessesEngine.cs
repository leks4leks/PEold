using ProgressoExpert.Common.Const;
using ProgressoExpert.DataAccess;
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
            model.StartDate = startDate;
            model.EndDate = endDate;

            model.TimeSpan = MainAccessor.GetTimeSpan();// и счета
            model.StartTranz = MainAccessor.GetAllTrans(startDate, null, model.TimeSpan); // Вытащим сразу все транзакции, отдельным запросом
            model.EndTranz = MainAccessor.GetAllTrans(startDate, endDate, model.TimeSpan);
            model.Scores = MainAccessor.GetAllScores();// и счета
            model.RegGroups = MainAccessor.GetAllGroups();// группы

            model.BusinessResults = Accessors.GetBusinessResults(model); //Баланс
            model.ReportProfitAndLoss = Accessors.GetReportProfitAndLoss(model); //Отчет о прибылях и убытках

            model.RatiosIndicatorsResult = CalculateRatiosIndicators(startDate, endDate, model.BusinessResults, model.ReportProfitAndLoss);

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
