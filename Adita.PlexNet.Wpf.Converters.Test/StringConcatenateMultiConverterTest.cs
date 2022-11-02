using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adita.PlexNet.Wpf.Converters.Test
{
    [TestClass]
    public class StringConcatenateMultiConverterTest
    {
        [TestMethod]
        public void CanConcate()
        {
            var converter = new StringConcatenateMultiConverter();
            Assert.IsNotNull(converter);

            var result = converter.Convert(new object[] { "Test", "concate" }, typeof(string), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result is string);
            Assert.AreEqual((string)result, "Testconcate");
        }

        [TestMethod]
        public void ShouldCannotConvertBack()
        {
            var converter = new StringConcatenateMultiConverter();
            Assert.IsNotNull(converter);

            var result = converter.ConvertBack("assa", new[] { typeof(string) , typeof(string) } , 0, CultureInfo.InvariantCulture);
            Assert.IsNull(result);
        }
    }
}
