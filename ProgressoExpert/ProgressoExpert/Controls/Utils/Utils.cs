using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProgressoExpert.Controls.Utils
{
    public static class Utils
    {
        public static void ChangeTextBlockStyle(decimal value, string styleNameGreen, string styleNameRed, ref TextBlock textBlock)
        {
            //textBlock.Style = value >= 0
            //    ? (Style)FindResource(styleNameGreen)
            //    : (Style)FindResource(styleNameRed);
        }
    }
}
