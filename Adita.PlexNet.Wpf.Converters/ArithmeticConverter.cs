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
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Adita.PlexNet.Wpf.Converters
{
    /// <summary>
    /// Represents an arithmetic converter.
    /// </summary>
    public sealed class ArithmeticConverter : MarkupExtension, IValueConverter
    {
        #region Public properties
        /// <summary>
        /// Gets or sets an <see cref="ArithmeticOperation"/> of current <see cref="ArithmeticConverter"/>.
        /// </summary>
        public ArithmeticOperation Operation { get; set; }
        #endregion Public properties

        #region Public methods
        /// <summary>Returns the result of arithmetic operation specified on <see cref="Operation"/> to specified <paramref name="value"/> and <paramref name="parameter"/> as the operands.</summary>
        /// <remarks>If specified <paramref name="value"/> and <paramref name="parameter"/> is not a number
        /// or an arithmetic operation has an invalid operand such as zero divisor, returns <see cref="DependencyProperty.UnsetValue"/> instead.</remarks>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>a <see cref="double"/> result of arithmetic operation.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(double.TryParse(value.ToString(), out double operand1) && double.TryParse(parameter.ToString(), out double operand2)))
            {
                return DependencyProperty.UnsetValue;
            }

            try
            {
                return Operation switch
                {
                    ArithmeticOperation.Addition => operand1 + operand2,
                    ArithmeticOperation.Subtraction => operand1 - operand2,
                    ArithmeticOperation.Multiplication => operand1 * operand2,
                    ArithmeticOperation.Division => operand1 / operand2,
                    _ => DependencyProperty.UnsetValue
                };
            }
            catch (ArithmeticException)
            {
                return DependencyProperty.UnsetValue;
            }
        }

        /// <summary>Convert back not supported and will return <see langword="null"/> instead.</summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns><see langword="null"/></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }

        /// <summary>Returns an object that is provided as the value of the target property for this markup extension.</summary>
        /// <param name="serviceProvider">A service provider helper that can provide services for the markup extension.</param>
        /// <returns>The object value to set on the property where the extension is applied.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        #endregion Public methods
    }
}
