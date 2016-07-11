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
        public static MainModel InitMainModel(DateTime startDate, DateTime endDate, ref MainModel model)
        {
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

            model.DaysInPeriod = Convert.ToInt32((model.EndDate - model.StartDate).TotalDays);

            return model;
        }


        public static LiveStreamModel GetLiveStream(DateTime startDate, DateTime endDate, MainModel MainModel)
        {
            //var MainModel = new MainModel();

            //MainModel.Sales = Accessors.GetSales(startDate, endDate);

            var model = new LiveStreamModel();

            var tmSpan = MainAccessor.GetTimeSpan();

            //TODO поставить текущую дату
            var stTodayDate = new DateTime(4013, 10, 01);
            var endTodayDate = new DateTime(4013, 10, 01).AddHours(23).AddMinutes(59).AddSeconds(59); //DateTime.Today.AddYears(tmSpan);

            MainModel.StartDate = new DateTime(stTodayDate.Year, stTodayDate.Month, 01);
            MainModel.EndDate = new DateTime(stTodayDate.Month != 12 ? stTodayDate.Year : stTodayDate.Year + 1, stTodayDate.Month != 12 ? stTodayDate.Month + 1 : 01, 01);
            
            // Сегодня
            var sales = Accessors.GetSales(stTodayDate, endTodayDate, true);
            model.SalesToday = sales.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS)).Sum();
            model.GrossProfitToday = model.SalesToday - sales.Select(i => i.Sales.Sum(j => j.CostPrise)).Sum();
            model.ProfitabilityToday = model.SalesToday != 0
                    ? (model.GrossProfitToday / model.SalesToday) * 100
                    : 0;

            MainModel.RegGroups = MainAccessor.GetAllGroups();// группы
            MainModel.ADDSTranz = Accessors.GetAddsTranz(stTodayDate, endTodayDate, MainModel.RegGroups ?? new List<RefGroupsEnt>(), new List<string> { "000000002" });
            model.PaymentCustomersToday = MainModel.ADDSTranz.Sum(_ => _.Money);

            MainModel.StartTranz = MainAccessor.GetAllTrans(stTodayDate, null); // Вытащим сразу все транзакции, отдельным запросом
            MainModel.EndTranz = MainAccessor.GetAllTrans(stTodayDate, endTodayDate);

            MainModel.StartTranzOriginal = MainAccessor.GetAllTransOriginal(MainModel.StartDate, null);
            MainModel.EndTranzOriginal = MainAccessor.GetAllTransOriginal(MainModel.StartDate, MainModel.EndDate);

            MainModel.BusinessResults = Accessors.GetBusinessResults(MainModel);

            model.DebtOfCustomers = MainModel.BusinessResults.DebtsOfCustomersAndOverpaymentsEnd;
            model.GoodsBalance = MainModel.BusinessResults.GoodsEnd;
            model.PayblesToSupplier = MainModel.BusinessResults.PayablesToSuppliersShortTermDebtsEnd;

            model.CycleMoneyDiagram = new Dictionary<string, decimal>();
            model.CycleMoneyDiagram.Add("Деньги в кассе", MainModel.BusinessResults.CashInCashBoxEnd);
            model.CycleMoneyDiagram.Add("Деньги на счетах", MainModel.BusinessResults.MoneyInTheBankAccountsEnd);

            model.CoveringCurrentDebtMoney = (MainModel.BusinessResults.CashInCashBoxEnd + MainModel.BusinessResults.MoneyInTheBankAccountsEnd
               + MainModel.BusinessResults.DepositsEnd) / (MainModel.BusinessResults.CurrentDebtEnd != 0 ? MainModel.BusinessResults.CurrentDebtEnd : 1) * 100;

            model.CoveringCurrentDebtMoneyAndCustomerDebt = (MainModel.BusinessResults.CashInCashBoxEnd + MainModel.BusinessResults.MoneyInTheBankAccountsEnd
                + MainModel.BusinessResults.DepositsEnd + MainModel.BusinessResults.DebtsOfCustomersAndOverpaymentsEnd)
                / (MainModel.BusinessResults.CurrentDebtEnd != 0 ? MainModel.BusinessResults.CurrentDebtEnd : 1) * 100;

            model.CoveringCurrentDebtOfCurrentAssets = MainModel.BusinessResults.CirculatingAssetsEnd
                / (MainModel.BusinessResults.CurrentDebtEnd != 0 ? MainModel.BusinessResults.CurrentDebtEnd : 1) * 100;

            // Текущий месяц            
            sales = Accessors.GetSales(MainModel.StartDate, MainModel.EndDate, true);
            model.SalesMonth = sales.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS)).Sum();
            model.GrossProfitMonth = model.SalesMonth - sales.Select(i => i.Sales.Sum(j => j.CostPrise)).Sum();
            model.ProfitabilityMonth = model.SalesMonth != 0
                    ? (model.GrossProfitMonth / model.SalesMonth) * 100
                    : 0;

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
                                        , MainModel.StartDate, true);
            model.SalesPastMonth = sales.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS)).Sum();
            model.GrossProfitPastMonth = model.SalesPastMonth - sales.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS - j.CostPrise)).Sum();

            MainModel.ADDSTranz = Accessors.GetAddsTranz(MainModel.StartDate.Month != 1 ?
                                                            new DateTime(MainModel.StartDate.Year, MainModel.StartDate.Month - 1, 01) :
                                                            new DateTime(MainModel.StartDate.Year - 1, 12, 01)
                                                            , MainModel.StartDate, MainModel.RegGroups ?? new List<RefGroupsEnt>(), new List<string> { "000000002" });
            model.PaymentCustomersPastMonth = MainModel.ADDSTranz.Sum(_ => _.Money);

            model.CurrentMonthDiagram = new Dictionary<string, decimal>();
            model.CurrentMonthDiagram.Add("Продажи", model.SalesPastMonth);
            model.CurrentMonthDiagram.Add("Валовая прибыль", model.GrossProfitPastMonth);
            model.CurrentMonthDiagram.Add("Оплата покупателя", model.PaymentCustomersPastMonth);

            model.AverageGrossProfit = model.GrossProfitPastMonth - model.GrossProfitMonth;
            model.AverageSales = model.SalesPastMonth - model.SalesMonth;
            model.AveragePayment = model.PaymentCustomersPastMonth - model.PaymentCustomersMonth;

            model.CountDaysToEndOfMonth = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) - DateTime.Today.Day + 1;

            MainModel.StartDate = startDate;
            MainModel.EndDate = endDate;

            return model;
        }

        public static GeneralBusinessAnalysis GetGeneralBusinessAnalysis(DateTime startDate, DateTime endDate, MainModel MainModel)
        {
            var tmSpan = MainAccessor.GetTimeSpan();
            var stTodayDate = MainModel.StartDate;
            var endTodayDate = MainModel.EndDate;

            var model = new GeneralBusinessAnalysis();

            model.Sales = MainModel.Sales.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS)).Sum();

            model.CostPrice = MainModel.Sales.Select(i => i.Sales.Sum(j => j.CostPrise)).Sum();
            //TODO вроде верная дрянь но считается она не верно
            model.GrossProfit = MainModel.Sales.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS - j.CostPrise)).Sum();
            model.AveGrossProfit = MainModel.Sales.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS - j.AveCostPrise)).Sum();

            model.Cost = MainModel.ReportProfitAndLoss.Costs.Sum();

            #region Прошлые периоды
            MainModel.newStTodayDate = new DateTime();
            MainModel.newEndTodayDate = new DateTime();
            dif = (endTodayDate.Year - stTodayDate.Year) * 12 + (endTodayDate.Month - stTodayDate.Month);
            //if (dif <= 12)
            //{
                decimal tmp = decimal.Zero;
                MainModel.newStTodayDate = stTodayDate.AddMonths(-dif);
                MainModel.newEndTodayDate = stTodayDate.AddMonths(1);
                model.salesFirst = Accessors.GetSales(MainModel.newStTodayDate, MainModel.newEndTodayDate, true);

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
                    tmp = RPALF / model.Cost * 100;
                    model.CostAnFirst = tmp; //(tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";
                }

                MainModel.newStTodayDate = stTodayDate.AddYears(-1);
                MainModel.newEndTodayDate = endTodayDate.AddYears(-1);
                var salesSecond = Accessors.GetSales(MainModel.newStTodayDate, MainModel.newEndTodayDate, true);

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
                    tmp = RPALS / model.Cost * 100;
                    model.CostAnSecond = tmp; // (tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";
                }

            if (model.Sales != 0)
            {
                tmp = model.salesFirst.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS)).Sum() / model.Sales * 100;
                model.SalesAnFirst = tmp; //(tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";

                tmp = salesSecond.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS)).Sum() / model.Sales * 100;
                model.SalesAnSecond = tmp; //(tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";
            }

            if (model.CostPrice != 0)
            {
                tmp = model.salesFirst.Select(i => i.Sales.Sum(j => j.CostPrise)).Sum() / model.CostPrice * 100;
                model.CostPriceAnFirst = tmp; //(tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";

                tmp = salesSecond.Select(i => i.Sales.Sum(j => j.CostPrise)).Sum() / model.CostPrice * 100;
                model.CostPriceAnSecond = tmp; //(tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";
            }

                var GPFtmp = model.salesFirst.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS - j.CostPrise)).Sum();
            if (model.CostPrice != 0)
            {
                tmp = GPFtmp / model.CostPrice * 100;
                model.GrossProfitAnFirst = tmp; //(GPFtmp > 1 ? (GPFtmp - 1).ToString() : (1 - GPFtmp).ToString()) + "%";
            }

                var GPStmp = salesSecond.Select(i => i.Sales.Sum(j => j.SalesWithoutNDS - j.CostPrise)).Sum();
            if (model.CostPrice != 0)
            {
                tmp = GPStmp / model.CostPrice * 100;
                model.GrossProfitAnSecond = tmp; // (GPStmp > 1 ? (GPStmp - 1).ToString() : (1 - GPStmp).ToString()) + "%";
            }

                model.NetProfit = model.GrossProfit - model.Cost;
            if (model.NetProfit != 0)
            {
                tmp = (GPFtmp - RPALF) / model.NetProfit * 100;
                model.NetProfitAnFirst = tmp; //(tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";
                tmp = (GPStmp - RPALS) / model.NetProfit * 100;
                model.NetProfitAnSecond = tmp; //(tmp > 1 ? (tmp - 1).ToString() : (1 - tmp).ToString()) + "%";
            }
            //}
            //else
            //{
            //    model.SalesAnFirst =
            //    model.SalesAnSecond =
            //    model.CostPriceAnSecond =
            //    model.GrossProfitAnFirst =
            //    model.GrossProfitAnSecond =
            //    model.NetProfitAnFirst =
            //    model.NetProfitAnSecond =
            //    model.CostAnFirst =
            //    model.CostAnSecond =
            //    model.CostPriceAnFirst = 0;//"-";
            //}
            #endregion

            model.StructureCompanyDiagram = new Dictionary<string, decimal>();
            model.StructureCompanyDiagram.Add("Оборотные активы", (MainModel.BusinessResults.CirculatingAssetsEnd + MainModel.BusinessResults.LongTermAssetsEnd) != 0 ? 
                MainModel.BusinessResults.CirculatingAssetsEnd / (MainModel.BusinessResults.CirculatingAssetsEnd + MainModel.BusinessResults.LongTermAssetsEnd) * 100 : 0);
            model.StructureCompanyDiagram.Add("Долгосрочные активы", (MainModel.BusinessResults.CirculatingAssetsEnd + MainModel.BusinessResults.LongTermAssetsEnd) != 0 ? 
                100 - MainModel.BusinessResults.CirculatingAssetsEnd / (MainModel.BusinessResults.CirculatingAssetsEnd + MainModel.BusinessResults.LongTermAssetsEnd) * 100 : 0);
            model.StructureCompanyDiagram.Add("Текущая задолженность", (MainModel.BusinessResults.CurrentDebtEnd + MainModel.BusinessResults.LongTermDebtEnd + MainModel.BusinessResults.OwnCapitalEnd) != 0 ? 
                MainModel.BusinessResults.CurrentDebtEnd / (MainModel.BusinessResults.CurrentDebtEnd + MainModel.BusinessResults.LongTermDebtEnd + MainModel.BusinessResults.OwnCapitalEnd) * 100 : 0);
            model.StructureCompanyDiagram.Add("Долгосрочная задолженность", (MainModel.BusinessResults.CurrentDebtEnd + MainModel.BusinessResults.LongTermDebtEnd + MainModel.BusinessResults.OwnCapitalEnd) != 0 ? 
                MainModel.BusinessResults.LongTermDebtEnd / (MainModel.BusinessResults.CurrentDebtEnd + MainModel.BusinessResults.LongTermDebtEnd + MainModel.BusinessResults.OwnCapitalEnd) * 100 : 0);
            model.StructureCompanyDiagram.Add("Собственный капитал", (MainModel.BusinessResults.CurrentDebtEnd + MainModel.BusinessResults.LongTermDebtEnd + MainModel.BusinessResults.OwnCapitalEnd) != 0 ? 100 -
                MainModel.BusinessResults.CurrentDebtEnd / (MainModel.BusinessResults.CurrentDebtEnd + MainModel.BusinessResults.LongTermDebtEnd + MainModel.BusinessResults.OwnCapitalEnd) * 100
                - MainModel.BusinessResults.LongTermDebtEnd / (MainModel.BusinessResults.CurrentDebtEnd + MainModel.BusinessResults.LongTermDebtEnd + MainModel.BusinessResults.OwnCapitalEnd) * 100 : 0);

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
                                        Share = MainModel.Sales.SelectMany(_ => _.Sales).Where(_ => _.GroupCode == s.GroupCode).Sum(i => i.SalesWithoutNDS - i.CostPrise) / ((s.CountGoodsSt + s.CountGoodsEnd) / 2) * 100
                                    }
                                    ).OrderByDescending(_ => _.Share).ToList();
            model.ProfitabilityDiagram = averageRentSales;
            #endregion

            #region объем оборотного капитала и все к нему
            model.SalesDiagram = new Dictionary<string, decimal>();
            foreach (var mon in MainModel.Sales)
            {
                model.SalesDiagram.Add(MainModel.IsItQuarter || (MainModel.EndDate - MainModel.StartDate).Days > 365 ? string.Format("{0}, {1}", (Month)mon.Date.Month, mon.Date.Year) : ((Month)mon.Date.Month).ToString(), mon.Sales.Sum(_ => _.SalesWithoutNDS));
            }

            model.NetProfitDiagram = new Dictionary<string, decimal>();
            var tmpMon = 0;
            for (int i = 0; i < dif; i++)
            {
                var _year = startDate;
                if (startDate.Month + i > 12) tmpMon = i - 12;
                else tmpMon = startDate.Month + i;
                model.NetProfitDiagram.Add(MainModel.IsItQuarter || (MainModel.EndDate - MainModel.StartDate).Days > 365 ? string.Format("{0}, {1}", (Month)tmpMon, _year.AddMonths(i).Year) : ((Month)tmpMon).ToString(), MainModel.ReportProfitAndLoss.Costs.ToArray()[i]);
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

                model.PastBisRes = Accessors.GetBusinessResults(mm);
                // TODO: XYUTA
                model.AverageWorkingCapitalDiagram.Add(
                MainModel.IsItQuarter || (MainModel.EndDate - MainModel.StartDate).Days >= 365 ? string.Format("{0}, {1}", (Month)startMonthYear[0], startMonthYear[1]) : ((Month)startMonthYear[0]).ToString(), (model.PastBisRes.CirculatingAssetsStart + model.PastBisRes.CirculatingAssetsEnd) / 2);

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
            while ((startMonthYear[1] < endMonthYear[1] && startMonthYear[1] != endMonthYear[1]) || (startMonthYear[0] < endMonthYear[0] && startMonthYear[1] == endMonthYear[1]));
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
            if (mM != 0) 
                model.NetProfitability = model.NetProfit / mM * 100;
            model.AverageNetProfitByMonth = model.NetProfit / dif;
            if (mM != 0)
                model.GrossProfitability = model.GrossProfit / mM * 100;
            model.AverageGrossProfitByMonth = model.GrossProfit / dif;

            model.SavedProfit = MainModel.BusinessResults.AccumulatedProfitAndLossStart + MainModel.BusinessResults.AccumulatedProfitAndLossEnd;

            //Динамика валовой и чистой прибыли и рентабильность тут же
            model.GrossProfitDiagram = new Dictionary<string, decimal>();
            model.NetProfitDiagram = new Dictionary<string, decimal>();
            model.GrossProfitabilityDiagram = new Dictionary<string, decimal>();
            model.NetProfitabilityDiagram = new Dictionary<string, decimal>();
            var counter = 0;//счетчик месяцев
            foreach (var mon in MainModel.Sales)
            {
                var gp = mon.Sales.Sum(_ => _.SalesWithoutNDS - _.CostPrise);
                   model.GrossProfitDiagram.Add(MainModel.IsItQuarter || (MainModel.EndDate - MainModel.StartDate).Days > 365 ? string.Format("{0}, {1}", (Month)mon.Date.Month, mon.Date.Year) : ((Month)mon.Date.Month).ToString(), gp);
                model.NetProfitDiagram.Add(MainModel.IsItQuarter || (MainModel.EndDate - MainModel.StartDate).Days > 365 ? string.Format("{0}, {1}", (Month)mon.Date.Month, mon.Date.Year) : ((Month)mon.Date.Month).ToString(),
                    gp - MainModel.ReportProfitAndLoss.Costs.ToArray()[counter]
                    );

                var tj =  mon.Sales.Sum(s => s.SalesWithoutNDS);// выручка - цена продажи
                 
                model.GrossProfitabilityDiagram.Add(MainModel.IsItQuarter || (MainModel.EndDate - MainModel.StartDate).Days > 365 ? string.Format("{0}, {1}", (Month)mon.Date.Month, mon.Date.Year) : ((Month)mon.Date.Month).ToString(), tj != 0 ? gp / tj * 100 : 0);

                model.NetProfitabilityDiagram.Add(MainModel.IsItQuarter || (MainModel.EndDate - MainModel.StartDate).Days > 365 ? string.Format("{0}, {1}", (Month)mon.Date.Month, mon.Date.Year) : ((Month)mon.Date.Month).ToString(),
                    tj != 0 ? (gp - MainModel.ReportProfitAndLoss.Costs[counter]) / tj * 100 : 0);
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
                model.StructureGrossProfitGoodsDiagram.Add(g.gName, g.gGrow);
                model.StructureGrossProfitGoodsInfo.Add(new FillModel
                {
                    Name = g.gName,
                    Share = ty / MainModel.GeneralBA.gSales.Sum(_ => _.SalesWithoutNDS - _.CostPrise) * 100 ,
                    Value = MainModel.GeneralBA.gSales.Sum(_ => _.SalesWithoutNDS) != 0 ? ty
                        / MainModel.GeneralBA.gSales.Sum(_ => _.SalesWithoutNDS) * 100 : 0
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
                model.StructureGrossProfitClientDiagram.Add(g.gName, g.gGrow / MainModel.GeneralBA.gSalesByClient.Sum(_ => _.SalesWithoutNDS - _.CostPrise)  
                     * 100);
                model.StructureGrossProfitClientInfo.Add(new FillModel
                {
                    Name = g.gName,
                    Share = tu / MainModel.GeneralBA.gSales.Sum(_ => _.SalesWithoutNDS - _.CostPrise) * 100,
                    Value = tu / MainModel.GeneralBA.gSalesByClient.Sum(_ => _.SalesWithoutNDS) * 100
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
                Value = MainModel.GeneralBA.gSalesByClient.Sum(_ => _.SalesWithoutNDS) != 0 ? tmOth.Sum(_ => _.gGrow) / MainModel.GeneralBA.gSalesByClient.Sum(_ => _.SalesWithoutNDS) * 100 : 0
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

                model.DynamicsSalesDiagram.Add(MainModel.IsItQuarter || (MainModel.EndDate - MainModel.StartDate).Days > 365 ? string.Format("{0}, {1}", (Month)mon.Date.Month, mon.Date.Year) : ((Month)mon.Date.Month).ToString(), tmp);

                var salGr = (from s in mon.Sales
                             group s by s.GroupCode into g
                             select new
                             {
                                 name = g.FirstOrDefault().GroupName,
                                 money = g.Sum(_ => _.SalesWithoutNDS)
                             }).OrderByDescending(_ => _.money).ToList();

                model.Goods1Diagram.Add(MainModel.IsItQuarter || (MainModel.EndDate - MainModel.StartDate).Days > 365 ? string.Format("{0}, {1}", (Month)mon.Date.Month, mon.Date.Year) : ((Month)mon.Date.Month).ToString(), salGr[0].money);
                model.Goods2Diagram.Add(MainModel.IsItQuarter || (MainModel.EndDate - MainModel.StartDate).Days > 365 ? string.Format("{0}, {1}", (Month)mon.Date.Month, mon.Date.Year) : ((Month)mon.Date.Month).ToString(), salGr[1].money);
                model.Goods3Diagram.Add(MainModel.IsItQuarter || (MainModel.EndDate - MainModel.StartDate).Days > 365 ? string.Format("{0}, {1}", (Month)mon.Date.Month, mon.Date.Year) : ((Month)mon.Date.Month).ToString(), salGr[2].money);

                if (tmp > model.maxCountSaleGoods)
                {
                    model.maxCountSaleGoods = tmp;
                    model.MonthOfMaxCountSaleGoods = MainModel.IsItQuarter || (MainModel.EndDate - MainModel.StartDate).Days > 365 ? string.Format("{0}, {1}", (Month)mon.Date.Month, mon.Date.Year) : ((Month)mon.Date.Month).ToString() + ", " + mon.Date.Year;
                }
            }

            model.SummSaleGoods = MainModel.Sales.SelectMany(_ => _.Sales).Select(_ => _.SalesWithoutNDS).Sum();
            model.maxAverageCountSaleGoods = MainModel.Sales.Count() != 0 ? model.SummSaleGoods / MainModel.Sales.Count() : 0;

            var tmpDecimal = MainModel.GeneralBA.salesFirst.SelectMany(_ => _.Sales).Select(_ => _.SalesWithoutNDS).Sum();
            model.DifSummSaleGoods = model.SummSaleGoods - tmpDecimal;
            if(tmpDecimal != 0)
                model.DifPercentSaleGoods = model.DifSummSaleGoods / tmpDecimal * 100;

            MainModel.allADDSTranz = Accessors.GetAllAddsTranz(MainModel.StartDate, MainModel.EndDate, MainModel.RegGroups ?? new List<RefGroupsEnt>(), new List<string> { });

            var rt = (from tt in MainModel.allADDSTranz
                      where tt.GroupCode == "000000002"
                      group tt by new { tt.period.Month, tt.period.Year } into g
                      select new
                      {
                          mon = g.FirstOrDefault().period.Month,
                          year = g.FirstOrDefault().period.Year,
                          money = g.Sum(_ => _.Money)
                      }).OrderByDescending(_ => _.year).ThenBy(_ => _.mon).ToList();

            model.DynamicsPaymentDiagram = new Dictionary<string, decimal>();

            rt.ForEach(_ => model.DynamicsPaymentDiagram.Add((
                MainModel.IsItQuarter || (MainModel.EndDate - MainModel.StartDate).Days > 365 ? string.Format("{0}, {1}", (Month)_.mon, _.year) : ((Month)_.mon).ToString()).ToString(), _.money));
            //так и не пригодилось
            //model.MonthOfMaxCountPaymentBuyer = ((Month)rt.OrderByDescending(_ => _.money).First().mon).ToString() + ", " + rt.OrderByDescending(_ => _.money).First().year;
            model.maxAverageCountPaymentBuyer = rt.Count() != 0 ? rt.Sum(_ => _.money) / rt.Count() : 0;
            model.maxCountPaymentBuyer = rt.Count != 0 ? rt.OrderByDescending(_ => _.money).First().money : 0;
            model.SummPaymentBuyer = rt.Sum(_ => _.money);

            MainModel.ADDSTranzPastPeriod = Accessors.GetAllAddsTranz(MainModel.newStTodayDate, MainModel.newEndTodayDate, MainModel.RegGroups ?? new List<RefGroupsEnt>(), new List<string> { });

            var rtPast = (from tt in MainModel.ADDSTranzPastPeriod
                          where tt.GroupCode == "000000002" // только оплата покупателя, если будет долго, можно отдельный запрос написать все не тащить
                          group tt by new { tt.period.Month, tt.period.Year } into g
                          select new
                          {
                              mon = g.FirstOrDefault().period.Month,
                              year = g.FirstOrDefault().period.Year,
                              money = g.Sum(_ => _.Money)
                          }).OrderByDescending(_ => _.year).ThenBy(_ => _.mon).ToList();

            tmpDecimal = rtPast.Sum(_ => _.money);
            model.DifSummPaymentBuyer = model.SummPaymentBuyer - tmpDecimal;
            model.DifPercentPaymentBuyer = tmpDecimal != 0 ? model.DifSummPaymentBuyer / tmpDecimal * 100 : 0;

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
            if (salGrNow.Count > 0)
            {
                model.Goods1Info.Name = salGrNow[0].name;
                model.Goods1Info.Value = salGrNow[0].money;
                model.Goods1Info.pastValue = salGrNow[0].money - salGrPast.Where(_ => _.name == salGrNow[0].name).FirstOrDefault().money;
                model.Goods1Info.Percent = salGrPast.Count != 0 ? model.Goods1Info.pastValue / salGrPast.Where(_ => _.name == salGrNow[0].name).FirstOrDefault().money * 100 : 0;
            }
            model.Goods2Info = new FillGoodsModel();
            if (salGrNow.Count > 1)
            {
                model.Goods2Info.Name = salGrNow[1].name;
                model.Goods2Info.Value = salGrNow[1].money;
                model.Goods2Info.pastValue = salGrNow[1].money - salGrPast.Where(_ => _.name == salGrNow[1].name).FirstOrDefault().money;
                model.Goods2Info.Percent = salGrPast.Count != 0 ? model.Goods2Info.pastValue / salGrPast.Where(_ => _.name == salGrNow[1].name).FirstOrDefault().money * 100 : 0;
            }

            model.Goods3Info = new FillGoodsModel();

            if (salGrNow.Count > 2)
            {
                model.Goods3Info.Name = salGrNow[2].name;
                model.Goods3Info.Value = salGrNow[2].money;
                model.Goods3Info.pastValue = salGrNow[2].money - salGrPast.Where(_ => _.name == salGrNow[2].name).FirstOrDefault().money;
                model.Goods3Info.Percent = salGrPast.Count != 0 ? model.Goods3Info.pastValue / salGrPast.Where(_ => _.name == salGrNow[2].name).FirstOrDefault().money * 100 : 0;
            }

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
            if(generalSumm != 0)
                foreach(var item in salCli.Take(5))
                {
                    model.StructureGrossProfitClientDiagram.Add(item.name, item.money / generalSumm * 100);
                }
            model.StructureGrossProfitClientDiagram.Add("Прочие", 100 - model.StructureGrossProfitClientDiagram.Sum(_ => _.Value));

            var tc = (from sa in MainModel.GeneralBA.gSalesByClient
                          //join addz in MainModel.ADDSTranz on sa.BuyerCode equals addz.MenCode
                      group sa by sa.BuyerCode into g
                      select new
                      {
                          code = g.FirstOrDefault().BuyerCode,
                          name = g.FirstOrDefault().BuyerName,
                          money = g.Sum(_ => _.SalesWithoutNDS)
                      }).OrderByDescending(_ => _.money);
            var ta = (from addz in MainModel.allADDSTranz
                     // where tc.Select(_ => _.code).ToList().Contains(addz.MenCode)
                      group addz by addz.MenCode into g
                      select new
                      {
                          code = g.FirstOrDefault().MenCode,
                          name = g.FirstOrDefault().MenName,
                          money = g.Sum(_ => _.Money)
                      }).ToList();

            model.StructureGrossProfitClientInfo = new List<FillModel>();
            foreach (var item in tc.Take(5))
                model.StructureGrossProfitClientInfo.Add(new FillModel { Name = item.name, Value = item.money,
                    Value2 = ta.FirstOrDefault(_ => _.code == item.code) != null ? ta.FirstOrDefault(_ => _.code == item.code).money : 0});

            model.StructureGrossProfitClientInfo.Add(new FillModel
            {
                Name = "Прочие",
                Value = tc.Sum(_ => _.money) - model.StructureGrossProfitClientInfo.Sum(_ => _.Value),
                Value2 = ta.Sum(_ => _.money) - model.StructureGrossProfitClientInfo.Sum(_ => _.Value2)
            });


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
            model.CostsDiagram.Add("Расходы по реализации", MainModel.ReportProfitAndLoss.CostsSalesServices.Sum());
            model.CostsDiagram.Add("Админ-ые", MainModel.ReportProfitAndLoss.AdministrativeExpenses.Sum());
            model.CostsDiagram.Add("Расходы на финансирование", MainModel.ReportProfitAndLoss.FinancingCosts.Sum());
            //TODO ЗАполнить в следующем окне
           // model.CostsDiagram.Add("Закуп", );

            // тут опасно, если вдруг в расходах не было записи за какой то месяц то у нас произойдет смещение, но вообще на норм предприятии это маловероятно
            // раньше не предусмотрели, поэтому делаем так
            var stMon = MainModel.StartDate.Month;
            var stYear = MainModel.StartDate.AddYears(MainModel.TimeSpan * -1).Year;
            model.CostsByMonthDiagram = new Dictionary<string, decimal>();
            foreach (var item in MainModel.ReportProfitAndLoss.Costs.Take(MainModel.ReportProfitAndLoss.Costs.Count - 2))
            {               
                model.CostsByMonthDiagram.Add(((Month)stMon).ToString() + "-" + stYear.ToString(), item);//расходы
                if (stMon != 12) stMon++;
                else
                {
                    stMon = 1; stYear++;
                }
            }
            model.GrosProfitDiagram = MainModel.ProfitBA.GrossProfitDiagram;// валовую уже считали
            model.SalesDiagram = MainModel.SalesBA.DynamicsSalesDiagram;// продажи тоже

            //аддс - операц деятельность - выбитие все кроме оплаты поставщику и - TODO ?? Авансы выданные под поставку активов и услуг
            model.CostsComming = MainModel.ReportProfitAndLoss.CostsSalesServices.Sum() +
                                 MainModel.ReportProfitAndLoss.AdministrativeExpenses.Sum() +
                                 MainModel.ReportProfitAndLoss.FinancingCosts.Sum() +
                                 MainModel.ReportProfitAndLoss.OtherCosts.Sum();

            model.CostsCommingDiagram = new Dictionary<string, decimal>();

            model.CostsCommingDiagram.Add("Расходы по реализации", model.CostsComming != 0 ? MainModel.ReportProfitAndLoss.CostsSalesServices.Sum() / model.CostsComming * 100 : 0);
            model.CostsCommingDiagram.Add("Админ-ые", model.CostsComming != 0 ? MainModel.ReportProfitAndLoss.AdministrativeExpenses.Sum() / model.CostsComming * 100 : 0);
            model.CostsCommingDiagram.Add("Расходы на финансирование", model.CostsComming != 0 ? MainModel.ReportProfitAndLoss.FinancingCosts.Sum() / model.CostsComming * 100 : 0);
            model.CostsCommingDiagram.Add("Прочие", 100 - model.CostsCommingDiagram.Sum(_ => _.Value));

            model.CostsOutDiagram = new Dictionary<string, decimal>();
            var ty = (from adz in MainModel.ADDSTranz
                      where adz.en302 == 1 && adz.en450 == 0 && adz.GroupCode != "000000001" && adz.GroupCode != "000000029"
                      group adz by adz.GroupCode into g
                      select new
                      {
                          grCode = g.FirstOrDefault().GroupCode,
                          grName = g.FirstOrDefault().GroupName,
                          money = g.Sum(_ => _.Money)
                      }
                      ).OrderByDescending(_ => _.money).ToList();

            model.CostsOut = ty.Sum(_ => _.money);
            if(model.CostsOut != 0)
                for (var i = 0; i < 4; i++)
                    model.CostsOutDiagram.Add(ty[i].grName, ty[i].money / model.CostsOut * 100);

            model.CostsOutDiagram.Add("Прочее", 100 - model.CostsOutDiagram.Sum(_ => _.Value));
            
            model.paidTaxes = MainModel.ADDSTranz.Where(_ => _.GroupCode == "000000037" || _.GroupCode == "000000036").Sum(_ => _.Money);
            model.paidTaxesFromSales = MainModel.GeneralBA.Sales != 0 ? model.paidTaxes / MainModel.GeneralBA.Sales * 100 : 0;
            model.paidTaxesFromGrosProfit = MainModel.GeneralBA.GrossProfit != 0 ? model.paidTaxes / MainModel.GeneralBA.GrossProfit * 100 : 0;

            return model;
        }

        public static PurchaseBusinessAnalysis GetPurchaseBA(MainModel MainModel)
        {
            var model = new PurchaseBusinessAnalysis();

            model.allPurchase = MainModel.Sales.SelectMany(_ => _.Sales).Where(_ => _.CountPur != decimal.Zero).Select(_ => _.CostPrise).Sum();
            MainModel.CostsBA.CostsDiagram.Add("Закуп", model.allPurchase);
            var pastPur = MainModel.GeneralBA.salesFirst.SelectMany(_ => _.Sales).Where(_ => _.CountPur != decimal.Zero).Select(_ => _.CostPrise).Sum();
            model.difPastPeriod = pastPur != 0 ? (model.allPurchase - pastPur) / pastPur * 100 : 0;

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
                    model.maxPurchaseByMonth = tmp;


                dt = MainModel.IsItQuarter || (MainModel.EndDate - MainModel.StartDate).Days > 365 ? string.Format("{0}, {1}", (Month)item.Date.Month, item.Date.Year) : ((Month)item.Date.Month).ToString();
                model.PurchaseDiagram.Add(dt, item.Sales.Sum(_ => _.CostPrise));
                model.SalesDiagram.Add(dt, item.Sales.Sum(_ => _.SalesWithoutNDS));
                model.PaymentDiagram.Add(dt, MainModel.ADDSTranzPastPeriod[counter].Money);

                counter++;
            }
            model.averagePurchaseByMonth = MainModel.Sales.Count() != 0 ? model.allPurchase / MainModel.Sales.Count() : 0;

            var tmpPurGroup = (from s in MainModel.Sales.SelectMany(_ => _.Sales)
                               group s by s.GroupCode into g
                               select new
                               {
                                   name = g.FirstOrDefault().GroupName,
                                   money = g.Sum(_ => _.CostPrise),
                                   count = g.Sum(_ => _.CountPur)
                               }).OrderByDescending(_ => _.money).ToList();

            model.PurchaseByGoodsDiagram = new Dictionary<string, decimal>();
            model.PurchaseByGoodsDiagram.Add("Прочее", tmpPurGroup.Skip(3).Sum(_ => _.money));
            if(tmpPurGroup.Count > 2)
             model.PurchaseByGoodsDiagram.Add(tmpPurGroup[2].name, tmpPurGroup[2].money);
            if (tmpPurGroup.Count > 1)
                model.PurchaseByGoodsDiagram.Add(tmpPurGroup[1].name, tmpPurGroup[1].money);
            if (tmpPurGroup.Count > 0)
                model.PurchaseByGoodsDiagram.Add(tmpPurGroup[0].name, tmpPurGroup[0].money);

            model.salesByGoodsDiagram = new Dictionary<string, decimal>();
            var ti = MainModel.GeneralBA.gSales.OrderByDescending(_ => _.SalesWithoutNDS).ToArray();
            model.salesByGoodsDiagram.Add("Прочее", ti.Skip(3).Sum(_ => _.SalesWithoutNDS));
            var ttv = 3;
            if (ti.Count() < 3) ttv = ti.Count();
            for (var i = ttv; i > 0; i --)
                model.salesByGoodsDiagram.Add(ti[i].GroupName, ti[i].SalesWithoutNDS);

            model.SalesvsPurchase = model.allPurchase != 0 ? MainModel.GeneralBA.Sales / model.allPurchase * 100 : 0;
            model.difSalesvsPurchasePastPeriod = pastPur != 0 ? model.SalesvsPurchase - 
                (MainModel.GeneralBA.salesFirst.SelectMany(_ => _.Sales).Sum(_ => _.SalesWithoutNDS) / pastPur * 100) : 0;

            model.PaymentvsPurchase = model.allPurchase != 0 ? MainModel.ADDSTranz.Where(_ => _.GroupCode == "000000001").Sum(_ => _.Money) / model.allPurchase * 100 : 0;
            model.difPaymentvsPurchasePastPeriod = pastPur != 0 ? MainModel.ADDSTranzPastPeriod.Sum(_ => _.Money) / pastPur : 0;

            var pusa = Accessors.getPurMan(MainModel.StartDate, MainModel.EndDate).OrderByDescending(_ => _.CostPrise).ToList();

            model.PurchaseByClientDiagram = new Dictionary<string, decimal>();

            for (var i = 0; i < 5; i++)
                model.PurchaseByClientDiagram.Add(pusa[i].SalerName, pusa[i].CostPrise);

            model.PurchaseByClientDiagram.Add("Прочие", pusa.Skip(5).Sum(_ => _.CostPrise));

            var adz = (from az in MainModel.allADDSTranz
                       group az by az.MenCode into g
                       select new
                       {
                           name = g.FirstOrDefault().MenName,
                           code = g.FirstOrDefault().MenCode,
                           money = g.Sum(_ => _.Money)
                       }).OrderByDescending(_ => _.money).ToList();


            model.PaymentByClientDiagram = new Dictionary<string, decimal>();

            for (var i = 0; i < 5; i++)
            {
                if (adz.FirstOrDefault(_ => _.code == pusa[i].SalerCode) != null)
                {
                    model.PaymentByClientDiagram.Add(adz.FirstOrDefault(_ => _.code == pusa[i].SalerCode).name, adz.FirstOrDefault(_ => _.code == pusa[i].SalerCode).money);
                }
                else
                {
                    model.PaymentByClientDiagram.Add(pusa[i].SalerName, 0);
                }
            }

            model.PaymentByClientDiagram.Add("Прочие", adz.Sum(_ => _.money) - model.PaymentByClientDiagram.Sum(_ => _.Value));

            var sstmp = model.PurchaseByClientDiagram.Sum(_ => _.Value);
            model.ClientDiagramInfo = new List<FillModel>();
            if(sstmp != 0)
                foreach (var item in model.PurchaseByClientDiagram)
                    model.ClientDiagramInfo.Add(new FillModel() { Name = item.Key, Share = item.Value / sstmp * 100 });


            return model;
        }

        public static WorkingСapitalBusinessAnalysis GetWorkingСapitalBA(MainModel MainModel)
        {
            var model = new WorkingСapitalBusinessAnalysis();

            model.myMoney = MainModel.BusinessResults.CirculatingAssetsEnd - MainModel.BusinessResults.CurrentDebtEnd;
            model.myCosts = MainModel.BusinessResults.CurrentDebtEnd;

            model.difmyMoney = model.myMoney - MainModel.GeneralBA.PastBisRes.CirculatingAssetsEnd - MainModel.GeneralBA.PastBisRes.CurrentDebtEnd;
            model.difmyMoneyByPercent = (MainModel.GeneralBA.PastBisRes.CirculatingAssetsEnd - MainModel.GeneralBA.PastBisRes.CurrentDebtEnd) != 0 ? 
                model.difmyMoney / (MainModel.GeneralBA.PastBisRes.CirculatingAssetsEnd - MainModel.GeneralBA.PastBisRes.CurrentDebtEnd) * 100 : 0;

            model.difmyCosts = model.myCosts - MainModel.GeneralBA.PastBisRes.CurrentDebtEnd;
            model.difmyCostsByPercent = MainModel.GeneralBA.PastBisRes.CurrentDebtEnd != 0 ? model.difmyCosts / MainModel.GeneralBA.PastBisRes.CurrentDebtEnd * 100 : 0;

            model.stSokDiagram = new Dictionary<string, decimal>();
            var st = ((Month)MainModel.StartDate.Month).ToString() + "," + MainModel.StartDate.AddYears(MainModel.TimeSpan * -1).Year.ToString();
            var en = ((Month)MainModel.EndDate.Month).ToString() + "," + MainModel.EndDate.AddYears(MainModel.TimeSpan * -1).Year.ToString();
            model.stSokDiagram.Add(st , MainModel.BusinessResults.CirculatingAssetsStart - MainModel.BusinessResults.CurrentDebtStart);
            model.stSokDiagram.Add(st + "-" + en, 0);
            model.stSokDiagram.Add(en, model.myMoney);

            model.profit = new Dictionary<string, decimal>();
            model.profit.Add(st, 0);
            model.profit.Add(st + "-" + en, MainModel.GeneralBA.NetProfit);
            model.profit.Add(en, 0);

            model.stDebtsDiagram = new Dictionary<string, decimal>();
            model.stDebtsDiagram.Add(st, MainModel.BusinessResults.CurrentDebtStart);
            model.stDebtsDiagram.Add(st + "-" + en, 0);
            model.stDebtsDiagram.Add(en, MainModel.BusinessResults.CurrentDebtEnd);

            model.turnoverDiagram = new Dictionary<string, decimal>();
            var tr = (from sa in MainModel.Sales.SelectMany(_ => _.Sales)
                      group sa by sa.GroupCode into g
                      select new
                      {
                          code = g.FirstOrDefault().GroupCode,
                          name = g.FirstOrDefault().GroupName,
                          val = (g.FirstOrDefault().CountGoodsSt + g.FirstOrDefault().CountGoodsEnd == 0 
                          ? 1 : g.Sum(_ => _.CostPrise) / (((g.Count() != 0 ? g.FirstOrDefault().CountGoodsSt  + g.FirstOrDefault().CountGoodsEnd : 0)) / 2)) * (MainModel.EndDate - MainModel.StartDate).Days
                      }).OrderByDescending(_ => _.val).ToList();

            var ttC = 3;
            if (tr.Count < 3) ttC = tr.Count;
            for (var i = 0; i < ttC; i++)
                model.turnoverDiagram.Add(tr[i].name, tr[i].val);

            model.turnoverDiagram.Add("Прочее", tr.Sum(_ => _.val) - model.turnoverDiagram.Sum(_ => _.Value));
            DateTime sty = MainModel.StartDate;
            DateTime eny = MainModel.EndDate;
            BusinessResults tmpBR = new BusinessResults();

            model.aveDZDiagram = new Dictionary<string, decimal>();
            model.aveGoodsDiagram = new Dictionary<string, decimal>();
            model.aveMoneyDiagram = new Dictionary<string, decimal>();
            model.aveSalesDiagram = new Dictionary<string, decimal>();
            model.DZ_dzVsKzDiagram = new Dictionary<string, decimal>();
            model.KZ_dzVsKzDiagram = new Dictionary<string, decimal>();
            var isMoreYear = (MainModel.EndDate - MainModel.StartDate).Days > 365;
            foreach (var item in MainModel.Sales)
            {
                MainModel.StartDate = item.Date;
                MainModel.EndDate = item.Date.AddMonths(1);
                // можно оптимизировать это, изначально это считается сразу за весь период, можно в первоначальной загрузке разбить по месяцам,
                // но это только если эта штука нужна будет еще где-то, если только тут, выгоды особой не будет, еще вариант вытаскивать не суммы, 
                // а массивы данных по счетам в массивы данных с датой и на клиенте ворочать, но я думаю это тоже трешак их может быть овер 100 000 по каждому
                tmpBR = GetBusinessResults(MainModel, true);

                var mm =
                 MainModel.IsItQuarter || isMoreYear ? string.Format("{0}, {1}", (Month)item.Date.Month, item.Date.Year) : ((Month)item.Date.Month).ToString();
               
                model.aveDZDiagram.Add(mm, (tmpBR.DebtsOfCustomersAndOverpaymentsStart + tmpBR.DebtsOfCustomersAndOverpaymentsEnd) / 2);
                model.aveGoodsDiagram.Add(mm, (tmpBR.RawAndMaterialsStart + tmpBR.RawAndMaterialsEnd) / 2);
                model.aveMoneyDiagram.Add(mm, (tmpBR.CashInCashBoxStart + tmpBR.MoneyInTheBankAccountsStart + tmpBR.CashInCashBoxEnd + tmpBR.MoneyInTheBankAccountsEnd) / 2);
                model.aveSalesDiagram.Add(mm, item.Sales.Sum(_ => _.SalesWithoutNDS));

                model.KZ_dzVsKzDiagram.Add(mm, (tmpBR.DebtsOfCustomersAndOverpaymentsStart + tmpBR.DebtsOfCustomersAndOverpaymentsEnd) / 2);
                model.DZ_dzVsKzDiagram.Add(mm, (tmpBR.PayablesToSuppliersShortTermDebtsStart + tmpBR.PayablesToSuppliersShortTermDebtsEnd) / 2);
            }

            MainModel.StartDate = sty;
            MainModel.EndDate = eny;


            return model;
        }

        public static BusinessResults GetBusinessResults(MainModel model, bool isForMonth = false)
        {
            return Accessors.GetBusinessResults(model, isForMonth);
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

            model.CoveringCurrentDebtMoneyStart = (businessResults.CashInCashBoxStart + businessResults.MoneyInTheBankAccountsStart
                + businessResults.DepositsStart) / (businessResults.CurrentDebtStart != 0 ? businessResults.CurrentDebtStart : 1);
            model.CoveringCurrentDebtMoneyEnd = (businessResults.CashInCashBoxEnd + businessResults.MoneyInTheBankAccountsEnd
                + businessResults.DepositsEnd) / (businessResults.CurrentDebtEnd != 0 ? businessResults.CurrentDebtEnd : 1);

            model.CoveringCurrentDebtMoneyAndCustomerDebtsStart = (businessResults.CashInCashBoxStart + businessResults.MoneyInTheBankAccountsStart
                + businessResults.DepositsStart + businessResults.DebtsOfCustomersAndOverpaymentsStart)
                / (businessResults.CurrentDebtStart != 0 ? businessResults.CurrentDebtStart : 1);
            model.CoveringCurrentDebtMoneyAndCustomerDebtsEnd = (businessResults.CashInCashBoxEnd + businessResults.MoneyInTheBankAccountsEnd
                + businessResults.DepositsEnd + businessResults.DebtsOfCustomersAndOverpaymentsEnd)
                / (businessResults.CurrentDebtEnd != 0 ? businessResults.CurrentDebtEnd : 1);

            model.CoveringCurrentDebtOfCurrentAssetsStart = businessResults.CirculatingAssetsStart
                / (businessResults.CurrentDebtStart != 0 ? businessResults.CurrentDebtStart : 1);
            model.CoveringCurrentDebtOfCurrentAssetsEnd = businessResults.CirculatingAssetsEnd
                / (businessResults.CurrentDebtEnd != 0 ? businessResults.CurrentDebtEnd : 1);

            #endregion

            #region Ист сайд

            model.DebtPartInTheCompanyAssetsStart = (businessResults.CurrentDebtStart + businessResults.LongTermDebtStart)
                / (businessResults.TotalLiabilitiesStart != 0 ? businessResults.TotalLiabilitiesStart : 1);
            model.DebtPartInTheCompanyAssetsEnd = (businessResults.CurrentDebtEnd + businessResults.LongTermDebtEnd)
                / (businessResults.TotalLiabilitiesEnd != 0 ? businessResults.TotalLiabilitiesEnd : 1);

            model.PartOfEquityInTheCompanyAssetsStart = businessResults.OwnCapitalStart + businessResults.TotalLiabilitiesStart;
            model.PartOfEquityInTheCompanyAssetsEnd = businessResults.OwnCapitalEnd + businessResults.TotalLiabilitiesEnd;

            model.CoveringLoansByEquityStart = (businessResults.CreditsForOneYearStart + businessResults.CreditsForLongerThanOneYearStart)
                / (businessResults.OwnCapitalStart != 0 ? businessResults.OwnCapitalStart : 1);
            model.CoveringLoansByEquityEnd = (businessResults.CreditsForOneYearEnd + businessResults.CreditsForLongerThanOneYearEnd)
                / (businessResults.OwnCapitalEnd != 0 ? businessResults.OwnCapitalEnd : 1);

            #endregion

            #endregion

            #region Второй блок

            var sum = reportProfitAndLoss.TotalCostPrice.Count != 0 ? reportProfitAndLoss.TotalCostPrice.Sum() : 1;
            model.SpeedOfTurnover = businessResults.GoodsEnd * MainModel.DaysInPeriod /
                (sum != 0 ? sum : 1);

            sum = reportProfitAndLoss.TotalIncome.Count != 0 ? reportProfitAndLoss.TotalIncome.Sum() : 1;
            model.TermOfCirculationOfClientsDebt = businessResults.DebtsOfCustomersAndOverpaymentsEnd * MainModel.DaysInPeriod /
                (sum != 0 ? sum : 1);

            sum = reportProfitAndLoss.TotalIncome.Count != 0 ? reportProfitAndLoss.TotalIncome.Sum() : 1;
            model.TermOfCirculationOfDebtToSuppliers = businessResults.PayablesToSuppliersShortTermDebtsEnd * MainModel.DaysInPeriod /
                (sum != 0 ? sum : 1);

            #endregion

            return model;
        }

        public static List<GroupsEnt> GetCashFlowReport(MainModel model)
        {
            return Accessors.GetAddsTranz(model.StartDate, model.EndDate, model.RegGroups ?? new List<RefGroupsEnt>(), new List<string> { });
        }

        public static StressTestingModel GetStressTesting(MainModel model)
        {
            return new StressTestingModel()
            {
                // Диаграммы
                Sales = model.GeneralBA.Sales,
                GrossProfit = model.GeneralBA.GrossProfit,
                NetProfit = model.GeneralBA.NetProfit,
                // Поля
                // Продажи
                SalesGeneral = model.GeneralBA.Sales,
                SalesTop3Clients = model.SalesBA.StructureGrossProfitClientInfo.Take(3).Sum(i => i.Value),
                SalesTopProduct = model.SalesBA.Goods1Info.Value,
                SalesTop3Products = model.SalesBA.Goods1Info.Value + model.SalesBA.Goods2Info.Value + model.SalesBA.Goods3Info.Value,
                // Рентабельность
                ProfitabilityGeneralPerc = model.ProfitBA.GrossProfitability,
                ProfitabilityGeneral= model.ProfitBA.GrossProfit,
                ProfitabilityTop3Clients = model.ProfitBA.StructureGrossProfitClientDiagram.Take(3).Sum(i => i.Value),
                ProfitabilityTopProduct = model.ProfitBA.StructureGrossProfitGoodsDiagram.Take(1).Sum(i => i.Value),
                ProfitabilityTop3Products = model.ProfitBA.StructureGrossProfitGoodsDiagram.Take(3).Sum(i => i.Value),
                // Расходы
                Expenses = model.GeneralBA.Cost

            };
        }

        private static void FillPercentForAllProperty(ref string First, ref string Second, DateTime stTodayDate, DateTime endTodayDate, GeneralBusinessAnalysis model
            , List<SalesModel> salesFirst, List<SalesModel> salesSecond, int dif)
        {

        }

    }
}
