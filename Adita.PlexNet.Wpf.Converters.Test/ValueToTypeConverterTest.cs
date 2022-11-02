using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Adita.PlexNet.Wpf.Converters.Test
{
    [TestClass]
    public class ValueToTypeConverterTest
    {
        [TestMethod]
        public void CanConvert()
        {
            var converter = new ValueToTypeConverter();
            Assert.IsNotNull(converter);

            var result1 = converter.Convert(new Random(), typeof(Random), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 is Type);
            Assert.AreEqual(result1, typeof(Random));

            var result2 = converter.Convert(new Random(), typeof(Random), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 is Type);
            Assert.AreNotEqual(result2, typeof(ConfigurationCollectionAttribute));
        }

        [TestMethod]
        public void ShouldCannotConvertBack()
        {
            var converter = new ValueToTypeConverter();
            Assert.IsNotNull(converter);

            var result1 = converter.ConvertBack(new Random(), typeof(Random), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 == DependencyProperty.UnsetValue);
        }
    }
}
