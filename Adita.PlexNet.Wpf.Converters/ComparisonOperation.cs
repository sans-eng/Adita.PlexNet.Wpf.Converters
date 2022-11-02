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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adita.PlexNet.Wpf.Converters
{
    /// <summary>
    /// Defines a comparison operation of <see cref="ComparisonConverter"/>.
    /// </summary>
    public enum ComparisonOperation
    {
        /// <summary>
        /// Less than operation.
        /// </summary>
        LessThan,
        /// <summary>
        /// Less than or equal operation.
        /// </summary>
        LessThanOrEqual,
        /// <summary>
        /// Greater than operation.
        /// </summary>
        GreaterThan,
        /// <summary>
        /// Greater than or equal operation.
        /// </summary>
        GreaterThanOrEqual,
        /// <summary>
        /// Equality operation.
        /// </summary>
        Equal,
        /// <summary>
        /// Inequality operation.
        /// </summary>
        Inequal
    }
}
