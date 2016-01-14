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
            model.StartTranz = MainAccessor.GetAllTrans(startDate, null, model.TimeSpan);// Вытащим сразу все транзакции, отдельным запросом
            model.EndTranz = MainAccessor.GetAllTrans(startDate, endDate, model.TimeSpan);
            model.Scores = MainAccessor.GetAllScores();// и счета

            model.BusinessResults = Accessors.GetBusinessResults(model); //Баланс
            model.ReportProfitAndLoss = Accessors.GetReportProfitAndLoss(model);//Отчет о прибылях и убытках

            model.RatiosIndicatorsResult = CalculateRatiosIndicators(endDate, model.BusinessResults, model.ReportProfitAndLoss);

            return model;
        }

        private static RatiosIndicatorsResult CalculateRatiosIndicators(DateTime endDate, BusinessResults businessResults, ReportProfitAndLoss reportProfitAndLoss)
        {
            var model = new RatiosIndicatorsResult();

            model.EndDate = endDate;

            #region Ликвидность

            model.AbsoluteLiquidityRatio = Math.Round((businessResults.BankrollEnd / businessResults.DebtsBanksEnd), 2);
            model.QuickLiquidityRatio = Math.Round(((businessResults.BankrollEnd + businessResults.ReceivablesEnd) / businessResults.DebtsBanksEnd), 2);
            model.CurrentLiquidityRatio = Math.Round((businessResults.TotalCurrentAssetsEnd / businessResults.DebtsBanksEnd), 2);

            #endregion

            #region Показатели деловой активности

            model.InventoryTurnoverRatio = Math.Round(reportProfitAndLoss.TotalCostPrice.Last() / businessResults.InventoriesEnd, 2);
            model.RateOfTurnover = reportProfitAndLoss.TotalCostPrice.Last() != 0 
                ? Math.Round(businessResults.InventoriesEnd * ProcessesEngineConsts.Days / reportProfitAndLoss.TotalCostPrice.Last(), 2)
                : 0;
            model.AccountsReceivableTurnoverRatio = Math.Round(reportProfitAndLoss.TotalIncome.Last() / businessResults.ReceivablesEnd, 2);
            model.TermOfReceivablesTurnover = reportProfitAndLoss.TotalCostPrice.Last() != 0
                ? Math.Round(businessResults.ReceivablesEnd * ProcessesEngineConsts.Days / reportProfitAndLoss.TotalCostPrice.Last(), 2)
                : 0;
            model.AccountsPayableTurnoverRatio = Math.Round(reportProfitAndLoss.TotalIncome.Last() / businessResults.DebtsSupplierBuyersEnd, 2);
            model.TermOfPayablesTurnover = reportProfitAndLoss.TotalIncome.Last() != 0
                ? Math.Round(businessResults.DebtsSupplierBuyersEnd * ProcessesEngineConsts.Days / reportProfitAndLoss.TotalIncome.Last(), 2)
                : 0;

            #endregion

            #region Показатели финансовой устойчивости

            model.CoefficientOfAutonomy = Math.Round(businessResults.OwnCapitalEnd / businessResults.TotalBalanceCurrencyEnd, 2);
            model.CoefficientOfFinancialDependence = Math.Round(businessResults.TotalAccountsPayableEnd / businessResults.OwnCapitalEnd, 2);

            #endregion

            #region Показатели рентабельности

            model.CoefficientOfProfabilityPrimaryActivity = Math.Round(reportProfitAndLoss.Ebitda.Last() / reportProfitAndLoss.TotalIncome.Last(), 2);
            model.CoefficientOfGrossMargin = reportProfitAndLoss.TotalIncome.Last() != 0
                ? Math.Round(reportProfitAndLoss.GrossProfit.Last() / reportProfitAndLoss.TotalIncome.Last(), 2)
                : 0;

            #endregion

            return model;
        }
    }
}
