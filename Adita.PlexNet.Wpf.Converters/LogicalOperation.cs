using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adita.PlexNet.Wpf.Converters
{
    /// <summary>
    /// Defines a logical operation for <see cref="LogicalMultiConverter"/>.
    /// </summary>
    public enum LogicalOperation
    {
        /// <summary>
        /// 'And' ('&amp;') logical operation.
        /// </summary>
        And,
        /// <summary>
        /// 'Or' ('|') logical operation.
        /// </summary>
        Or,
        /// <summary>
        /// 'Exclusive Or' ('^') logical operation.
        /// </summary>
        ExclusiveOr
    }
}
