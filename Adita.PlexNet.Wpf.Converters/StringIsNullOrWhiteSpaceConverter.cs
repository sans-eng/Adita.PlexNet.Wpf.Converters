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
    /// Represents a converter that checking the value of the <see cref="string"/> is <see langword="null"/>, <see cref="string.Empty"/> or only contains white spaces.
    /// </summary>
    public class StringIsNullOrWhiteSpaceConverter : IValueConverter
    {
        #region Public methods
        /// <summary>Returns whether specified <paramref name="value"/> is <see langword="null"/>, <see cref="string.Empty"/> or a <see cref="string"/> that only contains white spaces.</summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns><see langword="true"/> if specified <paramref name="value"/> is <see langword="null"/>, <see cref="string.Empty"/> or a <see cref="string"/> that only contains white spaces,
        /// otherwise <see langword="false"/></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string stringValue)
            {
                return true;
            }

            return string.IsNullOrWhiteSpace(stringValue);
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
