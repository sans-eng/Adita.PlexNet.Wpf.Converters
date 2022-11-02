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
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Adita.PlexNet.Wpf.Converters
{
    /// <summary>
    /// Represents a <see langword="bool"/> converter that converts a <see langword="bool"/> value to specified <typeparamref name="T"/> type value.
    /// </summary>
    /// <typeparam name="T">The type that represented as boolean value.</typeparam>
    public class BooleanToValueConverter<T> : MarkupExtension, IValueConverter
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="BooleanToValueConverter{T}"/> using specified <paramref name="trueValue"/> and <paramref name="falseValue"/>.
        /// </summary>
        /// <param name="trueValue">A value that represented as <see langword="true"/> value.</param>
        /// <param name="falseValue">A value that represented as <see langword="false"/> value.</param>
        public BooleanToValueConverter(T trueValue, T falseValue)
        {
            TrueValue = trueValue;
            FalseValue = falseValue;
        }
        #endregion Constructors

        #region Public properties
        /// <summary>
        /// Gets a <see langword="true"/> value of current <see cref="BooleanToValueConverter{T}"/>.
        /// </summary>
        public T TrueValue { get; }
        /// <summary>
        /// Gets a <see langword="false"/> value of current <see cref="BooleanToValueConverter{T}"/>.
        /// </summary>
        public T FalseValue { get; }
        #endregion Public properties

        #region Public methods

        /// <summary>Returns <see cref="TrueValue"/> if specified <paramref name="value"/> is <see langword="true"/>, otherwise <see cref="FalseValue"/>.</summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns><see cref="TrueValue"/> if specified <paramref name="value"/> is  <see langword="true"/>, otherwise <see cref="FalseValue"/>.</returns>
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!bool.TryParse(value.ToString(), out bool boolValue))
            {
                return DependencyProperty.UnsetValue;
            }

            return boolValue ? TrueValue : FalseValue;
        }

        /// <summary>Returns <see langword="true"/> if specified <paramref name="value"/> is <see cref="TrueValue"/>, otherwise <see langword="false"/>.</summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns><see langword="true"/> if specified <paramref name="value"/> is <see cref="TrueValue"/>, otherwise <see langword="false"/>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    // Cast ConvertFromString(string text) : object to (T)
                    T? tValue = (T?)converter.ConvertFromString(value.ToString()!);

                    if(tValue == null)
                    {
                        return DependencyProperty.UnsetValue;
                    }

                    return EqualityComparer<T>.Default.Equals(tValue, TrueValue);
                }
                return DependencyProperty.UnsetValue;
            }
            catch (Exception)
            {
                return DependencyProperty.UnsetValue;
            }
        }

        /// <summary>Returns current converter instance.</summary>
        /// <param name="serviceProvider">A service provider helper that can provide services for the markup extension.</param>
        /// <returns>Current converter instance.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        #endregion Public methods

        #region Private methods

        #endregion Private methods
    }
}
