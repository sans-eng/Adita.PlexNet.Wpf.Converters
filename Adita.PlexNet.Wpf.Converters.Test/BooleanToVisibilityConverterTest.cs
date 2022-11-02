using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Adita.PlexNet.Wpf.Converters.Test
{
    [TestClass]
    public class BooleanToVisibilityConverterTest
    {
        [TestMethod]
        public void CanConvert()
        {
            BooleanToVisibilityConverter converter = new();

            var result1 = converter.Convert(true, typeof(Visibility), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 is Visibility);
            Assert.IsTrue((Visibility)result1 == Visibility.Visible);

            var result2 = converter.Convert(false, typeof(Visibility), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 is Visibility);
            Assert.IsTrue((Visibility)result2 == Visibility.Collapsed);
        }

        [TestMethod]
        public void CanConvertBack()
        {
            BooleanToVisibilityConverter converter = new();

            var result1 = converter.ConvertBack(Visibility.Visible, typeof(Visibility), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 is bool);
            Assert.IsTrue((bool)result1);

            var result2 = converter.ConvertBack(Visibility.Collapsed, typeof(Visibility), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 is bool);
            Assert.IsTrue(!(bool)result2);
        }

        [TestMethod]
        public void ShouldReturnUnsetValue()
        {
            BooleanToVisibilityConverter converter = new();

            var result1 = converter.Convert("as", typeof(Visibility), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 == DependencyProperty.UnsetValue);

            var result2 = converter.ConvertBack("as", typeof(Visibility), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 == DependencyProperty.UnsetValue);
        }
    }
}
