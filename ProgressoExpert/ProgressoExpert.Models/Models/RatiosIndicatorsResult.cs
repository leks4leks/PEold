using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models
{
    public class RatiosIndicatorsResult: BaseViewModel
    {
        /// <summary>
        /// Начальная дата
        /// </summary>
        public DateTime StartDate
        {
            get { return _startDate; }
            set { SetValue(ref _startDate, value, "StartDate"); }
        }
        private DateTime _startDate;

        /// <summary>
        /// Конечная дата
        /// </summary>
        public DateTime EndDate
        {
            get { return _endDate; }
            set { SetValue(ref _endDate, value, "EndDate"); }
        }
        private DateTime _endDate;

        /// <summary>
        /// Покрытие текущей задолженности деньгами на начало периода
        /// </summary>
        public decimal CoveringCurrentDebtMoneyStart
        {
            get { return _coveringCurrentDebtMoneyStart; }
            set { SetValue(ref _coveringCurrentDebtMoneyStart, value, "CoveringCurrentDebtMoneyStart"); }
        }
        private decimal _coveringCurrentDebtMoneyStart;

        /// <summary>
        /// Покрытие текущей задолженности деньгами на конец периода
        /// </summary>
        public decimal CoveringCurrentDebtMoneyEnd
        {
            get { return _coveringCurrentDebtMoneyEnd; }
            set { SetValue(ref _coveringCurrentDebtMoneyEnd, value, "CoveringCurrentDebtMoneyEnd"); }
        }
        private decimal _coveringCurrentDebtMoneyEnd;

        /// <summary>
        /// Покрытие текущей задолженности деньгами и долгами клиентов на начало периода
        /// </summary>
        public decimal CoveringCurrentDebtMoneyAndCustomerDebtsStart
        {
            get { return _coveringCurrentDebtMoneyAndCustomerDebtsStart; }
            set { SetValue(ref _coveringCurrentDebtMoneyAndCustomerDebtsStart, value, "CoveringCurrentDebtMoneyAndCustomerDebtsStart"); }
        }
        private decimal _coveringCurrentDebtMoneyAndCustomerDebtsStart;

        /// <summary>
        /// Покрытие текущей задолженности деньгами и долгами клиентов на конец периода
        /// </summary>
        public decimal CoveringCurrentDebtMoneyAndCustomerDebtsEnd
        {
            get { return _coveringCurrentDebtMoneyAndCustomerDebtsEnd; }
            set { SetValue(ref _coveringCurrentDebtMoneyAndCustomerDebtsEnd, value, "CoveringCurrentDebtMoneyAndCustomerDebtsEnd"); }
        }
        private decimal _coveringCurrentDebtMoneyAndCustomerDebtsEnd;

        /// <summary>
        /// Покрытие текущей задолженности Оборотными активами на начало периода
        /// </summary>
        public decimal CoveringCurrentDebtOfCurrentAssetsStart
        {
            get { return _coveringCurrentDebtOfCurrentAssetsStart; }
            set { SetValue(ref _coveringCurrentDebtOfCurrentAssetsStart, value, "CoveringCurrentDebtOfCurrentAssetsStart"); }
        }
        private decimal _coveringCurrentDebtOfCurrentAssetsStart;

        /// <summary>
        /// Покрытие текущей задолженности Оборотными активами на конец периода
        /// </summary>
        public decimal CoveringCurrentDebtOfCurrentAssetsEnd
        {
            get { return _coveringCurrentDebtOfCurrentAssetsEnd; }
            set { SetValue(ref _coveringCurrentDebtOfCurrentAssetsEnd, value, "CoveringCurrentDebtOfCurrentAssetsEnd"); }
        }
        private decimal _coveringCurrentDebtOfCurrentAssetsEnd;

        /// <summary>
        /// Доля Задолженности в активах компании на начало периода
        /// </summary>
        public decimal DebtPartInTheCompanyAssetsStart
        {
            get { return _debtPartInTheCompanyAssetsStart; }
            set { SetValue(ref _debtPartInTheCompanyAssetsStart, value, "DebtPartInTheCompanyAssetsStart"); }
        }
        private decimal _debtPartInTheCompanyAssetsStart;

        /// <summary>
        /// Доля Задолженности в активах компании на конец периода
        /// </summary>
        public decimal DebtPartInTheCompanyAssetsEnd
        {
            get { return _debtPartInTheCompanyAssetsEnd; }
            set { SetValue(ref _debtPartInTheCompanyAssetsEnd, value, "DebtPartInTheCompanyAssetsEnd"); }
        }
        private decimal _debtPartInTheCompanyAssetsEnd;

        /// <summary>
        /// Доля Собственного капитала в активах компании на начало периода
        /// </summary>
        public decimal PartOfEquityInTheCompanyAssetsStart
        {
            get { return _partOfEquityInTheCompanyAssetsStart; }
            set { SetValue(ref _partOfEquityInTheCompanyAssetsStart, value, "PartOfEquityInTheCompanyAssetsStart"); }
        }
        private decimal _partOfEquityInTheCompanyAssetsStart;

        /// <summary>
        /// Доля Собственного капитала в активах компании на конец периода
        /// </summary>
        public decimal PartOfEquityInTheCompanyAssetsEnd
        {
            get { return _partOfEquityInTheCompanyAssetsEnd; }
            set { SetValue(ref _partOfEquityInTheCompanyAssetsEnd, value, "PartOfEquityInTheCompanyAssetsEnd"); }
        }
        private decimal _partOfEquityInTheCompanyAssetsEnd;

        /// <summary>
        /// Покрытие кредитов Собственным капиталом на начало периода
        /// </summary>
        public decimal CoveringLoansByEquityStart
        {
            get { return _coveringLoansByEquityStart; }
            set { SetValue(ref _coveringLoansByEquityStart, value, "CoveringLoansByEquityStart"); }
        }
        private decimal _coveringLoansByEquityStart;

        /// <summary>
        /// Покрытие кредитов Собственным капиталом на конец периода
        /// </summary>
        public decimal CoveringLoansByEquityEnd
        {
            get { return _coveringLoansByEquityEnd; }
            set { SetValue(ref _coveringLoansByEquityEnd, value, "CoveringLoansByEquityEnd"); }
        }
        private decimal _coveringLoansByEquityEnd;

        /// <summary>
        /// Скорость товарооборота 
        /// </summary>
        public decimal SpeedOfTurnover
        {
            get { return _speedOfTurnover; }
            set { SetValue(ref _speedOfTurnover, value, "SpeedOfTurnover"); }
        }
        private decimal _speedOfTurnover;

        /// <summary>
        /// Срок оборота долгов клиентов 
        /// </summary>
        public decimal TermOfCirculationOfClientsDebt
        {
            get { return _termOfCirculationOfClientsDebt; }
            set { SetValue(ref _termOfCirculationOfClientsDebt, value, "TermOfCirculationOfClientsDebt"); }
        }
        private decimal _termOfCirculationOfClientsDebt;

        /// <summary>
        /// Срок оборота задолженности перед поставщиками 
        /// </summary>
        public decimal TermOfCirculationOfDebtToSuppliers
        {
            get { return _termOfCirculationOfDebtToSuppliers; }
            set { SetValue(ref _termOfCirculationOfDebtToSuppliers, value, "TermOfCirculationOfDebtToSuppliers"); }
        }
        private decimal _termOfCirculationOfDebtToSuppliers;

        //#region Ликвидность

        ///// <summary>
        ///// Коэффициент абсолютной ликивдности
        ///// </summary>
        //public decimal AbsoluteLiquidityRatio
        //{
        //    get { return _absoluteLiquidityRatio; }
        //    set { SetValue(ref _absoluteLiquidityRatio, value, "AbsoluteLiquidityRatio"); }
        //}
        //private decimal _absoluteLiquidityRatio;

        ///// <summary>
        ///// Коэффициент быстрой ликвидности 
        ///// </summary>
        //public decimal QuickLiquidityRatio
        //{
        //    get { return _quickLiquidityRatio; }
        //    set { SetValue(ref _quickLiquidityRatio, value, "QuickLiquidityRatio"); }
        //}
        //private decimal _quickLiquidityRatio;

        ///// <summary>
        ///// Коэффициент текущей ликвидности 
        ///// </summary>
        //public decimal CurrentLiquidityRatio
        //{
        //    get { return _currentLiquidityRatio; }
        //    set { SetValue(ref _currentLiquidityRatio, value, "CurrentLiquidityRatio"); }
        //}
        //private decimal _currentLiquidityRatio;

        //#endregion

        //#region Показатели деловой активности

        ///// <summary>
        ///// Коэффициент оборачиваемости запасов
        ///// </summary>
        //public decimal InventoryTurnoverRatio
        //{
        //    get { return _inventoryTurnoverRatio; }
        //    set { SetValue(ref _inventoryTurnoverRatio, value, "InventoryTurnoverRatio"); }
        //}
        //private decimal _inventoryTurnoverRatio;

        ///// <summary>
        ///// Скорость товарооборота
        ///// </summary>
        //public decimal RateOfTurnover
        //{
        //    get { return _rateOfTurnover; }
        //    set { SetValue(ref _rateOfTurnover, value, "RateOfTurnover"); }
        //}
        //private decimal _rateOfTurnover;

        ///// <summary>
        ///// Коэффициент оборачиваемости дебиторской задолженности
        ///// </summary>
        //public decimal AccountsReceivableTurnoverRatio
        //{
        //    get { return _accountsReceivableTurnoverRatio; }
        //    set { SetValue(ref _accountsReceivableTurnoverRatio, value, "AccountsReceivableTurnoverRatio"); }
        //}
        //private decimal _accountsReceivableTurnoverRatio;

        ///// <summary>
        ///// Срок оборота дебиторской задолженности
        ///// </summary>
        //public decimal TermOfReceivablesTurnover
        //{
        //    get { return _termOfReceivablesTurnover; }
        //    set { SetValue(ref _termOfReceivablesTurnover, value, "TermOfReceivablesTurnover"); }
        //}
        //private decimal _termOfReceivablesTurnover;

        ///// <summary>
        ///// Коэффициент оборачиваемости кредиторской задолженности
        ///// </summary>
        //public decimal AccountsPayableTurnoverRatio
        //{
        //    get { return _accountsPayableTurnoverRatio; }
        //    set { SetValue(ref _accountsPayableTurnoverRatio, value, "AccountsPayableTurnoverRatio"); }
        //}
        //private decimal _accountsPayableTurnoverRatio;

        ///// <summary>
        ///// Срок оборота дебиторской задолженности
        ///// </summary>
        //public decimal TermOfPayablesTurnover
        //{
        //    get { return _termOfPayablesTurnover; }
        //    set { SetValue(ref _termOfPayablesTurnover, value, "TermOfPayablesTurnover"); }
        //}
        //private decimal _termOfPayablesTurnover;

        //#endregion

        //#region Показатели финансовой устойчивости

        ///// <summary>
        ///// Коэффициент автономии
        ///// </summary>
        //public decimal CoefficientOfAutonomy
        //{
        //    get { return _coefficientOfAutonomy; }
        //    set { SetValue(ref _coefficientOfAutonomy, value, "CoefficientOfAutonomy"); }
        //}
        //private decimal _coefficientOfAutonomy;

        ///// <summary>
        ///// Коэффициент финансовой зависимости 
        ///// </summary>
        //public decimal CoefficientOfFinancialDependence
        //{
        //    get { return _coefficientOfFinancialDependence; }
        //    set { SetValue(ref _coefficientOfFinancialDependence, value, "CoefficientOfFinancialDependence"); }
        //}
        //private decimal _coefficientOfFinancialDependence;

        //#endregion

        //#region Показатели рентабельности

        ///// <summary>
        ///// Коэффициент рентабельности основной деятельности
        ///// </summary>
        //public decimal CoefficientOfProfabilityPrimaryActivity
        //{
        //    get { return _coefficientOfProfabilityPrimaryActivity; }
        //    set { SetValue(ref _coefficientOfProfabilityPrimaryActivity, value, "CoefficientOfProfabilityPrimaryActivity"); }
        //}
        //private decimal _coefficientOfProfabilityPrimaryActivity;

        ///// <summary>
        ///// Коэффициент валовой рентабельности
        ///// </summary>
        //public decimal CoefficientOfGrossMargin
        //{
        //    get { return _coefficientOfGrossMargin; }
        //    set { SetValue(ref _coefficientOfGrossMargin, value, "CoefficientOfGrossMargin"); }
        //}
        //private decimal _coefficientOfGrossMargin;

        //#endregion

    }
}
