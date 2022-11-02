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
    public class StringIsNullOrWhiteSpaceConverterTest
    {
        [TestMethod]
        public void CanCheck()
        {
            StringIsNullOrWhiteSpaceConverter converter = new();
            Assert.IsNotNull(converter);

            var result1 = converter.Convert(null!, typeof(string), "", CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 is bool);
            Assert.IsTrue((bool)result1);

            var result2 = converter.Convert("", typeof(string), "", CultureInfo.InvariantCulture);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 is bool);
            Assert.IsTrue((bool)result2);

            var result3 = converter.Convert("  ", typeof(string), "", CultureInfo.InvariantCulture);
            Assert.IsNotNull(result3);
            Assert.IsTrue(result3 is bool);
            Assert.IsTrue((bool)result3);

            var result4 = converter.Convert("aa", typeof(string), "", CultureInfo.InvariantCulture);
            Assert.IsNotNull(result4);
            Assert.IsTrue(result4 is bool);
            Assert.IsFalse((bool)result4);
        }

        [TestMethod]
        public void ShouldCannotConvertBack()
        {
            StringIsNullOrWhiteSpaceConverter converter = new();
            Assert.IsNotNull(converter);

            var result1 = converter.ConvertBack("", typeof(string), "", CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 == DependencyProperty.UnsetValue);
        }
    }
}
