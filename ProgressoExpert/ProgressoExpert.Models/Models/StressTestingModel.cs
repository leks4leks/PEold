using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models
{
    public class StressTestingModel : BaseViewModel
    {
        #region Диаграммы
        /// <summary>
        /// Продажи факт
        /// </summary>
        public decimal Sales
        {
            get { return _sales; }
            set { SetValue(ref _sales, value, "Sales"); }
        }
        private decimal _sales;

        /// <summary>
        /// Продажи прогноз
        /// </summary>
        public decimal SalesForecast
        {
            get { return _salesForecast; }
            set { SetValue(ref _salesForecast, value, "SalesForecast"); }
        }
        private decimal _salesForecast;

        /// <summary>
        /// Валовая прибыль факт
        /// </summary>
        public decimal GrossProfit
        {
            get { return _grossProfit; }
            set { SetValue(ref _grossProfit, value, "GrossProfit"); }
        }
        private decimal _grossProfit;

        /// <summary>
        /// Валовая прибыль прогноз
        /// </summary>
        public decimal GrossProfitForecast
        {
            get { return _grossProfitForecast; }
            set { SetValue(ref _grossProfitForecast, value, "GrossProfitForecast"); }
        }
        private decimal _grossProfitForecast;

        /// <summary>
        /// Чистая прибыль факт
        /// </summary>
        public decimal NetProfit
        {
            get { return _netProfit; }
            set { SetValue(ref _netProfit, value, "NetProfit"); }
        }
        private decimal _netProfit;

        /// <summary>
        /// Чистая прибыль прогноз
        /// </summary>
        public decimal NetProfitForecast
        {
            get { return _netProfitForecast; }
            set { SetValue(ref _netProfitForecast, value, "NetProfitForecast"); }
        }
        private decimal _netProfitForecast;

        #endregion

        #region Данные по полям

        /// <summary>
        /// Продажи общее
        /// </summary>
        public decimal SalesGeneral
        {
            get { return _salesGeneral; }
            set { SetValue(ref _salesGeneral, value, "SalesGeneral"); }
        }
        private decimal _salesGeneral;

        /// <summary>
        /// Продажи 3-м клиентам
        /// </summary>
        public decimal SalesTop3Clients
        {
            get { return _salesTop3Clients; }
            set { SetValue(ref _salesTop3Clients, value, "SalesTop3Clients"); }
        }
        private decimal _salesTop3Clients;

        /// <summary>
        /// Продажи самого популярного товара
        /// </summary>
        public decimal SalesTopProduct
        {
            get { return _salesTopProduct; }
            set { SetValue(ref _salesTopProduct, value, "SalesTopProduct"); }
        }
        private decimal _salesTopProduct;

        /// <summary>
        /// Продажи 3 популярных товаров
        /// </summary>
        public decimal SalesTop3Products
        {
            get { return _salesTop3Products; }
            set { SetValue(ref _salesTop3Products, value, "SalesTop3Products"); }
        }
        private decimal _salesTop3Products;

        /// <summary>
        /// Рентабельность Общее
        /// </summary>
        public decimal ProfitabilityGeneral
        {
            get { return _profabilityGeneral; }
            set { SetValue(ref _profabilityGeneral, value, "ProfitabilityGeneral"); }
        }
        private decimal _profabilityGeneral;

        /// <summary>
        /// Рентабельность Общее %
        /// </summary>
        public decimal ProfitabilityGeneralPerc
        {
            get { return _profabilityGeneralPerc; }
            set { SetValue(ref _profabilityGeneralPerc, value, "ProfitabilityGeneralPerc"); }
        }
        private decimal _profabilityGeneralPerc;

        /// <summary>
        /// Рентабельность 3-х клиентов
        /// </summary>
        public decimal ProfitabilityTop3Clients
        {
            get { return _profabilityTop3Clients; }
            set { SetValue(ref _profabilityTop3Clients, value, "ProfitabilityTop3Clients"); }
        }
        private decimal _profabilityTop3Clients;

        /// <summary>
        /// Рентабельность самого популярного товара
        /// </summary>
        public decimal ProfitabilityTopProduct
        {
            get { return _profabilityTopProduct; }
            set { SetValue(ref _profabilityTopProduct, value, "ProfitabilityTopProduct"); }
        }
        private decimal _profabilityTopProduct;

        /// <summary>
        /// Рентабельность 3-х товаров
        /// </summary>
        public decimal ProfitabilityTop3Products
        {
            get { return _profabilityTop3Products; }
            set { SetValue(ref _profabilityTop3Products, value, "ProfitabilityTop3Products"); }
        }
        private decimal _profabilityTop3Products;

        /// <summary>
        /// Расходы
        /// </summary>
        public decimal Expenses
        {
            get { return _expenses; }
            set { SetValue(ref _expenses, value, "Expenses"); }
        }
        private decimal _expenses;

        #endregion

        #region Проценты

        /// <summary>
        /// Продажи общее (Проценты)
        /// </summary>
        public int SalesGeneralPercentage
        {
            get { return _salesGeneralPercentage; }
            set { SetValue(ref _salesGeneralPercentage, value, "SalesGeneralPercentage"); }
        }
        private int _salesGeneralPercentage;

        /// <summary>
        /// Продажи 3-м клиентам (Проценты)
        /// </summary>
        public int SalesTop3ClientsPercentage
        {
            get { return _salesTop3ClientsPercentage; }
            set { SetValue(ref _salesTop3ClientsPercentage, value, "SalesTop3ClientsPercentage"); }
        }
        private int _salesTop3ClientsPercentage;

        /// <summary>
        /// Продажи самого популярного товара (Проценты)
        /// </summary>
        public int SalesTopProductPercentage
        {
            get { return _salesTopProductPercentage; }
            set { SetValue(ref _salesTopProductPercentage, value, "SalesTopProductPercentage"); }
        }
        private int _salesTopProductPercentage;

        /// <summary>
        /// Продажи 3 популярных товаров (Проценты)
        /// </summary>
        public int SalesTop3ProductsPercentage
        {
            get { return _salesTop3ProductsPercentage; }
            set { SetValue(ref _salesTop3ProductsPercentage, value, "SalesTop3ProductsPercentage"); }
        }
        private int _salesTop3ProductsPercentage;

        /// <summary>
        /// Рентабельность Общее (Проценты)
        /// </summary>
        public int ProfitabilityGeneralPercentage
        {
            get { return _profitabilityGeneralPercentage; }
            set { SetValue(ref _profitabilityGeneralPercentage, value, "ProfitabilityGeneralPercentage"); }
        }
        private int _profitabilityGeneralPercentage;

        /// <summary>
        /// Рентабельность 3-х клиентов (Проценты)
        /// </summary>
        public int ProfitabilityTop3ClientsPercentage
        {
            get { return _profitabilityTop3ClientsPercentage; }
            set { SetValue(ref _profitabilityTop3ClientsPercentage, value, "ProfitabilityTop3ClientsPercentage"); }
        }
        private int _profitabilityTop3ClientsPercentage;

        /// <summary>
        /// Рентабельность самого популярного товара (Проценты)
        /// </summary>
        public int ProfitabilityTopProductPercentage
        {
            get { return _profitabilityTopProductPercentage; }
            set { SetValue(ref _profitabilityTopProductPercentage, value, "ProfitabilityTopProductPercentage"); }
        }
        private int _profitabilityTopProductPercentage;

        /// <summary>
        /// Рентабельность 3-х товаров (Проценты)
        /// </summary>
        public int ProfitabilityTop3ProductsPercentage
        {
            get { return _profitabilityTop3ProductsPercentage; }
            set { SetValue(ref _profitabilityTop3ProductsPercentage, value, "ProfitabilityTop3ProductsPercentage"); }
        }
        private int _profitabilityTop3ProductsPercentage;

        /// <summary>
        /// Расходы (Проценты)
        /// </summary>
        public int ExpensesPercentage
        {
            get { return _expensesPercentage; }
            set { SetValue(ref _expensesPercentage, value, "ExpensesPercentage"); }
        }
        private int _expensesPercentage;

        /// <summary>
        /// Продажи разница - (Проценты)
        /// </summary>
        public decimal SalesPercentageValue
        {
            get { return _salesPercentageValue; }
            set { SetValue(ref _salesPercentageValue, value, "SalesPercentageValue"); }
        }
        private decimal _salesPercentageValue;

        /// <summary>
        /// Валовая прибыль -  разница (Проценты)
        /// </summary>
        public decimal GrossProfitPercentageValue
        {
            get { return _grossProfitPercentageValue; }
            set { SetValue(ref _grossProfitPercentageValue, value, "GrossProfitPercentageValue"); }
        }
        private decimal _grossProfitPercentageValue;

        /// <summary>
        /// Чистая прибыль -  разница (Проценты)
        /// </summary>
        public decimal NetProfitPercentageValue
        {
            get { return _netProfitPercentageValue; }
            set { SetValue(ref _netProfitPercentageValue, value, "NetProfitPercentageValue"); }
        }
        private decimal _netProfitPercentageValue;

        #endregion


        //#region Продажи

        ///// <summary>
        ///// Продажи Прогноз (Общее) = продажи (за базовый период)*(100%+изменение%);
        ///// </summary>
        //public void CalculateSalesGeneral()
        //{
        //    this.SalesForecast = this.Sales + (this.SalesGeneral * this.SalesGeneralPercentage / 100);//this.Sales * ((100 + this.SalesGeneralPercentage) / 100);
        //}

        ///// <summary>
        ///// Продажи прогноз (3 крупных клиента) = Продажи факт - продажи факт по 3-м крупным клиентам 
        ///// + продажи факт по 3-м крупным клиентам * (100% + изменение%).
        ///// </summary>
        //public void CalculateSalesTop3Clients()
        //{
        //    this.SalesForecast = this.Sales + (this.SalesTop3Clients * this.SalesTop3ClientsPercentage / 100); //this.Sales - this.SalesTop3Clients + (this.SalesTop3Clients + this.SalesTop3Clients * (100 + this.SalesTop3ClientsPercentage) / 100);
        //}

        ///// <summary>
        ///// Продажи прогноз (Самый популярный товар)
        ///// </summary>
        ///// <param name="sales"></param>
        //public void CalculateSalesTopProduct()
        //{
        //    this.SalesForecast = this.Sales - this.SalesTopProduct + this.SalesTopProduct + (this.SalesTopProduct * this.SalesTopProductPercentage / 100);
        //}

        ///// <summary>
        ///// Продажи прогноз (3 популярных товара)
        ///// </summary>
        ///// <param name="sales"></param>
        //public void CalculateSalesTop3Products()
        //{
        //    this.SalesForecast = this.Sales - this.SalesTop3Products + this.SalesTop3Products + (this.SalesTop3Products * this.SalesTop3ProductsPercentage / 100);
        //}

        //#endregion

        //#region Валовая прибыль

        ///// <summary>
        ///// Валовая прибыль (Общее)
        ///// Валовая прибыль Прогноз = Валовая прибыль Факт * (Рентальбельность факт + 5%), то есть + процент изменения.
        ///// </summary>
        //public void CalculateGrossProfitGeneral()
        //{
        //    this.GrossProfitForecast = this.GrossProfit * (this.ProfitabilityGeneral + (this.ProfitabilityGeneral * 5 / 100));
        //}

        //#endregion Валовая прибыль

        //#region Чистая прибыль

        ///// <summary>
        ///// Чистая прибыль
        ///// Чистая прибыль прогноз = Валовая прибыль-Расходы * (100% + %    изменения).
        ///// </summary>
        //public void CalculateNetProfit()
        //{
        //    this.NetProfitForecast = this.GrossProfit - this.Expenses * ((100 + this.ExpensesPercentage) / 100);
        //}

        //#endregion 


        public void CalculateAll()
        {
            SalesForecast = Sales + GetPercentage(SalesGeneral, SalesGeneralPercentage)
                + GetPercentage(SalesTop3Clients, SalesTop3ClientsPercentage)
                + GetPercentage(SalesTopProduct, SalesTopProductPercentage)
                + GetPercentage(SalesTop3Products, SalesTop3ProductsPercentage);

            var cc = SalesForecast * (ProfitabilityGeneralPerc / 100);
            GrossProfitForecast = cc
                + GetPercentage2(SalesForecast, ProfitabilityGeneralPercentage)
                + GetPercentage2(ProfitabilityTop3Clients, ProfitabilityTop3ClientsPercentage)
                + GetPercentage2(ProfitabilityTopProduct, ProfitabilityTopProductPercentage)
                + GetPercentage2(ProfitabilityTop3Products, ProfitabilityTop3ProductsPercentage);

            NetProfitForecast = GrossProfitForecast - Expenses
                + GetPercentage(Expenses, ExpensesPercentage);

            try
            {
                SalesPercentageValue = Sales == SalesForecast
                    ? 0 // x == y
                    : Sales > SalesForecast
                        ? 100 * Sales / SalesForecast - 100 // x > y
                        : 100 - 100 * SalesForecast / Sales; // x < y
                SalesPercentageValue *= (-1);

                GrossProfitPercentageValue = GrossProfit == GrossProfitForecast
                    ? 0 // x == y
                    : GrossProfit > GrossProfitForecast
                        ? 100 * Sales / GrossProfitForecast - 100 // x > y
                        : 100 - 100 * GrossProfitForecast / GrossProfit; // x < y
                GrossProfitPercentageValue *= (-1);

                NetProfitPercentageValue = NetProfit == NetProfitForecast
                    ? 0 // x == y
                    : NetProfit > NetProfitForecast
                        ? 100 * NetProfit / NetProfitForecast - 100 // x > y
                        : 100 - 100 * NetProfitForecast / NetProfit; // x < y
                NetProfitPercentageValue *= (-1);
            }
            catch { }

            if (SalesGeneralPercentage == 0 && SalesTop3ClientsPercentage == 0 && SalesTopProductPercentage == 0 && SalesTop3ProductsPercentage
                == 0 && ProfitabilityGeneralPercentage == 0 && ProfitabilityTop3ClientsPercentage == 0 && ProfitabilityTopProductPercentage
                == 0 && ProfitabilityTop3ProductsPercentage == 0 && ExpensesPercentage == 0)
            {
                SalesForecast = GrossProfitForecast = NetProfitForecast = 0;
            }
        }

        private decimal GetPercentage(decimal value, int percentage)
        {
            decimal result = 0;
            if (value != 0)
            {
                result =  value * percentage / 100;
            }
            else
            {
                result =  0;
            }
            return result;
        }

        private decimal GetPercentage2(decimal value, int percentage)
        {
            decimal result = 0;
            if (value != 0)
            {
                result = value / 100 * percentage;
            }
            else
            {
                result = 0;
            }
            return result;
        }

    }
}
