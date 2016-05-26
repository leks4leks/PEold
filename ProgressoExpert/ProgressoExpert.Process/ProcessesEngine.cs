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
        static int dif = 0;
        public static MainModel InitMainModel(DateTime startDate, DateTime endDate)
        {
            var model = new MainModel();

            model.TimeSpan = MainAccessor.GetTimeSpan();// и счета

            model.StartDate = startDate.AddYears(model.TimeSpan);
            model.EndDate = endDate.AddYears(model.TimeSpan);

            model.StartTranz = MainAccessor.GetAllTrans(model.StartDate, null); // Вытащим сразу все транзакции, отдельным запросом
            model.EndTranz = MainAccessor.GetAllTrans(model.StartDate, model.EndDate);

            model.StartTranzOriginal = MainAccessor.GetAllTransOriginal(model.StartDate, null); // Вытащим сразу все транзакции, отдельным запросом
            model.EndTranzOriginal = MainAccessor.GetAllTransOriginal(model.StartDate, model.EndDate);

            model.RegGroups = MainAccessor.GetAllGroups();// группы
            model.ADDSTranz = Accessors.GetAddsTranz(model.StartDate, model.EndDate, model.RegGroups ?? new List<RefGroupsEnt>(), new List<string> { });
            
            model.Sales = Accessors.GetSales(model.StartDate, model.EndDate);

            return model;
        }

        public static BusinessResults GetBusinessResults(MainModel model)
        {
            return Accessors.GetBusinessResults(model);
        }

        public static ReportProfitAndLoss GetReportProfitAndLoss(MainModel model)
        {
            return Accessors.GetReportProfitAndLoss(model);
        }

        public static RatiosIndicatorsResult GetRatiosIndicatorsResult(MainModel MainModel)
        {
            var model = new RatiosIndicatorsResult();
            BusinessResults businessResults = MainModel.BusinessResults;
            ReportProfitAndLoss reportProfitAndLoss = MainModel.ReportProfitAndLoss;

            model.EndDate = MainModel.EndDate;
            model.StartDate = MainModel.StartDate;

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

            var sum = reportProfitAndLoss.TotalCostPrice.Count != 0 ? reportProfitAndLoss.TotalCostPrice.Sum() : 1;
            model.SpeedOfTurnover = Math.Round(businessResults.GoodsEnd * MainModel.DaysInPeriod /
                (sum != 0 ? sum : 1), 0);

            sum = reportProfitAndLoss.TotalIncome.Count != 0 ? reportProfitAndLoss.TotalIncome.Sum() : 1;
            model.TermOfCirculationOfClientsDebt = Math.Round(businessResults.DebtsOfCustomersAndOverpaymentsEnd * MainModel.DaysInPeriod /
                (sum != 0 ? sum : 1), 0);

            sum = reportProfitAndLoss.TotalIncome.Count != 0 ? reportProfitAndLoss.TotalIncome.Sum() : 1;
            model.TermOfCirculationOfDebtToSuppliers = Math.Round(businessResults.PayablesToSuppliersShortTermDebtsEnd * MainModel.DaysInPeriod /
                (sum != 0 ? sum : 1), 0);

            #endregion

            return model;
        }

        public static LiveStreamModel GetLiveStream(DateTime startDate, DateTime endDate)
        {
            var MainModel = new MainModel();
            var model = new LiveStreamModel();

            var tmSpan = MainAccessor.GetTimeSpan();
            //TODO поставить текущую дату
            var stTodayDate = new DateTime(4012, 10, 01);
            var endTodayDate = new DateTime(4013, 09, 01); //DateTime.Today.AddYears(tmSpan);

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

            MainModel.StartTranzOriginal = MainAccessor.GetAllTransOriginal(MainModel.StartDate, null);
            MainModel.EndTranzOriginal = MainAccessor.GetAllTransOriginal(MainModel.StartDate, MainModel.EndDate);

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

            model.AverageGrossProfit = Math.Round(model.GrossProfitPastMonth - model.GrossProfitMonth, 2);
            model.AverageSales = Math.Round(model.SalesPastMonth - model.SalesMonth, 2);
            model.AveragePayment = Math.Round(model.PaymentCustomersPastMonth - model.PaymentCustomersMonth, 2);

            model.CountDaysToEndOfMonth = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) - DateTime.Today.Day + 1;

            return model;
        }

        public static GeneralBusinessAnalysis GetGeneralBusinessAnalysis(DateTime startDate, DateTime endDate, MainModel MainModel)
        {
            var tmSpan = MainAccessor.GetTimeSpan();
            var stTodayDate = MainModel.StartDate;
            var endTodayDate = MainModel.EndDate;

            var model = new GeneralBusinessAnalysis();

            model.Sales = Math.Round(MainModel.Sales.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS)).Sum(), 2);

            model.CostPrice = Math.Round(MainModel.Sales.Select(i => i.Sales.Sum(j => j.CostPrise)).Sum(), 2);
            //TODO вроде верная дрянь но считается она не верно
            model.GrossProfit = Math.Round(MainModel.Sales.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS - j.CostPrise)).Sum(), 2);
            model.AveGrossProfit = Math.Round(MainModel.Sales.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS - j.AveCostPrise)).Sum(), 2);

            model.Cost = MainModel.ReportProfitAndLoss.Costs.Sum();

            #region Прошлые периоды
            MainModel.newStTodayDate = new DateTime();
            MainModel.newEndTodayDate = new DateTime();
            dif = (endTodayDate.Year - stTodayDate.Year) * 12 + (endTodayDate.Month - stTodayDate.Month);
            if (dif <= 12)
            {
                decimal tmp = decimal.Zero;
                MainModel.newStTodayDate = stTodayDate.AddMonths(-dif);
                MainModel.newEndTodayDate = stTodayDate.AddMonths(1);
                model.salesFirst = Accessors.GetSales(MainModel.newStTodayDate, MainModel.newEndTodayDate);

                MainModel tmMain = new MainModel();
                decimal RPALF = decimal.Zero;
                if (model.Cost > 0)
                {
                    tmMain.StartDate = MainModel.newStTodayDate;
                    tmMain.EndDate = MainModel.newEndTodayDate;
                    tmMain.StartTranz = MainAccessor.GetAllTrans(MainModel.StartDate, null);
                    tmMain.EndTranz = MainAccessor.GetAllTrans(MainModel.StartDate, MainModel.EndDate);
                    tmMain.StartTranzOriginal = MainAccessor.GetAllTransOriginal(MainModel.StartDate, null);
                    tmMain.EndTranzOriginal = MainAccessor.GetAllTransOriginal(MainModel.StartDate, MainModel.EndDate);
                    tmMain.ReportProfitAndLoss = Accessors.GetReportProfitAndLoss(MainModel);
                    RPALF = tmMain.ReportProfitAndLoss.Costs.Sum();
                    tmp = Math.Round(RPALF / model.Cost * 100, 2);
                    model.CostAnFirst = tmp; //(tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";
                }

                MainModel.newStTodayDate = stTodayDate.AddYears(-1);
                MainModel.newEndTodayDate = endTodayDate.AddYears(-1);
                var salesSecond = Accessors.GetSales(MainModel.newStTodayDate, MainModel.newEndTodayDate);

                decimal RPALS = decimal.Zero;
                if (model.Cost > 0)
                {
                    tmMain.StartDate = MainModel.newStTodayDate;
                    tmMain.EndDate = MainModel.newEndTodayDate;
                    tmMain.StartTranz = MainAccessor.GetAllTrans(MainModel.StartDate, null);
                    tmMain.EndTranz = MainAccessor.GetAllTrans(MainModel.StartDate, MainModel.EndDate);
                    tmMain.StartTranzOriginal = MainAccessor.GetAllTransOriginal(MainModel.StartDate, null);
                    tmMain.EndTranzOriginal = MainAccessor.GetAllTransOriginal(MainModel.StartDate, MainModel.EndDate);
                    tmMain.ReportProfitAndLoss = Accessors.GetReportProfitAndLoss(MainModel);
                    RPALS = tmMain.ReportProfitAndLoss.Costs.Sum();
                    tmp = Math.Round(RPALS / model.Cost * 100, 2);
                    model.CostAnSecond = tmp; // (tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";
                }

                tmp = Math.Round(model.salesFirst.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS)).Sum() / model.Sales * 100, 2);
                model.SalesAnFirst = tmp; //(tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";

                tmp = Math.Round(salesSecond.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS)).Sum() / model.Sales * 100, 2);
                model.SalesAnSecond = tmp; //(tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";

                tmp = Math.Round(model.salesFirst.Select(i => i.Sales.Sum(j => j.CostPrise)).Sum() / model.CostPrice * 100, 2);
                model.CostPriceAnFirst = tmp; //(tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";

                tmp = Math.Round(salesSecond.Select(i => i.Sales.Sum(j => j.CostPrise)).Sum() / model.CostPrice * 100, 2);
                model.CostPriceAnSecond = tmp; //(tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";

                var GPFtmp = model.salesFirst.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS - j.CostPrise)).Sum();
                tmp = Math.Round(GPFtmp / model.CostPrice * 100, 2);
                model.GrossProfitAnFirst = tmp; //(GPFtmp > 1 ? (GPFtmp - 1).ToString() : (1 - GPFtmp).ToString()) + "%";

                var GPStmp = salesSecond.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS - j.CostPrise)).Sum();
                tmp = Math.Round(GPStmp / model.CostPrice * 100, 2);
                model.GrossProfitAnSecond = tmp; // (GPStmp > 1 ? (GPStmp - 1).ToString() : (1 - GPStmp).ToString()) + "%";

                model.NetProfit = Math.Round(model.GrossProfit - model.Cost, 2);
                tmp = Math.Round((GPFtmp - RPALF) / model.NetProfit * 100, 2);
                model.NetProfitAnFirst = tmp; //(tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";
                tmp = Math.Round((GPStmp - RPALS) / model.NetProfit * 100, 2);
                model.NetProfitAnSecond = tmp; //(tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";
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
                model.CostPriceAnFirst = 0;//"-";
            }
            #endregion

            model.StructureCompanyDiagram = new Dictionary<string, decimal>();
            model.StructureCompanyDiagram.Add("Оборотные активы", Math.Round(MainModel.BusinessResults.CirculatingAssetsEnd / (MainModel.BusinessResults.CirculatingAssetsEnd + MainModel.BusinessResults.LongTermAssetsEnd) * 100, 2));
            model.StructureCompanyDiagram.Add("Долгосрочные активы", 100 - Math.Round(MainModel.BusinessResults.CirculatingAssetsEnd / (MainModel.BusinessResults.CirculatingAssetsEnd + MainModel.BusinessResults.LongTermAssetsEnd) * 100, 2));
            model.StructureCompanyDiagram.Add("Текущая задолженность", Math.Round(MainModel.BusinessResults.CurrentDebtEnd / (MainModel.BusinessResults.CurrentDebtEnd + MainModel.BusinessResults.LongTermDebtEnd + MainModel.BusinessResults.OwnCapitalEnd) * 100, 2));
            model.StructureCompanyDiagram.Add("Долгосрочная задолженность", Math.Round(MainModel.BusinessResults.LongTermDebtEnd / (MainModel.BusinessResults.CurrentDebtEnd + MainModel.BusinessResults.LongTermDebtEnd + MainModel.BusinessResults.OwnCapitalEnd) * 100, 2));
            model.StructureCompanyDiagram.Add("Собственный капитал", 100 -
                Math.Round(MainModel.BusinessResults.CurrentDebtEnd / (MainModel.BusinessResults.CurrentDebtEnd + MainModel.BusinessResults.LongTermDebtEnd + MainModel.BusinessResults.OwnCapitalEnd) * 100, 2)
                - Math.Round(MainModel.BusinessResults.LongTermDebtEnd / (MainModel.BusinessResults.CurrentDebtEnd + MainModel.BusinessResults.LongTermDebtEnd + MainModel.BusinessResults.OwnCapitalEnd) * 100, 2));

            #region рентабельность
            //Для рентабельности вложенных денег нам необходимо знать сколько какого товара на начало периода
            //var beginingDate = new DateTime(2010, 01, 01);
            //var beginingSalesModel = Accessors.GetSalesOneQuery(stTodayDate, endTodayDate);
            //var beginingSales = beginingSalesModel.SelectMany(_ => _.Sales);// вытащим все месяца в одну ентити
            //var GroupsBSales = (from bs in beginingSales
            //                    group bs by bs.GroupCode into g
            //                    select new SalesEnt
            //                    {
            //                        GroupCode = g.FirstOrDefault().GroupCode,
            //                        GroupName = g.FirstOrDefault().GroupName,
            //                        CostPrise = g.Sum(_ => _.CostPrise),
            //                        SalesWithoutNDS = g.Sum(_ => _.SalesWithoutNDS),
            //                        CountPur = g.Sum(_ => _.CountPur),
            //                        CountSal = g.Sum(_ => _.CountSal),
            //                        CountGoodsSt = g.Sum(_ => _.CountGoodsSt),
            //                        CountGoodsEnd = g.Sum(_ => _.CountGoodsEnd)
            //                    }
            //                    ).ToList();

            //тоже самое уже для нашего периода
            //Вроде не нужно
            //var thisSales = Accessors.GetSalesOneQuery(stTodayDate, endTodayDate);
            var sEnt = MainModel.Sales.SelectMany(_ => _.Sales);
            model.gSales = (from s in sEnt
                            group s by s.GroupCode into g
                            select new SalesEnt
                            {
                                GroupCode = g.FirstOrDefault().GroupCode,
                                GroupName = g.FirstOrDefault().GroupName,
                                CostPrise = g.Sum(_ => _.CostPrise),
                                SalesWithoutNDS = g.Sum(_ => _.SalesWithoutNDS),
                                CountPur = g.Sum(_ => _.CountPur),
                                CountSal = g.Sum(_ => _.CountSal),
                                CountGoodsSt = g.Sum(_ => _.CountGoodsSt),
                                CountGoodsEnd = g.Sum(_ => _.CountGoodsEnd),
                                AveCostPrise = g.Sum(_ => _.AveCostPrise)
                            }
                          ).ToList();

            model.gSalesByClient = (from s in sEnt
                                    group s by s.BuyerCode into g
                                    select new SalesEnt
                                    {
                                        BuyerCode = g.FirstOrDefault().BuyerCode,
                                        BuyerName = g.FirstOrDefault().BuyerName,
                                        CostPrise = g.Sum(_ => _.CostPrise),
                                        SalesWithoutNDS = g.Sum(_ => _.SalesWithoutNDS),
                                        CountPur = g.Sum(_ => _.CountPur),
                                        CountSal = g.Sum(_ => _.CountSal),
                                        CountGoodsSt = g.Sum(_ => _.CountGoodsSt),
                                        CountGoodsEnd = g.Sum(_ => _.CountGoodsEnd),
                                        AveCostPrise = g.Sum(_ => _.AveCostPrise)
                                    }
                                  ).ToList();

            //TODO  спросить что с группами которые купили и продали внутри периода
            //с процентами беда
            var averageRentSales = (from s in model.gSales 
                                    where s.CountGoodsSt != 0 || s.CountGoodsEnd != 0
                                    select new FillModel
                                    {
                                        Name = s.GroupName,
                                        Share = MainModel.Sales.SelectMany(_ => _.Sales).Where(_ => _.GroupCode == s.GroupCode).Sum(i => i.SalesWithoutNDS - i.AveCostPrise) / ((s.CountGoodsSt + s.CountGoodsEnd) / 2) * 100
                                    }
                                    ).OrderByDescending(_ => _.Share).ToList();
            model.ProfitabilityDiagram = averageRentSales;
            #endregion

            #region объем оборотного капитала и все к нему
            model.SalesDiagram = new Dictionary<string, decimal>();
            foreach (var mon in MainModel.Sales)
            {
                model.SalesDiagram.Add(((Month)mon.Date.Month).ToString(), mon.Sales.Sum(_ => _.SalesWithoutNDS));
            }

            model.NetProfitDiagram = new Dictionary<string, decimal>();
            var tmpMon = 0;
            for (int i = 0; i <= dif; i++)
            {
                if (startDate.Month + i > 12) tmpMon = i - 12;
                else tmpMon = startDate.Month + i;
                model.NetProfitDiagram.Add(((Month)tmpMon).ToString(), MainModel.ReportProfitAndLoss.Costs.ToArray()[i]);
            }

            var mm = new MainModel();
            model.AverageWorkingCapitalDiagram = new Dictionary<string, decimal>();
            int[] endMonthYear = new int[] { MainModel.EndDate.Month, MainModel.EndDate.Year };

            int monthCount = 0;
            int[] startMonthYear = new int[] { MainModel.StartDate.Month, MainModel.StartDate.Year };//будем бежать от начала до конца периода
            do
            {
                mm.StartDate = new DateTime(startMonthYear[1], startMonthYear[0], 01);
                mm.EndDate = new DateTime(startMonthYear[1], startMonthYear[0], DateTime.DaysInMonth(startMonthYear[1], startMonthYear[0]))
                    .AddHours(23).AddMinutes(59).AddSeconds(59);

                mm.StartTranz = MainModel.StartTranz.Where(_ => _.period < mm.StartDate).ToList();
                mm.EndTranz = MainModel.EndTranz.Where(_ => _.period < mm.EndDate).ToList();
                
                mm.StartTranzOriginal = MainModel.StartTranzOriginal.Where(_ => _.period < mm.StartDate).ToList();
                mm.EndTranzOriginal = MainModel.EndTranzOriginal.Where(_ => _.period < mm.EndDate).ToList();
                if (mm.EndTranz.Where(_ => _.period < mm.StartDate).Count() > 0)
                    mm.StartTranz.AddRange(mm.EndTranz.Where(_ => _.period < mm.StartDate).ToList());//чтобы из бд не тащить мы переложим из модельки за текущий период транзикции в прошедщий период

                var tmp = Accessors.GetBusinessResults(mm);
                model.AverageWorkingCapitalDiagram.Add(((Month)startMonthYear[0]).ToString(), (tmp.CirculatingAssetsStart + tmp.CirculatingAssetsEnd) / 2);

                #region Cчитаем кол-во месяцев
                if (startMonthYear[0] == 12)
                {
                    startMonthYear[1]++;
                    startMonthYear[0] = 1;
                    monthCount++;
                }
                else
                {
                    startMonthYear[0]++;
                    monthCount++;
                }
                #endregion

            }
            while ((startMonthYear[1] <= endMonthYear[1] && startMonthYear[1] != endMonthYear[1]) || (startMonthYear[0] <= endMonthYear[0] && startMonthYear[1] == endMonthYear[1]));
            #endregion 

            return model;
        }

        public static ProfitBusinessAnalysis GetProfitBA(MainModel MainModel)
        {
            var model = new ProfitBusinessAnalysis();

            //пока валовая равна чистой т.к. у нас нет расходов
            model.GrossProfit = MainModel.GeneralBA.GrossProfit;
            model.GrossProfitAnFirst = MainModel.GeneralBA.GrossProfitAnFirst;
            model.NetProfit = MainModel.GeneralBA.NetProfit;
            model.NetProfitAnFirst = MainModel.GeneralBA.NetProfitAnFirst;

            var mM = MainModel.Sales.Sum(_ => _.Sales.Sum(s => s.SalesWithoutNDS));// выручка - цена продажи
            model.NetProfitability = Math.Round(model.NetProfit / mM * 100, 2);
            model.AverageNetProfitByMonth = Math.Round(model.NetProfit / dif, 2);

            model.GrossProfitability = Math.Round(model.GrossProfit / mM * 100, 2);
            model.AverageGrossProfitByMonth = Math.Round(model.GrossProfit / dif, 2);

            model.SavedProfit = Math.Round(MainModel.BusinessResults.AccumulatedProfitAndLossStart + MainModel.BusinessResults.AccumulatedProfitAndLossEnd, 2);

            //Динамика валовой и чистой прибыли и рентабильность тут же
            model.GrossProfitDiagram = new Dictionary<string, decimal>();
            model.NetProfitDiagram = new Dictionary<string, decimal>();
            model.GrossProfitabilityDiagram = new Dictionary<string, decimal>();
            model.NetProfitabilityDiagram = new Dictionary<string, decimal>();
            var counter = 0;//счетчик месяцев
            foreach (var mon in MainModel.Sales)
            {
                var gp = mon.Sales.Sum(_ => _.SalesWithoutNDS - _.CostPrise);
                   model.GrossProfitDiagram.Add(((Month)mon.Date.Month).ToString(), gp);
                model.NetProfitDiagram.Add(((Month)mon.Date.Month).ToString(),
                    gp - MainModel.ReportProfitAndLoss.Costs.ToArray()[counter]
                    );

                var tj =  mon.Sales.Sum(s => s.SalesWithoutNDS);// выручка - цена продажи

                model.GrossProfitabilityDiagram.Add(((Month)mon.Date.Month).ToString(), Math.Round(gp / tj * 100, 2));

                model.NetProfitabilityDiagram.Add(((Month)mon.Date.Month).ToString(),
                    Math.Round((gp - MainModel.ReportProfitAndLoss.Costs[counter]) / tj * 100, 2));
                counter++;
            }

            //структура валовой прибыли по товарам
            var StrBestGoods = MainModel.GeneralBA.gSales
                        .Select(_ => new { gName = _.GroupName, gGrow = _.SalesWithoutNDS - _.CostPrise, gPrice = _.SalesWithoutNDS })
                        .OrderByDescending(_ => _.gGrow)
                        .Take(3);
            model.StructureGrossProfitGoodsDiagram = new Dictionary<string, decimal>();
            model.StructureGrossProfitGoodsInfo = new List<FillModel>();
            foreach (var g in StrBestGoods)
            {
                var ty = MainModel.GeneralBA.gSales.Where(_ => _.GroupName == g.gName).Sum(_ => _.SalesWithoutNDS - _.CostPrise);
                model.StructureGrossProfitGoodsDiagram.Add(g.gName, Math.Round(g.gGrow, 2));
                model.StructureGrossProfitGoodsInfo.Add(new FillModel
                {
                    Name = g.gName,
                    Share = Math.Round(ty / MainModel.GeneralBA.gSales.Sum(_ => _.SalesWithoutNDS - _.CostPrise) * 100, 2) ,
                    Value = Math.Round(ty
                        / MainModel.GeneralBA.gSales.Sum(_ => _.SalesWithoutNDS) * 100, 2)
                });
            }

            model.StructureGrossProfitGoodsInfo.OrderByDescending(_ => _.Share);


            //структура валовой прибыли по клиентам
            var StrBestClient = MainModel.GeneralBA.gSalesByClient
                        .Select(_ => new { gName = _.BuyerName, gGrow = _.SalesWithoutNDS - _.CostPrise, gPrice = _.SalesWithoutNDS })
                        .OrderByDescending(_ => _.gGrow)
                        .Take(5);
            model.StructureGrossProfitClientDiagram = new Dictionary<string, decimal>();
            model.StructureGrossProfitClientInfo = new List<FillModel>();
            foreach (var g in StrBestClient)
            {
                var tu = MainModel.GeneralBA.gSalesByClient.Where(_ => _.BuyerName == g.gName).Sum(_ => _.SalesWithoutNDS - _.CostPrise);
                model.StructureGrossProfitClientDiagram.Add(g.gName, Math.Round(g.gGrow / MainModel.GeneralBA.gSalesByClient.Sum(_ => _.SalesWithoutNDS - _.CostPrise)  
                     * 100, 2));
                model.StructureGrossProfitClientInfo.Add(new FillModel
                {
                    Name = g.gName,
                    Share = Math.Round(tu / MainModel.GeneralBA.gSales.Sum(_ => _.SalesWithoutNDS - _.CostPrise) * 100, 2),
                    Value = Math.Round(tu / MainModel.GeneralBA.gSalesByClient.Sum(_ => _.SalesWithoutNDS) * 100, 2)
                });
            }
            model.StructureGrossProfitClientDiagram.Add("Прочее", 100 - model.StructureGrossProfitClientDiagram.Sum(_ => _.Value));
            var tmOth =
                MainModel.GeneralBA.gSalesByClient
                            .Select(_ => new { gName = _.BuyerName, gGrow = _.SalesWithoutNDS - _.CostPrise, gPrice = _.SalesWithoutNDS })
                            .OrderByDescending(_ => _.gGrow).Skip(5);
            model.StructureGrossProfitClientInfo.Add(new FillModel
            {
                Name = "Прочие",
                Share = 100 - model.StructureGrossProfitClientInfo.Sum(_ => _.Share),
                Value =   Math.Round(tmOth.Sum(_ => _.gGrow) / MainModel.GeneralBA.gSalesByClient.Sum(_ => _.SalesWithoutNDS) * 100, 2)
            });

            return model;
        }

        public static SalesBusinessAnalysis GetSalesBA(MainModel MainModel)
        {
            //TODO
            // структура компании перевести в проценты
            var model = new SalesBusinessAnalysis();
            model.DynamicsSalesDiagram = new Dictionary<string, decimal>();
            model.Goods1Diagram = new Dictionary<string, decimal>();
            model.Goods2Diagram = new Dictionary<string, decimal>();
            model.Goods3Diagram = new Dictionary<string, decimal>();
            foreach (var mon in MainModel.Sales)
            {
                var tmp = mon.Sales.Select(_ => _.SalesWithoutNDS).Sum();

                model.DynamicsSalesDiagram.Add(((Month)mon.Date.Month).ToString(), tmp);

                var salGr = (from s in mon.Sales
                             group s by s.GroupCode into g
                             select new
                             {
                                 name = g.FirstOrDefault().GroupName,
                                 money = g.Sum(_ => _.SalesWithoutNDS)
                             }).OrderByDescending(_ => _.money).ToList();

                model.Goods1Diagram.Add(((Month)mon.Date.Month).ToString(), salGr[0].money);
                model.Goods2Diagram.Add(((Month)mon.Date.Month).ToString(), salGr[1].money);
                model.Goods3Diagram.Add(((Month)mon.Date.Month).ToString(), salGr[2].money);

                if (tmp > model.maxCountSaleGoods)
                {
                    model.maxCountSaleGoods = Math.Round(tmp, 2);
                    model.MonthOfMaxCountSaleGoods = ((Month)mon.Date.Month).ToString() + ", " + mon.Date.Year;
                }
            }

            model.SummSaleGoods = Math.Round(MainModel.Sales.SelectMany(_ => _.Sales).Select(_ => _.SalesWithoutNDS).Sum(), 2);
            model.maxAverageCountSaleGoods = Math.Round(model.SummSaleGoods / MainModel.Sales.Count(), 2);

            var tmpDecimal = MainModel.GeneralBA.salesFirst.SelectMany(_ => _.Sales).Select(_ => _.SalesWithoutNDS).Sum();
            model.DifSummSaleGoods = Math.Round(model.SummSaleGoods - tmpDecimal, 2);
            model.DifPercentSaleGoods = Math.Round(model.SummSaleGoods / tmpDecimal * 100, 2);

            MainModel.allADDSTranz = Accessors.GetAllAddsTranz(MainModel.StartDate, MainModel.EndDate, MainModel.RegGroups ?? new List<RefGroupsEnt>(), new List<string> { });

            var rt = (from tt in MainModel.allADDSTranz
                      group tt by new { tt.period.Month, tt.period.Year } into g
                      select new
                      {
                          mon = g.FirstOrDefault().period.Month,
                          year = g.FirstOrDefault().period.Year,
                          money = g.Sum(_ => _.Money)
                      }).OrderByDescending(_ => _.year).ThenBy(_ => _.mon).ToList();

            model.DynamicsPaymentDiagram = new Dictionary<string, decimal>();
            rt.ForEach(_ => model.DynamicsPaymentDiagram.Add(((Month)_.mon).ToString(), _.money));

            model.MonthOfMaxCountPaymentBuyer = ((Month)rt.OrderByDescending(_ => _.money).First().mon).ToString() + ", " + rt.OrderByDescending(_ => _.money).First().year;
            model.maxAverageCountPaymentBuyer = Math.Round(rt.Sum(_ => _.money) / rt.Count(), 2);
            model.maxCountPaymentBuyer = Math.Round(rt.OrderByDescending(_ => _.money).First().money, 2);
            model.SummPaymentBuyer = Math.Round(rt.Sum(_ => _.money), 2);

            MainModel.ADDSTranzPastPeriod = Accessors.GetAllAddsTranz(MainModel.newStTodayDate, MainModel.newEndTodayDate, MainModel.RegGroups ?? new List<RefGroupsEnt>(), new List<string> { });

            var rtPast = (from tt in MainModel.ADDSTranzPastPeriod
                          group tt by new { tt.period.Month, tt.period.Year } into g
                          select new
                          {
                              mon = g.FirstOrDefault().period.Month,
                              year = g.FirstOrDefault().period.Year,
                              money = g.Sum(_ => _.Money)
                          }).OrderByDescending(_ => _.year).ThenBy(_ => _.mon).ToList();

            tmpDecimal = rtPast.Sum(_ => _.money);
            model.DifSummPaymentBuyer = Math.Round(model.SummPaymentBuyer - tmpDecimal, 2);
            model.DifPercentPaymentBuyer = Math.Round(model.SummPaymentBuyer / tmpDecimal * 100, 2);

            var salGrNow = (from s in MainModel.Sales.SelectMany(_ => _.Sales)
                            group s by s.GroupCode into g
                            select new
                            {
                                name = g.FirstOrDefault().GroupName,
                                money = g.Sum(_ => _.SalesWithoutNDS)
                            }).OrderByDescending(_ => _.money).ToList();

            var salGrPast = (from s in MainModel.GeneralBA.salesFirst.SelectMany(_ => _.Sales)
                             group s by s.GroupCode into g
                             select new
                             {
                                 name = g.FirstOrDefault().GroupName,
                                 money = g.Sum(_ => _.SalesWithoutNDS)
                             }).OrderByDescending(_ => _.money).ToList();

            model.Goods1Info = new FillGoodsModel();
            model.Goods1Info.Name = salGrNow[0].name;
            model.Goods1Info.Value = Math.Round(salGrNow[0].money, 2);
            model.Goods1Info.pastValue = Math.Round(salGrNow[0].money - salGrPast.Where(_ => _.name == salGrNow[0].name).FirstOrDefault().money, 2);
            model.Goods1Info.Percent = Math.Round(salGrNow[0].money / salGrPast.Where(_ => _.name == salGrNow[0].name).FirstOrDefault().money * 100, 2);

            model.Goods2Info = new FillGoodsModel();
            model.Goods2Info.Name = salGrNow[1].name;
            model.Goods2Info.Value = Math.Round(salGrNow[1].money, 2);
            model.Goods2Info.pastValue = Math.Round(salGrNow[1].money - salGrPast.Where(_ => _.name == salGrNow[1].name).FirstOrDefault().money, 2);
            model.Goods2Info.Percent = Math.Round(salGrNow[1].money / salGrPast.Where(_ => _.name == salGrNow[1].name).FirstOrDefault().money * 100, 2);

            model.Goods3Info = new FillGoodsModel();
            model.Goods3Info.Name = salGrNow[2].name;
            model.Goods3Info.Value = Math.Round(salGrNow[2].money, 2);
            model.Goods3Info.pastValue = Math.Round(salGrNow[2].money - salGrPast.Where(_ => _.name == salGrNow[2].name).FirstOrDefault().money, 2);
            model.Goods3Info.Percent = Math.Round(salGrNow[2].money / salGrPast.Where(_ => _.name == salGrNow[2].name).FirstOrDefault().money * 100, 2);

            var salCli = (from s in MainModel.Sales.SelectMany(_ => _.Sales)
                          group s by s.BuyerCode into g
                          select new
                          {
                              name = g.FirstOrDefault().BuyerName,
                              money = g.Sum(_ => _.SalesWithoutNDS)
                          }
                          ).OrderByDescending(_ => _.money).ToList();
            model.StructureGrossProfitClientDiagram = new Dictionary<string, decimal>();
            var generalSumm = salCli.Sum(_ => _.money);
            for (var i = 0; i < 5; i++)
            {
                model.StructureGrossProfitClientDiagram.Add(salCli[i].name, Math.Round(salCli[i].money / generalSumm * 100, 2));
            }
            model.StructureGrossProfitClientDiagram.Add("Прочие", Math.Round(100 - model.StructureGrossProfitClientDiagram.Sum(_ => _.Value), 2));

            return model;

        }
        
        public static CostsBusinessAnalysis GetCostsBA(MainModel MainModel)
        {
            var model = new CostsBusinessAnalysis();

            model.allCosts = MainModel.GeneralBA.Cost; // MainModel.ReportProfitAndLoss.Costs.Sum();
            model.difPastPeriod = MainModel.GeneralBA.CostAnFirst;
            model.maxCostsByMonth = MainModel.ReportProfitAndLoss.Costs.Max();
            model.averageCostsByMonth = model.allCosts / MainModel.ReportProfitAndLoss.Costs.Count();

            model.CostsDiagram = new Dictionary<string, decimal>();
            model.CostsDiagram.Add("Прочие", MainModel.ReportProfitAndLoss.OtherCosts.Sum());
            model.CostsDiagram.Add("Бонусы", 0);
            model.CostsDiagram.Add("По реализации", MainModel.ReportProfitAndLoss.CostsSalesServices.Sum());
            model.CostsDiagram.Add("Админ-ые", MainModel.ReportProfitAndLoss.AdministrativeExpenses.Sum());
            model.CostsDiagram.Add("Закуп", 0);

            // тут опасно, если вдруг в расходах не было записи за какой то месяц то у нас произойдет смещение, но вообще на норм предприятии это маловероятно
            // раньше не предусмотрели, поэтому делаем так
            var stMon = MainModel.StartDate.Month;
            var stYear = MainModel.StartDate.Year;
            model.CostsByMonthDiagram = new Dictionary<string, decimal>();
            foreach (var item in MainModel.ReportProfitAndLoss.Costs)
            {
                if (stMon != 12) stMon++;
                else
                {
                    stMon = 0; stYear++;
                }
                model.CostsByMonthDiagram.Add(((Month)stMon).ToString() + "-" + stYear.ToString(), item);//расходы
            }
            model.GrosProfitDiagram = MainModel.ProfitBA.GrossProfitDiagram;// валовую уже считали
            model.SalesDiagram = MainModel.SalesBA.DynamicsSalesDiagram;// продажи тоже

            //аддс - операц деятельность - выбитие все кроме оплаты поставщику и - TODO ?? Авансы выданные под поставку активов и услуг
            model.CostsOut = MainModel.ADDSTranz.Where(_ => _.en302 == 1 && _.en450 == 0 && _.GroupCode != "000000001" && _.GroupCode != "000000029").Sum(_ => _.Money);

            model.paidTaxes = MainModel.ADDSTranz.Where(_ => _.GroupCode == "000000037" || _.GroupCode == "000000036").Sum(_ => _.Money);
            model.paidTaxesFromSales = Math.Round(MainModel.GeneralBA.Sales / model.paidTaxes * 100, 2);
            model.paidTaxesFromGrosProfit = Math.Round(MainModel.GeneralBA.GrossProfit / model.paidTaxes * 100, 2);

            return model;
        }

        public static PurchaseBusinessAnalysis GetPurchaseBA(MainModel MainModel)
        {
            var model = new PurchaseBusinessAnalysis();

            model.allPurchase = Math.Round(MainModel.Sales.SelectMany(_ => _.Sales).Where(_ => _.CountPur != decimal.Zero).Select(_ => _.CostPrise).Sum(), 2);
            var pastPur = MainModel.GeneralBA.salesFirst.SelectMany(_ => _.Sales).Where(_ => _.CountPur != decimal.Zero).Select(_ => _.CostPrise).Sum();
            model.difPastPeriod = Math.Round(model.allPurchase / pastPur * 100, 2);

            model.maxPurchaseByMonth = decimal.Zero;
            var counter = 0;
            model.PurchaseDiagram = new Dictionary<string, decimal>();
            model.SalesDiagram = new Dictionary<string, decimal>();
            model.PaymentDiagram = new Dictionary<string, decimal>();
            foreach (var item in MainModel.Sales)
            {
                var dt = string.Empty;
                var tmp = item.Sales.Where(_ => _.CountPur != decimal.Zero).Select(_ => _.CostPrise).Sum();
                if (tmp > model.maxPurchaseByMonth)
                    model.maxPurchaseByMonth = Math.Round(tmp, 2);

                dt = ((Month)item.Date.Month).ToString();
                model.PurchaseDiagram.Add(dt, Math.Round(item.Sales.Sum(_ => _.CostPrise), 2));
                model.SalesDiagram.Add(dt, Math.Round(item.Sales.Sum(_ => _.SalesWithoutNDS), 2));
                model.PaymentDiagram.Add(dt, MainModel.ADDSTranzPastPeriod[counter].Money);

                counter++;
            }
            model.averagePurchaseByMonth = Math.Round(model.allPurchase / MainModel.Sales.Count(), 2);

            var tmpPurGroup = (from s in MainModel.Sales.SelectMany(_ => _.Sales)
                               group s by s.GroupCode into g
                               select new
                               {
                                   name = g.FirstOrDefault().GroupName,
                                   money = g.Sum(_ => _.CostPrise),
                                   count = g.Sum(_ => _.CountPur)
                               }).OrderByDescending(_ => _.money).ToList();

            model.PurchaseByGoodsDiagram = new Dictionary<string, decimal>();
            model.PurchaseByGoodsDiagram.Add("Прочее", Math.Round(tmpPurGroup.Skip(3).Sum(_ => _.money), 2));
            model.PurchaseByGoodsDiagram.Add(tmpPurGroup[2].name, Math.Round(tmpPurGroup[2].money, 2));
            model.PurchaseByGoodsDiagram.Add(tmpPurGroup[1].name, Math.Round(tmpPurGroup[1].money, 2));
            model.PurchaseByGoodsDiagram.Add(tmpPurGroup[0].name, Math.Round(tmpPurGroup[0].money, 2));

            model.SalesvsPurchase = Math.Round(MainModel.GeneralBA.Sales / model.allPurchase * 100, 2);
            model.difSalesvsPurchasePastPeriod = Math.Round(model.SalesvsPurchase - 
                (MainModel.GeneralBA.salesFirst.SelectMany(_ => _.Sales).Sum(_ => _.SalesWithoutNDS) / pastPur * 100), 2);

            model.PaymentvsPurchase = Math.Round(MainModel.SalesBA.SummPaymentBuyer / model.allPurchase * 100, 2);
            model.difPaymentvsPurchasePastPeriod = Math.Round(MainModel.ADDSTranzPastPeriod.Sum(_ => _.Money) / pastPur, 2);
            
            return model;
        }

        public static WorkingСapitalBusinessAnalysis GetWorkingСapitalBA(MainModel MainModel)
        {
            var model = new WorkingСapitalBusinessAnalysis();

            return model;
        }

        private static void FillPercentForAllProperty(ref string First, ref string Second, DateTime stTodayDate, DateTime endTodayDate, GeneralBusinessAnalysis model
            , List<SalesModel> salesFirst, List<SalesModel> salesSecond, int dif)
        {

        }

    }
}
