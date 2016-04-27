using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models.BusinessAnalysis
{
    public class FillModel : BaseViewModel
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
        /// доля
        /// </summary>
        public decimal Share
        {
            get { return _share; }
            set { SetValue(ref _share, value, "Share"); }
        }
        private decimal _share;

        /// <summary>
        /// значение
        /// </summary>
        public decimal Value
        {
            get { return _value; }
            set { SetValue(ref _value, value, "Value"); }
        }
        private decimal _value;

        
    }
}
