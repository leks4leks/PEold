using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models
{
    public class BusinessResults : BaseViewModel
    {
        #region Краткосрочные активы 
        
        #region Денежные средства в кассе

        /// <summary>
        /// Денежные средства в кассе на начало периода
        /// </summary>
        public decimal CashInCashBoxStart
        {
            get { return _cashInCashBoxStart; }
            set { SetValue(ref _cashInCashBoxStart, value, "CashInCashBoxStart"); }
        }
        private decimal _cashInCashBoxStart;

        /// <summary>
        /// Денежные средства в кассе на конец периода
        /// </summary>
        public decimal CashInCashBoxEnd
        {
            get { return _cashInCashBoxEnd; }
            set { SetValue(ref _cashInCashBoxEnd, value, "CashInCashBoxEnd"); }
        }
        private decimal _cashInCashBoxEnd;

        #endregion

        #region Денежные средства на рассчетном счете

        /// <summary>
        /// Денежные средства на рассчетном счете на начало периода
        /// </summary>
        public decimal CasnInCheckingAccountStart
        {
            get { return _casnInCheckingAccountStart; }
            set { SetValue(ref _casnInCheckingAccountStart, value, "CasnInCheckingAccountStart"); }
        }
        private decimal _casnInCheckingAccountStart;

        /// <summary>
        /// Денежные средства на рассчетном счете на конец периода
        /// </summary>
        public decimal CasnInCheckingAccountEnd
        {
            get { return _casnInCheckingAccountEnd; }
            set { SetValue(ref _casnInCheckingAccountEnd, value, "CasnInCheckingAccountEnd"); }
        }
        private decimal _casnInCheckingAccountEnd;

        #endregion

        #region Депозиты

        /// <summary>
        /// Депозиты на начало периода
        /// </summary>
        public decimal DepositsStart
        {
            get { return _depositsStart; }
            set { SetValue(ref _depositsStart, value, "DepositsStart"); }
        }
        private decimal _depositsStart;

        /// <summary>
        /// Депозиты на конец периода
        /// </summary>
        public decimal DepositsEnd
        {
            get { return _depositsEnd; }
            set { SetValue(ref _depositsEnd, value, "DepositsEnd"); }
        }
        private decimal _depositsEnd;

        #endregion

        #region Дебиторская задолженность

        /// <summary>
        /// Дебиторская задолженность на начало периода
        /// </summary>
        public decimal ReceivablesStart
        {
            get { return _receivablesStart; }
            set { SetValue(ref _receivablesStart, value, "ReceivablesStart"); }
        }
        private decimal _receivablesStart;

        /// <summary>
        /// Дебиторская задолженность на конец периода
        /// </summary>
        public decimal ReceivablesEnd
        {
            get { return _receivablesEnd; }
            set { SetValue(ref _receivablesEnd, value, "ReceivablesEnd"); }
        }
        private decimal _receivablesEnd;

        #endregion

        #region Сырье и материалы

        /// <summary>
        /// Сырье и материалы на начало периода
        /// </summary>
        public decimal RawAndMaterialsStart
        {
            get { return _rawAndMaterialsStart; }
            set { SetValue(ref _rawAndMaterialsStart, value, "RawAndMaterialsStart"); }
        }
        private decimal _rawAndMaterialsStart;

        /// <summary>
        /// Сырье и материалы на конец периода
        /// </summary>
        public decimal RawAndMaterialsEnd
        {
            get { return _rawAndMaterialsEnd; }
            set { SetValue(ref _rawAndMaterialsEnd, value, "RawAndMaterialsEnd"); }
        }
        private decimal _rawAndMaterialsEnd;

        #endregion

        #region Товары

        /// <summary>
        /// Товары на начало периода
        /// </summary>
        public decimal GoodsStart
        {
            get { return _goodsStart; }
            set { SetValue(ref _goodsStart, value, "GoodsStart"); }
        }
        private decimal _goodsStart;

        /// <summary>
        /// Товары на конец периода
        /// </summary>
        public decimal GoodsEnd
        {
            get { return _goodsEnd; }
            set { SetValue(ref _goodsEnd, value, "GoodsEnd"); }
        }
        private decimal _goodsEnd;

        #endregion

        #region Незавершенное производство

        /// <summary>
        /// Незавершенное производство на начало периода
        /// </summary>
        public decimal UnfinishedProductionStart
        {
            get { return _unfinishedProductionStart; }
            set { SetValue(ref _unfinishedProductionStart, value, "UnfinishedProductionStart"); }
        }
        private decimal _unfinishedProductionStart;

        /// <summary>
        /// Незавершенное производство на конец периода
        /// </summary>
        public decimal UnfinishedProductionEnd
        {
            get { return _unfinishedProductionEnd; }
            set { SetValue(ref _unfinishedProductionEnd, value, "UnfinishedProductionEnd"); }
        }
        private decimal _unfinishedProductionEnd;

        #endregion

        #region Прочие краткосрочные активы

        /// <summary>
        /// Прочие краткосрочные активы на начало периода
        /// </summary>
        public decimal OtherCurrentAssetsStart
        {
            get { return _otherCurrentAssetsStart; }
            set { SetValue(ref _otherCurrentAssetsStart, value, "OtherCurrentAssetsStart"); }
        }
        private decimal _otherCurrentAssetsStart;

        /// <summary>
        /// Прочие краткосрочные активы на конец периода
        /// </summary>
        public decimal OtherCurrentAssetsEnd
        {
            get { return _otherCurrentAssetsEnd; }
            set { SetValue(ref _otherCurrentAssetsEnd, value, "OtherCurrentAssetsEnd"); }
        }
        private decimal _otherCurrentAssetsEnd;

        #endregion

        #region Налоговые активы

        /// <summary>
        /// Налоговые активы на начало периода
        /// </summary>
        public decimal TaxAssetsStart
        {
            get { return _taxAssetsStart; }
            set { SetValue(ref _taxAssetsStart, value, "TaxAssetsStart"); }
        }
        private decimal _taxAssetsStart;

        /// <summary>
        /// Налоговые активы на конец периода
        /// </summary>
        public decimal TaxAssetsEnd
        {
            get { return _taxAssetsEnd; }
            set { SetValue(ref _taxAssetsEnd, value, "TaxAssetsEnd"); }
        }
        private decimal _taxAssetsEnd;

        #endregion

        #region Краткосрочные активы

        /// <summary>
        /// Краткосрочные активы на начало периода
        /// </summary>
        public decimal ShortTermAssetsStart
        {
            get { return _shortTermAssetsStart; }
            set { SetValue(ref _shortTermAssetsStart, value, "ShortTermAssetsStart"); }
        }
        private decimal _shortTermAssetsStart;

        /// <summary>
        /// Краткосрочные активы на конец периода
        /// </summary>
        public decimal ShortTermAssetsEnd
        {
            get { return _shortTermAssetsEnd; }
            set { SetValue(ref _shortTermAssetsEnd, value, "ShortTermAssetsEnd"); }
        }
        private decimal _shortTermAssetsEnd;

        #endregion

        #endregion

        #region Долгосрочные активы

        #region Долгосрочная дебиторская задолженность контрагентов

        /// <summary>
        /// Долгосрочная дебиторская задолженность контрагентов на начало периода
        /// </summary>
        public decimal LongTermReceivablesStart
        {
            get { return _longTermReceivablesStart; }
            set { SetValue(ref _longTermReceivablesStart, value, "LongTermReceivablesStart"); }
        }
        private decimal _longTermReceivablesStart;

        /// <summary>
        /// Долгосрочная дебиторская задолженность контрагентов на конец периода
        /// </summary>
        public decimal LongTermReceivablesEnd
        {
            get { return _longTermReceivablesEnd; }
            set { SetValue(ref _longTermReceivablesEnd, value, "LongTermReceivablesEnd"); }
        }
        private decimal _longTermReceivablesEnd;

        #endregion

        #region Прочая долгосрочная дебиторская задолженность

        /// <summary>
        /// Прочая долгосрочная дебиторская задолженность  на начало периода
        /// </summary>
        public decimal OtherLongTermReceivablesStart
        {
            get { return _otherLongTermReceivablesStart; }
            set { SetValue(ref _otherLongTermReceivablesStart, value, "OtherLongTermReceivablesStart"); }
        }
        private decimal _otherLongTermReceivablesStart;

        /// <summary>
        /// Прочая долгосрочная дебиторская задолженность  на конец периода
        /// </summary>
        public decimal OtherLongTermReceivablesEnd
        {
            get { return _otherLongTermReceivablesEnd; }
            set { SetValue(ref _otherLongTermReceivablesEnd, value, "OtherLongTermReceivablesEnd"); }
        }
        private decimal _otherLongTermReceivablesEnd;

        #endregion

        #region Инвестиции

        /// <summary>
        /// Инвестиции  на начало периода
        /// </summary>
        public decimal InvestmentsStart
        {
            get { return _investmentsStart; }
            set { SetValue(ref _investmentsStart, value, "InvestmentsStart"); }
        }
        private decimal _investmentsStart;

        /// <summary>
        /// Инвестиции  на конец периода
        /// </summary>
        public decimal InvestmentsEnd
        {
            get { return _investmentsEnd; }
            set { SetValue(ref _investmentsEnd, value, "InvestmentsEnd"); }
        }
        private decimal _investmentsEnd;

        #endregion

        #region Основные средства

        /// <summary>
        /// Основные средства на начало периода
        /// </summary>
        public decimal FixedAssetsStart
        {
            get { return _fixedAssetsStart; }
            set { SetValue(ref _fixedAssetsStart, value, "FixedAssetsStart"); }
        }
        private decimal _fixedAssetsStart;

        /// <summary>
        /// Основные средства на конец периода
        /// </summary>
        public decimal FixedAssetsEnd
        {
            get { return _fixedAssetsEnd; }
            set { SetValue(ref _fixedAssetsEnd, value, "FixedAssetsEnd"); }
        }
        private decimal _fixedAssetsEnd;

        #endregion

        #region Нематериальные активы

        /// <summary>
        /// Нематериальные активы на начало периода
        /// </summary>
        public decimal IntangibleAssetsStart
        {
            get { return _intangibleAssetsStart; }
            set { SetValue(ref _intangibleAssetsStart, value, "IntangibleAssetsStart"); }
        }
        private decimal _intangibleAssetsStart;

        /// <summary>
        /// Нематериальные активы на конец периода
        /// </summary>
        public decimal IntangibleAssetsEnd
        {
            get { return _intangibleAssetsEnd; }
            set { SetValue(ref _intangibleAssetsEnd, value, "IntangibleAssetsEnd"); }
        }
        private decimal _intangibleAssetsEnd;

        #endregion

        #region Долгосрочные налоговые активы

        /// <summary>
        /// Долгосрочные налоговые активы на начало периода
        /// </summary>
        public decimal LongTermTaxAssetsStart
        {
            get { return _longTermTaxAssetsStart; }
            set { SetValue(ref _longTermTaxAssetsStart, value, "LongTermTaxAssetsStart"); }
        }
        private decimal _longTermTaxAssetsStart;

        /// <summary>
        /// Долгосрочные налоговые активы на конец периода
        /// </summary>
        public decimal LongTermTaxAssetsEnd
        {
            get { return _longTermTaxAssetsEnd; }
            set { SetValue(ref _longTermTaxAssetsEnd, value, "LongTermTaxAssetsEnd"); }
        }
        private decimal _longTermTaxAssetsEnd;

        #endregion

        #region Долгосрочные активы

        /// <summary>
        /// Долгосрочные активы на начало периода
        /// </summary>
        public decimal LongTermAssetsStart
        {
            get { return _longermAssetsStart; }
            set { SetValue(ref _longermAssetsStart, value, "LongTermAssetsStart"); }
        }
        private decimal _longermAssetsStart;

        /// <summary>
        /// Долгосрочные активы на конец периода
        /// </summary>
        public decimal LongTermAssetsEnd
        {
            get { return _longTermAssetsEnd; }
            set { SetValue(ref _longTermAssetsEnd, value, "LongTermAssetsEnd"); }
        }
        private decimal _longTermAssetsEnd;

        #endregion

        #endregion

        #region Краткосрочные долги

        #region Краткосрочные банковские займы

        /// <summary>
        /// Краткосрочные банковские займы на начало периода
        /// </summary>
        public decimal ShortTermBankLoansStart
        {
            get { return _shortTermBankLoansStart; }
            set { SetValue(ref _shortTermBankLoansStart, value * (-1), "ShortTermBankLoansStart"); }
        }
        private decimal _shortTermBankLoansStart;

        /// <summary>
        /// Краткосрочные банковские займы на конец периода
        /// </summary>
        public decimal ShortTermBankLoansEnd
        {
            get { return _shortTermBankLoansEnd; }
            set { SetValue(ref _shortTermBankLoansEnd, value * (-1), "ShortTermBankLoansEnd"); }
        }
        private decimal _shortTermBankLoansEnd;

        #endregion

        #region Задолженность по КПН/ИПН

        /// <summary>
        /// Задолженность по КПН/ИПН на начало периода
        /// </summary>
        public decimal DebtCitIitStart
        {
            get { return _debtCitIitStart; }
            set { SetValue(ref _debtCitIitStart, value * (-1), "DebtCitIitStart"); }
        }
        private decimal _debtCitIitStart;

        /// <summary>
        /// Задолженность по КПН/ИПН на конец периода
        /// </summary>
        public decimal DebtCitIitEnd
        {
            get { return _debtCitIitEnd; }
            set { SetValue(ref _debtCitIitEnd, value * (-1), "DebtCitIitEnd"); }
        }
        private decimal _debtCitIitEnd;

        #endregion

        #region Задолженность по НДС

        /// <summary>
        /// Задолженность по НДС на начало периода
        /// </summary>
        public decimal DebtVatStart
        {
            get { return _debtVatStart; }
            set { SetValue(ref _debtVatStart, value, "DebtVatStart"); }
        }
        private decimal _debtVatStart;

        /// <summary>
        /// Задолженность по НДС на конец периода
        /// </summary>
        public decimal DebtVatEnd
        {
            get { return _debtVatEnd; }
            set { SetValue(ref _debtVatEnd, value, "DebtVatEnd"); }
        }
        private decimal _debtVatEnd;

        #endregion

        #region Прочая задолженность по налогам

        /// <summary>
        /// Прочая задолженность по налогам на начало периода
        /// </summary>
        public decimal OtherTaxesPayableStart
        {
            get { return _otherTaxesPayableStart; }
            set { SetValue(ref _otherTaxesPayableStart, value, "OtherTaxesPayableStart"); }
        }
        private decimal _otherTaxesPayableStart;

        /// <summary>
        /// Прочая задолженность по налогам на конец периода
        /// </summary>
        public decimal OtherTaxesPayableEnd
        {
            get { return _otherTaxesPayableEnd; }
            set { SetValue(ref _otherTaxesPayableEnd, value, "OtherTaxesPayableEnd"); }
        }
        private decimal _otherTaxesPayableEnd;

        #endregion

        #region Задолженность перед контрагентами

        /// <summary>
        /// Задолженность перед контрагентами на начало периода
        /// </summary>
        public decimal PayablesToCounterpartiesShortTermDebtsStart
        {
            get { return _payablesToCounterpartiesShortTermDebtsStart; }
            set { SetValue(ref _payablesToCounterpartiesShortTermDebtsStart, value, "PayablesToCounterpartiesShortTermDebtsStart"); }
        }
        private decimal _payablesToCounterpartiesShortTermDebtsStart;

        /// <summary>
        /// Задолженность перед контрагентами на конец периода
        /// </summary>
        public decimal PayablesToCounterpartiesShortTermDebtsEnd
        {
            get { return _payablesToCounterpartiesShortTermDebtsEnd; }
            set { SetValue(ref _payablesToCounterpartiesShortTermDebtsEnd, value, "PayablesToCounterpartiesShortTermDebtsEnd"); }
        }
        private decimal _payablesToCounterpartiesShortTermDebtsEnd;

        #endregion

        #region Задолженность перед сотрудниками

        /// <summary>
        /// Задолженность перед сотрудниками на начало периода
        /// </summary>
        public decimal PayablesToEmployeesStart
        {
            get { return _payablesToEmployeesStart; }
            set { SetValue(ref _payablesToEmployeesStart, value, "PayablesToEmployeesStart"); }
        }
        private decimal _payablesToEmployeesStart;

        /// <summary>
        /// Задолженность перед сотрудниками на конец периода
        /// </summary>
        public decimal PayablesToEmployeesEnd
        {
            get { return _payablesToEmployeesEnd; }
            set { SetValue(ref _payablesToEmployeesEnd, value, "PayablesToEmployeesEnd"); }
        }
        private decimal _payablesToEmployeesEnd;

        #endregion

        #region Прочая задолженность

        /// <summary>
        /// Прочая задолженность  на начало периода
        /// </summary>
        public decimal OtherDebtsShortTermDebtsStart
        {
            get { return _otherDebtsShortTermDebtsStart; }
            set { SetValue(ref _otherDebtsShortTermDebtsStart, value, "OtherDebtsShortTermDebtsStart"); }
        }
        private decimal _otherDebtsShortTermDebtsStart;

        /// <summary>
        /// Прочая задолженность  на конец периода
        /// </summary>
        public decimal OtherDebtsShortTermDebtsEnd
        {
            get { return _otherDebtsShortTermDebtsEnd; }
            set { SetValue(ref _otherDebtsShortTermDebtsEnd, value, "OtherDebtsShortTermDebtsEnd"); }
        }
        private decimal _otherDebtsShortTermDebtsEnd;

        #endregion

        #region Краткосрочные долги

        /// <summary>
        /// Краткосрочные долги на начало периода
        /// </summary>
        public decimal ShortTermDebtStart
        {
            get { return _shortTermDebtStart; }
            set { SetValue(ref _shortTermDebtStart, value, "ShortTermDebtStart"); }
        }
        private decimal _shortTermDebtStart;

        /// <summary>
        /// Краткосрочные долги на конец периода
        /// </summary>
        public decimal ShortTermDebtEnd
        {
            get { return _shortTermDebtEnd; }
            set { SetValue(ref _shortTermDebtEnd, value, "ShortTermDebtEnd"); }
        }
        private decimal _shortTermDebtEnd;

        #endregion

        #endregion

        #region Долгосрочные долги

        #region Долгосрочные банковские займы

        /// <summary>
        /// Долгосрочные банковские займы на начало периода
        /// </summary>
        public decimal LongTermBankLoansStart
        {
            get { return _longTermBankLoansStart; }
            set { SetValue(ref _longTermBankLoansStart, value, "LongTermBankLoansStart"); }
        }
        private decimal _longTermBankLoansStart;

        /// <summary>
        /// Долгосрочные банковские займы на конец периода
        /// </summary>
        public decimal LongTermBankLoansEnd
        {
            get { return _longTermBankLoansEnd; }
            set { SetValue(ref _longTermBankLoansEnd, value, "LongTermBankLoansEnd"); }
        }
        private decimal _longTermBankLoansEnd;

        #endregion

        #region Задолженность перед контрагентами

        /// <summary>
        /// Задолженность перед контрагентами на начало периода
        /// </summary>
        public decimal PayablesToCounterpartiesLongTermDebtsStart
        {
            get { return _payablesToCounterpartiesLongTermDebtsStart; }
            set { SetValue(ref _payablesToCounterpartiesLongTermDebtsStart, value, "PayablesToCounterpartiesLongTermDebtsStart"); }
        }
        private decimal _payablesToCounterpartiesLongTermDebtsStart;

        /// <summary>
        /// Задолженность перед контрагентами на конец периода
        /// </summary>
        public decimal PayablesToCounterpartiesLongTermDebtsEnd
        {
            get { return _payablesToCounterpartiesLongTermDebtsEnd; }
            set { SetValue(ref _payablesToCounterpartiesLongTermDebtsEnd, value, "PayablesToCounterpartiesLongTermDebtsEnd"); }
        }
        private decimal _payablesToCounterpartiesLongTermDebtsEnd;

        #endregion

        #region Отложеннные налоговая задолженность

        /// <summary>
        /// Отложеннные налоговая задолженность на начало периода
        /// </summary>
        public decimal DefferedTaxDebtsStart
        {
            get { return _defferedTaxDebtsStart; }
            set { SetValue(ref _defferedTaxDebtsStart, value, "DefferedTaxDebtsStart"); }
        }
        private decimal _defferedTaxDebtsStart;

        /// <summary>
        /// Отложеннные налоговая задолженность на конец периода
        /// </summary>
        public decimal DefferedTaxDebtsEnd
        {
            get { return _defferedTaxDebtsEnd; }
            set { SetValue(ref _defferedTaxDebtsEnd, value, "DefferedTaxDebtsEnd"); }
        }
        private decimal _defferedTaxDebtsEnd;

        #endregion

        #region Прочая задолженность

        /// <summary>
        /// Прочая задолженность на начало периода
        /// </summary>
        public decimal OtherDebtsLongTermDebtsStart
        {
            get { return _otherDebtsLongTermDebtsStart; }
            set { SetValue(ref _otherDebtsLongTermDebtsStart, value, "OtherDebtsLongTermDebtsStart"); }
        }
        private decimal _otherDebtsLongTermDebtsStart;

        /// <summary>
        /// Прочая задолженность на конец периода
        /// </summary>
        public decimal OtherDebtsLongTermDebtsEnd
        {
            get { return _otherDebtsLongTermDebtsEnd; }
            set { SetValue(ref _otherDebtsLongTermDebtsEnd, value, "OtherDebtsLongTermDebtsEnd"); }
        }
        private decimal _otherDebtsLongTermDebtsEnd;

        #endregion

        #region Долгосрочные долги

        /// <summary>
        /// Долгосрочные долги на начало периода
        /// </summary>
        public decimal LongTermDebtStart
        {
            get { return _longTermDebtStart; }
            set { SetValue(ref _longTermDebtStart, value, "LongTermDebtStart"); }
        }
        private decimal _longTermDebtStart;

        /// <summary>
        /// Долгосрочные долги на конец периода
        /// </summary>
        public decimal LongTermDebtEnd
        {
            get { return _longTermDebtEnd; }
            set { SetValue(ref _longTermDebtEnd, value, "LongTermDebtEnd"); }
        }
        private decimal _longTermDebtEnd;

        #endregion

        #endregion

        #region Собственный капитал

        #region Уставной капитал

        /// <summary>
        /// Уставной капитал на начало периода
        /// </summary>
        public decimal AuthorizedCapitalStart
        {
            get { return _authorizedCapitalStart; }
            set { SetValue(ref _authorizedCapitalStart, value, "AuthorizedCapitalStart"); }
        }
        private decimal _authorizedCapitalStart;

        /// <summary>
        /// Уставной капитал на конец периода
        /// </summary>
        public decimal AuthorizedCapitalEnd
        {
            get { return _authorizedCapitalEnd; }
            set { SetValue(ref _authorizedCapitalEnd, value, "AuthorizedCapitalEnd"); }
        }
        private decimal _authorizedCapitalEnd;

        #endregion

        #region Накопленная прибыль/убыток

        /// <summary>
        /// Накопленная прибыль/убыток на начало периода
        /// </summary>
        public decimal AccumulatedProfitAndLossStart
        {
            get { return _accumulatedProfitAndLossStart; }
            set { SetValue(ref _accumulatedProfitAndLossStart, value, "AccumulatedProfitAndLossStart"); }
        }
        private decimal _accumulatedProfitAndLossStart;

        /// <summary>
        /// Накопленная прибыль/убыток на конец периода
        /// </summary>
        public decimal AccumulatedProfitAndLossEnd
        {
            get { return _accumulatedProfitAndLossEnd; }
            set { SetValue(ref _accumulatedProfitAndLossEnd, value, "AccumulatedProfitAndLossEnd"); }
        }
        private decimal _accumulatedProfitAndLossEnd;

        #endregion

        #region Прочий капитал

        /// <summary>
        /// Прочий капитал на начало периода
        /// </summary>
        public decimal OtherCapitalStart
        {
            get { return _otherCapitalStart; }
            set { SetValue(ref _otherCapitalStart, value, "OtherCapitalStart"); }
        }
        private decimal _otherCapitalStart;

        /// <summary>
        /// Прочий капитал на конец периода
        /// </summary>
        public decimal OtherCapitalEnd
        {
            get { return _otherCapitalEnd; }
            set { SetValue(ref _otherCapitalEnd, value, "OtherCapitalEnd"); }
        }
        private decimal _otherCapitalEnd;

        #endregion

        #region Собственный капитал

        /// <summary>
        /// Собственный капитал на начало периода
        /// </summary>
        public decimal OwnCapitalStart
        {
            get { return _ownCapitalStart; }
            set { SetValue(ref _ownCapitalStart, value, "OwnCapitalStart"); }
        }
        private decimal _ownCapitalStart;

        /// <summary>
        /// Собственный капитал на конец периода
        /// </summary>
        public decimal OwnCapitalEnd
        {
            get { return _ownCapitalEnd; }
            set { SetValue(ref _ownCapitalEnd, value, "OwnCapitalEnd"); }
        }
        private decimal _ownCapitalEnd;

        #endregion

        #endregion

        #region Итого

        #region Итого активов

        /// <summary>
        /// Итого активов на начало периода
        /// </summary>
        public decimal TotalAssetsStart
        {
            get { return _totalAssetsStart; }
            set { SetValue(ref _totalAssetsStart, value, "TotalAssetsStart"); }
        }
        private decimal _totalAssetsStart;

        /// <summary>
        /// Итого активов на конец периода
        /// </summary>
        public decimal TotalAssetsEnd
        {
            get { return _totalAssetsEnd; }
            set { SetValue(ref _totalAssetsEnd, value, "TotalAssetsEnd"); }
        }
        private decimal _totalAssetsEnd;

        #endregion

        #region Итого пассивов

        /// <summary>
        /// Итого пассивов на начало периода
        /// </summary>
        public decimal TotalLiabilitiesStart
        {
            get { return _totalLiabilitiesStart; }
            set { SetValue(ref _totalLiabilitiesStart, value, "TotalLiabilitiesStart"); }
        }
        private decimal _totalLiabilitiesStart;

        /// <summary>
        /// Итого пассивов на конец периода
        /// </summary>
        public decimal TotalLiabilitiesEnd
        {
            get { return _totalLiabilitiesEnd; }
            set { SetValue(ref _totalLiabilitiesEnd, value, "TotalLiabilitiesEnd"); }
        }
        private decimal _totalLiabilitiesEnd;

        #endregion

        #endregion

        #region Рассчеты итоговых сумм


        /// <summary>
        /// Рассчитать Краткосрочные активы
        /// </summary>
        public void CalculateShortTermAssets()
        {
            ShortTermAssetsStart = CashInCashBoxStart + CasnInCheckingAccountStart + DepositsStart + ReceivablesStart
                 + RawAndMaterialsStart + GoodsStart + UnfinishedProductionStart + OtherCurrentAssetsStart + TaxAssetsStart;
            ShortTermAssetsEnd = CashInCashBoxEnd + CasnInCheckingAccountEnd + DepositsEnd + ReceivablesEnd
                 + RawAndMaterialsEnd + GoodsEnd + UnfinishedProductionEnd + OtherCurrentAssetsEnd + TaxAssetsEnd;
        }

        /// <summary>
        /// Рассчитать Долгосрочные активы
        /// </summary>
        public void CalculateLongTermAssets()
        {
            LongTermAssetsStart = LongTermReceivablesStart + OtherLongTermReceivablesStart + InvestmentsStart + FixedAssetsStart
                 + IntangibleAssetsStart + LongTermAssetsStart;
            LongTermAssetsEnd = LongTermReceivablesEnd + OtherLongTermReceivablesEnd + InvestmentsEnd + FixedAssetsEnd
                 + IntangibleAssetsEnd + LongTermAssetsEnd;
        }


        /// <summary>
        /// Рассчитать Краткосрочные долги
        /// </summary>
        public void CalculateShortTermDebt()
        {
            ShortTermDebtStart = ShortTermBankLoansStart + DebtCitIitStart + DebtVatStart + OtherTaxesPayableStart
                 + PayablesToCounterpartiesShortTermDebtsStart + PayablesToEmployeesStart + OtherDebtsShortTermDebtsStart;
            ShortTermDebtEnd = ShortTermBankLoansEnd + DebtCitIitEnd + DebtVatEnd + OtherTaxesPayableEnd
                 + PayablesToCounterpartiesShortTermDebtsEnd + PayablesToEmployeesEnd + OtherDebtsShortTermDebtsEnd;
        }

        /// <summary>
        /// Рассчитать Долгосрочные долги
        /// </summary>
        public void CalculateLongTermDebt()
        {
            LongTermDebtStart = LongTermBankLoansStart + PayablesToCounterpartiesLongTermDebtsStart + DefferedTaxDebtsStart + OtherDebtsLongTermDebtsStart;
            LongTermDebtEnd = LongTermBankLoansEnd + PayablesToCounterpartiesLongTermDebtsEnd + DefferedTaxDebtsEnd + OtherDebtsLongTermDebtsEnd;
        }

        /// <summary>
        /// Рассчитать Краткосрочные активы
        /// </summary>
        public void CalculateOwnCapital()
        {
            OwnCapitalStart = AuthorizedCapitalStart + AccumulatedProfitAndLossStart + OtherCapitalStart;
            OwnCapitalEnd = AuthorizedCapitalEnd + AccumulatedProfitAndLossEnd + OtherCapitalEnd;
        }

        /// <summary>
        /// Рассчитать Итого активов
        /// </summary>
        public void CalculateTotalAssets()
        {
            TotalAssetsStart = ShortTermAssetsStart + LongTermAssetsStart;
            TotalAssetsEnd = ShortTermAssetsEnd + LongTermAssetsEnd;
        }

        /// <summary>
        /// Рассчитать Итого пассивов
        /// </summary>
        public void CalculateTotalLiabilities()
        {
            TotalLiabilitiesStart = TotalAssetsStart;//ShortTermDebtStart + LongTermDebtStart + OwnCapitalStart;
            TotalLiabilitiesEnd = TotalAssetsEnd;//ShortTermDebtEnd + LongTermDebtEnd + OwnCapitalEnd;
        }

        /// <summary>
        /// Рассчитать Накопленная прибыль/убыток
        /// </summary>
        public void CalculateAccumulatedProfitAndLoss()
        {
            AccumulatedProfitAndLossStart = TotalLiabilitiesStart - ShortTermDebtStart - LongTermDebtStart - AuthorizedCapitalStart - OtherCapitalStart;
            AccumulatedProfitAndLossEnd = TotalLiabilitiesEnd - ShortTermDebtEnd - LongTermDebtEnd - AuthorizedCapitalEnd - OtherCapitalEnd;
        }

        /// <summary>
        /// Рассчитать дополнительные налоговые активы (Все то, что в пассиве в минусе)
        /// </summary>
        public void CalculateAdditionalTaxAssets()
        {
            TaxAssetsStart = 1;
            TaxAssetsEnd = 1;
        }

        #endregion
    }
}
