using ProgressoExpert.Models.Models.BaseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Models.Models.BusinessAnalysis
{
    public class ArrayModel : BaseViewModel
    {
        /// <summary>
        /// значение 1
        /// </summary>
        public int value1
        {
            get { return _value1; }
            set { SetValue(ref _value1, value, "value1"); }
        }
        private int _value1;

        /// <summary>
        /// значение 2
        /// </summary>
        public int value2
        {
            get { return _value2; }
            set { SetValue(ref _value2, value, "value2"); }
        }
        private int _value2;
    }
}
