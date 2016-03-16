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
        #region Оборотные активы

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

        #region Деньги на банковских счетах

        /// <summary>
        /// Деньги на банковских счетах на начало периода
        /// </summary>
        public decimal MoneyInTheBankAccountsStart
        {
            get { return _moneyInTheBankAccountsStart; }
            set { SetValue(ref _moneyInTheBankAccountsStart, value, "MoneyInTheBankAccountsStart"); }
        }
        private decimal _moneyInTheBankAccountsStart;

        /// <summary>
        /// Деньги на банковских счетах на конец периода
        /// </summary>
        public decimal MoneyInTheBankAccountsEnd
        {
            get { return _moneyInTheBankAccountsEnd; }
            set { SetValue(ref _moneyInTheBankAccountsEnd, value, "MoneyInTheBankAccountsEnd"); }
        }
        private decimal _moneyInTheBankAccountsEnd;

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

        #region Долги клиентов и переплаты

        /// <summary>
        /// Долги клиентов и переплаты на начало периода
        /// </summary>
        public decimal DebtsOfCustomersAndOverpaymentsStart
        {
            get { return _debtsOfCustomersAndOverpaymentsStart; }
            set { SetValue(ref _debtsOfCustomersAndOverpaymentsStart, value, "DebtsOfCustomersAndOverpaymentsStart"); }
        }
        private decimal _debtsOfCustomersAndOverpaymentsStart;

        /// <summary>
        /// Долги клиентов и переплаты на конец периода
        /// </summary>
        public decimal DebtsOfCustomersAndOverpaymentsEnd
        {
            get { return _debtsOfCustomersAndOverpaymentsEnd; }
            set { SetValue(ref _debtsOfCustomersAndOverpaymentsEnd, value, "DebtsOfCustomersAndOverpaymentsEnd"); }
        }
        private decimal _debtsOfCustomersAndOverpaymentsEnd;

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

        #region Прочие оборотные активы

        /// <summary>
        /// Прочие оборотные активы на начало периода
        /// </summary>
        public decimal OtherCurrentAssetsStart
        {
            get { return _otherCurrentAssetsStart; }
            set { SetValue(ref _otherCurrentAssetsStart, value, "OtherCurrentAssetsStart"); }
        }
        private decimal _otherCurrentAssetsStart;

        /// <summary>
        /// Прочие оборотные активы на конец периода
        /// </summary>
        public decimal OtherCurrentAssetsEnd
        {
            get { return _otherCurrentAssetsEnd; }
            set { SetValue(ref _otherCurrentAssetsEnd, value, "OtherCurrentAssetsEnd"); }
        }
        private decimal _otherCurrentAssetsEnd;

        #endregion

        #region Налоговые переплаты/авансы

        /// <summary>
        /// Налоговые переплаты/авансы на начало периода
        /// </summary>
        public decimal TaxOverpaymentsAndAdvancesStart
        {
            get { return _taxOverpaymentsAndAdvancesStart; }
            set { SetValue(ref _taxOverpaymentsAndAdvancesStart, value, "TaxOverpaymentsAndAdvancesStart"); }
        }
        private decimal _taxOverpaymentsAndAdvancesStart;

        /// <summary>
        /// Налоговые переплаты/авансы на конец периода
        /// </summary>
        public decimal TaxOverpaymentsAndAdvancesEnd
        {
            get { return _taxOverpaymentsAndAdvancesEnd; }
            set { SetValue(ref _taxOverpaymentsAndAdvancesEnd, value, "TaxOverpaymentsAndAdvancesEnd"); }
        }
        private decimal _taxOverpaymentsAndAdvancesEnd;

        #endregion

        #region Оборотные активы

        /// <summary>
        /// Оборотные активы на начало периода
        /// </summary>
        public decimal CirculatingAssetsStart
        {
            get { return _сirculatingAssetsStart; }
            set { SetValue(ref _сirculatingAssetsStart, value, "CirculatingAssetsStart"); }
        }
        private decimal _сirculatingAssetsStart;

        /// <summary>
        /// Оборотные активы на конец периода
        /// </summary>
        public decimal CirculatingAssetsEnd
        {
            get { return _сirculatingAssetsEnd; }
            set { SetValue(ref _сirculatingAssetsEnd, value, "CirculatingAssetsEnd"); }
        }
        private decimal _сirculatingAssetsEnd;

        #endregion

        #endregion

        #region Долгосрочные активы

        #region Долги клиентов (срок возврата более 1 года)

        /// <summary>
        /// Долги клиентов (срок возврата более 1 года) на начало периода
        /// </summary>
        public decimal CustomerDebtsStart
        {
            get { return _customerDebtsStart; }
            set { SetValue(ref _customerDebtsStart, value, "CustomerDebtsStart"); }
        }
        private decimal _customerDebtsStart;

        /// <summary>
        /// Долги клиентов (срок возврата более 1 года) на конец периода
        /// </summary>
        public decimal CustomerDebtsEnd
        {
            get { return _customerDebtsEnd; }
            set { SetValue(ref _customerDebtsEnd, value, "CustomerDebtsEnd"); }
        }
        private decimal _customerDebtsEnd;

        #endregion

        #region Прочие долги клиентов/переплаты

        /// <summary>
        /// Прочие долги клиентов/переплаты  на начало периода
        /// </summary>
        public decimal OtherDebtsOfClientsAndOverpaymentStart
        {
            get { return _otherDebtsOfClientsAndOverpaymentStart; }
            set { SetValue(ref _otherDebtsOfClientsAndOverpaymentStart, value, "OtherDebtsOfClientsAndOverpaymentStart"); }
        }
        private decimal _otherDebtsOfClientsAndOverpaymentStart;

        /// <summary>
        /// Прочие долги клиентов/переплаты  на конец периода
        /// </summary>
        public decimal OtherDebtsOfClientsAndOverpaymentEnd
        {
            get { return _otherDebtsOfClientsAndOverpaymentEnd; }
            set { SetValue(ref _otherDebtsOfClientsAndOverpaymentEnd, value, "OtherDebtsOfClientsAndOverpaymentEnd"); }
        }
        private decimal _otherDebtsOfClientsAndOverpaymentEnd;

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

        #region Отложенные налоговые переплаты/авансы

        /// <summary>
        /// Отложенные налоговые переплаты/авансы на начало периода
        /// </summary>
        public decimal TheDeferredTaxOverpaymentsAndAdvancesStart
        {
            get { return _theDeferredTaxOverpaymentsAndAdvancesStart; }
            set { SetValue(ref _theDeferredTaxOverpaymentsAndAdvancesStart, value, "TheDeferredTaxOverpaymentsAndAdvancesStart"); }
        }
        private decimal _theDeferredTaxOverpaymentsAndAdvancesStart;

        /// <summary>
        /// Отложенные налоговые переплаты/авансы на конец периода
        /// </summary>
        public decimal TheDeferredTaxOverpaymentsAndAdvancesEnd
        {
            get { return _theDeferredTaxOverpaymentsAndAdvancesEnd; }
            set { SetValue(ref _theDeferredTaxOverpaymentsAndAdvancesEnd, value, "TheDeferredTaxOverpaymentsAndAdvancesEnd"); }
        }
        private decimal _theDeferredTaxOverpaymentsAndAdvancesEnd;

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

        #region Текущая задолженность

        #region Кредиты сроком до 1 года

        /// <summary>
        /// Кредиты сроком до 1 года на начало периода
        /// </summary>
        public decimal CreditsForOneYearStart
        {
            get { return _creditsForOneYearStart; }
            set { SetValue(ref _creditsForOneYearStart, value, "CreditsForOneYearStart"); }
        }
        private decimal _creditsForOneYearStart;

        /// <summary>
        /// Кредиты сроком до 1 года на конец периода
        /// </summary>
        public decimal CreditsForOneYearEnd
        {
            get { return _creditsForOneYearEnd; }
            set { SetValue(ref _creditsForOneYearEnd, value, "CreditsForOneYearEnd"); }
        }
        private decimal _creditsForOneYearEnd;

        #endregion

        #region Задолженность по КПН/ИПН

        /// <summary>
        /// Задолженность по КПН/ИПН на начало периода
        /// </summary>
        public decimal DebtCitIitStart
        {
            get { return _debtCitIitStart; }
            set { SetValue(ref _debtCitIitStart, value, "DebtCitIitStart"); }
        }
        private decimal _debtCitIitStart;

        /// <summary>
        /// Задолженность по КПН/ИПН на конец периода
        /// </summary>
        public decimal DebtCitIitEnd
        {
            get { return _debtCitIitEnd; }
            set { SetValue(ref _debtCitIitEnd, value, "DebtCitIitEnd"); }
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

        #region Задолженность перед поставщиками

        /// <summary>
        /// Задолженность перед поставщиками на начало периода
        /// </summary>
        public decimal PayablesToSuppliersShortTermDebtsStart
        {
            get { return _payablesToSuppliersShortTermDebtsStart; }
            set { SetValue(ref _payablesToSuppliersShortTermDebtsStart, value, "PayablesToSuppliersShortTermDebtsStart"); }
        }
        private decimal _payablesToSuppliersShortTermDebtsStart;

        /// <summary>
        /// Задолженность перед поставщиками на конец периода
        /// </summary>
        public decimal PayablesToSuppliersShortTermDebtsEnd
        {
            get { return _payablesToSuppliersShortTermDebtsEnd; }
            set { SetValue(ref _payablesToSuppliersShortTermDebtsEnd, value, "PayablesToSuppliersShortTermDebtsEnd"); }
        }
        private decimal _payablesToSuppliersShortTermDebtsEnd;

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

        #region Текущая задолженность

        /// <summary>
        /// Текущая задолженность на начало периода
        /// </summary>
        public decimal CurrentDebtStart
        {
            get { return _currentDebtStart; }
            set { SetValue(ref _currentDebtStart, value, "CurrentDebtStart"); }
        }
        private decimal _currentDebtStart;

        /// <summary>
        /// Текущая задолженность на конец периода
        /// </summary>
        public decimal CurrentDebtEnd
        {
            get { return _currentDebtEnd; }
            set { SetValue(ref _currentDebtEnd, value, "CurrentDebtEnd"); }
        }
        private decimal _currentDebtEnd;

        #endregion

        #endregion

        #region Долгосрочная задолженность

        #region Кредиты сроком более 1 года

        /// <summary>
        /// Кредиты сроком более 1 года на начало периода
        /// </summary>
        public decimal CreditsForLongerThanOneYearStart
        {
            get { return _creditsForLongerThanOneYearStart; }
            set { SetValue(ref _creditsForLongerThanOneYearStart, value, "CreditsForLongerThanOneYearStart"); }
        }
        private decimal _creditsForLongerThanOneYearStart;

        /// <summary>
        /// Кредиты сроком более 1 года на конец периода
        /// </summary>
        public decimal CreditsForLongerThanOneYearEnd
        {
            get { return _creditsForLongerThanOneYearEnd; }
            set { SetValue(ref _creditsForLongerThanOneYearEnd, value, "CreditsForLongerThanOneYearEnd"); }
        }
        private decimal _creditsForLongerThanOneYearEnd;

        #endregion

        #region Задолженность перед поставщиками

        /// <summary>
        /// Задолженность перед поставщиками на начало периода
        /// </summary>
        public decimal PayablesToSuppliersLongTermDebtsStart
        {
            get { return _payablesToSuppliersLongTermDebtsStart; }
            set { SetValue(ref _payablesToSuppliersLongTermDebtsStart, value, "PayablesToSuppliersLongTermDebtsStart"); }
        }
        private decimal _payablesToSuppliersLongTermDebtsStart;

        /// <summary>
        /// Задолженность перед поставщиками на конец периода
        /// </summary>
        public decimal PayablesToSuppliersLongTermDebtsEnd
        {
            get { return _payablesToSuppliersLongTermDebtsEnd; }
            set { SetValue(ref _payablesToSuppliersLongTermDebtsEnd, value, "PayablesToSuppliersLongTermDebtsEnd"); }
        }
        private decimal _payablesToSuppliersLongTermDebtsEnd;

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

        #region Долгосрочная задолженность

        /// <summary>
        /// Долгосрочная задолженность на начало периода
        /// </summary>
        public decimal LongTermDebtStart
        {
            get { return _longTermDebtStart; }
            set { SetValue(ref _longTermDebtStart, value, "LongTermDebtStart"); }
        }
        private decimal _longTermDebtStart;

        /// <summary>
        /// Долгосрочная задолженность на конец периода
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
        /// Рассчитать Оборотные активы
        /// </summary>
        public void CalculateCirculatingAssets()
        {
            CirculatingAssetsStart = CashInCashBoxStart + MoneyInTheBankAccountsStart + DepositsStart + DebtsOfCustomersAndOverpaymentsStart
                 + RawAndMaterialsStart + GoodsStart + UnfinishedProductionStart + OtherCurrentAssetsStart + TaxOverpaymentsAndAdvancesStart;
            CirculatingAssetsEnd = CashInCashBoxEnd + MoneyInTheBankAccountsEnd + DepositsEnd + DebtsOfCustomersAndOverpaymentsEnd
                 + RawAndMaterialsEnd + GoodsEnd + UnfinishedProductionEnd + OtherCurrentAssetsEnd + TaxOverpaymentsAndAdvancesEnd;
        }

        /// <summary>
        /// Рассчитать Долгосрочные активы
        /// </summary>
        public void CalculateLongTermAssets()
        {
            LongTermAssetsStart = CustomerDebtsStart + OtherDebtsOfClientsAndOverpaymentStart + InvestmentsStart + FixedAssetsStart
                 + IntangibleAssetsStart + LongTermAssetsStart;
            LongTermAssetsEnd = CustomerDebtsEnd + OtherDebtsOfClientsAndOverpaymentEnd + InvestmentsEnd + FixedAssetsEnd
                 + IntangibleAssetsEnd + LongTermAssetsEnd;
        }


        /// <summary>
        /// Рассчитать Текущую задолженность
        /// </summary>
        public void CalculateCurrentDebt()
        {
            CurrentDebtStart = CreditsForOneYearStart 
                + CheckDenailOf(ref _debtCitIitStart, ref _taxOverpaymentsAndAdvancesStart) 
                + CheckDenailOf(ref _debtVatStart, ref _taxOverpaymentsAndAdvancesStart)
                + CheckDenailOf(ref _otherTaxesPayableStart, ref _taxOverpaymentsAndAdvancesStart)
                + CheckDenailOf(ref _debtsOfCustomersAndOverpaymentsStart, ref _payablesToSuppliersShortTermDebtsStart) 
                + CheckDenailOf(ref _payablesToEmployeesStart, ref _otherCurrentAssetsStart)
                + CheckDenailOf(ref _otherDebtsShortTermDebtsStart, ref _otherCurrentAssetsStart);
            CurrentDebtEnd = CreditsForOneYearEnd
                + CheckDenailOf(ref _debtCitIitEnd, ref _taxOverpaymentsAndAdvancesEnd)
                + CheckDenailOf(ref _debtVatEnd, ref _taxOverpaymentsAndAdvancesEnd)
                + CheckDenailOf(ref _otherTaxesPayableEnd, ref _taxOverpaymentsAndAdvancesEnd)
                + CheckDenailOf(ref _debtsOfCustomersAndOverpaymentsEnd, ref _payablesToSuppliersShortTermDebtsEnd)
                + CheckDenailOf(ref _payablesToEmployeesEnd, ref _otherCurrentAssetsEnd)
                + CheckDenailOf(ref _otherDebtsShortTermDebtsEnd, ref _otherCurrentAssetsEnd);
        }

        /// <summary>
        /// Рассчитать Долгосрочную задолженность
        /// </summary>
        public void CalculateLongTermDebt()
        {
            LongTermDebtStart = CreditsForLongerThanOneYearStart 
                + CheckDenailOf(ref _payablesToSuppliersLongTermDebtsStart, ref _otherDebtsOfClientsAndOverpaymentStart)
                + CheckDenailOf(ref _defferedTaxDebtsStart, ref _theDeferredTaxOverpaymentsAndAdvancesStart) 
                + CheckDenailOf(ref _otherDebtsLongTermDebtsStart, ref _otherDebtsOfClientsAndOverpaymentStart);
            LongTermDebtEnd = CreditsForLongerThanOneYearEnd
                + CheckDenailOf(ref _payablesToSuppliersLongTermDebtsEnd, ref _otherDebtsOfClientsAndOverpaymentEnd)
                + CheckDenailOf(ref _defferedTaxDebtsEnd, ref _theDeferredTaxOverpaymentsAndAdvancesEnd) 
                + CheckDenailOf(ref _otherDebtsLongTermDebtsEnd, ref _otherDebtsOfClientsAndOverpaymentEnd);
        }

        /// <summary>
        /// Рассчитать Собственный капитал
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
            TotalAssetsStart = CirculatingAssetsStart + LongTermAssetsStart;
            TotalAssetsEnd = CirculatingAssetsEnd + LongTermAssetsEnd;
        }

        /// <summary>
        /// Рассчитать Итого пассивов
        /// </summary>
        public void CalculateTotalLiabilities()
        {
            TotalLiabilitiesStart = TotalAssetsStart;//CurrentDebtStart + LongTermDebtStart + OwnCapitalStart;
            TotalLiabilitiesEnd = TotalAssetsEnd;//CurrentDebtEnd + LongTermDebtEnd + OwnCapitalEnd;
        }

        /// <summary>
        /// Рассчитать Накопленная прибыль/убыток
        /// </summary>
        public void CalculateAccumulatedProfitAndLoss()
        {
            AccumulatedProfitAndLossStart = TotalLiabilitiesStart - CurrentDebtStart - LongTermDebtStart - AuthorizedCapitalStart - OtherCapitalStart;
            AccumulatedProfitAndLossEnd = TotalLiabilitiesEnd - CurrentDebtEnd - LongTermDebtEnd - AuthorizedCapitalEnd - OtherCapitalEnd;
        }

        #endregion

        /// <summary>
        /// Проверка на отрицание
        /// </summary>
        /// <param name="value">Проверяемое значние</param>
        /// <param name="finalValue">Итоговое значение, к которому прибавляется проверяемое значение в случае наличия отрицания</param>
        /// <returns></returns>
        private decimal CheckDenailOf(ref decimal value, ref decimal finalValue)
        {
            if (value < 0)
            {
                finalValue += Math.Abs(value);
                value = 0;
            }
            return value;
        }
    }
}
