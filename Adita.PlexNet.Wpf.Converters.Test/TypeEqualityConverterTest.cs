using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Security.Claims;
using System.Text;
using System.Windows;

namespace Adita.PlexNet.Wpf.Converters.Test
{
    [TestClass]
    public class TypeEqualityConverterTest
    {
        [TestMethod]
        public void CanCheckEquality()
        {
            TypeEqualityConverter converter = new TypeEqualityConverter();
            Assert.IsNotNull(converter);

            var result1 = converter.Convert(new Claim(ClaimTypes.Name, "name"), typeof(bool), typeof(Claim), CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 is bool);
            Assert.IsTrue((bool)result1);

            var result2 = converter.Convert(new Claim(ClaimTypes.Name, "name"), typeof(bool), typeof(ClaimsPrincipal), CultureInfo.InvariantCulture);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 is bool);
            Assert.IsFalse((bool)result2);
        }

        [TestMethod]
        public void ShouldCannotConvertBack()
        {
            TypeEqualityConverter converter = new TypeEqualityConverter();
            Assert.IsNotNull(converter);

            var result = converter.ConvertBack(new Claim(ClaimTypes.Name, "name"), typeof(bool), typeof(Claim), CultureInfo.InvariantCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == DependencyProperty.UnsetValue);
        }
    }
}
