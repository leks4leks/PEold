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
        #region Ликвидность

        /// <summary>
        /// Коэффициент абсолютной ликивдности
        /// </summary>
        public decimal AbsoluteLiquidityRatio
        {
            get { return _absoluteLiquidityRatio; }
            set { SetValue(ref _absoluteLiquidityRatio, value, "AbsoluteLiquidityRatio"); }
        }
        private decimal _absoluteLiquidityRatio;

        /// <summary>
        /// Коэффициент быстрой ликвидности 
        /// </summary>
        public decimal QuickLiquidityRatio
        {
            get { return _quickLiquidityRatio; }
            set { SetValue(ref _quickLiquidityRatio, value, "QuickLiquidityRatio"); }
        }
        private decimal _quickLiquidityRatio;

        /// <summary>
        /// Коэффициент текущей ликвидности 
        /// </summary>
        public decimal CurrentLiquidityRatio
        {
            get { return _currentLiquidityRatio; }
            set { SetValue(ref _currentLiquidityRatio, value, "CurrentLiquidityRatio"); }
        }
        private decimal _currentLiquidityRatio;

        #endregion

        #region Показатели деловой активности

        /// <summary>
        /// Коэффициент оборачиваемости запасов
        /// </summary>
        public decimal InventoryTurnoverRatio
        {
            get { return _inventoryTurnoverRatio; }
            set { SetValue(ref _inventoryTurnoverRatio, value, "InventoryTurnoverRatio"); }
        }
        private decimal _inventoryTurnoverRatio;

        /// <summary>
        /// Скорость товарооборота
        /// </summary>
        public decimal RateOfTurnover
        {
            get { return _rateOfTurnover; }
            set { SetValue(ref _rateOfTurnover, value, "RateOfTurnover"); }
        }
        private decimal _rateOfTurnover;

        /// <summary>
        /// Коэффициент оборачиваемости дебиторской задолженности
        /// </summary>
        public decimal AccountsReceivableTurnoverRatio
        {
            get { return _accountsReceivableTurnoverRatio; }
            set { SetValue(ref _accountsReceivableTurnoverRatio, value, "AccountsReceivableTurnoverRatio"); }
        }
        private decimal _accountsReceivableTurnoverRatio;

        /// <summary>
        /// Срок оборота дебиторской задолженности
        /// </summary>
        public decimal TermOfReceivablesTurnover
        {
            get { return _termOfReceivablesTurnover; }
            set { SetValue(ref _termOfReceivablesTurnover, value, "TermOfReceivablesTurnover"); }
        }
        private decimal _termOfReceivablesTurnover;

        /// <summary>
        /// Коэффициент оборачиваемости кредиторской задолженности
        /// </summary>
        public decimal AccountsPayableTurnoverRatio
        {
            get { return _accountsPayableTurnoverRatio; }
            set { SetValue(ref _accountsPayableTurnoverRatio, value, "AccountsPayableTurnoverRatio"); }
        }
        private decimal _accountsPayableTurnoverRatio;

        /// <summary>
        /// Срок оборота дебиторской задолженности
        /// </summary>
        public decimal TermOfPayablesTurnover
        {
            get { return _termOfPayablesTurnover; }
            set { SetValue(ref _termOfPayablesTurnover, value, "TermOfPayablesTurnover"); }
        }
        private decimal _termOfPayablesTurnover;

        #endregion

        #region Показатели финансовой устойчивости

        /// <summary>
        /// Коэффициент автономии
        /// </summary>
        public decimal CoefficientOfAutonomy
        {
            get { return _coefficientOfAutonomy; }
            set { SetValue(ref _coefficientOfAutonomy, value, "CoefficientOfAutonomy"); }
        }
        private decimal _coefficientOfAutonomy;

        /// <summary>
        /// Коэффициент финансовой зависимости 
        /// </summary>
        public decimal CoefficientOfFinancialDependence
        {
            get { return _coefficientOfFinancialDependence; }
            set { SetValue(ref _coefficientOfFinancialDependence, value, "CoefficientOfFinancialDependence"); }
        }
        private decimal _coefficientOfFinancialDependence;

        #endregion

        #region Показатели рентабельности

        /// <summary>
        /// Коэффициент рентабельности основной деятельности
        /// </summary>
        public decimal CoefficientOfProfabilityPrimaryActivity
        {
            get { return _coefficientOfProfabilityPrimaryActivity; }
            set { SetValue(ref _coefficientOfProfabilityPrimaryActivity, value, "CoefficientOfProfabilityPrimaryActivity"); }
        }
        private decimal _coefficientOfProfabilityPrimaryActivity;

        /// <summary>
        /// Коэффициент валовой рентабельности
        /// </summary>
        public decimal CoefficientOfGrossMargin
        {
            get { return _coefficientOfGrossMargin; }
            set { SetValue(ref _coefficientOfGrossMargin, value, "CoefficientOfGrossMargin"); }
        }
        private decimal _coefficientOfGrossMargin;

        #endregion

    }
}
