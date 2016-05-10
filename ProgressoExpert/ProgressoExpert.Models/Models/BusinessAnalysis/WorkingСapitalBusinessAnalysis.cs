using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models.BusinessAnalysis
{
    public class WorkingСapitalBusinessAnalysis : BaseViewModel
    {        
        /// <summary>
        /// свои деньги
        /// </summary>
        public decimal myMoney
        {
            get { return _myMoney; }
            set { SetValue(ref _myMoney, value, "myMoney"); }
        }
        private decimal _myMoney = 0;

        /// <summary>
        /// разница с пред периодом
        /// </summary>
        public decimal difmyMoney
        {
            get { return _difmyMoney; }
            set { SetValue(ref _difmyMoney, value, "difmyMoney"); }
        }
        private decimal _difmyMoney;

        /// <summary>
        /// разница с пред периодом в процентах
        /// </summary>
        public decimal difmyMoneyByPercent
        {
            get { return _difmyMoneyByPercent; }
            set { SetValue(ref _difmyMoneyByPercent, value, "difmyMoneyByPercent"); }
        }
        private decimal _difmyMoneyByPercent;

        /// <summary>
        /// долги
        /// </summary>
        public decimal myCosts
        {
            get { return _myCosts; }
            set { SetValue(ref _myCosts, value, "myCosts"); }
        }
        private decimal _myCosts = 0;

        /// <summary>
        /// разница с пред периодом
        /// </summary>
        public decimal difmyCosts
        {
            get { return _difmyCosts; }
            set { SetValue(ref _difmyCosts, value, "difmyCosts"); }
        }
        private decimal _difmyCosts;

        /// <summary>
        /// разница с пред периодом в процентах
        /// </summary>
        public decimal difmyCostsByPercent
        {
            get { return _difmyCostsByPercent; }
            set { SetValue(ref _difmyCostsByPercent, value, "difmyCostsByPercent"); }
        }
        private decimal _difmyCostsByPercent;
                                
        /// <summary>
        /// задолжность - Структура оборотного капитала по источникам
        /// </summary>
        public Dictionary<string, decimal> stDebtsDiagram
        {
            get { return _stDebtsDiagram; }
            set { SetValue(ref _stDebtsDiagram, value, "stDebtsDiagram"); }
        }
        private Dictionary<string, decimal> _stDebtsDiagram;
        
        /// <summary>
        /// сок - Структура оборотного капитала по источникам
        /// </summary>
        public Dictionary<string, decimal> stSokDiagram
        {
            get { return _stSokDiagram; }
            set { SetValue(ref _stSokDiagram, value, "stSokDiagram"); }
        }
        private Dictionary<string, decimal> _stSokDiagram;

        /// <summary>
        /// прибыль - Структура оборотного капитала по источникам
        /// </summary>
        public Dictionary<string, decimal> profit
        {
            get { return _profit; }
            set { SetValue(ref _profit, value, "profit"); }
        }
        private Dictionary<string, decimal> _profit;
        
        /// <summary>
        /// оборачиваемочть по видам товара дней
        /// </summary>
        public Dictionary<string, decimal> turnoverDiagram
        {
            get { return _turnoverDiagram; }
            set { SetValue(ref _turnoverDiagram, value, "turnoverDiagram"); }
        }
        private Dictionary<string, decimal> _turnoverDiagram;
                
        /// <summary>
        /// дз - Соотношение дз и кз
        /// </summary>
        public Dictionary<string, decimal> DZ_dzVsKzDiagram
        {
            get { return _DZ_dzVsKzDiagram; }
            set { SetValue(ref _DZ_dzVsKzDiagram, value, "DZ_dzVsKzDiagram"); }
        }
        private Dictionary<string, decimal> _DZ_dzVsKzDiagram;
        
        /// <summary>
        /// кз - Соотношение дз и кз
        /// </summary>
        public Dictionary<string, decimal> KZ_dzVsKzDiagram
        {
            get { return _KZ_dzVsKzDiagram; }
            set { SetValue(ref _KZ_dzVsKzDiagram, value, "KZ_dzVsKzDiagram"); }
        }
        private Dictionary<string, decimal> _KZ_dzVsKzDiagram;

        /// <summary>
        /// дз - структура оборотного капитала
        /// </summary>
        public Dictionary<string, decimal> aveDZDiagram
        {
            get { return _aveDZDiagram; }
            set { SetValue(ref _aveDZDiagram, value, "aveDZDiagram"); }
        }
        private Dictionary<string, decimal> _aveDZDiagram;

        /// <summary>
        /// товарыы - структура оборотного капитала
        /// </summary>
        public Dictionary<string, decimal> aveGoodsDiagram
        {
            get { return _aveGoodsDiagram; }
            set { SetValue(ref _aveGoodsDiagram, value, "aveGoodsDiagram"); }
        }
        private Dictionary<string, decimal> _aveGoodsDiagram;

        /// <summary>
        /// деньги - структура оборотного капитала
        /// </summary>
        public Dictionary<string, decimal> aveMoneyDiagram
        {
            get { return _aveMoneyDiagram; }
            set { SetValue(ref _aveMoneyDiagram, value, "aveMoneyDiagram"); }
        }
        private Dictionary<string, decimal> _aveMoneyDiagram;

        /// <summary>
        /// продажи - структура оборотного капитала
        /// </summary>
        public Dictionary<string, decimal> aveSalesDiagram
        {
            get { return _aveSalesDiagram; }
            set { SetValue(ref _aveSalesDiagram, value, "aveSalesDiagram"); }
        }
        private Dictionary<string, decimal> _aveSalesDiagram;
    }
}
