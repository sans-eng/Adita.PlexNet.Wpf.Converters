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
    public class LogicalMultiConverterTest
    {
        [TestMethod]
        public void CanCheckAndLogic()
        {
            LogicalMultiConverter converter = new LogicalMultiConverter();
            Assert.IsNotNull(converter);

            converter.Operation = LogicalOperation.And;

            var result1 = converter.Convert(new object[] { true, true, true }, typeof(bool), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 is bool);
            Assert.IsTrue((bool)result1);

            var result2 = converter.Convert(new object[] { true, true, false }, typeof(bool), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 is bool);
            Assert.IsFalse((bool)result2);
        }

        [TestMethod]
        public void CanCheckOrLogic()
        {
            LogicalMultiConverter converter = new LogicalMultiConverter();
            Assert.IsNotNull(converter);

            converter.Operation = LogicalOperation.Or;

            var result1 = converter.Convert(new object[] { true, true, true }, typeof(bool), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 is bool);
            Assert.IsTrue((bool)result1);

            var result2 = converter.Convert(new object[] { true, true, false }, typeof(bool), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 is bool);
            Assert.IsTrue((bool)result2);

            var result3 = converter.Convert(new object[] { false, false, false }, typeof(bool), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result3);
            Assert.IsTrue(result3 is bool);
            Assert.IsFalse((bool)result3);
        }

        [TestMethod]
        public void CanCheckExclusiveOrLogic()
        {
            LogicalMultiConverter converter = new LogicalMultiConverter();
            Assert.IsNotNull(converter);

            converter.Operation = LogicalOperation.ExclusiveOr;

            var result1 = converter.Convert(new object[] { true, true, true }, typeof(bool), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 is bool);
            Assert.IsFalse((bool)result1);

            var result2 = converter.Convert(new object[] { true, true, false }, typeof(bool), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 is bool);
            Assert.IsTrue((bool)result2);

            var result3 = converter.Convert(new object[] { false, false, false }, typeof(bool), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result3);
            Assert.IsTrue(result3 is bool);
            Assert.IsFalse((bool)result3);
        }

        [TestMethod]
        public void ShouldReturnUnsetValue()
        {
            var converter = new LogicalMultiConverter();
            converter.Operation = LogicalOperation.ExclusiveOr;

            var result1 = converter.Convert(new object[] { "as", true, true }, typeof(bool), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 == DependencyProperty.UnsetValue);

        }

        [TestMethod]
        public void ShouldCannotConvertBack()
        {
            var converter = new LogicalMultiConverter();
            converter.Operation = LogicalOperation.ExclusiveOr;

            var result = converter.ConvertBack(new object[] { "as", true, true }, new[] { typeof(bool), typeof(bool), typeof(bool) }, 0, CultureInfo.InvariantCulture);
            Assert.IsNull(result);

        }
    }
}
