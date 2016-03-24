using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ProgressoExpert.Common.Const;

namespace ProgressoExpert.Models.Entities
{
    public class SalesEnt : BaseViewModel
    {
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
    }
}
