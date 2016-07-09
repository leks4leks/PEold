using ProgressoExpert.Common.Enums;
using ProgressoExpert.Models.Entities;
using ProgressoExpert.Models.Models;
using ProgressoExpert.Models.Models.BusinessAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProgressoExpert.DataAccess
{
    public class Accessors
    {
        private const int minusOne = -1;
        private static List<TranzEnt> Start = null;
        private static List<TranzEnt> End = null;

        private static List<TranzEnt> StartOriginal = null;
        private static List<TranzEnt> EndOriginal = null;

        private static List<int> ourScr = null;

        private static List<TranzEnt> ourDbtSt; // Это уже транзакции связанные с нашим счетом на начало
        private static List<TranzEnt> ourDbtEnd; // Это уже транзакции связанные с нашим счетом на конец (мы не будем считать на конец периода заного, почтитаем между датами, и сложем)
        private static List<TranzEnt> ourCrtSt;
        private static List<TranzEnt> ourCrtEnd;
        
        public static BusinessResults GetBusinessResults(MainModel mainModel, bool isForMonth = false)
        {
            BusinessResults model = new BusinessResults();
            model.StartDate = mainModel.StartDate;
            model.EndDate = mainModel.EndDate;

            using (dbEntities db = new dbEntities())
            {
                Start = mainModel.StartTranz;
                End = mainModel.EndTranz;
                StartOriginal = mainModel.StartTranzOriginal;
                EndOriginal = mainModel.EndTranzOriginal;

                if (isForMonth)
                {
                    Start.AddRange(mainModel.EndTranz.Where(_ => _.period < mainModel.StartDate).ToList());
                    End = mainModel.EndTranz.Where(_ => _.period >= mainModel.StartDate && _.period < mainModel.EndDate).ToList();

                    StartOriginal.AddRange(mainModel.EndTranzOriginal.Where(_ => _.period < mainModel.StartDate).ToList());
                    EndOriginal = mainModel.EndTranzOriginal.Where(_ => _.period >= mainModel.StartDate && _.period < mainModel.EndDate).ToList();
                }

                ourScr = new List<int>(); // Вытащим ID интересующих нас счетов нас счетов

                decimal _outStart = 0;
                decimal _outEnd = 0;

                #region Оборотные активы

                #region Денежные средства в кассе

                CalculateOriginal(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.CashInCashBox1,
                    (int)ScoresForBusinessResults.CashInCashBox2);
                model.CashInCashBoxStart = _outStart;
                model.CashInCashBoxEnd = _outEnd;

                #endregion

                #region Денежные средства на рассчетном счете

                CalculateOriginal(out _outStart, out _outEnd,
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

                #region Долги клиентов и переплаты

                CalculateOriginal(out _outStart, out _outEnd,
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

                #region Прочие оборотные активы

                CalculateOriginal(out _outStart, out _outEnd,
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

                #region Налоговые переплаты / авансы

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.TaxOverpaymentsAndAdvances);
                model.TaxOverpaymentsAndAdvancesStart = _outStart;
                model.TaxOverpaymentsAndAdvancesEnd = _outEnd;

                #endregion

            #endregion
                #region Долгосрочные активы

                    #region Долгосрочная дебиторская задолженность контрагентов

                    Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.CustomerDebts);
                model.CustomerDebtsStart = _outStart;
                model.CustomerDebtsEnd = _outEnd;

                #endregion

                #region Прочие долги клиентов/переплаты

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

                #region Отложенные налоговые переплаты/авансы

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.TheDeferredTaxOverpaymentsAndAdvances);
                model.TheDeferredTaxOverpaymentsAndAdvancesStart = _outStart;
                model.TheDeferredTaxOverpaymentsAndAdvancesEnd = _outEnd;

                #endregion

                #endregion

                #region Текущая задолженность

                #region Кредиты сроком до одного года

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.CreditsForOneYear1,
                    (int)ScoresForBusinessResults.CreditsForOneYear2);
                model.CreditsForOneYearStart = _outStart * minusOne;
                model.CreditsForOneYearEnd = _outEnd * minusOne;

                #endregion

                #region Задолженность по КПН/ИПН

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.DebtCitIit);
                model.DebtCitIitStart = _outStart * minusOne;
                model.DebtCitIitEnd = _outEnd * minusOne;

                #endregion

                #region Задолженность по НДС

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.DebtVat);
                model.DebtVatStart = _outStart * minusOne;
                model.DebtVatEnd = _outEnd * minusOne;

                #endregion

                #region Прочая задолженность по налогам

                CalculateOriginal(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.OtherTaxesPayable1,
                    (int)ScoresForBusinessResults.OtherTaxesPayable2,
                    (int)ScoresForBusinessResults.OtherTaxesPayable3,
                    (int)ScoresForBusinessResults.OtherTaxesPayable4,
                    (int)ScoresForBusinessResults.OtherTaxesPayable5,
                    (int)ScoresForBusinessResults.OtherTaxesPayable6,
                    (int)ScoresForBusinessResults.OtherTaxesPayable7);
                model.OtherTaxesPayableStart = _outStart * minusOne;
                model.OtherTaxesPayableEnd = _outEnd * minusOne;

                #endregion

                #region Задолжность перед поставщиками

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.PayablesToSuppliersShortTermDebts);
                model.PayablesToSuppliersShortTermDebtsStart = _outStart * minusOne;
                model.PayablesToSuppliersShortTermDebtsEnd = _outEnd * minusOne;

                #endregion

                #region Задолженность перед сотрудниками

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.PayablesToEmployees);
                model.PayablesToEmployeesStart = _outStart * minusOne;
                model.PayablesToEmployeesEnd = _outEnd * minusOne;

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
                model.OtherDebtsShortTermDebtsStart = _outStart * minusOne;
                model.OtherDebtsShortTermDebtsEnd = _outEnd * minusOne;

                #endregion

                #endregion

                #region Долгосрочные долги

                #region Долгосрочные банковские займы

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.CreditsForLongerThanOneYear1,
                    (int)ScoresForBusinessResults.CreditsForLongerThanOneYear2);
                model.CreditsForLongerThanOneYearStart = _outStart * minusOne;
                model.CreditsForLongerThanOneYearEnd = _outEnd * minusOne;

                #endregion

                #region Задолженность перед контрагентами

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.PayablesToSuppliersLongTermDebts);
                model.PayablesToSuppliersLongTermDebtsStart = _outStart * minusOne;
                model.PayablesToSuppliersLongTermDebtsEnd = _outEnd * minusOne;

                #endregion

                #region Отложеннные налоговая задолженность

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.DefferedTaxDebts);
                model.DefferedTaxDebtsStart = _outStart * minusOne;
                model.DefferedTaxDebtsEnd = _outEnd * minusOne;

                #endregion

                #region Прочая задолженность

                Calculate(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.OtherDebtsLongTermDebts1,
                    (int)ScoresForBusinessResults.OtherDebtsLongTermDebts2,
                    (int)ScoresForBusinessResults.OtherDebtsLongTermDebts3,
                    (int)ScoresForBusinessResults.OtherDebtsLongTermDebts4);
                model.OtherDebtsLongTermDebtsStart = _outStart * minusOne;
                model.OtherDebtsLongTermDebtsEnd = _outEnd * minusOne;

                #endregion

                #endregion

                #region Собственный капитал

                #region Уставной капитал

                CalculateOriginal(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.AuthorizedCapital1,
                    (int)ScoresForBusinessResults.AuthorizedCapital2);
                model.AuthorizedCapitalStart = _outStart * minusOne;
                model.AuthorizedCapitalEnd = _outEnd * minusOne;

                #endregion

                #region Прочий капитал

                CalculateOriginal(out _outStart, out _outEnd,
                    (int)ScoresForBusinessResults.OtherCapital);
                model.OtherCapitalStart = _outStart * minusOne;
                model.OtherCapitalEnd = _outEnd * minusOne;

                #endregion

                #endregion

                #region Итого

                // Сначала считаем пассивые, потом активы

                #region Текущая задолженность

                model.CalculateCurrentDebt();

                #endregion

                #region Долгосрочная задолженность

                model.CalculateLongTermDebt();

                #endregion

                #region Собственный капитал

                model.CalculateOwnCapital();

                #endregion

                #region Оборотные активы

                model.CalculateCirculatingAssets();

                #endregion

                #region Долгосрочные активы

                model.CalculateLongTermAssets();

                #endregion

                #region Итого активов

                model.CalculateTotalAssets();

                #endregion

                #region Итого пассивов

                model.CalculateTotalLiabilities();

                #endregion

                #region Накопленная прибыль/убыток

                model.CalculateAccumulatedProfitAndLoss();
                    //Calculate(out _outStart, out _outEnd,
                    //    (int)ScoresForBusinessResults.AccumulatedProfitAndLoss);
                    //model.AccumulatedProfitAndLossStart = _outStart;
                    //model.AccumulatedProfitAndLossEnd = _outEnd;

                #endregion


                #endregion
                //model.StartDate = mainModel.StartDate.AddYears(mainModel.TimeSpan * -1);
                //model.EndDate = mainModel.EndDate.AddYears(mainModel.TimeSpan * -1);
                return model;
            }
        }

        public static ReportProfitAndLoss GetReportProfitAndLoss(MainModel mainModel)
        {
            ReportProfitAndLoss model = new ReportProfitAndLoss();
            using (dbEntities db = new dbEntities())
            {
                //var scores = mainModel.Scores;
                List<int> ourScr = new List<int>();
                List<TranzEnt> ourDbt = new List<TranzEnt>();
                List<TranzEnt> ourCrt = new List<TranzEnt>();

                int[] endMonthYear = new int[] { mainModel.EndDate.Month, mainModel.EndDate.Year };
                int[] startMonthYear = new int[] { mainModel.StartDate.Month, mainModel.StartDate.Year };//будем бежать от начала до конца периода

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
                    endMonthYear = new int[] { mainModel.EndDate.Month, mainModel.EndDate.Year };
                    startMonthYear = new int[] { mainModel.StartDate.Month, mainModel.StartDate.Year };

                    switch (scoreNum)
                    {
                        #region Вытаскиваем наши счета
                        case (int)ProfitAndLossNumServer.Income:
                            ourScr = new List<int> { (int)ScoresReportProfitAndLoss.Income0,
                                                     (int)ScoresReportProfitAndLoss.Income1,
                                                     (int)ScoresReportProfitAndLoss.Income2
                                                   };
                            break;
                        case (int)ProfitAndLossNumServer.CostPrice:
                            ourScr = new List<int> { (int)ScoresReportProfitAndLoss.CostPrice };
                            break;
                        case (int)ProfitAndLossNumServer.OtherIncome:
                            ourScr = new List<int> { (int)ScoresReportProfitAndLoss.OtherIncome0,
                                                     (int)ScoresReportProfitAndLoss.OtherIncome1,
                                                     (int)ScoresReportProfitAndLoss.OtherIncome2,
                                                     (int)ScoresReportProfitAndLoss.OtherIncome3,
                                                   };
                            break;
                        case (int)ProfitAndLossNumServer.CostsSalesServices:
                            ourScr = new List<int> { (int)ScoresReportProfitAndLoss.CostsSalesServices };
                            break;
                        case (int)ProfitAndLossNumServer.AdministrativeExpenses:
                            ourScr = new List<int> { (int)ScoresReportProfitAndLoss.AdministrativeExpenses };
                            break;
                        case (int)ProfitAndLossNumServer.FinancingCosts:
                            ourScr = new List<int> { (int)ScoresReportProfitAndLoss.FinancingCosts };
                            break;
                        case (int)ProfitAndLossNumServer.OtherCosts:
                            ourScr = new List<int> { (int)ScoresReportProfitAndLoss.OtherCosts0,
                                                     (int)ScoresReportProfitAndLoss.OtherCosts1,
                                                     (int)ScoresReportProfitAndLoss.OtherCosts2,
                                                     (int)ScoresReportProfitAndLoss.OtherCosts3,
                                                     (int)ScoresReportProfitAndLoss.OtherCosts4,
                                                     (int)ScoresReportProfitAndLoss.OtherCosts5,
                                                     (int)ScoresReportProfitAndLoss.OtherCosts6,
                                                   };
                            break;
                        case (int)ProfitAndLossNumServer.Depreciation:
                            ourScr = new List<int> { (int)ScoresReportProfitAndLoss.Depreciation };
                            break;
                        case (int)ProfitAndLossNumServer.OtherTaxes:
                            ourScr = new List<int> { (int)ScoresReportProfitAndLoss.OtherTaxes };
                            break;
                        case (int)ProfitAndLossNumServer.KPN20:
                            ourScr = new List<int> { (int)ScoresReportProfitAndLoss.KPN20 };
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
                                model.TotalIncome.Add(ourCrt.Select(_ => _.Money).Sum() * 112 / 100); // + 12 процентов
                                break;
                            case (int)ProfitAndLossNumServer.CostPrice:
                                model.TotalCostPrice.Add(ourCrt.Select(_ => _.Money).Sum());
                                break;
                            case (int)ProfitAndLossNumServer.OtherIncome:
                                model.OtherIncome.Add(ourDbt.Select(_ => _.Money).Sum());
                                break;
                            case (int)ProfitAndLossNumServer.CostsSalesServices:
                                model.CostsSalesServices.Add(ourDbt.Select(_ => _.Money).Sum());
                                break;
                            case (int)ProfitAndLossNumServer.AdministrativeExpenses:
                                model.AdministrativeExpenses.Add(ourDbt.Select(_ => _.Money).Sum());
                                break;
                            case (int)ProfitAndLossNumServer.FinancingCosts:
                                model.FinancingCosts.Add(ourDbt.Select(_ => _.Money).Sum());
                                break;
                            case (int)ProfitAndLossNumServer.OtherCosts:
                                model.OtherCosts.Add(ourDbt.Select(_ => _.Money).Sum());
                                break;
                            case (int)ProfitAndLossNumServer.Depreciation:
                                model.Depreciation.Add(ourDbt.Select(_ => _.Money).Sum());
                                break;
                            case (int)ProfitAndLossNumServer.OtherTaxes:
                                model.OtherTaxes.Add(ourDbt.Select(_ => _.Money).Sum());
                                break;
                            case (int)ProfitAndLossNumServer.KPN20:
                                model.KPN20.Add(ourDbt.Select(_ => _.Money).Sum() * 20 / 100); // берем только 20 процентов
                                break;
                                #endregion
                        }
                    }
                    while ((startMonthYear[1] <= endMonthYear[1] && startMonthYear[1] != endMonthYear[1]) || (startMonthYear[0] <= endMonthYear[0] && startMonthYear[1] == endMonthYear[1]));
                }

                // Заполним расчитываемые поля
                for (int i = 0; i < monthCounter; i++)
                {
                    model.GrossProfit.Add(model.TotalIncome[i] + model.TotalCostPrice[i]);
                    model.Costs.Add(model.AdministrativeExpenses[i] + model.CostsSalesServices[i] + model.FinancingCosts[i] + model.OtherTaxes[i]);
                    model.OperatingProfit.Add(model.GrossProfit[i] + model.OtherIncome[i] - model.Costs[i]);
                    model.ProfitBeforeTaxation.Add(model.OperatingProfit[i] - model.Depreciation[i]);
                    model.TotalProfit.Add(model.ProfitBeforeTaxation[i] - model.OtherTaxes[i] - model.KPN20[i]);
                }

                #region Расчитаем среднюю и общую сумму по каждой строке
                model.TotalIncome.Add(model.TotalIncome.Take(monthCounter).Sum());// общее
                model.TotalIncome.Add(model.TotalIncome.Take(monthCounter).Sum() / monthCounter);// среднее

                model.TotalCostPrice.Add(model.TotalCostPrice.Take(monthCounter).Sum());// общее
                model.TotalCostPrice.Add(model.TotalCostPrice.Take(monthCounter).Sum() / monthCounter);// среднее

                model.GrossProfit.Add(model.GrossProfit.Take(monthCounter).Sum());// общее
                model.GrossProfit.Add(model.GrossProfit.Take(monthCounter).Sum() / monthCounter);// среднее

                model.OtherIncome.Add(model.OtherIncome.Take(monthCounter).Sum());// общее
                model.OtherIncome.Add(model.OtherIncome.Take(monthCounter).Sum() / monthCounter);// среднее

                model.CostsSalesServices.Add(model.CostsSalesServices.Take(monthCounter).Sum());// общее
                model.CostsSalesServices.Add(model.CostsSalesServices.Take(monthCounter).Sum() / monthCounter);// среднее

                model.Costs.Add(model.Costs.Take(monthCounter).Sum());// общее
                model.Costs.Add(model.Costs.Take(monthCounter).Sum() / monthCounter);// среднее

                model.Depreciation.Add(model.Depreciation.Take(monthCounter).Sum());// общее
                model.Depreciation.Add(model.Depreciation.Take(monthCounter).Sum() / monthCounter);// среднее

                model.KPN20.Add(model.KPN20.Take(monthCounter).Sum());// общее
                model.KPN20.Add(model.KPN20.Take(monthCounter).Sum() / monthCounter);// среднее

                model.ProfitBeforeTaxation.Add(model.ProfitBeforeTaxation.Take(monthCounter).Sum());// общее
                model.ProfitBeforeTaxation.Add(model.ProfitBeforeTaxation.Take(monthCounter).Sum() / monthCounter);// среднее

                model.AdministrativeExpenses.Add(model.AdministrativeExpenses.Take(monthCounter).Sum());// общее
                model.AdministrativeExpenses.Add(model.AdministrativeExpenses.Take(monthCounter).Sum() / monthCounter);// среднее

                model.FinancingCosts.Add(model.FinancingCosts.Take(monthCounter).Sum());// общее
                model.FinancingCosts.Add(model.FinancingCosts.Take(monthCounter).Sum() / monthCounter);// среднее

                model.OtherCosts.Add(model.OtherCosts.Take(monthCounter).Sum());// общее
                model.OtherCosts.Add(model.OtherCosts.Take(monthCounter).Sum() / monthCounter);// среднее

                model.OtherTaxes.Add(model.OtherTaxes.Take(monthCounter).Sum());// общее
                model.OtherTaxes.Add(model.OtherTaxes.Take(monthCounter).Sum() / monthCounter);// среднее

                model.OperatingProfit.Add(model.OperatingProfit.Take(monthCounter).Sum());// общее
                model.OperatingProfit.Add(model.OperatingProfit.Take(monthCounter).Sum() / monthCounter);// среднее

                model.TotalProfit.Add(model.TotalProfit.Take(monthCounter).Sum());// общее
                model.TotalProfit.Add(model.TotalProfit.Take(monthCounter).Sum() / monthCounter);// среднее                
                #endregion

                model.Calculate();

                return model;
            }
        }

        public static List<GroupsEnt> GetAllAddsTranz(DateTime stDate, DateTime endDate, List<RefGroupsEnt> group, List<string> GroupsCode)
        {
            using (dbEntities db = new dbEntities())
            {
                List<GroupsEnt> res = new List<GroupsEnt>();
                List<string> codeGroups = new List<string>();
                ContinGetAddzTr(stDate, endDate, GroupsCode, db, out res, out codeGroups);
                return res;
            }
        }

        public static List<GroupsEnt> GetAddsTranz(DateTime stDate, DateTime endDate, List<RefGroupsEnt> group, List<string> GroupsCode)
        {
            using (dbEntities db = new dbEntities())
            {
                List<GroupsEnt> res = new List<GroupsEnt>();
                List<string> codeGroups = new List<string>();
                ContinGetAddzTr(stDate, endDate, GroupsCode, db, out res, out codeGroups);

                List<GroupsEnt> realres = new List<GroupsEnt>();
                decimal money;
                string desc = string.Empty;
                string descNum = string.Empty;
                decimal e3 = 0;
                decimal e5 = 0;
                foreach(var code in codeGroups)
                {
                    money = res.Where(_ => _.GroupCode != null && _.GroupCode.Contains(code)).Sum(_ => Math.Abs(_.Money));
                    if (res.Any(_ => _.GroupCode.Contains(code)))
                    {
                        descNum = res.FirstOrDefault(_ => _.GroupCode != null && _.GroupCode.Contains(code)).GroupCode;
                        desc = group.FirstOrDefault(_ => _.Name != null && _.Code == code).Name;
                        e3 = res.FirstOrDefault(_ => _.GroupCode != null && _.GroupCode.Contains(code)).en302;
                        e5 = res.FirstOrDefault(_ => _.GroupCode != null && _.GroupCode.Contains(code)).en450;
                    }
                    if (money != 0)
                    {
                        realres.Add(new GroupsEnt()
                        {
                            Money = money,
                            GroupCode = descNum,
                            GroupName = desc,
                            en302 = e3,
                            en450 = e5
                        });
                    }
                }
                return realres;

            }
        }

        private static void ContinGetAddzTr(DateTime stDate, DateTime endDate, List<string> GroupsCode, dbEntities db, out List<GroupsEnt> res, out List<string> codeGroups)
        {
            if (GroupsCode.Count() > 0)
            {
                res = (from accEd in db.C_AccumRg9987
                       join refs in db.C_Reference113 on accEd.C_Fld9991RRef equals refs.C_IDRRef
                       join en302 in db.C_Enum302 on refs.C_Fld1334RRef equals en302.C_IDRRef
                       join en450 in db.C_Enum450 on refs.C_Fld1333RRef equals en450.C_IDRRef
                       join men in db.C_Reference67 on accEd.C_Fld9993_RRRef equals men.C_IDRRef
                       where accEd.C_Period >= stDate && accEd.C_Period < endDate && GroupsCode.Contains(refs.C_Code)
                       select new GroupsEnt
                       {
                           Money = accEd.C_Fld10000,
                           period = accEd.C_Period,
                           GroupCode = refs.C_Code,
                           en302 = en302.C_EnumOrder,
                           en450 = en450.C_EnumOrder,
                           MenCode = men.C_Code,
                           MenName = men.C_Description

                       }).ToList();

                codeGroups = (from gg in db.C_Reference113
                              where GroupsCode.Contains(gg.C_Code)
                              select gg.C_Code).OrderBy(_ => _).ToList();
            }
            else
            {
                res = (from accEd in db.C_AccumRg9987
                       join refs in db.C_Reference113 on accEd.C_Fld9991RRef equals refs.C_IDRRef
                       join en302 in db.C_Enum302 on refs.C_Fld1334RRef equals en302.C_IDRRef
                       join en450 in db.C_Enum450 on refs.C_Fld1333RRef equals en450.C_IDRRef
                       join men in db.C_Reference67 on accEd.C_Fld9993_RRRef equals men.C_IDRRef
                       where accEd.C_Period >= stDate && accEd.C_Period < endDate
                       select new GroupsEnt
                       {
                           Money = accEd.C_Fld10000,
                           period = accEd.C_Period,
                           GroupCode = refs.C_Code,
                           en302 = en302.C_EnumOrder,
                           en450 = en450.C_EnumOrder,
                           MenCode = men.C_Code,
                           MenName = men.C_Description
                       }).ToList();

                codeGroups = (from gg in db.C_Reference113
                              select gg.C_Code).OrderBy(_ => _).ToList();
            }
        }

        public static List<SalesModel> GetSales(DateTime stDate, DateTime endDate, bool isLoadBeginOfTheTime = false)
        {
            using (dbEntities db = new dbEntities())
            {
                List<SalesModel> result = new List<SalesModel>();
                int[] endMonthYear = new int[] { endDate.Month, endDate.Year };

                int monthCount = 0;
                int[] startMonthYear = new int[] { stDate.Month, stDate.Year };//будем бежать от начала до конца периода
                List<SalesEnt> qSeb = new List<SalesEnt>();
                if(!isLoadBeginOfTheTime)
                    qSeb = Accessors.QueryForGetSalesForSeb(stDate, endDate, db);
                do
                {
                    DateTime stDt = new DateTime(startMonthYear[1], startMonthYear[0], 1);
                    DateTime endDt = new DateTime();
                    #region Cчитаем кол-во месяцев
                    if (startMonthYear[0] == 12)
                    {
                        startMonthYear[1]++;
                        startMonthYear[0] = 1;
                        monthCount++;
                        endDt = new DateTime(startMonthYear[1], startMonthYear[0], 1);
                    }
                    else
                    {
                        startMonthYear[0]++;
                        monthCount++;
                        endDt = new DateTime(startMonthYear[1], startMonthYear[0], 1);
                    }
                    #endregion
                    
                    SalesModel tmp = new SalesModel();
                    tmp.Date = stDt;
                    tmp.Sales = QueryForGetSales(stDt, endDt, db, qSeb);
                    if(tmp.Sales.Count != 0)
                        result.Add(tmp);
                }
                while ((startMonthYear[1] <= endMonthYear[1] && startMonthYear[1] != endMonthYear[1]) || (startMonthYear[0] <= endMonthYear[0] && startMonthYear[1] == endMonthYear[1]));
                
                return result;
            }
        }

        public static List<SalesModel> GetSalesOneQuery(DateTime stDate, DateTime endDate)
        {
            using (dbEntities db = new dbEntities())
            {
                List<SalesModel> result = new List<SalesModel>();

                var qSeb = Accessors.QueryForGetSalesForSeb(stDate, endDate, db);
                //только инфа по группам и производителям или как их
                SalesModel tmp = new SalesModel();
                tmp.Date = stDate;
                tmp.Sales = QueryForGetSales(stDate, endDate, db, qSeb);
                if (tmp.Sales.Count != 0)
                    result.Add(tmp);

                return result;
            }
        }

        public static List<SalesEnt> getPurMan(DateTime stDate, DateTime endDate)
        {
            using (dbEntities db = new dbEntities())
            {
                List<SalesEnt> result = new List<SalesEnt>();

                var tt = (from adz in db.C_AccRgAT210888
                          group adz by adz.C_Value1_RRRef into g
                          select new SalesEnt
                          {
                              SalersRefId = g.FirstOrDefault().C_Value1_RRRef,
                              CostPrise = g.Sum(_ => _.C_TurnoverCt10882 ?? 0),
                              SalerCode = string.Empty,
                              SalerName = string.Empty
                          });

                var t1 = (from r67 in db.C_Reference67
                          select new SalesEnt
                          {
                              SalersRefId = r67.C_IDRRef,
                              CostPrise = decimal.Zero,
                              SalerCode = r67.C_Code,
                              SalerName = r67.C_Description
                          });

                result = (from t0 in tt
                          join t_1 in t1 on t0.SalersRefId equals t_1.SalersRefId
                          select new SalesEnt
                          {
                              SalersRefId = t0.SalersRefId,
                              CostPrise = t0.CostPrise,
                              SalerCode = t_1.SalerCode,
                              SalerName = t_1.SalerName
                          }).ToList();

                return result;
            }
        }

        public static List<SalesEnt> QueryForGetSalesForSeb(DateTime stDate, DateTime endDate, dbEntities db)
        {
            var result = new List<SalesEnt>();
            var res = (from r77 in db.C_Reference77
                       join r78 in db.C_Reference78 on r77.C_Fld1089RRef equals r78.C_IDRRef
                       select new SalesEnt
                       {
                           Mont = 0,
                           Year = 0,
                           refId = r77.C_IDRRef,
                           ClientRefId = new byte[] { },
                           SalersRefId = new byte[] { },
                           CostPrise = decimal.Zero,
                           CountPur = decimal.Zero,
                           SalesWithoutNDS = decimal.Zero,
                           CountSal = decimal.Zero,
                           DivName = r77.C_Description,
                           GroupCode = r78.C_Code,
                           GroupName = r78.C_Description,
                           BuyerCode = string.Empty,
                           BuyerName = string.Empty
                       }
                                        );

            //Себестоимость за период + кол-во сколько поставили(в C_AccumRgTn10122) +  сам поставщик (C_Value1_RRRef)
            var res1 = (from s888 in db.C_AccRgAT210888
                        where s888.C_Period >= stDate && s888.C_Period < endDate
                        group s888 by s888.C_Value2_RRRef into g
                        select new SalesEnt
                        {
                            Mont = 0,
                            Year = 0,
                            refId = g.FirstOrDefault().C_Value2_RRRef,
                            ClientRefId = new byte[] { },
                            SalersRefId = g.FirstOrDefault().C_Value1_RRRef,
                            CostPrise = g.Sum(_ => _.C_TurnoverCt10882 ?? 0),
                            CountPur = decimal.Zero,
                            SalesWithoutNDS = decimal.Zero,
                            CountSal = decimal.Zero,
                            DivName = string.Empty,
                            GroupCode = string.Empty,
                            GroupName = string.Empty,
                            BuyerCode = string.Empty,
                            BuyerName = string.Empty
                        });

            //Цена продажи без ндс
            var res2 = (from r27 in db.C_AccumRgTn10472
                        where r27.C_Period >= stDate && r27.C_Period < endDate
                        group r27 by r27.C_Fld10452_RRRef into g
                        select new SalesEnt
                        {
                            Mont = 0,
                            Year = 0,
                            refId = g.FirstOrDefault().C_Fld10452_RRRef,
                            ClientRefId = g.FirstOrDefault().C_Fld10459RRef,
                            SalersRefId = new byte[] { },
                            CostPrise = decimal.Zero,
                            CountPur = decimal.Zero,
                            SalesWithoutNDS = g.Sum(_ => _.C_Fld10464),
                            CountSal = g.Sum(_ => _.C_Fld10462),
                            DivName = string.Empty,
                            GroupCode = string.Empty,
                            GroupName = string.Empty,
                            BuyerCode = string.Empty,
                            BuyerName = string.Empty
                        }
                        );

            // количество сколько поступило на конечную дату
            var res3 = (from s888 in db.C_AccumRgTn10122
                        where s888.C_Period < endDate && s888.C_Period >= stDate
                        group s888 by s888.C_Fld10107_RRRef into g
                        select new SalesEnt
                        {
                            Mont = 0,
                            Year = 0,
                            refId = new byte[] { },
                            ClientRefId = new byte[] { },
                            SalersRefId = g.FirstOrDefault().C_Fld10107_RRRef,
                            CostPrise = decimal.Zero,
                            CountPur = g.Sum(_ => _.C_Fld10117),
                            SalesWithoutNDS = decimal.Zero,
                            CountSal = decimal.Zero,
                            DivName = string.Empty,
                            GroupCode = string.Empty,
                            GroupName = string.Empty,
                            BuyerCode = string.Empty,
                            BuyerName = string.Empty
                        });

            //покупатели 
            var res4 = (from s888 in db.C_Reference67
                        select new SalesEnt
                        {
                            Mont = 0,
                            Year = 0,
                            refId = new byte[] { },
                            ClientRefId = s888.C_IDRRef,
                            SalersRefId = new byte[] { },
                            CostPrise = decimal.Zero,
                            CountPur = decimal.Zero,
                            SalesWithoutNDS = decimal.Zero,
                            CountSal = decimal.Zero,
                            DivName = string.Empty,
                            GroupCode = string.Empty,
                            GroupName = string.Empty,
                            BuyerCode = s888.C_Code,
                            BuyerName = s888.C_Description
                        });

            #region посчитаем себистоимость товара за период
            /// Группируем по группа товаров в разрезе по месяцам
            /// нам этого будет достаточно, чтобы посчитать среднюю себестоимость остатка товара на указанный период
            /// т.к. минимальный период это месяц
            /// после будем циклом бежать по группам и внутри считать сколько пришло сколько ушло товара
            /// и по какой цене
            //Себестоимость считаем от начала времен +  сам поставщик (C_Value1_RRRef)
            var resCostSeb = (from s888 in db.C_AccRgAT210888
                              where s888.C_Period < endDate
                              group s888 by new { s888.C_Value2_RRRef, s888.C_Period.Month, s888.C_Period.Year } into g
                              select new SalesEnt
                              {
                                  Mont = g.FirstOrDefault().C_Period.Month,
                                  Year = g.FirstOrDefault().C_Period.Year,
                                  refId = g.FirstOrDefault().C_Value2_RRRef,
                                  ClientRefId = new byte[] { },
                                  SalersRefId = g.FirstOrDefault().C_Value1_RRRef,
                                  CostPrise = g.Sum(_ => _.C_TurnoverCt10882 ?? 0),
                                  CountPur = decimal.Zero,
                                  SalesWithoutNDS = decimal.Zero,
                                  CountSal = decimal.Zero,
                                  DivName = string.Empty,
                                  GroupCode = string.Empty,
                                  GroupName = string.Empty,
                                  BuyerCode = string.Empty,
                                  BuyerName = string.Empty
                              });

            // количество сколько поступило от начала времен
            var resCountSeb = (from s888 in db.C_AccumRgTn10122
                               where s888.C_Period < endDate
                               group s888 by new { s888.C_Fld10107_RRRef, s888.C_Period.Month, s888.C_Period.Year } into g
                               select new SalesEnt
                               {
                                   Mont = 0,
                                   Year = 0,
                                   refId = new byte[] { },
                                   ClientRefId = new byte[] { },
                                   SalersRefId = g.FirstOrDefault().C_Fld10107_RRRef,
                                   CostPrise = decimal.Zero,
                                   CountPur = g.Sum(_ => _.C_Fld10117),
                                   SalesWithoutNDS = decimal.Zero,
                                   CountSal = decimal.Zero,
                                   DivName = string.Empty,
                                   GroupCode = string.Empty,
                                   GroupName = string.Empty,
                                   BuyerCode = string.Empty,
                                   BuyerName = string.Empty
                               });

            //Цена продажи без ндс
            var resSalesSeb = (from r27 in db.C_AccumRgTn10472
                               where r27.C_Period < endDate
                               group r27 by new { r27.C_Fld10452_RRRef, r27.C_Period.Month, r27.C_Period.Year } into g
                               select new SalesEnt
                               {
                                   Mont = 0,
                                   Year = 0,
                                   refId = g.FirstOrDefault().C_Fld10452_RRRef,
                                   ClientRefId = g.FirstOrDefault().C_Fld10459RRef,
                                   SalersRefId = new byte[] { },
                                   CostPrise = decimal.Zero,
                                   CountPur = decimal.Zero,
                                   SalesWithoutNDS = decimal.Zero,
                                   CountSal = g.Sum(_ => _.C_Fld10462),
                                   DivName = string.Empty,
                                   GroupCode = string.Empty,
                                   GroupName = string.Empty,
                                   BuyerCode = string.Empty,
                                   BuyerName = string.Empty
                               }
                        );
            var resSeb =
                (from r in res
                 join r1 in resCostSeb on r.refId equals r1.refId
                 join r2 in resSalesSeb on r.refId equals r2.refId
                 join r3 in resCountSeb on r.refId equals r3.SalersRefId
                 join r4 in res4 on r2.ClientRefId equals r4.ClientRefId
                 select new SalesEnt
                 {
                     Mont = r1.Mont,
                     Year = r1.Year,
                     refId = r.refId,
                     ClientRefId = r2.ClientRefId,
                     SalersRefId = r1.SalersRefId,
                     CostPrise = r3.CountPur != 0 ? r1.CostPrise / r3.CountPur : 0,
                     CountPur = r3.CountPur,
                     SalesWithoutNDS = r2.SalesWithoutNDS,
                     CountSal = r2.CountSal,
                     DivName = r.DivName,
                     GroupCode = r.GroupCode,
                     GroupName = r.GroupName,
                     BuyerCode = r4.BuyerCode,
                     BuyerName = r4.BuyerName
                 }).ToList();

            List<SalesEnt> gSeb = new List<SalesEnt>();
            foreach (var gr in db.C_Reference78.ToList())
            {
                decimal resSebValue = decimal.Zero;
                decimal resSebValueCount = decimal.Zero;
                var gst = decimal.Zero;
                var gent = decimal.Zero;
                var pastTmp = decimal.Zero;
                var tmp = decimal.Zero;
                var counterPur = 0;
                var counterSales = 0;
                bool WeGoCalcSeb = false;
                bool WeGoCalcSebReal = false;
                bool isSoSmall = false;
                // вытащим только нашу группу
                var salesForGroup = resSeb.Where(_ => _.GroupCode == gr.C_Code).OrderBy(_ => _.Year).ThenBy(_ => _.Mont).ToList();

                while (counterSales < salesForGroup.Count && !WeGoCalcSebReal)
                {
                    if (!isSoSmall)
                        pastTmp = tmp;
                    if (tmp <= 0 && counterPur < salesForGroup.Count)
                    {
                        tmp += salesForGroup[counterPur].CountPur;
                        counterPur++;
                    }
                    // если после того как мы сбегали за партией, у нас на складе все еще отрецательное кол-во,
                    // бежим еще за одной партией
                    if (tmp <= 0)
                    {
                        // это нужно в том случае если мы дойдем до момента расчета себестоимости для нашего периода
                        // а мы дважды бегали за новой партией
                        // мы должны будем вернуться и посмотреть цены за прошлые месяца
                        // нам нельзя перетереть pastTmp
                        isSoSmall = true;
                        if (counterPur < salesForGroup.Count)
                            continue;
                    }
                    else
                    {
                        isSoSmall = false;
                    }

                    while (counterSales < salesForGroup.Count && !WeGoCalcSebReal)
                    {
                        // если мы еще не дошли до даты начала периода - перебираем месяца смотрим что подали что купили
                        // чтобы определить с какого месяца брать себестоимость для нашего периода
                        // смотрим от продаж, т.к. мы могли продать то что купили 2 года назад в этом периоде
                        // дата поставки > даты продажи
                        if (!WeGoCalcSeb && (salesForGroup[counterSales].Mont <= (stDate.Month - 1) && salesForGroup[counterSales].Year == stDate.Year || salesForGroup[counterSales].Year < stDate.Year))
                        {
                            tmp -= salesForGroup[counterSales].CountSal;
                            counterSales++;
                            if (tmp > 0) // после того как мы отняли от кол-ва поставки, кол-во продажи, проверим если у нас еще из партии что то на складе
                            // если есть, то эту же партию мы будем продавать и в следующем месяце                                         
                            {
                                continue;
                            }
                            else // если нет, бежим за новой партией
                            {
                                break;
                            }
                        }//если дошли - считаем среднюю себестоимость остатка
                        else
                        {
                            if (!WeGoCalcSeb)
                            {
                                for (var i = counterPur; i < counterSales; i++)
                                { gst += salesForGroup[i].CostPrise; }
                            }
                            WeGoCalcSeb = true;
                            // при расчете среднего остатка за период мы уже бежим до конца периода по продажам
                            if (salesForGroup[counterSales].Mont <= (endDate.Month - 1) && salesForGroup[counterSales].Year == endDate.Year || salesForGroup[counterSales].Year < endDate.Year)
                            {
                                counterSales++;
                                if (pastTmp < 0)
                                {
                                    var antiCounter = 1;
                                    var summCount = decimal.Zero;
                                    do
                                    {
                                        summCount += salesForGroup[counterPur - 1 - antiCounter].CountPur;
                                        if (summCount > Math.Abs(pastTmp))
                                        {
                                            resSebValue += Math.Abs(pastTmp) * salesForGroup[counterPur - 1 - antiCounter].CostPrise;
                                            resSebValueCount += Math.Abs(pastTmp) * salesForGroup[counterPur - 1 - antiCounter].CountPur;
                                            pastTmp = summCount + pastTmp;
                                            break;
                                        }
                                        else
                                        {
                                            resSebValue += summCount * salesForGroup[counterPur - 1 - antiCounter].CostPrise;
                                            resSebValue += summCount * salesForGroup[counterPur - 1 - antiCounter].CountPur;
                                            pastTmp = 0;
                                            antiCounter++;
                                            continue;
                                        }
                                    }
                                    while (pastTmp < 0);
                                }
                                resSebValue += salesForGroup.Skip(counterPur).Where(_ => _.Year <= endDate.Year && _.Mont < endDate.Month).Sum(_ => _.CostPrise * _.CountSal);
                                resSebValueCount += salesForGroup.Skip(counterPur).Where(_ => _.Year <= endDate.Year && _.Mont < endDate.Month).Sum(_ => _.CountPur);
                                WeGoCalcSebReal = true;
                                continue;

                            }
                            else //все посчитали выходим
                            {
                                break;
                            }
                        }
                    };
                };
                gent = gst + salesForGroup.Skip(counterSales).Sum(_ => _.CostPrise);
                //for (var i = counterPur; i < counterSales; i++)
                //{ gent += salesForGroup[i].CountPur; }
                if (resSebValue > 0 && resSebValueCount > 0)
                    gSeb.Add(new SalesEnt() { GroupCode = gr.C_Code, CostPrise = resSebValue / resSebValueCount, CountGoodsSt = gst, CountGoodsEnd = gent });
            }
            #endregion
            return gSeb;
        }

        private static List<SalesEnt> QueryForGetSales(DateTime stDate, DateTime endDate, dbEntities db, List<SalesEnt> gSeb)
        {
            var res = (from r77 in db.C_Reference77
                       join r78 in db.C_Reference78 on r77.C_Fld1089RRef equals r78.C_IDRRef
                       select new SalesEnt
                       {
                           Mont = 0,
                           Year = 0,
                           refId = r77.C_IDRRef,
                           ClientRefId = new byte[] { },
                           SalersRefId = new byte[] { },
                           CostPrise = decimal.Zero,
                           CountPur = decimal.Zero,
                           SalesWithoutNDS = decimal.Zero,
                           CountSal = decimal.Zero,
                           DivName = r77.C_Description,
                           GroupCode = r78.C_Code,
                           GroupName = r78.C_Description,
                           BuyerCode = string.Empty,
                           BuyerName = string.Empty,
                           CountGoodsEnd = decimal.Zero,
                           CountGoodsSt = decimal.Zero,
                           AveCostPrise = decimal.Zero
                       }
                                        );

            //Себестоимость за период + кол-во сколько поставили(в C_AccumRgTn10122) +  сам поставщик (C_Value1_RRRef)
            var res1 = (from s888 in db.C_AccRgAT210888
                        where s888.C_Period >= stDate && s888.C_Period < endDate
                        group s888 by s888.C_Value2_RRRef into g
                        select new SalesEnt
                        {
                            Mont = 0,
                            Year = 0,
                            refId = g.FirstOrDefault().C_Value2_RRRef,
                            ClientRefId = new byte[] { },
                            SalersRefId = g.FirstOrDefault().C_Value1_RRRef,
                            CostPrise = g.Sum(_ => _.C_TurnoverCt10882 ?? 0),
                            CountPur = decimal.Zero,
                            SalesWithoutNDS = decimal.Zero,
                            CountSal = decimal.Zero,
                            DivName = string.Empty,
                            GroupCode = string.Empty,
                            GroupName = string.Empty,
                            BuyerCode = string.Empty,
                            BuyerName = string.Empty,
                            CountGoodsEnd = decimal.Zero,
                            CountGoodsSt = decimal.Zero,
                            AveCostPrise = decimal.Zero
                        });
            
            //Цена продажи без ндс
            var res2 = (from r27 in db.C_AccumRgTn10472
                        where r27.C_Period >= stDate && r27.C_Period < endDate
                        group r27 by r27.C_Fld10452_RRRef into g
                        select new SalesEnt
                        {
                            Mont = 0,
                            Year = 0,
                            refId = g.FirstOrDefault().C_Fld10452_RRRef,
                            ClientRefId = g.FirstOrDefault().C_Fld10459RRef,
                            SalersRefId = new byte[] { },
                            CostPrise = decimal.Zero,
                            CountPur = decimal.Zero,
                            SalesWithoutNDS = g.Sum(_ => _.C_Fld10464),
                            CountSal = g.Sum(_ => _.C_Fld10462),
                            DivName = string.Empty,
                            GroupCode = string.Empty,
                            GroupName = string.Empty,
                            BuyerCode = string.Empty,
                            BuyerName = string.Empty,
                            CountGoodsEnd = decimal.Zero,
                            CountGoodsSt = decimal.Zero,
                            AveCostPrise = decimal.Zero
                        }
                        );

            // количество сколько поступило на конечную дату
            var res3 = (from s888 in db.C_AccumRgTn10122
                        where s888.C_Period < endDate && s888.C_Period >= stDate
                        group s888 by s888.C_Fld10107_RRRef into g
                        select new SalesEnt
                        {
                            Mont = 0,
                            Year = 0,
                            refId = new byte[] { },
                            ClientRefId = new byte[] { },
                            SalersRefId = g.FirstOrDefault().C_Fld10107_RRRef,
                            CostPrise = decimal.Zero,
                            CountPur = g.Sum(_ => _.C_Fld10117),
                            SalesWithoutNDS = decimal.Zero,
                            CountSal = decimal.Zero,
                            DivName = string.Empty,
                            GroupCode = string.Empty,
                            GroupName = string.Empty,
                            BuyerCode = string.Empty,
                            BuyerName = string.Empty,
                            CountGoodsEnd = decimal.Zero,
                            CountGoodsSt = decimal.Zero,
                            AveCostPrise = decimal.Zero
                        });

            //покупатели 
            var res4 = (from s888 in db.C_Reference67
                        select new SalesEnt
                        {
                            Mont = 0,
                            Year = 0,
                            refId = new byte[] { },
                            ClientRefId = s888.C_IDRRef,
                            SalersRefId = new byte[] { },
                            CostPrise = decimal.Zero,
                            CountPur = decimal.Zero,
                            SalesWithoutNDS = decimal.Zero,
                            CountSal = decimal.Zero,
                            DivName = string.Empty,
                            GroupCode = string.Empty,
                            GroupName = string.Empty,
                            BuyerCode = s888.C_Code,
                            BuyerName = s888.C_Description,
                            CountGoodsEnd = decimal.Zero,
                            CountGoodsSt = decimal.Zero,
                            AveCostPrise = decimal.Zero
                        });
            
            var res5 =
                (from r in res
                 join r1 in res1 on r.refId equals r1.refId
                 join r2 in res2 on r.refId equals r2.refId
                 join r3 in res3 on r.refId equals r3.SalersRefId
                 join r4 in res4 on r2.ClientRefId equals r4.ClientRefId
                 select new SalesEnt
                 {
                     Mont = 0,
                     Year = 0,
                     refId = r.refId,
                     ClientRefId = r2.ClientRefId,
                     SalersRefId = r1.SalersRefId,
                     CostPrise = r1.CostPrise,
                     CountPur = r3.CountPur,
                     SalesWithoutNDS = r2.SalesWithoutNDS,
                     CountSal = r2.CountSal,
                     DivName = r.DivName,
                     GroupCode = r.GroupCode,
                     GroupName = r.GroupName,
                     BuyerCode = r4.BuyerCode,
                     BuyerName = r4.BuyerName,
                     CountGoodsEnd = decimal.Zero,
                     CountGoodsSt = decimal.Zero,
                     AveCostPrise = decimal.Zero
                 });

            var result = res5.ToList();
            if (gSeb.Count() > 0)
                Parallel.ForEach(result, i =>
                {
                    if (gSeb.FirstOrDefault(f => f.GroupCode == i.GroupCode) != null)
                    {
                        i.AveCostPrise = gSeb.FirstOrDefault(f => f.GroupCode == i.GroupCode).CostPrise;
                        i.CountGoodsSt = gSeb.FirstOrDefault(f => f.GroupCode == i.GroupCode).CountGoodsSt;
                        i.CountGoodsEnd = gSeb.FirstOrDefault(f => f.GroupCode == i.GroupCode).CountGoodsEnd;
                    }
                });
            return result;
        }

        #region SubQuery

        /// <summary>
        /// Метод рассчета упр учета
        /// </summary>
        /// <param name="values"></param>
        /// <param name="_start"></param>
        /// <param name="_end"></param>
        private static void Calculate(out decimal _start, out decimal _end, params int[] values)
        {
            _start = 0;
            _end = 0;

            List<int> list = values.ToList();
            
            GetStartEndDateMoney(Start, End, list, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);
            _start = ourDbtSt.Select(_ => _.Money).Sum() - ourCrtSt.Select(_ => _.Money).Sum();
            _end = _start + ourDbtSt.Select(_ => _.Money).Sum() - ourCrtSt.Select(_ => _.Money).Sum();
        }

        /// <summary>
        /// Метод рассчета бух учета
        /// </summary>
        /// <param name="values"></param>
        /// <param name="_start"></param>
        /// <param name="_end"></param>
        private static void CalculateOriginal(out decimal _start, out decimal _end, params int[] values)
        {
            _start = 0;
            _end = 0;

            List<int> list = values.ToList();

            GetStartEndDateMoney(StartOriginal, EndOriginal, list, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);
            _start = ourDbtSt.Select(_ => _.Money).Sum() - ourCrtSt.Select(_ => _.Money).Sum();
            _end = _start + ourDbtSt.Select(_ => _.Money).Sum() - ourCrtSt.Select(_ => _.Money).Sum();
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
        /// Метод вытаскивает деньги на начало периода и на конец, по дебету и кредету
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        /// <param name="ourScr"></param>
        /// <param name="ourDbtSt"></param>
        /// <param name="ourDbtEnd"></param>
        /// <param name="ourCrtSt"></param>
        /// <param name="ourCrtEnd"></param>
        private static void GetStartEndDateMoney(List<TranzEnt> Start, List<TranzEnt> End, List<int> ourScr, out List<TranzEnt> ourDbtSt, out List<TranzEnt> ourDbtEnd, out List<TranzEnt> ourCrtSt, out List<TranzEnt> ourCrtEnd)
        {
            ourDbtSt = Start.Where(w => ourScr.Contains(Convert.ToInt32(Regex.Match(w.ScoreDt, @"\d+").Value))).ToList();

            ourCrtSt = Start.Where(w => ourScr.Contains(Convert.ToInt32(Regex.Match(w.ScoreCt, @"\d+").Value))).ToList();

            ourDbtEnd = End.Where(w => ourScr.Contains(Convert.ToInt32(Regex.Match(w.ScoreDt, @"\d+").Value))).ToList();

            ourCrtEnd = End.Where(w => ourScr.Contains(Convert.ToInt32(Regex.Match(w.ScoreDt, @"\d+").Value))).ToList();            
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
        private static void GetPeriodMoney(List<TranzEnt> Trans, List<int> ourScr, out List<TranzEnt> ourDbt, out List<TranzEnt> ourCrt)
        {
            ourDbt = Trans.Where(w => ourScr.Contains(Convert.ToInt32(Regex.Match(w.ScoreDt, @"\d+").Value ))).ToList();

            ourCrt = Trans.Where(w => ourScr.Contains(Convert.ToInt32(Regex.Match(w.ScoreCt, @"\d+").Value ))).ToList();            
        }        
              
        #endregion
    }

    
}
