using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Adita.PlexNet.Wpf.Converters
{
    /// <summary>
    /// Represents a value to <see cref="Type"/> converter.
    /// </summary>
    public class ValueToTypeConverter : IValueConverter
    {
        #region Public methods
        /// <summary>Returns the <see cref="Type"/> of specified <paramref name="value"/>.</summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>The <see cref="Type"/> of specified <paramref name="value"/>, or <see langword="null"/> if the specified <paramref name="value"/> is <see langword="null"/>.</returns>
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.GetType();
        }

        /// <summary>Convert back not supported and will return <see cref="DependencyProperty.UnsetValue"/> instead.</summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns><see cref="DependencyProperty.UnsetValue"/></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
        #endregion Public methods
    }
}
