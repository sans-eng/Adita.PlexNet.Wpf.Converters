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
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Adita.PlexNet.Wpf.Converters
{
    /// <summary>
    /// Represents an arithmetic multi converter.
    /// </summary>
    public sealed class ArithmeticMultiConverter : MarkupExtension, IMultiValueConverter
    {
        #region Public properties
        /// <summary>
        /// Gets or sets an <see cref="ArithmeticOperation"/> of current <see cref="ArithmeticMultiConverter"/>.
        /// </summary>
        public ArithmeticOperation Operation { get; set; }
        #endregion Public properties

        #region Public methods
        /// <summary>Returns the result of arithmetic operation specified on <see cref="Operation"/> agains all the objects on specified <paramref name="values"/> as operands.</summary>
        /// <remarks>If specified <paramref name="values"/> has any object(s) that is not a number
        /// or an arithmetic operation has an invalid operand such as zero divisor, returns <see cref=" DependencyProperty.UnsetValue"/> instead.</remarks>
        /// <param name="values">The array of values that the source bindings in the <see cref="MultiBinding" /> produces. The value <see cref="F:System.Windows.DependencyProperty.UnsetValue" /> indicates that the source binding has no value to provide for conversion.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A <see cref="double"/> result of arithmetic operation agains specified <paramref name="values"/>.</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Queue<double> operandsQueue = new Queue<double>();
            foreach (var value in values)
            {
                if (double.TryParse(value.ToString(), out double parsed))
                {
                    operandsQueue.Enqueue(parsed);
                }
                else
                {
                    return DependencyProperty.UnsetValue;
                }
            }

            double result = operandsQueue.Count > 0 ? operandsQueue.Dequeue() : 0;

            while (operandsQueue.Count > 0)
            {
                try
                {
                    switch (Operation)
                    {
                        case ArithmeticOperation.Addition:
                            result += operandsQueue.Dequeue();
                            break;
                        case ArithmeticOperation.Subtraction:
                            result -= operandsQueue.Dequeue();
                            break;
                        case ArithmeticOperation.Multiplication:
                            result *= operandsQueue.Dequeue();
                            break;
                        case ArithmeticOperation.Division:
                            result /= operandsQueue.Dequeue();
                            break;
                    }
                }
                catch (ArithmeticException)
                {
                    return DependencyProperty.UnsetValue;
                }
            }

            return result;
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

        /// <summary>Returns current <see cref="ArithmeticMultiConverter"/> instance.</summary>
        /// <param name="serviceProvider">A service provider helper that can provide services for the markup extension.</param>
        /// <returns>Current <see cref="ArithmeticMultiConverter"/> instance.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        #endregion Public methods
    }
}
