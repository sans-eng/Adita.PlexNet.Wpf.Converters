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
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Adita.PlexNet.Wpf.Converters
{
    /// <summary>
    /// Represents a <see langword="bool"/> logical converter.
    /// </summary>
    public sealed class LogicalMultiConverter : MarkupExtension, IMultiValueConverter
    {
        #region Public properties
        /// <summary>
        /// Gets or sets an <see cref="LogicalOperation"/> of current <see cref="LogicalMultiConverter"/>.
        /// </summary>
        public LogicalOperation Operation { get; set; }
        #endregion Public properties

        #region Public methods
        /// <summary>Returns whether all objects on <paramref name="values"/> is fulfill the logical condition which is defined on <see cref="Operation"/>.</summary>
        /// <remarks>All objects on specified <paramref name="values"/> must be <see cref="bool"/> otherwise return <see cref="DependencyProperty.UnsetValue"/> instead.</remarks>
        /// <param name="values">The array of values that the source bindings in the <see cref="MultiBinding" /> produces. The value <see cref="F:System.Windows.DependencyProperty.UnsetValue" /> indicates that the source binding has no value to provide for conversion.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns><see langword="true"/> if all objects on <paramref name="values"/> is fulfill the logical condition, otherwise <see langword="false"/>.</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            IList<bool> bools = new List<bool>();

            foreach (var value in values)
            {
                if (bool.TryParse(value.ToString(), out bool result))
                {
                    bools.Add(result);
                }
                else
                {
                    return DependencyProperty.UnsetValue;
                }
            }

            return Operation switch
            {
                LogicalOperation.And => bools.All(p => p),
                LogicalOperation.Or => bools.Any(p => p),
                LogicalOperation.ExclusiveOr => !(bools.All(p => p) || bools.All(p => !p)),
                _ => DependencyProperty.UnsetValue,
            };
        }

        /// <summary>Convert back not supported and will return <see langword="null"/> instead.</summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetTypes">The types to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns><see langword="null"/></returns>
        public object[]? ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }

        /// <summary>Returns current <see cref="LogicalMultiConverter"/> instance.</summary>
        /// <param name="serviceProvider">A service provider helper that can provide services for the markup extension.</param>
        /// <returns>Current <see cref="LogicalMultiConverter"/> instance.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        #endregion Public methods
    }
}
