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
                    (int)ScoresForBusinessResults.MoneyInTheBankAccounts1,
                    (int)ScoresForBusinessResults.MoneyInTheBankAccounts2);
                model.MoneyInTheBankAccountsStart = _outStart;
                model.MoneyInTheBankAccountsEnd = _outEnd;

                #endregion

                #region Депозиты

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.Deposits);
                model.DepositsStart = _outStart;
                model.DepositsEnd = _outEnd;

                #endregion

                #region Дебиторская задолженность

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.DebtsOfCustomersAndOverpayments);
                model.DebtsOfCustomersAndOverpaymentsStart = _outStart;
                model.DebtsOfCustomersAndOverpaymentsEnd = _outEnd;

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
                    (int)ScoresForBusinessResults.TaxOverpaymentsAndAdvances);
                model.TaxOverpaymentsAndAdvancesStart = _outStart;
                model.TaxOverpaymentsAndAdvancesEnd = _outEnd;

                #endregion

                #region Краткосрочные активы

                model.CalculateCirculatingAssets();

                #endregion

                #endregion

                #region Долгосрочные активы

                #region Долгосрочная дебиторская задолженность контрагентов

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.CustomerDebts);
                model.CustomerDebtsStart = _outStart;
                model.CustomerDebtsEnd = _outEnd;

                #endregion

                #region Прочая долгосрочная дебиторская задолженность контрагентов

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.OtherDebtsOfClientsAndOverpayment1,
                    (int)ScoresForBusinessResults.OtherDebtsOfClientsAndOverpayment2,
                    (int)ScoresForBusinessResults.OtherDebtsOfClientsAndOverpayment3,
                    (int)ScoresForBusinessResults.OtherDebtsOfClientsAndOverpayment4,
                    (int)ScoresForBusinessResults.OtherDebtsOfClientsAndOverpayment5,
                    (int)ScoresForBusinessResults.OtherDebtsOfClientsAndOverpayment6,
                    (int)ScoresForBusinessResults.OtherDebtsOfClientsAndOverpayment7,
                    (int)ScoresForBusinessResults.OtherDebtsOfClientsAndOverpayment8,
                    (int)ScoresForBusinessResults.OtherDebtsOfClientsAndOverpayment9,
                    (int)ScoresForBusinessResults.OtherDebtsOfClientsAndOverpayment10,
                    (int)ScoresForBusinessResults.OtherDebtsOfClientsAndOverpayment11,
                    (int)ScoresForBusinessResults.OtherDebtsOfClientsAndOverpayment12);
                model.OtherDebtsOfClientsAndOverpaymentStart = _outStart;
                model.OtherDebtsOfClientsAndOverpaymentEnd = _outEnd;

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
                    (int)ScoresForBusinessResults.TheDeferredTaxOverpaymentsAndAdvances);
                model.TheDeferredTaxOverpaymentsAndAdvancesStart = _outStart;
                model.TheDeferredTaxOverpaymentsAndAdvancesEnd = _outEnd;

                #endregion

                #region Долгосрочные активы

                model.CalculateLongTermAssets();

                #endregion

                #endregion

                #region Краткосрочные долги

                #region Краткосрочные банковские займы

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.CreditsForOneYear1,
                    (int)ScoresForBusinessResults.CreditsForOneYear2);
                model.CreditsForOneYearStart = _outStart;
                model.CreditsForOneYearEnd = _outEnd;

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
                    (int)ScoresForBusinessResults.PayablesToSuppliersShortTermDebts);
                model.PayablesToSuppliersShortTermDebtsStart = _outStart;
                model.PayablesToSuppliersShortTermDebtsEnd = _outEnd;

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

                model.CalculateCurrentDebt();

                #endregion

                #endregion

                #region Долгосрочные долги

                #region Долгосрочные банковские займы

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.CreditsForLongerThanOneYear1,
                    (int)ScoresForBusinessResults.CreditsForLongerThanOneYear2);
                model.CreditsForLongerThanOneYearStart = _outStart;
                model.CreditsForLongerThanOneYearEnd = _outEnd;

                #endregion

                #region Задолженность перед контрагентами

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.PayablesToSuppliersLongTermDebts);
                model.PayablesToSuppliersLongTermDebtsStart = _outStart;
                model.PayablesToSuppliersLongTermDebtsEnd = _outEnd;

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

                model.CalculateAccumulatedProfitAndLoss();
                //Calculate(out _outStart, out _outEnd,
                //    (int)ScoresForBusinessResults.AccumulatedProfitAndLoss);
                //model.AccumulatedProfitAndLossStart = _outStart;
                //model.AccumulatedProfitAndLossEnd = _outEnd;

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
                model.TotalIncome = new List<decimal>();
                model.TotalCostPrice = new List<decimal>();
                model.GrossProfit = new List<decimal>();
                model.OtherIncome = new List<decimal>();
                model.Costs = new List<decimal>();
                model.CostsSalesServices = new List<decimal>();
                model.AdministrativeExpenses = new List<decimal>();
                model.FinancingCosts = new List<decimal>();
                model.OtherCosts = new List<decimal>();
                model.OperatingProfit = new List<decimal>();
                model.Depreciation = new List<decimal>();
                model.ProfitBeforeTaxation = new List<decimal>();
                model.OtherTaxes = new List<decimal>();
                model.KPN20 = new List<decimal>();
                model.TotalProfit = new List<decimal>();
                #endregion


                int monthCounter = 0; // счетчик пройденых месяцев
                for (int scoreNum = 0; scoreNum < (int)ProfitAndLossNumServer.Total; scoreNum++)
                {
                    endMonthYear = new int[] { mainModel.EndDate.Month, mainModel.EndDate.Year + mainModel.TimeSpan };
                    startMonthYear = new int[] { mainModel.StartDate.Month, mainModel.StartDate.Year + mainModel.TimeSpan };

                    switch (scoreNum)
                    {
                        #region Вытаскиваем наши счета
                        case (int)ProfitAndLossNumServer.Income:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.Income0,
                                                                 (int)ScoresReportProfitAndLoss.Income1,
                                                                 (int)ScoresReportProfitAndLoss.Income2
                                                               }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.CostPrice:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.CostPrice}, scores);
                            break;
                        case (int)ProfitAndLossNumServer.OtherIncome:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.OtherIncome0,
                                                                 (int)ScoresReportProfitAndLoss.OtherIncome1,
                                                                 (int)ScoresReportProfitAndLoss.OtherIncome2,
                                                                 (int)ScoresReportProfitAndLoss.OtherIncome3,
                                                               }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.CostsSalesServices:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.CostsSalesServices}, scores);
                            break;
                        case (int)ProfitAndLossNumServer.AdministrativeExpenses:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.AdministrativeExpenses }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.FinancingCosts:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.FinancingCosts }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.OtherCosts:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.OtherCosts0,
                                                                 (int)ScoresReportProfitAndLoss.OtherCosts1,
                                                                 (int)ScoresReportProfitAndLoss.OtherCosts2,
                                                                 (int)ScoresReportProfitAndLoss.OtherCosts3,
                                                                 (int)ScoresReportProfitAndLoss.OtherCosts4,
                                                                 (int)ScoresReportProfitAndLoss.OtherCosts5,
                                                                 (int)ScoresReportProfitAndLoss.OtherCosts6,
                                                               }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.Depreciation:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.Depreciation }, scores);
                            break;
                        case (int)ProfitAndLossNumServer.OtherTaxes:
                            ourScr = GetOurScore(new List<int> { (int)ScoresReportProfitAndLoss.OtherTaxes }, scores);
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
                            case (int)ProfitAndLossNumServer.Income:
                                model.TotalIncome.Add(Math.Round(ourCrt.Select(_ => _.Money).Sum() * 112 / 100, 2)); // + 12 процентов
                                break;
                            case (int)ProfitAndLossNumServer.CostPrice:
                                model.TotalCostPrice.Add(Math.Round(ourCrt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.OtherIncome:
                                model.OtherIncome.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.CostsSalesServices:
                                model.CostsSalesServices.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.AdministrativeExpenses:
                                model.AdministrativeExpenses.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.FinancingCosts:
                                model.FinancingCosts.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.OtherCosts:
                                model.OtherCosts.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.Depreciation:
                                model.Depreciation.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.OtherTaxes:
                                model.OtherTaxes.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.KPN20:
                                model.KPN20.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum() * 20 / 100, 2)); // берем только 20 процентов
                                break;
                            #endregion
                        }                        
                    }
                    while ((startMonthYear[1] <= endMonthYear[1] && startMonthYear[1] != endMonthYear[1]) || (startMonthYear[0] <= endMonthYear[0] && startMonthYear[1] == endMonthYear[1]));
                }

                // Заполним расчитываемые поля
                for(int i = 0; i < monthCounter; i++)
                {
                    model.GrossProfit.Add(model.TotalIncome[i] + model.TotalCostPrice[i]);
                    model.Costs.Add(model.AdministrativeExpenses[i] + model.CostsSalesServices[i] + model.FinancingCosts[i] + model.OtherTaxes[i]);
                    model.OperatingProfit.Add(model.GrossProfit[i] + model.OtherIncome[i] - model.Costs[i]);
                    model.ProfitBeforeTaxation.Add(model.OperatingProfit[i] - model.Depreciation[i]);                    
                    model.TotalProfit.Add(model.ProfitBeforeTaxation[i] - model.OtherTaxes[i] - model.KPN20[i]);                    
                }

                #region Расчитаем среднюю и общую сумму по каждой строке
                model.TotalIncome.Add(Math.Round(model.TotalIncome.Take(monthCounter).Sum(), 2));// общее
                model.TotalIncome.Add(Math.Round(model.TotalIncome.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                
                model.TotalCostPrice.Add(Math.Round(model.TotalCostPrice.Take(monthCounter).Sum(), 2));// общее
                model.TotalCostPrice.Add(Math.Round(model.TotalCostPrice.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                
                model.GrossProfit.Add(Math.Round(model.GrossProfit.Take(monthCounter).Sum(), 2));// общее
                model.GrossProfit.Add(Math.Round(model.GrossProfit.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                
                model.OtherIncome.Add(Math.Round(model.OtherIncome.Take(monthCounter).Sum(), 2));// общее
                model.OtherIncome.Add(Math.Round(model.OtherIncome.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.CostsSalesServices.Add(Math.Round(model.CostsSalesServices.Take(monthCounter).Sum(), 2));// общее
                model.CostsSalesServices.Add(Math.Round(model.CostsSalesServices.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.Costs.Add(Math.Round(model.Costs.Take(monthCounter).Sum(), 2));// общее
                model.Costs.Add(Math.Round(model.Costs.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                
                model.Depreciation.Add(Math.Round(model.Depreciation.Take(monthCounter).Sum(), 2));// общее
                model.Depreciation.Add(Math.Round(model.Depreciation.Take(monthCounter).Sum() / monthCounter, 2));// среднее

                model.KPN20.Add(Math.Round(model.KPN20.Take(monthCounter).Sum(), 2));// общее
                model.KPN20.Add(Math.Round(model.KPN20.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                
                model.ProfitBeforeTaxation.Add(Math.Round(model.ProfitBeforeTaxation.Take(monthCounter).Sum(), 2));// общее
                model.ProfitBeforeTaxation.Add(Math.Round(model.ProfitBeforeTaxation.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                
                model.AdministrativeExpenses.Add(Math.Round(model.AdministrativeExpenses.Take(monthCounter).Sum(), 2));// общее
                model.AdministrativeExpenses.Add(Math.Round(model.AdministrativeExpenses.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                
                model.FinancingCosts.Add(Math.Round(model.FinancingCosts.Take(monthCounter).Sum(), 2));// общее
                model.FinancingCosts.Add(Math.Round(model.FinancingCosts.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                
                model.OtherCosts.Add(Math.Round(model.OtherCosts.Take(monthCounter).Sum(), 2));// общее
                model.OtherCosts.Add(Math.Round(model.OtherCosts.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                
                model.OtherTaxes.Add(Math.Round(model.OtherTaxes.Take(monthCounter).Sum(), 2));// общее
                model.OtherTaxes.Add(Math.Round(model.OtherTaxes.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                
                model.OperatingProfit.Add(Math.Round(model.OperatingProfit.Take(monthCounter).Sum(), 2));// общее
                model.OperatingProfit.Add(Math.Round(model.OperatingProfit.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                
                model.TotalProfit.Add(Math.Round(model.TotalProfit.Take(monthCounter).Sum(), 2));// общее
                model.TotalProfit.Add(Math.Round(model.TotalProfit.Take(monthCounter).Sum() / monthCounter, 2));// среднее                
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
                    if (ms.ToString().Equals(sc.Code))
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
