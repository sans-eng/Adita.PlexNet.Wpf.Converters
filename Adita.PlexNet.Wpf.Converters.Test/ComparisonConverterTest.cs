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
    public class ComparisonConverterTest
    {
        [TestMethod]
        public void CanCompareLessThan()
        {
            ComparisonConverter converter = new();

            converter.Operation = ComparisonOperation.LessThan;

            var result1 = converter.Convert(10, typeof(bool), 20, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 is bool);
            Assert.IsTrue((bool)result1);

            var result2 = converter.Convert(10, typeof(bool), 5, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 is bool);
            Assert.IsFalse((bool)result2);
        }

        [TestMethod]
        public void CanCompareGreaterThan()
        {
            ComparisonConverter converter = new();

            converter.Operation = ComparisonOperation.GreaterThan;

            var result1 = converter.Convert(20, typeof(bool), 5, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 is bool);
            Assert.IsTrue((bool)result1);

            var result2 = converter.Convert(5, typeof(bool), 10, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 is bool);
            Assert.IsFalse((bool)result2);
        }

        [TestMethod]
        public void CanCompareLessThanOrEqual()
        {
            ComparisonConverter converter = new();

            converter.Operation = ComparisonOperation.LessThanOrEqual;

            var result1 = converter.Convert(10, typeof(bool), 20, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 is bool);
            Assert.IsTrue((bool)result1);

            var result2 = converter.Convert(10, typeof(bool), 5, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 is bool);
            Assert.IsFalse((bool)result2);

            var result3 = converter.Convert(10, typeof(bool), 10, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result3);
            Assert.IsTrue(result3 is bool);
            Assert.IsTrue((bool)result3);
        }

        [TestMethod]
        public void CanCompareGreaterThanOrEqual()
        {
            ComparisonConverter converter = new();

            converter.Operation = ComparisonOperation.GreaterThanOrEqual;

            var result1 = converter.Convert(20, typeof(bool), 5, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 is bool);
            Assert.IsTrue((bool)result1);

            var result2 = converter.Convert(5, typeof(bool), 10, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 is bool);
            Assert.IsFalse((bool)result2);

            var result3 = converter.Convert(10, typeof(bool), 10, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result3);
            Assert.IsTrue(result3 is bool);
            Assert.IsTrue((bool)result3);
        }

        [TestMethod]
        public void CanCompareEqual()
        {
            ComparisonConverter converter = new();

            converter.Operation = ComparisonOperation.Equal;

            var result1 = converter.Convert(5, typeof(bool), 5, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 is bool);
            Assert.IsTrue((bool)result1);

            var result2 = converter.Convert(5, typeof(bool), 6, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 is bool);
            Assert.IsFalse((bool)result2);
        }

        [TestMethod]
        public void CanCompareInEqual()
        {
            ComparisonConverter converter = new();

            converter.Operation = ComparisonOperation.Inequal;

            var result1 = converter.Convert(5, typeof(bool), 5, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 is bool);
            Assert.IsFalse((bool)result1);

            var result2 = converter.Convert(5, typeof(bool), 6, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 is bool);
            Assert.IsTrue((bool)result2);
        }

        [TestMethod]
        public void ShouldReturnUnsetValue()
        {
            ComparisonConverter converter = new();

            converter.Operation = ComparisonOperation.Inequal;

            var result = converter.Convert("as", typeof(bool), 5, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == DependencyProperty.UnsetValue);
        }

        [TestMethod]
        public void ShouldCannotConvertBack()
        {
            ComparisonConverter converter = new();

            converter.Operation = ComparisonOperation.Inequal;

            var result = converter.ConvertBack(5, typeof(bool), 5, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == DependencyProperty.UnsetValue);
        }
    }
}
