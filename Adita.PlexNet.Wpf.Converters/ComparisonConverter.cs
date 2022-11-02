//MIT License

//Copyright (c) 2022 Adita

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Adita.PlexNet.Wpf.Converters
{
    /// <summary>
    /// Represents a comparison converter.
    /// </summary>
    public sealed class ComparisonConverter : MarkupExtension, IValueConverter
    {
        #region Public properties
        /// <summary>
        /// Gets or sets a <see cref="ComparisonOperation"/> of current <see cref="ComparisonConverter"/>.
        /// </summary>
        public ComparisonOperation Operation { get; set; }
        #endregion Public properties

        #region Public methods
        /// <summary>Returns whether specified <paramref name="value"/> has fulfill the condition defined on <see cref="Operation"/> agains the <paramref name="parameter"/>.</summary>
        /// <remarks>Returns <see cref=" DependencyProperty.UnsetValue"/> instead if specified <paramref name="value"/> and specified <paramref name="parameter"/>
        /// is not a number which has upper and lower bound of <see cref="double"/>.</remarks>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns <see langword="null" />, the valid null value is used.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(double.TryParse(value.ToString(), out double value1) && double.TryParse(parameter.ToString(), out double value2)))
            {
                return DependencyProperty.UnsetValue;
            }

            return Operation switch
            {
                ComparisonOperation.LessThan => value1 < value2,
                ComparisonOperation.GreaterThan => value1 > value2,
                ComparisonOperation.LessThanOrEqual => value1 <= value2,
                ComparisonOperation.GreaterThanOrEqual => value1 >= value2,
                ComparisonOperation.Equal => value1 == value2,
                ComparisonOperation.Inequal => value1 != value2,
                _ => DependencyProperty.UnsetValue
        };
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

        /// <summary>Returns current <see cref="ComparisonConverter"/> instance.</summary>
        /// <param name="serviceProvider">A service provider helper that can provide services for the markup extension.</param>
        /// <returns>Current <see cref="ComparisonConverter"/> instance.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        #endregion Public methods
    }
}
