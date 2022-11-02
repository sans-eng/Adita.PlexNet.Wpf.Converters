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
    public class StringWhiteSpaceRemoverConverterTest
    {
        [TestMethod]
        public void CanRemove()
        {
            StringWhiteSpaceRemoverConverter converter = new();

            var result1 = converter.Convert("This is string", typeof(string), "", CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 is string);
            Assert.AreEqual((string)result1, "Thisisstring");

            var result2 = converter.Convert(122, typeof(string), "", CultureInfo.InvariantCulture);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 == DependencyProperty.UnsetValue);
        }

        [TestMethod]
        public void ShouldCannotConvertBack()
        {
            StringWhiteSpaceRemoverConverter converter = new();
            var result = converter.ConvertBack("as dd", typeof(string), "", CultureInfo.InvariantCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == DependencyProperty.UnsetValue);
        }
    }
}
