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
        /// <summary>
        /// Денежные средства на начало периода
        /// </summary>
        public decimal BankrollStart
        {
            get { return _bankrollStart; }
            set { SetValue(ref _bankrollStart, value, "BankrollStart"); }
        }
        private decimal _bankrollStart;

        /// <summary>
        /// Денежные средства на конец периода
        /// </summary>
        public decimal BankrollEnd
        {
            get { return _bankrollEnd; }
            set { SetValue(ref _bankrollEnd, value, "BankrollEnd"); }
        }
        private decimal _bankrollEnd;

        /// <summary>
        /// Дебиторская задолженность на начало периода
        /// </summary>
        public decimal ReceivablesStart
        {
            get { return _shortTermReceivablesStart; }
            set { SetValue(ref _shortTermReceivablesStart, value, "ReceivablesStart"); }
        }
        private decimal _shortTermReceivablesStart;

        /// <summary>
        /// Дебиторская задолженность на конец периода
        /// </summary>
        public decimal ReceivablesEnd
        {
            get { return _shortTermReceivablesEnd; }
            set { SetValue(ref _shortTermReceivablesEnd, value, "ReceivablesEnd"); }
        }
        private decimal _shortTermReceivablesEnd;

        /// <summary>
        /// Товары (запасы) на начало периода
        /// </summary>
        public decimal InventoriesStart
        {
            get { return _inventoriesStart; }
            set { SetValue(ref _inventoriesStart, value, "InventoriesStart"); }
        }
        private decimal _inventoriesStart;

        /// <summary>
        /// Товары (запасы) на конец периода
        /// </summary>
        public decimal InventoriesEnd
        {
            get { return _inventoriesEnd; }
            set { SetValue(ref _inventoriesEnd, value, "InventoriesEnd"); }
        }
        private decimal _inventoriesEnd;

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

        /// <summary>
        /// Итого краткосрочные активы на начало периода
        /// </summary>
        public decimal TotalCurrentAssetsStart
        {
            get { return _totalCurrentAssetsStart; }
            set { SetValue(ref _totalCurrentAssetsStart, value, "TotalCurrentAssetsStart"); }
        }
        private decimal _totalCurrentAssetsStart;

        /// <summary>
        /// Итого краткосрочные активы на конец периода
        /// </summary>
        public decimal TotalCurrentAssetsEnd
        {
            get { return _totalCurrentAssetsEnd; }
            set { SetValue(ref _totalCurrentAssetsEnd, value, "TotalCurrentAssetsEnd"); }
        }
        private decimal _totalCurrentAssetsEnd;

        /// <summary>
        /// Оборудование на начало периода
        /// </summary>
        public decimal EquipmentStart
        {
            get { return _equipmentStart; }
            set { SetValue(ref _equipmentStart, value, "EquipmentStart"); }
        }
        private decimal _equipmentStart;

        /// <summary>
        /// Оборудование на конец периода
        /// </summary>
        public decimal EquipmentEnd
        {
            get { return _equipmentEnd; }
            set { SetValue(ref _equipmentEnd, value, "EquipmentEnd"); }
        }
        private decimal _equipmentEnd;

        /// <summary>
        /// Прочий инвентарь на начало периода
        /// </summary>
        public decimal OtherEquipmentStart
        {
            get { return _otherEquipmentStart; }
            set { SetValue(ref _otherEquipmentStart, value, "OtherEquipmentStart"); }
        }
        private decimal _otherEquipmentStart;

        /// <summary>
        /// Прочий инвентарь на конец периода
        /// </summary>
        public decimal OtherEquipmentEnd
        {
            get { return _otherEquipmentEnd; }
            set { SetValue(ref _otherEquipmentEnd, value, "OtherEquipmentEnd"); }
        }
        private decimal _otherEquipmentEnd;

        /// <summary>
        /// Итого валюта баланса на начало периода
        /// </summary>
        public decimal TotalBalanceCurrencyStart
        {
            get { return _totalBalanceCurrencyStart; }
            set { SetValue(ref _totalBalanceCurrencyStart, value, "TotalBalanceCurrencyStart"); }
        }
        private decimal _totalBalanceCurrencyStart;

        /// <summary>
        /// Итого валюта баланса на конец периода
        /// </summary>
        public decimal TotalBalanceCurrencyEnd
        {
            get { return _totalBalanceCurrencyEnd; }
            set { SetValue(ref _totalBalanceCurrencyEnd, value, "TotalBalanceCurrencyEnd"); }
        }
        private decimal _totalBalanceCurrencyEnd;



        /// <summary>
        /// Долги перед Банком на начало периода
        /// </summary>
        public decimal DebtsBanksStart
        {
            get { return _shortTermDebtsBanksStart; }
            set { SetValue(ref _shortTermDebtsBanksStart, value, "DebtsBanksStart"); }
        }
        private decimal _shortTermDebtsBanksStart;

        /// <summary>
        /// Долги перед Банком на конец периода
        /// </summary>
        public decimal DebtsBanksEnd
        {
            get { return _shortTermDebtsBanksEnd; }
            set { SetValue(ref _shortTermDebtsBanksEnd, value, "DebtsBanksEnd"); }
        }
        private decimal _shortTermDebtsBanksEnd;

        
        /// <summary>
        /// Долги перед налоговой на начало периода
        /// </summary>
        public decimal DebtsTaxAndOtherPaymentsBudgetStart
        {
            get { return _debtsTaxAndOtherPaymentsBudgetStart; }
            set { SetValue(ref _debtsTaxAndOtherPaymentsBudgetStart, value, "DebtsTaxAndOtherPaymentsBudgetStart"); }
        }
        private decimal _debtsTaxAndOtherPaymentsBudgetStart;

        /// <summary>
        /// Долги перед налоговой на конец периода
        /// </summary>
        public decimal DebtsTaxAndOtherPaymentsBudgetEnd
        {
            get { return _debtsTaxAndOtherPaymentsBudgetEnd; }
            set { SetValue(ref _debtsTaxAndOtherPaymentsBudgetEnd, value, "DebtsTaxAndOtherPaymentsBudgetEnd"); }
        }
        private decimal _debtsTaxAndOtherPaymentsBudgetEnd;


        /// <summary>
        /// Долги перед поставщиками/покупателями на начало периода
        /// </summary>
        public decimal DebtsSupplierBuyersStart
        {
            get { return _shortTermDebtsSupplierBuyersStart; }
            set { SetValue(ref _shortTermDebtsSupplierBuyersStart, value, "ShortTermDebtsSupplierBuyersStart"); }
        }
        private decimal _shortTermDebtsSupplierBuyersStart;

        /// <summary>
        /// Долги перед поставщиками/покупателями на конец периода
        /// </summary>
        public decimal DebtsSupplierBuyersEnd
        {
            get { return _shortTermDebtsSupplierBuyersEnd; }
            set { SetValue(ref _shortTermDebtsSupplierBuyersEnd, value, "DebtsSupplierBuyersEnd"); }
        }
        private decimal _shortTermDebtsSupplierBuyersEnd;


        /// <summary>
        /// Прочие долги на начало периода
        /// </summary>
        public decimal OtherDebtsStart
        {
            get { return _otherDebtsStart; }
            set { SetValue(ref _otherDebtsStart, value, "OtherDebtsStart"); }
        }
        private decimal _otherDebtsStart;

        /// <summary>
        /// Прочие долги на конец периода
        /// </summary>
        public decimal OtherDebtsEnd
        {
            get { return _otherDebtsEnd; }
            set { SetValue(ref _otherDebtsEnd, value, "OtherDebtsEnd"); }
        }
        private decimal _otherDebtsEnd;

        /// <summary>
        /// Итого кредиторская задолженность на конец периода
        /// </summary>
        public decimal TotalAccountsPayableStart
        {
            get { return _totalAccountsPayableStart; }
            set { SetValue(ref _totalAccountsPayableStart, value, "TotalAccountsPayableStart"); }
        }
        private decimal _totalAccountsPayableStart;

        /// <summary>
        /// Итого кредиторская задолженность на конец периода
        /// </summary>
        public decimal TotalAccountsPayableEnd
        {
            get { return _totalAccountsPayableEnd; }
            set { SetValue(ref _totalAccountsPayableEnd, value, "TotalAccountsPayableEnd"); }
        }
        private decimal _totalAccountsPayableEnd;

        /// <summary>
        /// Собственный капитал на конец периода
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




        /// <summary>
        /// Итого краткосрочные активы
        /// </summary>
        public void CalculateTotalCurrentAssetsStartEnd()
        {
            TotalCurrentAssetsStart = BankrollStart + ReceivablesStart + InventoriesStart + OtherCurrentAssetsStart;
            TotalCurrentAssetsEnd = BankrollEnd + ReceivablesEnd + InventoriesEnd + OtherCurrentAssetsEnd;
        }

        /// <summary>
        /// Итого валюта баланса
        /// </summary>
        public void CalculateTotalBalanceCurrencyStartEnd()
        {
            TotalBalanceCurrencyStart = TotalCurrentAssetsStart + EquipmentStart + OtherEquipmentStart;
            TotalBalanceCurrencyEnd = TotalCurrentAssetsEnd + EquipmentEnd + OtherEquipmentEnd;
        }

        /// <summary>
        /// Итого кредиторская задолженность
        /// </summary>
        public void CalculateTotalAccountsPayableStartEnd()
        {
            TotalAccountsPayableStart = DebtsBanksStart + DebtsTaxAndOtherPaymentsBudgetStart + DebtsSupplierBuyersStart + OtherDebtsStart;
            TotalAccountsPayableEnd = DebtsBanksEnd + DebtsTaxAndOtherPaymentsBudgetEnd + DebtsSupplierBuyersEnd + OtherDebtsEnd;
        }

        /// <summary>
        /// Собственный капитал
        /// </summary>
        public void CalculateOwnCapitalStartEnd()
        {
            OwnCapitalStart = TotalBalanceCurrencyStart - TotalAccountsPayableStart;
            OwnCapitalEnd = TotalBalanceCurrencyStart - TotalAccountsPayableEnd;
        }
    }
}
