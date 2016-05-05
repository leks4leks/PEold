using ProgressoExpert.Models.Entities;
using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models.BusinessAnalysis
{
    public class GeneralBusinessAnalysis : BaseViewModel
    {
        /// <summary>
        /// Продажи
        /// </summary>
        public decimal Sales
        {
            get { return _sales; }
            set { SetValue(ref _sales, value, "Sales"); }
        }
        private decimal _sales;

        /// <summary>
        /// Продажи
        /// Значение сранивается с предыдущим периодом (если задается август, то сранивается с июлем, если 1-ый квартал -
        /// с 4-ым кварталом прошлого года, если текущий год - прошлый год). 
        /// Сравнение идет по следующей формуле: (заданный период - предыдущий период)/предыдущий перод*100%. 
        /// Если значение положительное, то процент зеленого цвета, если отрицательное - красного.
        /// </summary>
        public decimal SalesAnFirst
        {
            get { return _salesAnFirst; }
            set { SetValue(ref _salesAnFirst, value, "SalesAnFirst"); }
        }
        private decimal _salesAnFirst;

        /// <summary>
        /// Продажи
        /// Значение сранивается с предыдущим аналогичным периодом (если задается август, то сранивается с августом прошлого года, если 1-ый квартал 
        /// - с 1-ым кварталом прошлого года, если текущий год - с позапрошлым годом, так как с прошлым годом сравнивает первый %). 
        ///Сравнение идет по следующей формуле: (заданный период - предыдущий аналогичный период)/предыдущий аналогичный перод*100%. 
        ///Если значение положительное, то процент зеленого цвета, если отрицательное - красного.
        /// </summary>
        public decimal SalesAnSecond
        {
            get { return _salesAnSecond; }
            set { SetValue(ref _salesAnSecond, value, "SalesAnSecond"); }
        }
        private decimal _salesAnSecond;

        /// <summary>
        /// Валовая прибыль
        /// </summary>
        public decimal GrossProfit
        {
            get { return _grossProfit; }
            set { SetValue(ref _grossProfit, value, "GrossProfit"); }
        }
        private decimal _grossProfit;

        /// <summary>
        /// Валовая прибыль
        /// </summary>
        public decimal GrossProfitAnFirst
        {
            get { return _grossProfitAnFirst; }
            set { SetValue(ref _grossProfitAnFirst, value, "GrossProfitAnFirst"); }
        }
        private decimal _grossProfitAnFirst;

        /// <summary>
        /// Валовая прибыль
        /// </summary>
        public decimal GrossProfitAnSecond
        {
            get { return _grossProfitAnSecond; }
            set { SetValue(ref _grossProfitAnSecond, value, "GrossProfitAnSecond"); }
        }
        private decimal _grossProfitAnSecond;

        /// <summary>
        /// Себестоимость
        /// </summary>
        public decimal CostPrice
        {
            get { return _costPrice; }
            set { SetValue(ref _costPrice, value, "CostPrice"); }
        }
        private decimal _costPrice;

        /// <summary>
        /// Себестоимость
        /// </summary>
        public decimal CostPriceAnFirst
        {
            get { return _costPriceAnFirst; }
            set { SetValue(ref _costPriceAnFirst, value, "CostPriceAnFirst"); }
        }
        private decimal _costPriceAnFirst;

        /// <summary>
        /// Себестоимость
        /// </summary>
        public decimal CostPriceAnSecond
        {
            get { return _costPriceAnSecond; }
            set { SetValue(ref _costPriceAnSecond, value, "CostPriceAnSecond"); }
        }
        private decimal _costPriceAnSecond;

        /// <summary>
        /// Расходы
        /// </summary>
        public decimal Cost
        {
            get { return _cost; }
            set { SetValue(ref _cost, value, "Cost"); }
        }
        private decimal _cost;

        /// <summary>
        /// Расходы
        /// </summary>
        public decimal CostAnFirst
        {
            get { return _costAnFirst; }
            set { SetValue(ref _costAnFirst, value, "CostAnFirst"); }
        }
        private decimal _costAnFirst;

        /// <summary>
        /// Расходы
        /// </summary>
        public decimal CostAnSecond
        {
            get { return _costAnSecond; }
            set { SetValue(ref _costAnSecond, value, "CostAnSecond"); }
        }
        private decimal _costAnSecond;


        /// <summary>
        /// Чистая прибыль
        /// </summary>
        public decimal NetProfit
        {
            get { return _netProfit; }
            set { SetValue(ref _netProfit, value, "NetProfit"); }
        }
        private decimal _netProfit;

        /// <summary>
        /// Чистая прибыль
        /// </summary>
        public decimal NetProfitAnFirst
        {
            get { return _netProfitAnFirst; }
            set { SetValue(ref _netProfitAnFirst, value, "NetProfitAnFirst"); }
        }
        private decimal _netProfitAnFirst;

        /// <summary>
        /// Чистая прибыль
        /// </summary>
        public decimal NetProfitAnSecond
        {
            get { return _netProfitAnSecond; }
            set { SetValue(ref _netProfitAnSecond, value, "NetProfitAnSecond"); }
        }
        private decimal _netProfitAnSecond;
        
        /// <summary>
        /// Диагранма продажи
        /// </summary>
        public Dictionary<string, decimal> SalesDiagram
        {
            get { return _salesDiagram; }
            set { SetValue(ref _salesDiagram, value, "SalesDiagram"); }
        }
        private Dictionary<string, decimal> _salesDiagram;

        /// <summary>
        /// Диаграмма чистая прибыль
        /// </summary>
        public Dictionary<string, decimal> NetProfitDiagram
        {
            get { return _netProfitDiagram; }
            set { SetValue(ref _netProfitDiagram, value, "NetProfitDiagram"); }
        }
        private Dictionary<string, decimal> _netProfitDiagram;


        /// <summary>
        /// Диаграмма Средний оборотный капитал
        /// </summary>
        public Dictionary<string, decimal> AverageWorkingCapitalDiagram
        {
            get { return _averageWorkingCapitalDiagram; }
            set { SetValue(ref _averageWorkingCapitalDiagram, value, "AverageWorkingCapitalDiagram"); }
        }
        private Dictionary<string, decimal> _averageWorkingCapitalDiagram;


        /// <summary>
        /// Диаграмма Структура компании
        /// </summary>
        public Dictionary<string, decimal> StructureCompanyDiagram
        {
            get { return _structureCompanyDiagram; }
            set { SetValue(ref _structureCompanyDiagram, value, "StructureCompanyDiagram"); }
        }
        private Dictionary<string, decimal> _structureCompanyDiagram;
        
        /// <summary>
        /// Продажи сгрупированные по группам
        /// </summary>
        public List<SalesEnt> gSales
        {
            get { return _gSales; }
            set { SetValue(ref _gSales, value, "gSales"); }
        }
        private List<SalesEnt> _gSales;

        /// <summary>
        /// Продажи сгрупированные по клиентам
        /// </summary>
        public List<SalesEnt> gSalesByClient
        {
            get { return _gSalesByClient; }
            set { SetValue(ref _gSalesByClient, value, "gSalesByClient"); }
        }
        private List<SalesEnt> _gSalesByClient;       


        /// <summary>
        /// Диаграмма рентабельность
        /// </summary>
        public Dictionary<string, decimal> ProfitabilityDiagram
        {
            get { return _profitabilityDiagram; }
            set { SetValue(ref _profitabilityDiagram, value, "ProfitabilityDiagram"); }
        }
        private Dictionary<string, decimal> _profitabilityDiagram;
        
        /// <summary>
        /// Продажи прошлого периода
        /// </summary>
        public List<SalesModel> salesFirst
        {
            get { return _salesFirst; }
            set { SetValue(ref _salesFirst, value, "salesFirst"); }
        }
        private List<SalesModel> _salesFirst;
        

    }
}
