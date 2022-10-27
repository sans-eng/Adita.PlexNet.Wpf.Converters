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
    /// Represents a <see langword="string"/> white spaces remover.
    /// </summary>
    public class StringWhiteSpaceRemoverConverter : IValueConverter
    {
        #region Public methods
        /// <summary>Converts a <paramref name="value"/>. If <paramref name="value"/> is not <see langword="string"/>, returns <see cref="DependencyProperty.UnsetValue"/> instead..</summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A <see langword="string"/> that has no white space(s).</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string stringValue)
            {
                return DependencyProperty.UnsetValue;
            }

            return string.Concat(stringValue.Where(c => !char.IsWhiteSpace(c)));
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
