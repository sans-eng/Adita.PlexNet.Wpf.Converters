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
