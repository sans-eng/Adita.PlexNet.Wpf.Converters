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
    /// Represents a <see cref="Type"/> equality converter that compares the <see cref="Type"/> of value with the <see cref="Type"/> of parameter.
    /// </summary>
    public class TypeEqualityConverter : IValueConverter
    {
        #region public methods
        /// <summary>Returns <see langword="true"/> if the specified <paramref name="value"/> has <see cref="Type"/> that defined on specified <paramref name="parameter"/>,
        /// otherwise <see langword="false"/>.</summary>
        /// <remarks>Returns <see cref="DependencyProperty.UnsetValue"/> instead If <paramref name="parameter"/> is not a <see cref="Type"/>.</remarks>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> has <see cref="Type"/> that defined on specified <paramref name="parameter"/>, otherwise <see langword="false"/>.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(parameter is not Type expectedType)
            {
                return DependencyProperty.UnsetValue;
            }

            return value?.GetType() == expectedType;
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
        #endregion public methods
    }
}
