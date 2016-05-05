using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models.BusinessAnalysis
{
    public class ProfitBusinessAnalysis : BaseViewModel
    {        
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
        /// Динамика валовой прибыли
        /// </summary>
        public Dictionary<string, decimal> GrossProfitDiagram
        {
            get { return _grossProfitDiagram; }
            set { SetValue(ref _grossProfitDiagram, value, "GrossProfitDiagram"); }
        }
        private Dictionary<string, decimal> _grossProfitDiagram;

        /// <summary>
        /// Динамика чистая прибыль
        /// </summary>
        public Dictionary<string, decimal> NetProfitDiagram
        {
            get { return _netProfitDiagram; }
            set { SetValue(ref _netProfitDiagram, value, "NetProfitDiagram"); }
        }
        private Dictionary<string, decimal> _netProfitDiagram;


        /// <summary>
        /// Динамика валовой рентабельности
        /// </summary>
        public Dictionary<string, decimal> GrossProfitabilityDiagram
        {
            get { return _grossProfitabilityDiagram; }
            set { SetValue(ref _grossProfitabilityDiagram, value, "GrossProfitabilityDiagram"); }
        }
        private Dictionary<string, decimal> _grossProfitabilityDiagram;

        /// <summary>
        /// Динамика чистой рентабильности
        /// </summary>
        public Dictionary<string, decimal> NetProfitabilityDiagram
        {
            get { return _netProfitabilityDiagram; }
            set { SetValue(ref _netProfitabilityDiagram, value, "NetProfitabilityDiagram"); }
        }
        private Dictionary<string, decimal> _netProfitabilityDiagram;

        /// <summary>
        /// Чистая рентабильность
        /// </summary>
        public decimal NetProfitability
        {
            get { return _netProfitability; }
            set { SetValue(ref _netProfitability, value, "NetProfitability"); }
        }
        private decimal _netProfitability;

        /// <summary>
        /// валовая рентабильность
        /// </summary>
        public decimal GrossProfitability
        {
            get { return _grossProfitability; }
            set { SetValue(ref _grossProfitability, value, "GrossProfitability"); }
        }
        private decimal _grossProfitability;

        /// <summary>
        /// Средняя чистая прибыль в месяц
        /// </summary>
        public decimal AverageNetProfitByMonth
        {
            get { return _averageNetProfitByMonth; }
            set { SetValue(ref _averageNetProfitByMonth, value, "AverageNetProfitByMonth"); }
        }
        private decimal _averageNetProfitByMonth;


        /// <summary>
        /// Средняя валовая прибыль в месяц
        /// </summary>
        public decimal AverageGrossProfitByMonth
        {
            get { return _averageGrossProfitByMonth; }
            set { SetValue(ref _averageGrossProfitByMonth, value, "AverageGrossProfitByMonth"); }
        }
        private decimal _averageGrossProfitByMonth;

        /// <summary>
        /// накопленная прибыль
        /// </summary>
        public decimal SavedProfit
        {
            get { return _savedProfit; }
            set { SetValue(ref _savedProfit, value, "SavedProfit"); }
        }
        private decimal _savedProfit;

        /// <summary>
        /// Структура валовой прибыли по товарам
        /// </summary>
        public Dictionary<string, decimal> StructureGrossProfitGoodsDiagram
        {
            get { return _structureGrossProfitGoodsDiagram; }
            set { SetValue(ref _structureGrossProfitGoodsDiagram, value, "StructureGrossProfitGoodsDiagram"); }
        }
        private Dictionary<string, decimal> _structureGrossProfitGoodsDiagram;

        /// <summary>
        /// Структура валовой прибыли по клиентам
        /// </summary>
        public Dictionary<string, decimal> StructureGrossProfitClientDiagram
        {
            get { return _structureGrossProfitClientDiagram; }
            set { SetValue(ref _structureGrossProfitClientDiagram, value, "StructureGrossProfitClientDiagram"); }
        }
        private Dictionary<string, decimal> _structureGrossProfitClientDiagram;

        /// <summary>
        /// Структура валовой прибыли по товарам + Доля и рентабельность
        /// </summary>
        public List<FillModel> StructureGrossProfitGoodsInfo
        {
            get { return _structureGrossProfitGoodsInfo; }
            set { SetValue(ref _structureGrossProfitGoodsInfo, value, "StructureGrossProfitGoodsInfo"); }
        }
        private List<FillModel> _structureGrossProfitGoodsInfo;

        /// <summary>
        /// Структура валовой прибыли по клиентам + Доля и рентабельность
        /// </summary>
        public List<FillModel> StructureGrossProfitClientInfo
        {
            get { return _structureGrossProfitClientInfo; }
            set { SetValue(ref _structureGrossProfitClientInfo, value, "StructureGrossProfitClientInfo"); }
        }
        private List<FillModel> _structureGrossProfitClientInfo;
    }
}
