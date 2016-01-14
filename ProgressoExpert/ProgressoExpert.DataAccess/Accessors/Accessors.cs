using ProgressoExpert.Common.Enums;
using ProgressoExpert.DataAccess.Entities;
using ProgressoExpert.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.DataAccess
{
    public class Accessors
    {
        public static BusinessResults GetBusinessResults(MainModel mainModel)
        {
            BusinessResults model = new BusinessResults();
            using (dbEntities db = new dbEntities())
            {
                var scores = mainModel.Scores;
                var Start = mainModel.StartTranz;
                var End = mainModel.EndTranz;

                List<TranzEnt> ourDbtSt; // Это уже транзакции связанные с нашим счетом на начало
                List<TranzEnt> ourDbtEnd; // Это уже транзакции связанные с нашим счетом на конец (мы не будем считать на конец периода заного, почтитаем между датами, и сложем)
                List<TranzEnt> ourCrtSt;
                List<TranzEnt> ourCrtEnd;

                var ourScr = new List<ScoreEnt>(); // Вытащим ID интересующих нас счетов нас счетов

                #region Денежные средства
                ourScr = GetOurScore((long)ScoresForBusinessResults.Cash, scores);

                GetStartEndDateMoney(Start, End, ourScr, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);

                model= new BusinessResults();
                model.BankrollStart = CalculateStart(ourDbtSt, ourCrtSt);
                model.BankrollEnd = CalculateEnd(model.BankrollStart, ourDbtEnd, ourCrtEnd);
                #endregion

                #region Дебиторская задолженность (Краткосрочная Дебиторская задолженность + Долгосрочная Дебиторская задолженность)

                // Краткосрочная Дебиторская задолженность
                ourScr = GetOurScore((long)ScoresForBusinessResults.ShortTermReceivables, scores);
                GetStartEndDateMoney(Start, End, ourScr, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);

                var _shortTermReceivablesStart = CalculateStart(ourDbtSt, ourCrtSt);
                var _shortTermReceivablesEnd = CalculateEnd(_shortTermReceivablesStart, ourDbtEnd, ourCrtEnd);

                // Долгосрочная Дебиторская задолженность 
                ourScr = GetOurScore((long)ScoresForBusinessResults.LongTermReceivables, scores);
                GetStartEndDateMoney(Start, End, ourScr, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);

                var _longTermReceivablesStart = CalculateStart(ourDbtSt, ourCrtSt);
                var _longTermReceivablesEnd = CalculateEnd(_longTermReceivablesStart, ourDbtEnd, ourCrtEnd);

                // Итого
                model.ReceivablesStart = _shortTermReceivablesStart + _longTermReceivablesStart;
                model.ReceivablesEnd = _shortTermReceivablesEnd + _longTermReceivablesEnd;
                #endregion

                #region Товары
                ourScr = GetOurScore((long)ScoresForBusinessResults.Inventories, scores);

                GetStartEndDateMoney(Start, End, ourScr, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);

                model.InventoriesStart = CalculateStart(ourDbtSt, ourCrtSt);
                model.InventoriesEnd = CalculateEnd(model.InventoriesStart, ourDbtEnd, ourCrtEnd);
                #endregion

                #region Прочие краткосрочные активы
                ourScr = GetOurScore((long)ScoresForBusinessResults.OtherCurrentAssets, scores);

                GetStartEndDateMoney(Start, End, ourScr, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);

                model.OtherCurrentAssetsStart = CalculateStart(ourDbtSt, ourCrtSt);
                model.OtherCurrentAssetsEnd = CalculateEnd(model.OtherCurrentAssetsStart, ourDbtEnd, ourCrtEnd);
                #endregion

                #region Итого краткосрочные активы

                model.CalculateTotalCurrentAssetsStartEnd();

                #endregion

                #region Оборудование (Основные средства)
                ourScr = GetOurScore((long)ScoresForBusinessResults.FixedAssets, scores);

                GetStartEndDateMoney(Start, End, ourScr, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);

                model.EquipmentStart = CalculateStart(ourDbtSt, ourCrtSt);
                model.EquipmentEnd = CalculateEnd(model.EquipmentStart, ourDbtEnd, ourCrtEnd);
                #endregion

                #region Прочий инвентарь (Прочие долгосрочные активы + Инвестиции)

                // Прочие долгосрочные активы
                ourScr = GetOurScore((long)ScoresForBusinessResults.OtherLongTermReceivables, scores);
                GetStartEndDateMoney(Start, End, ourScr, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);

                var _otherLongTermReceivablesStart = CalculateStart(ourDbtSt, ourCrtSt);
                var _otherLongTermReceivablesEnd = CalculateEnd(_otherLongTermReceivablesStart, ourDbtEnd, ourCrtEnd);

                // Инвестиции 
                ourScr = GetOurScore((long)ScoresForBusinessResults.Investments, scores);
                GetStartEndDateMoney(Start, End, ourScr, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);

                var _investmentsStart = CalculateStart(ourDbtSt, ourCrtSt);
                var _investmentsEnd = CalculateEnd(_investmentsStart, ourDbtEnd, ourCrtEnd);

                // Итого
                model.OtherEquipmentStart = _otherLongTermReceivablesStart + _investmentsStart;
                model.OtherEquipmentEnd = _otherLongTermReceivablesEnd + _investmentsEnd;
                #endregion

                #region Итого валюта баланса

                model.CalculateTotalBalanceCurrencyStartEnd();

                #endregion

                #region Долги перед Банком (Краткосрочные Долги перед Банком + Долгосрочные Долги перед Банком)

                //Краткосрочные Долги перед Банком
                ourScr = GetOurScore((long)ScoresForBusinessResults.ShortTermDebtsBanks, scores);
                GetStartEndDateMoney(Start, End, ourScr, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);

                var _shortTermDebtsBanksStart = CalculateStart(ourDbtSt, ourCrtSt);
                var _shortTermDebtsBanksEnd = CalculateEnd(_shortTermDebtsBanksStart, ourDbtEnd, ourCrtEnd);

                // Долгосрочные Долги перед Банком
                ourScr = GetOurScore((long)ScoresForBusinessResults.LongTermDebtsBanks, scores);
                GetStartEndDateMoney(Start, End, ourScr, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);

                var _longTermDebtsBanksStart = CalculateStart(ourDbtSt, ourCrtSt);
                var _longTermDebtsBanksEnd = CalculateEnd(_longTermDebtsBanksStart, ourDbtEnd, ourCrtEnd);

                // Итого
                model.DebtsBanksStart = _shortTermDebtsBanksStart + _longTermDebtsBanksStart;
                model.DebtsBanksEnd = _shortTermDebtsBanksEnd + _longTermDebtsBanksEnd;
                #endregion

                #region Долги перед налоговой
                ourScr = GetOurScore((long)ScoresForBusinessResults.DebtsTaxAndOtherPaymentsBudget, scores);

                GetStartEndDateMoney(Start, End, ourScr, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);

                model.DebtsTaxAndOtherPaymentsBudgetStart = CalculateStart(ourDbtSt, ourCrtSt);
                model.DebtsTaxAndOtherPaymentsBudgetEnd = CalculateEnd(model.DebtsTaxAndOtherPaymentsBudgetStart, ourDbtEnd, ourCrtEnd);
                #endregion

                #region Долги перед поставщиками/покупателями (Краткосрочные Долги перед поставщиками/покупателями + Долгосрочные Долги перед поставщиками/покупателями)

                // Краткосрочные Долги перед поставщиками/покупателями
                ourScr = GetOurScore((long)ScoresForBusinessResults.ShortTermDebtsSupplierBuyers, scores);
                GetStartEndDateMoney(Start, End, ourScr, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);

                var _shortTermDebtsSupplierBuyersStart = CalculateStart(ourDbtSt, ourCrtSt);
                var _shortTermDebtsSupplierBuyersEnd = CalculateEnd(_shortTermDebtsSupplierBuyersStart, ourDbtEnd, ourCrtEnd);

                // Долгосрочные Долги перед поставщиками/покупателями
                ourScr = GetOurScore((long)ScoresForBusinessResults.LongTermDebtSuppliersBuyers, scores);
                GetStartEndDateMoney(Start, End, ourScr, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);

                var _longTermDebtsSupplierBuyersStart = CalculateStart(ourDbtSt, ourCrtSt);
                var _longTermDebtsSupplierBuyersEnd = CalculateEnd(_longTermDebtsSupplierBuyersStart, ourDbtEnd, ourCrtEnd);

                // Итого
                model.DebtsSupplierBuyersStart = _shortTermDebtsSupplierBuyersStart + _longTermDebtsSupplierBuyersStart;
                model.DebtsSupplierBuyersEnd = _shortTermDebtsSupplierBuyersEnd + _longTermDebtsSupplierBuyersEnd;

                #endregion

                #region Прочие долги (Прочие долги + прочие долгосрочные долги)

                // Прочие долги
                ourScr = GetOurScore((long)ScoresForBusinessResults.OtherDebts, scores);
                GetStartEndDateMoney(Start, End, ourScr, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);

                var _otherDebtsStart = CalculateStart(ourDbtSt, ourCrtSt);
                var _otherDebtsEnd = CalculateEnd(_otherDebtsStart, ourDbtEnd, ourCrtEnd);

                // Прочие долгосрочные долги
                ourScr = GetOurScore((long)ScoresForBusinessResults.OtherLongTermDebt, scores);
                GetStartEndDateMoney(Start, End, ourScr, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);

                var _otherLongDebtsStart = CalculateStart(ourDbtSt, ourCrtSt);
                var _otherLongDebtsEnd = CalculateEnd(_otherLongDebtsStart, ourDbtEnd, ourCrtEnd);

                // Итого
                model.OtherDebtsStart = _otherDebtsStart + _otherLongDebtsStart;
                model.OtherDebtsEnd = _otherDebtsEnd + _otherLongDebtsEnd;
                #endregion

                #region Итого кредиторская задолженность

                model.CalculateTotalAccountsPayableStartEnd();

                #endregion

                #region Собственный капитал

                model.CalculateOwnCapitalStartEnd();

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
                                model.IncomeSale.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum() - ourCrt.Select(_ => _.Money).Sum(), 2));;
                                break;
                            case (int)ProfitAndLossNumServer.IncomeService:
                                model.IncomeService.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum() - ourCrt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.CostPriceSale:
                                model.CostPriceSale.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum() - ourCrt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.CostPriceService:
                                model.CostPriceService.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum() - ourCrt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.SalaryAdmPer:
                                model.SalaryAdmPer.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum() - ourCrt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.SalarySalesDepartment:
                                model.SalarySalesDepartment.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum() - ourCrt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.SalaryServicePer:
                                model.SalaryServicePer.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum() - ourCrt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.BonusesSalesManagerSellers:
                                model.BonusesSalesManagerSellers.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum() - ourCrt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.RentOfficeWarehouse:
                                model.RentOfficeWarehouse.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum() - ourCrt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.DistributionСosts:
                                model.DistributionСosts.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum() - ourCrt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.OtherAdministrativeExpenses:
                                model.OtherAdministrativeExpenses.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum() - ourCrt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.BankInterest:
                                model.BankInterest.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum() - ourCrt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.Depreciation:
                                model.Depreciation.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum() - ourCrt.Select(_ => _.Money).Sum(), 2));
                                break;
                            case (int)ProfitAndLossNumServer.KPN20:
                                model.KPN20.Add(Math.Round(ourDbt.Select(_ => _.Money).Sum() - ourCrt.Select(_ => _.Money).Sum(), 2));
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
                model.TotalIncome.Add(Math.Round(model.TotalIncome.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.TotalIncome.Add(Math.Round(model.TotalIncome.Take(monthCounter).Sum(), 2));// общее

                model.IncomeSale.Add(Math.Round(model.IncomeSale.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.IncomeSale.Add(Math.Round(model.IncomeSale.Take(monthCounter).Sum(), 2));// общее

                model.IncomeService.Add(Math.Round(model.IncomeService.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.IncomeService.Add(Math.Round(model.IncomeService.Take(monthCounter).Sum(), 2));// общее

                model.TotalCostPrice.Add(Math.Round(model.TotalCostPrice.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.TotalCostPrice.Add(Math.Round(model.TotalCostPrice.Take(monthCounter).Sum(), 2));// общее

                model.CostPriceSale.Add(Math.Round(model.CostPriceSale.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.CostPriceSale.Add(Math.Round(model.CostPriceSale.Take(monthCounter).Sum(), 2));// общее

                model.CostPriceService.Add(Math.Round(model.CostPriceService.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.CostPriceService.Add(Math.Round(model.CostPriceService.Take(monthCounter).Sum(), 2));// общее

                model.GrossProfitSale.Add(Math.Round(model.GrossProfitSale.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.GrossProfitSale.Add(Math.Round(model.GrossProfitSale.Take(monthCounter).Sum(), 2));// общее

                model.GrossProfitService.Add(Math.Round(model.GrossProfitService.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.GrossProfitService.Add(Math.Round(model.GrossProfitService.Take(monthCounter).Sum(), 2));// общее
                
                model.GrossProfit.Add(Math.Round(model.GrossProfit.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.GrossProfit.Add(Math.Round(model.GrossProfit.Take(monthCounter).Sum(), 2));// общее

                model.Costs.Add(Math.Round(model.Costs.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.Costs.Add(Math.Round(model.Costs.Take(monthCounter).Sum(), 2));// общее

                model.SalaryAdmPer.Add(Math.Round(model.SalaryAdmPer.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.SalaryAdmPer.Add(Math.Round(model.SalaryAdmPer.Take(monthCounter).Sum(), 2));// общее

                model.SalarySalesDepartment.Add(Math.Round(model.SalarySalesDepartment.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.SalarySalesDepartment.Add(Math.Round(model.SalarySalesDepartment.Take(monthCounter).Sum(), 2));// общее

                model.SalaryServicePer.Add(Math.Round(model.SalaryServicePer.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.SalaryServicePer.Add(Math.Round(model.SalaryServicePer.Take(monthCounter).Sum(), 2));// общее

                model.BonusesSalesManagerSellers.Add(Math.Round(model.BonusesSalesManagerSellers.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.BonusesSalesManagerSellers.Add(Math.Round(model.BonusesSalesManagerSellers.Take(monthCounter).Sum(), 2));// общее

                model.RentOfficeWarehouse.Add(Math.Round(model.RentOfficeWarehouse.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.RentOfficeWarehouse.Add(Math.Round(model.RentOfficeWarehouse.Take(monthCounter).Sum(), 2));// общее

                model.DistributionСosts.Add(Math.Round(model.DistributionСosts.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.DistributionСosts.Add(Math.Round(model.DistributionСosts.Take(monthCounter).Sum(), 2));// общее

                model.OtherAdministrativeExpenses.Add(Math.Round(model.OtherAdministrativeExpenses.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.OtherAdministrativeExpenses.Add(Math.Round(model.OtherAdministrativeExpenses.Take(monthCounter).Sum(), 2));// общее

                model.BankInterest.Add(Math.Round(model.BankInterest.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.BankInterest.Add(Math.Round(model.BankInterest.Take(monthCounter).Sum(), 2));// общее

                model.Depreciation.Add(Math.Round(model.Depreciation.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.Depreciation.Add(Math.Round(model.Depreciation.Take(monthCounter).Sum(), 2));// общее

                model.KPN20.Add(Math.Round(model.KPN20.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.KPN20.Add(Math.Round(model.KPN20.Take(monthCounter).Sum(), 2));// общее

                model.Ebitda.Add(Math.Round(model.Ebitda.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.Ebitda.Add(Math.Round(model.Ebitda.Take(monthCounter).Sum(), 2));// общее

                model.ProfitBeforeTaxation.Add(Math.Round(model.ProfitBeforeTaxation.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.ProfitBeforeTaxation.Add(Math.Round(model.ProfitBeforeTaxation.Take(monthCounter).Sum(), 2));// общее

                model.ProfitAfterTaxation.Add(Math.Round(model.ProfitAfterTaxation.Take(monthCounter).Sum() / monthCounter, 2));// среднее
                model.ProfitAfterTaxation.Add(Math.Round(model.ProfitAfterTaxation.Take(monthCounter).Sum(), 2));// общее
                #endregion

                return model;
            }
        }

        #region SubQuery
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="_start"></param>
        /// <param name="_end"></param>
        private static void Calculate(long[] items, out decimal _start, out decimal _end)
        {
            _start = 0;
            _end = 0;

            foreach (var item in items)
            {
            //    var _ourScr = GetOurScore(item, scores);
            //    GetStartEndDateMoney(Start, End, ourScr, out ourDbtSt, out ourDbtEnd, out ourCrtSt, out ourCrtEnd);
            //    var _itemStart = CalculateStart(ourDbtSt, ourCrtSt);
            //    var _itemFinish = CalculateEnd(_itemStart, ourDbtEnd, ourCrtEnd);
            //    _start += _itemStart;
            //    _end += _itemFinish;
            }
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
            List<string> Scores = new List<string>();
            for (int i = 0; i < _myScore.Count(); i = i + 2)
            {
                Scores.Add(_myScore[i].ToString() + _myScore[i + 1].ToString());
            }

            foreach (var sc in scores)
            {
                if (sc.Code.Length < 2) continue;
                var tt = string.Join("", sc.Code.Take(2)); // берем все счета которые начинаются с 10
                if (Scores.Contains(tt))
                {
                    _ourScr.Add(sc);
                }
            }
            return _ourScr;
        }

        /// <summary>
        /// Метод возращает массив счетов которые нам нужны
        /// </summary>
        /// <param name="sroreArr">массив состоящий из первых двух цыфр счетов которые нам нужны</param>
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
