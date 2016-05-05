using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models.BusinessAnalysis
{
    public class FillGoodsModel : BaseViewModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, value, "Name"); }
        }
        private string _name;

        /// <summary>
        /// процент
        /// </summary>
        public decimal Percent
        {
            get { return _percent; }
            set { SetValue(ref _percent, value, "Percent"); }
        }
        private decimal _percent;

        /// <summary>
        /// значение
        /// </summary>
        public decimal Value
        {
            get { return _value; }
            set { SetValue(ref _value, value, "Value"); }
        }
        private decimal _value;

        /// <summary>
        /// значение прошлого периода
        /// </summary>
        public decimal pastValue
        {
            get { return _pastValue; }
            set { SetValue(ref _pastValue, value, "pastValue"); }
        }
        private decimal _pastValue;
    }
}
