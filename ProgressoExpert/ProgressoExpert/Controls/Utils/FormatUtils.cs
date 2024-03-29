﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressoExpert.Controls.Utils
{
    public static class FormatUtils
    {
        /// <summary>
        /// 100 000 000
        /// </summary>
        public static readonly string Thousand = "{0:#,##0,}"; //"{0:N2}";

        /// <summary>
        /// 100 000 000
        /// </summary>
        public static readonly string Thousand2 = "{0:N0}";

        /// <summary>
        /// 100 тыс
        /// </summary>
        public static readonly string ThousandWithK = "# ##0,";

        /// <summary>
        /// 10%
        /// </summary>
        public static readonly string Percentage = "{0:N0}%";

        /// <summary>
        /// Целое число
        /// </summary>
        public static readonly string IntNumber = "{0:N0}";

        /// <summary>
        /// 10.00%
        /// </summary>
        public static readonly string Percentage2 = "{0:N2}%";
    }
}
