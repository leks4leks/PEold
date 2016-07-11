using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ProgressoExpert.Common.Const;
using ProgressoExpert.Models.Models.BusinessAnalysis;

namespace ProgressoExpert.Models.Entities
{
    public class SalesEnt : BaseViewModel
    {
        /// <summary>
        /// месяц + год
        /// </summary>
        public int Mont
        {
            get { return _mont; }
            set { SetValue(ref _mont, value, "Mont"); }
        }
        private int _mont;

        /// <summary>
        /// месяц + год
        /// </summary>
        public int Year
        {
            get { return _year; }
            set { SetValue(ref _year, value, "Year"); }
        }
        private int _year;

        /// <summary>
        /// период
        /// </summary>
        public DateTime Period
        {
            get { return _period; }
            set { SetValue(ref _period, value, "Period"); }
        }
        private DateTime _period;

        /// <summary>
        /// 
        /// </summary>
        public byte[] refId
        {
            get { return _refId; }
            set { SetValue(ref _refId, value, "refId"); }
        }
        private byte[] _refId;

        /// <summary>
        /// Мужики продавцы
        /// </summary>
        public byte[] SalersRefId
        {
            get { return _salersRefId; }
            set { SetValue(ref _salersRefId, value, "SalersRefId"); }
        }
        private byte[] _salersRefId;

        /// <summary>
        /// Мужики покупатели
        /// </summary>
        public byte[] ClientRefId
        {
            get { return _clientRefId; }
            set { SetValue(ref _clientRefId, value, "ClientRefId"); }
        }
        private byte[] _clientRefId;

        /// <summary>
        /// 
        /// </summary>
        public byte[] refManId
        {
            get { return _refManId; }
            set { SetValue(ref _refManId, value, "refManId"); }
        }
        private byte[] _refManId;
                
        /// <summary>
        /// Наименование производителя
        /// </summary>
        public string DivName
        {
            get { return _divName; }
            set { SetValue(ref _divName, value, "DivName"); }
        }
        private string _divName;

        /// <summary>
        /// Код группы
        /// </summary>
        public string GroupCode
        {
            get { return _groupCode; }
            set { SetValue(ref _groupCode, value, "GroupCode"); }
        }
        private string _groupCode;

        /// <summary>
        /// Код группы
        /// </summary>
        public string GroupName
        {
            get { return _groupName; }
            set { SetValue(ref _groupName, value, "GroupName"); }
        }
        private string _groupName;

        /// <summary>
        /// Продажи без ндс
        /// </summary>
        public decimal SalesWithoutNDS
        {
            get { return _salesWithoutNDS; }
            set { SetValue(ref _salesWithoutNDS, value, "SalesWithoutNDS"); }
        }
        private decimal _salesWithoutNDS;

        /// <summary>
        /// Себестоимость
        /// </summary>
        public decimal CostPrise
        {
            get { return _costPrise; }
            set { SetValue(ref _costPrise, value, "CostPrise"); }
        }
        private decimal _costPrise;

        /// <summary>
        /// средняя себ остатка товара 
        /// </summary>
        public decimal AveCostPrise
        {
            get { return _aveCostPrise; }
            set { SetValue(ref _aveCostPrise, value, "AveCostPrise"); }
        }
        private decimal _aveCostPrise;

        /// <summary>
        /// Код покупателя
        /// </summary>
        public string BuyerCode
        {
            get { return _buyerCode; }
            set { SetValue(ref _buyerCode, value, "BuyerCode"); }
        }
        private string _buyerCode;

        /// <summary>
        /// Имя покупателя
        /// </summary>
        public string BuyerName
        {
            get { return _buyerName; }
            set { SetValue(ref _buyerName, value, "BuyerName"); }
        }
        private string _buyerName;

        /// <summary>
        /// Код поставщика
        /// </summary>
        public string SalerCode
        {
            get { return _salerCode; }
            set { SetValue(ref _salerCode, value, "SalerCode"); }
        }
        private string _salerCode;

        /// <summary>
        /// Имя поставщика
        /// </summary>
        public string SalerName
        {
            get { return _salerName; }
            set { SetValue(ref _salerName, value, "SalerName"); }
        }
        private string _salerName;

        /// <summary>
        /// Количество покупки
        /// </summary>
        public decimal CountPur
        {
            get { return _countPur; }
            set { SetValue(ref _countPur, value, "CountPur"); }
        }
        private decimal _countPur;

        /// <summary>
        /// Количество продажи
        /// </summary>
        public decimal CountSal
        {
            get { return _countSal; }
            set { SetValue(ref _countSal, value, "CountSal"); }
        }
        private decimal _countSal;


        /// <summary>
        /// Количество остатка товара на начало периода
        /// </summary>
        public decimal CountGoodsSt
        {
            get { return _countGoodsSt; }
            set { SetValue(ref _countGoodsSt, value, "CountGoodsSt"); }
        }
        private decimal _countGoodsSt;

        /// <summary>
        /// Количество остатка товара на конец периода
        /// </summary>
        public decimal CountGoodsEnd
        {
            get { return _countGoodsEnd; }
            set { SetValue(ref _countGoodsEnd, value, "CountGoodsEnd"); }
        }
        private decimal _countGoodsEnd;

    }
}
