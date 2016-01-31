using ProgressoExpert.Common.Enums;
using ProgressoExpert.DataAccess.Entities;
using ProgressoExpert.Models.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.DataAccess
{
    public class Accessors
    {
        private static List<ScoreEnt> scores = null;
        private static List<TranzEnt> Start = null;
        private static List<TranzEnt> End = null;

        private static List<ScoreEnt> ourScr = null;

        private static List<TranzEnt> ourDbtSt; // Это уже транзакции связанные с нашим счетом на начало
        private static List<TranzEnt> ourDbtEnd; // Это уже транзакции связанные с нашим счетом на конец (мы не будем считать на конец периода заного, почтитаем между датами, и сложем)
        private static List<TranzEnt> ourCrtSt;
        private static List<TranzEnt> ourCrtEnd;

        public static BusinessResults GetBusinessResults(MainModel mainModel)
        {
            BusinessResults model = new BusinessResults();
            using (dbEntities db = new dbEntities())
            {
                scores = mainModel.Scores;
                Start = mainModel.StartTranz;
                End = mainModel.EndTranz;

                ourScr = new List<ScoreEnt>(); // Вытащим ID интересующих нас счетов нас счетов

                decimal _outStart = 0;
                decimal _outEnd = 0;

                #region Краткосрочные активы

                #region Денежные средства в кассе

                Calculate(out _outStart, out _outEnd, 
                    (int)ScoresForBusinessResults.CashInCashBox1,
                    (int)ScoresForBusinessResults.CashInCashBox2);
                model.CashInCashBoxStart = _outStart;
                model.CashInCashBoxEnd = _outEnd;

                #endregion

                #region Денежные средства на рассчетном счете

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.CasnInCheckingAccount1,
                    (int)ScoresForBusinessResults.CasnInCheckingAccount2);
                model.CasnInCheckingAccountStart = _outStart;
                model.CasnInCheckingAccountEnd = _outEnd;

                #endregion

                #region Депозиты

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.Deposits);
                model.DepositsStart = _outStart;
                model.DepositsEnd = _outEnd;

                #endregion

                #region Дебиторская задолженность

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.Receivables);
                model.ReceivablesStart = _outStart;
                model.ReceivablesEnd = _outEnd;

                #endregion

                #region Сырье и материалы

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.RawAndMaterials);
                model.RawAndMaterialsStart = _outStart;
                model.RawAndMaterialsEnd = _outEnd;

                #endregion

                #region Товары

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.Goods1,
                    (int)ScoresForBusinessResults.Goods2);
                model.GoodsStart = _outStart;
                model.GoodsEnd = _outEnd;

                #endregion

                #region Незавершенное производство

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.UnfinishedProduction);
                model.UnfinishedProductionStart = _outStart;
                model.UnfinishedProductionEnd = _outEnd;

                #endregion

                #region Прочие краткосрочные активы

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.OtherCurrentAssets1,
                    (int)ScoresForBusinessResults.OtherCurrentAssets2,
                    (int)ScoresForBusinessResults.OtherCurrentAssets3,
                    (int)ScoresForBusinessResults.OtherCurrentAssets4,
                    (int)ScoresForBusinessResults.OtherCurrentAssets5,
                    (int)ScoresForBusinessResults.OtherCurrentAssets6,
                    (int)ScoresForBusinessResults.OtherCurrentAssets7,
                    (int)ScoresForBusinessResults.OtherCurrentAssets8,
                    (int)ScoresForBusinessResults.OtherCurrentAssets9,
                    (int)ScoresForBusinessResults.OtherCurrentAssets10,
                    (int)ScoresForBusinessResults.OtherCurrentAssets11,
                    (int)ScoresForBusinessResults.OtherCurrentAssets12);
                model.OtherCurrentAssetsStart = _outStart;
                model.OtherCurrentAssetsEnd = _outEnd;

                #endregion

                #region Налоговые активы

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.TaxAssets);
                model.TaxAssetsStart = _outStart;
                model.TaxAssetsEnd = _outEnd;

                #endregion

                #region Краткосрочные активы

                model.CalculateShortTermAssets();

                #endregion

                #endregion

                #region Долгосрочные активы

                #region Долгосрочная дебиторская задолженность контрагентов

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.LongTermReceivables);
                model.LongTermReceivablesStart = _outStart;
                model.LongTermReceivablesEnd = _outEnd;

                #endregion

                #region Прочая долгосрочная дебиторская задолженность контрагентов

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.OtherLongTermReceivables1,
                    (int)ScoresForBusinessResults.OtherLongTermReceivables2,
                    (int)ScoresForBusinessResults.OtherLongTermReceivables3,
                    (int)ScoresForBusinessResults.OtherLongTermReceivables4,
                    (int)ScoresForBusinessResults.OtherLongTermReceivables5,
                    (int)ScoresForBusinessResults.OtherLongTermReceivables6,
                    (int)ScoresForBusinessResults.OtherLongTermReceivables7,
                    (int)ScoresForBusinessResults.OtherLongTermReceivables8,
                    (int)ScoresForBusinessResults.OtherLongTermReceivables9,
                    (int)ScoresForBusinessResults.OtherLongTermReceivables10,
                    (int)ScoresForBusinessResults.OtherLongTermReceivables11,
                    (int)ScoresForBusinessResults.OtherLongTermReceivables12);
                model.OtherLongTermReceivablesStart = _outStart;
                model.OtherLongTermReceivablesEnd = _outEnd;

                #endregion

                #region Инвестиции

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.Investments1,
                    (int)ScoresForBusinessResults.Investments2,
                    (int)ScoresForBusinessResults.Investments3);
                model.InvestmentsStart = _outStart;
                model.InvestmentsEnd = _outEnd;

                #endregion

                #region Основные средства

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.FixedAssets);
                model.FixedAssetsStart = _outStart;
                model.FixedAssetsEnd = _outEnd;

                #endregion

                #region Нематериальные активы

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.IntangibleAssets);
                model.IntangibleAssetsStart = _outStart;
                model.IntangibleAssetsEnd = _outEnd;

                #endregion

                #region Долгосрочные налоговые активы

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.LongTermTaxAssets);
                model.LongTermTaxAssetsStart = _outStart;
                model.LongTermTaxAssetsEnd = _outEnd;

                #endregion

                #region Долгосрочные активы

                model.CalculateLongTermAssets();

                #endregion

                #endregion

                #region Краткосрочные долги

                #region Краткосрочные банковские займы

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.ShortTermBankLoans1,
                    (int)ScoresForBusinessResults.ShortTermBankLoans2);
                model.ShortTermBankLoansStart = _outStart;
                model.ShortTermBankLoansEnd = _outEnd;

                #endregion

                #region Задолженность по КПН/ИПН

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.DebtCitIit);
                model.DebtCitIitStart = _outStart;
                model.DebtCitIitEnd = _outEnd;

                #endregion

                #region Задолженность по НДС

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.DebtVat);
                model.DebtVatStart = _outStart;
                model.DebtVatEnd = _outEnd;

                #endregion

                #region Прочая задолженность по налогам

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.OtherTaxesPayable1,
                    (int)ScoresForBusinessResults.OtherTaxesPayable2,
                    (int)ScoresForBusinessResults.OtherTaxesPayable3,
                    (int)ScoresForBusinessResults.OtherTaxesPayable4,
                    (int)ScoresForBusinessResults.OtherTaxesPayable5,
                    (int)ScoresForBusinessResults.OtherTaxesPayable6,
                    (int)ScoresForBusinessResults.OtherTaxesPayable7);
                model.OtherTaxesPayableStart = _outStart;
                model.OtherTaxesPayableEnd = _outEnd;

                #endregion

                #region Прочая задолженность по налогам

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.PayablesToCounterpartiesShortTermDebts);
                model.PayablesToCounterpartiesShortTermDebtsStart = _outStart;
                model.PayablesToCounterpartiesShortTermDebtsEnd = _outEnd;

                #endregion

                #region Задолженность перед сотрудниками

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.PayablesToEmployees);
                model.PayablesToEmployeesStart = _outStart;
                model.PayablesToEmployeesEnd = _outEnd;

                #endregion

                #region Прочая задолженность

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.OtherDebtsShortTermDebts1,
                    (int)ScoresForBusinessResults.OtherDebtsShortTermDebts2,
                    (int)ScoresForBusinessResults.OtherDebtsShortTermDebts3,
                    (int)ScoresForBusinessResults.OtherDebtsShortTermDebts4,
                    (int)ScoresForBusinessResults.OtherDebtsShortTermDebts5,
                    (int)ScoresForBusinessResults.OtherDebtsShortTermDebts6,
                    (int)ScoresForBusinessResults.OtherDebtsShortTermDebts7,
                    (int)ScoresForBusinessResults.OtherDebtsShortTermDebts8,
                    (int)ScoresForBusinessResults.OtherDebtsShortTermDebts9,
                    (int)ScoresForBusinessResults.OtherDebtsShortTermDebts10);
                model.OtherDebtsShortTermDebtsStart = _outStart;
                model.OtherDebtsShortTermDebtsEnd = _outEnd;

                #endregion

                #region Краткосрочные долги

                model.CalculateShortTermDebt();

                #endregion

                #endregion

                #region Долгосрочные долги

                #region Долгосрочные банковские займы

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.LongTermBankLoans1,
                    (int)ScoresForBusinessResults.LongTermBankLoans2);
                model.LongTermBankLoansStart = _outStart;
                model.LongTermBankLoansEnd = _outEnd;

                #endregion

                #region Задолженность перед контрагентами

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.PayablesToCounterpartiesLongTermDebts);
                model.PayablesToCounterpartiesLongTermDebtsStart = _outStart;
                model.PayablesToCounterpartiesLongTermDebtsEnd = _outEnd;

                #endregion

                #region Отложеннные налоговая задолженность

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.DefferedTaxDebts);
                model.DefferedTaxDebtsStart = _outStart;
                model.DefferedTaxDebtsEnd = _outEnd;

                #endregion

                #region Прочая задолженность

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.OtherDebtsLongTermDebts1,
                    (int)ScoresForBusinessResults.OtherDebtsLongTermDebts2,
                    (int)ScoresForBusinessResults.OtherDebtsLongTermDebts3,
                    (int)ScoresForBusinessResults.OtherDebtsLongTermDebts4);
                model.OtherDebtsLongTermDebtsStart = _outStart;
                model.OtherDebtsLongTermDebtsEnd = _outEnd;

                #endregion

                #region Долгосрочные долги

                model.CalculateLongTermDebt();

                #endregion

                #endregion

                #region Собственный капитал

                #region Уставной капитал

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.AuthorizedCapital1,
                    (int)ScoresForBusinessResults.AuthorizedCapital2);
                model.AuthorizedCapitalStart = _outStart;
                model.AuthorizedCapitalEnd = _outEnd;

                #endregion

                #region Накопленная прибыль/убыток

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.AccumulatedProfitAndLoss);
                model.AccumulatedProfitAndLossStart = _outStart;
                model.AccumulatedProfitAndLossEnd = _outEnd;

                #endregion

                #region Прочий капитал

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.OtherCapital);
                model.OtherCapitalStart = _outStart;
                model.OtherCapitalEnd = _outEnd;

                #endregion

                #region Собственный капитал

                model.CalculateOwnCapital();

                #endregion

                #endregion

                #region Итого

                #region Итого активов

                model.CalculateTotalAssets();

                #endregion

                #region Итого пассивов

                model.CalculateTotalLiabilities();

                #endregion



                #endregion

                return model;
            }         
        }

        public static ReportProfitAndLoss GetReportProfitAndLoss(MainModel mainModel)
        {
            ReportProfitAndLoss model = new ReportProfitAndLoss();
            using (dbEntities db = new dbEntities())
            {
                var scores = mainModel.Scores;
                List<ScoreEnt> ourScr = new List<ScoreEnt>();
                List<TranzEnt> ourDbt = new List<TranzEnt>();
                List<TranzEnt> ourCrt = new List<TranzEnt>();

                int[] endMonthYear = new int[] { mainModel.EndDate.Month, mainModel.EndDate.Year + mainModel.TimeSpan };
                int[] startMonthYear = new int[] { mainModel.StartDate.Month, mainModel.StartDate.Year + mainModel.TimeSpan };//будем бежать от начала до конца периода

                #region Посчитаем кол-во месяцев
                int monthCount = 0;
                do
                {
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

                List<TranzEnt> monthTranz = new List<TranzEnt>();//все транзакции за месяц (первый и последний могут быть обрезаны)
                DateTime oneMonthDateStart = new DateTime();// стартовая дата для каждого месяца
                DateTime oneMonthDateEnd = new DateTime();// конечная дата для каждого месяца
                
                #region Инициализация
                model.IncomeSale = new List<decimal>();
                model.IncomeService = new List<decimal>();
                model.CostPriceSale = new List<decimal>();
                model.CostPriceService = new List<decimal>();
                model.SalaryAdmPer = new List<decimal>();
                model.SalarySalesDepartment = new List<decimal>();
                model.SalaryServicePer = new List<decimal>();
                model.BonusesSalesManagerSellers = new List<decimal>();
                model.RentOfficeWarehouse = new List<decimal>();
                model.DistributionСosts = new List<decimal>();
                model.OtherAdministrativeExpenses = new List<decimal>();
                model.BankInterest = new List<decimal>();
                model.Depreciation = new List<decimal>();
                model.KPN20 = new List<decimal>();
                model.TotalIncome = new List<decimal>();
                model.TotalCostPrice = new List<decimal>();
                model.GrossProfitSale = new List<decimal>();
                model.GrossProfitService = new List<decimal>();
                model.GrossProfit = new List<decimal>();
                model.Costs = new List<decimal>();
                model.Ebitda = new List<decimal>();
                model.ProfitBeforeTaxation = new List<decimal>();
                model.ProfitAfterTaxation = new List<decimal>();           
                #endregion

                
                int monthCounter = 0; // счетчик пройденых месяцев
                for (int scoreNum = 0; scoreNum < (int)ProfitAndLossNumServer.Total; scoreNum++)
                {
                    endMonthYear = new int[] { mainModel.EndDate.Month, mainModel.EndDate.Year + mainModel.TimeSpan };
                    startMonthYear = new int[] { mainModel.StartDate.Month, mainModel.StartDate.Year + mainModel.TimeSpan };

                    switch (scoreNum)
                    {
                        #region Вытаскиваем наши счета
                        case (int)ProfitAndLossNumServer.IncomeSale:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.IncomeSale }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.IncomeService:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.IncomeService1,
                                                                 (int)ScoresReportProfitAndLoss.IncomeService2, 
                                                                 (int)ScoresReportProfitAndLoss.IncomeService3, 
                                                                 (int)ScoresReportProfitAndLoss.IncomeService4, 
                                                                 (int)ScoresReportProfitAndLoss.IncomeService5, 
                                                                 (int)ScoresReportProfitAndLoss.IncomeService6  
                                                               }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.CostPriceSale:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.СostPriceSale1,
                                                                 (int)ScoresReportProfitAndLoss.СostPriceSale2
                                                               }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.CostPriceService:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.СostPriceService}, scores);
                            break;
                        case (int)ProfitAndLossNumServer.SalaryAdmPer:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.SalaryAdmPer }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.SalarySalesDepartment:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.SalarySalesDepartment }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.SalaryServicePer:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.SalaryServicePer }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.BonusesSalesManagerSellers:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.BonusesSalesManagerSellers }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.RentOfficeWarehouse:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.RentOfficeWarehouse }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.DistributionСosts:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.DistributionСosts }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.OtherAdministrativeExpenses:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.OtherAdministrativeExpenses }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.BankInterest:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.BankInterest }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.Depreciation:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.Depreciation1,
                                                                 (int)ScoresReportProfitAndLoss.Depreciation2
                                                               }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.KPN20:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.KPN20 }, scores);
                            break;
                        #endregion
                    }

                    bool isFirstMonth = true;
                    monthCounter = 0; // счетчик пройденых месяцев
                    do
                    {
                        #region Определим дату начала и конца месяца
                        monthCounter++;                        
                        if (isFirstMonth)
                        {
                            oneMonthDateStart = new DateTime(startMonthYear[1], startMonthYear[0], mainModel.StartDate.Day);
                            isFirstMonth = false;
                        }
                        else
                        {
                            oneMonthDateStart = new DateTime(startMonthYear[1], startMonthYear[0], 1);
                        }

                        #region Cчитаем кол-во месяцев
                        if (startMonthYear[0] == 12)
                        {
                            startMonthYear[1]++;
                            startMonthYear[0] = 1;
                        }
                        else
                        {
                            startMonthYear[0]++;
                        }
                        #endregion

                        if (monthCounter > monthCount) // если последний месяц возьмем с него дату
                        {
                            oneMonthDateEnd = new DateTime(endMonthYear[1], endMonthYear[0], mainModel.EndDate.Day);
                        }
                        else // иначе мы должны довести старт до начала следующего месяца
                        {
                            oneMonthDateEnd = new DateTime(startMonthYear[1], startMonthYear[0], 1);
                        }
                        #endregion

                        List<TranzEnt> monthTrans = new List<TranzEnt>();
                        if (monthCounter > monthCount)
                        {
                            monthTrans = mainModel.EndTranz.Where(_ => _.period >= oneMonthDateStart && _.period <= oneMonthDateEnd).ToList();
                        }
                        else
                        {
                            monthTrans = mainModel.EndTranz.Where(_ => _.period >= oneMonthDateStart && _.period < oneMonthDateEnd).ToList();// тут строго т.к. мы в середине общего периода берем конец как начало следующуго
                        }

                        GetPeriodMoney(monthTrans, ourScr, out ourDbt, out ourCrt);
                        
                        switch (scoreNum)
                        {
                            #region Запишем суммы в модель
                            case (int)ProfitAndLossNumServer.IncomeSale:
                                model.IncomeSale.Add(Math.Round(ourCrt.Select(_ => _.Money).Sum(), 2));;
                                break;
                            case (int)ProfitAndLossNumServer.IncomeService:
                                model.IncomeService.Add(Math.Round(ourCrt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.CostPriceSale:
                                model.CostPriceSale.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.CostPriceService:
                                model.CostPriceService.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.SalaryAdmPer:
                                model.SalaryAdmPer.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.SalarySalesDepartment:
                                model.SalarySalesDepartment.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.SalaryServicePer:
                                model.SalaryServicePer.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.BonusesSalesManagerSellers:
                                model.BonusesSalesManagerSellers.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.RentOfficeWarehouse:
                                model.RentOfficeWarehouse.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.DistributionСosts:
                                model.DistributionСosts.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.OtherAdministrativeExpenses:
                                model.OtherAdministrativeExpenses.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.BankInterest:
                                model.BankInterest.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.Depreciation:
                                model.Depreciation.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.KPN20:
                                model.KPN20.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            #endregion
                        }                        
                    }
                    while ((startMonthYear[1] <= endMonthYear[1] && startMonthYear[1] != endMonthYear[1]) || (startMonthYear[0] <= endMonthYear[0] && startMonthYear[1] == endMonthYear[1]));
                }

                // Заполним расчитываемые поля
                for(int i = 0; i < monthCounter; i++)
                {
                    model.TotalIncome.Add(model.IncomeSale[i] + model.IncomeService[i]);
                    model.TotalCostPrice.Add(model.CostPriceSale[i] + model.CostPriceService[i]);
                    model.GrossProfitSale.Add(model.IncomeSale[i] - model.CostPriceSale[i]);
                    model.GrossProfitService.Add(model.IncomeService[i] - model.CostPriceService[i]);                    
                    model.GrossProfit.Add(model.GrossProfitSale[i] - model.GrossProfitService[i]);
                    model.Costs.Add(model.SalaryAdmPer[i] + model.SalarySalesDepartment[i] + model.SalaryServicePer[i] + model.BonusesSalesManagerSellers[i]
                                    + model.RentOfficeWarehouse[i] + model.DistributionСosts[i] + model.OtherAdministrativeExpenses[i]);
                    model.Ebitda.Add(model.GrossProfitSale[i] + model.GrossProfitService[i] - model.Costs[i]);
                    model.ProfitBeforeTaxation.Add(model.Ebitda[i] - model.BankInterest[i] - model.Depreciation[i]);
                    model.ProfitAfterTaxation.Add(model.ProfitBeforeTaxation[i] - model.KPN20[i]);
                }

                #region Расчитаем среднюю и общую сумму по каждой строке
                model.TotalIncome.Add(Math.Round(model.TotalIncome.Take(monthCounter).Sum(), 2));// общее
                model.TotalIncome.Add(Math.Round(model.TotalIncome.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.IncomeSale.Add(Math.Round(model.IncomeSale.Take(monthCounter).Sum(), 2));// общее
                model.IncomeSale.Add(Math.Round(model.IncomeSale.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.IncomeService.Add(Math.Round(model.IncomeService.Take(monthCounter).Sum(), 2));// общее
                model.IncomeService.Add(Math.Round(model.IncomeService.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.TotalCostPrice.Add(Math.Round(model.TotalCostPrice.Take(monthCounter).Sum(), 2));// общее
                model.TotalCostPrice.Add(Math.Round(model.TotalCostPrice.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.CostPriceSale.Add(Math.Round(model.CostPriceSale.Take(monthCounter).Sum(), 2));// общее
                model.CostPriceSale.Add(Math.Round(model.CostPriceSale.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.CostPriceService.Add(Math.Round(model.CostPriceService.Take(monthCounter).Sum(), 2));// общее
                model.CostPriceService.Add(Math.Round(model.CostPriceService.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.GrossProfitSale.Add(Math.Round(model.GrossProfitSale.Take(monthCounter).Sum(), 2));// общее
                model.GrossProfitSale.Add(Math.Round(model.GrossProfitSale.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.GrossProfitService.Add(Math.Round(model.GrossProfitService.Take(monthCounter).Sum(), 2));// общее
                model.GrossProfitService.Add(Math.Round(model.GrossProfitService.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.GrossProfit.Add(Math.Round(model.GrossProfit.Take(monthCounter).Sum(), 2));// общее
                model.GrossProfit.Add(Math.Round(model.GrossProfit.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.Costs.Add(Math.Round(model.Costs.Take(monthCounter).Sum(), 2));// общее
                model.Costs.Add(Math.Round(model.Costs.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.SalaryAdmPer.Add(Math.Round(model.SalaryAdmPer.Take(monthCounter).Sum(), 2));// общее
                model.SalaryAdmPer.Add(Math.Round(model.SalaryAdmPer.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.SalarySalesDepartment.Add(Math.Round(model.SalarySalesDepartment.Take(monthCounter).Sum(), 2));// общее
                model.SalarySalesDepartment.Add(Math.Round(model.SalarySalesDepartment.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.SalaryServicePer.Add(Math.Round(model.SalaryServicePer.Take(monthCounter).Sum(), 2));// общее
                model.SalaryServicePer.Add(Math.Round(model.SalaryServicePer.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.BonusesSalesManagerSellers.Add(Math.Round(model.BonusesSalesManagerSellers.Take(monthCounter).Sum(), 2));// общее
                model.BonusesSalesManagerSellers.Add(Math.Round(model.BonusesSalesManagerSellers.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.RentOfficeWarehouse.Add(Math.Round(model.RentOfficeWarehouse.Take(monthCounter).Sum(), 2));// общее
                model.RentOfficeWarehouse.Add(Math.Round(model.RentOfficeWarehouse.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.DistributionСosts.Add(Math.Round(model.DistributionСosts.Take(monthCounter).Sum(), 2));// общее
                model.DistributionСosts.Add(Math.Round(model.DistributionСosts.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.OtherAdministrativeExpenses.Add(Math.Round(model.OtherAdministrativeExpenses.Take(monthCounter).Sum(), 2));// общее
                model.OtherAdministrativeExpenses.Add(Math.Round(model.OtherAdministrativeExpenses.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.BankInterest.Add(Math.Round(model.BankInterest.Take(monthCounter).Sum(), 2));// общее
                model.BankInterest.Add(Math.Round(model.BankInterest.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.Depreciation.Add(Math.Round(model.Depreciation.Take(monthCounter).Sum(), 2));// общее
                model.Depreciation.Add(Math.Round(model.Depreciation.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.KPN20.Add(Math.Round(model.KPN20.Take(monthCounter).Sum(), 2));// общее
                model.KPN20.Add(Math.Round(model.KPN20.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.Ebitda.Add(Math.Round(model.Ebitda.Take(monthCounter).Sum(), 2));// общее
                model.Ebitda.Add(Math.Round(model.Ebitda.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.ProfitBeforeTaxation.Add(Math.Round(model.ProfitBeforeTaxation.Take(monthCounter).Sum(), 2));// общее
                model.ProfitBeforeTaxation.Add(Math.Round(model.ProfitBeforeTaxation.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.ProfitAfterTaxation.Add(Math.Round(model.ProfitAfterTaxation.Take(monthCounter).Sum(), 2));// общее
                model.ProfitAfterTaxation.Add(Math.Round(model.ProfitAfterTaxation.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                #endregion

                return model;
            }
        }

        #region SubQuery

        /// <summary>
        /// Метод рассчета
        /// </summary>
        /// <param name="values"></param>
        /// <param name="_start"></param>
        /// <param name="_end"></param>
        private static void Calculate(out decimal _start, out decimal _end, params int[] values)
        {
            _start = 0;
            _end = 0;

            List<int> list = values.OfType<int>().ToList();

            ourScr = GetOurScore(list, scores);
            GetStartEndDateMoney(Start, End, ourScr, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);
            var _itemStart = CalculateStart(ourDbtSt, ourCrtSt);
            var _itemFinish = CalculateEnd(_itemStart, ourDbtEnd, ourCrtEnd);
            _start += _itemStart;
            _end += _itemFinish;
        }

        /// <summary>
        /// Метод возращает массив счетов которые нам нужны, нужны айдишники через которые уже и будем вязаться на транзакции
        /// </summary>
        /// <param name="sroreArr">массив состоящий из первых двух цыфр счетов которые нам нужны</param>
        /// <param name="scores">все счета</param>
        /// <param name="ourScr">результат</param>
        private static List<ScoreEnt> GetOurScore(long MyScore, List<ScoreEnt> scores)
        {
            var _ourScr = new List<ScoreEnt>();
            var _myScore = MyScore.ToString();
            //List<string> Scores = new List<string>();
            //for (int i = 0; i < _myScore.Count(); i = i + 2)
            //{
            //    Scores.Add(_myScore[i].ToString() + _myScore[i + 1].ToString());
            //}

            foreach (var sc in scores)
            {
                if (sc.Code.Length < 4) continue;
                if (sc.ToString().Contains(_myScore))
                {
                    _ourScr.Add(sc);
                }
                //var tt = string.Join("", sc.Code.Take(4)); // берем все счета которые начинаются с 10
                //if (Scores.Contains(tt))
                //{
                //    _ourScr.Add(sc);
                //}
            }
            return _ourScr;

            //var _ourScr = new List<ScoreEnt>();
            //var _myScore = MyScore.ToString();
            //List<string> Scores = new List<string>();
            //for (int i = 0; i < _myScore.Count(); i = i + 2)
            //{
            //    Scores.Add(_myScore[i].ToString() + _myScore[i + 1].ToString());
            //}

            //foreach (var sc in scores)
            //{
            //    if (sc.Code.Length < 4) continue;
            //    var tt = string.Join("", sc.Code.Take(2)); // берем все счета которые начинаются с 10
            //    if (Scores.Contains(tt))
            //    {
            //        _ourScr.Add(sc);
            //    }
            //}
            //return _ourScr;
        }

        /// <summary>
        /// Метод возращает массив счетов которые нам нужны
        /// </summary>
        /// <param name="sroreArr">массив состоящий из первых двух цифр счетов которые нам нужны</param>
        /// <param name="scores">все счета</param>
        /// <param name="ourScr">результат</param>
        private static List<ScoreEnt> GetOurScore(List<int> MyScores, List<ScoreEnt> scores)
        {
            var _ourScr = new List<ScoreEnt>();
            List<string> Scores = new List<string>();
            foreach (var sc in scores)
            {
                if (sc.ToString().Length < 4) continue;
                foreach (var ms in MyScores)
                {
                    if (ms.ToString().Contains(sc.Code))
                    {
                        _ourScr.Add(sc);
                    }
                }
            }
            return _ourScr;
        }


        /// <summary>
        /// Метод вытаскивает деньги на начало периода и на конец, по дебету и кредету
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        /// <param name="ourScr"></param>
        /// <param name="ourDbtSt"></param>
        /// <param name="ourDbtEnd"></param>
        /// <param name="ourCrtSt"></param>
        /// <param name="ourCrtEnd"></param>
        private static void GetStartEndDateMoney(List<TranzEnt> Start, List<TranzEnt> End, List<ScoreEnt> ourScr, out List<TranzEnt> ourDbtSt, out List<TranzEnt> ourDbtEnd, out List<TranzEnt> ourCrtSt, out List<TranzEnt> ourCrtEnd)
        {
            ourDbtSt = new List<TranzEnt>();
            ourDbtEnd = new List<TranzEnt>();

            ourCrtSt = new List<TranzEnt>();
            ourCrtEnd = new List<TranzEnt>();

            foreach (var item in ourScr)
            {
                foreach (var St in Start)
                {
                    // ID приходит как массив байтов, поэтому
                    if (UnsafeCompare(St.DtRRef, item.Id)) { ourDbtSt.Add(St); }
                    if (UnsafeCompare(St.CtRRef, item.Id)) { ourCrtSt.Add(St); }
                }
                foreach (var En in End)
                {
                    if (UnsafeCompare(En.DtRRef, item.Id)) { ourDbtEnd.Add(En); }
                    if (UnsafeCompare(En.CtRRef, item.Id)) { ourCrtEnd.Add(En); }
                }
            }
        }

         /// <summary>
        /// Метод вытаскивает транзакции по дебету и кредиту
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        /// <param name="ourScr"></param>
        /// <param name="ourDbtSt"></param>
        /// <param name="ourDbtEnd"></param>
        /// <param name="ourCrtSt"></param>
        /// <param name="ourCrtEnd"></param>
        private static void GetPeriodMoney(List<TranzEnt> Trans, List<ScoreEnt> ourScr, out List<TranzEnt> ourDbt, out List<TranzEnt> ourCrt)
        {
            ourDbt = new List<TranzEnt>();
            ourCrt = new List<TranzEnt>();

            foreach (var item in ourScr)
            {
                foreach (var St in Trans)
                {
                    if (UnsafeCompare(St.DtRRef, item.Id)) { ourDbt.Add(St); }
                    if (UnsafeCompare(St.CtRRef, item.Id)) { ourCrt.Add(St); }
                }
            }
        }        

        /// <summary>
        /// Сравнение 2х массивов
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <returns></returns>
        private static unsafe bool UnsafeCompare(byte[] a1, byte[] a2)
          {
             if (a1 == null || a2 == null || a1.Length != a2.Length)
                return false;
             fixed (byte* p1 = a1, p2 = a2)
             {
                byte* x1 = p1, x2 = p2;
                int l = a1.Length;
                for (int i = 0; i < l / 8; i++, x1 += 8, x2 += 8)
                   if (*((long*) x1) != *((long*) x2))
                      return false;
                if ((l & 4) != 0)
                {
                   if (*((int*) x1) != *((int*) x2)) return false;
                   x1 += 4;
                   x2 += 4;
                }
                if ((l & 2) != 0)
                {
                   if (*((short*) x1) != *((short*) x2)) return false;
                   x1 += 2;
                   x2 += 2;
                }
                if ((l & 1) != 0)
                   if (*((byte*) x1) != *((byte*) x2))
                      return false;
                return true;
             }
          }

        /// <summary>
        /// Рассчет суммы даты начала периоды
        /// </summary>
        /// <param name="_ourDbtSt"></param>
        /// <param name="_ourCrtSt"></param>
        /// <returns></returns>
        private static decimal CalculateStart(List<TranzEnt> _ourDbtSt, List<TranzEnt> _ourCrtSt) 
         {
#if DEBUG
             var start = _ourDbtSt.Select(_ => _.Money).Sum();
             var end = _ourCrtSt.Select(_ => _.Money).Sum();
             foreach (var item in _ourCrtSt)
             {
                 Debug.Print("Value: " + item.Money);
             }

             var total = start - end;
#endif
             return Math.Round(_ourDbtSt.Select(_ => _.Money).Sum() - _ourCrtSt.Select(_ => _.Money).Sum(), 2);
         }

        /// <summary>
        /// Рассчет суммы даты конца периода
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="_ourDbtEnd"></param>
        /// <param name="_ourCrtEnd"></param>
        /// <returns></returns>
        private static decimal CalculateEnd(decimal startValue, List<TranzEnt> _ourDbtEnd, List<TranzEnt> _ourCrtEnd)
        {
#if DEBUG
            var start = _ourDbtEnd.Select(_ => _.Money).Sum();
            var end = _ourCrtEnd.Select(_ => _.Money).Sum();

            var total = start - end;
            var superTotal = startValue + total;
#endif
            return startValue + Math.Round(_ourDbtEnd.Select(_ => _.Money).Sum() - _ourCrtEnd.Select(_ => _.Money).Sum(), 2);
        }
        #endregion
    }

    
}
