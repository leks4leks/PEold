using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ProgressoExpert.Converters
{
    /// <summary>
    /// A type converter for visibility and boolean values.
    /// </summary>
    public class VisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Конвертер булева значения в Visibility
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter">Если этот параметр установлен в True, то возвращаемое значение будет инвертировано</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = System.Convert.ToBoolean(value);
            if (parameter != null)
                if (Boolean.Parse(parameter.ToString()))
                    visibility = !visibility;

            return visibility ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;
            return (visibility == Visibility.Visible);
        }
    }
}
