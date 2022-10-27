using System.Windows;

namespace Adita.PlexNet.Wpf.Converters
{
    /// <summary>
    /// Represents a <see langword="bool"/> to <see cref="Visibility"/> converter
    /// </summary>
    public sealed class BooleanToVisibilityConverter : BooleanToValueConverter<Visibility>
    {
        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="BooleanToVisibilityConverter" /> .
        /// </summary>
        public BooleanToVisibilityConverter() : base(Visibility.Visible, Visibility.Collapsed) { }
        #endregion Constructors
    }
}
