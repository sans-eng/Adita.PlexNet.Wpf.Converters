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
    public class ArithmeticConverterTest
    {
        [TestMethod]
        public void CanMultiply()
        {
            ArithmeticConverter converter = new ArithmeticConverter();

            converter.Operation = ArithmeticOperation.Multiplication;
            var result = converter.Convert(10, typeof(double), 2, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result is double);
            Assert.IsTrue((double)result == 20);
        }

        [TestMethod]
        public void CanDivide()
        {
            ArithmeticConverter converter = new ArithmeticConverter();

            converter.Operation = ArithmeticOperation.Division;
            var result = converter.Convert(10, typeof(double), 2, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result is double);
            Assert.IsTrue((double)result == 5);
        }

        [TestMethod]
        public void CanAdd()
        {
            ArithmeticConverter converter = new ArithmeticConverter();

            converter.Operation = ArithmeticOperation.Addition;
            var result = converter.Convert(10, typeof(double), 2, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result is double);
            Assert.IsTrue((double)result == 12);
        }

        [TestMethod]
        public void CanSubstract()
        {
            ArithmeticConverter converter = new ArithmeticConverter();

            converter.Operation = ArithmeticOperation.Subtraction;
            var result = converter.Convert(10, typeof(double), 2, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result is double);
            Assert.IsTrue((double)result == 8);
        }

        [TestMethod]
        public void ShouldReturnUnsetValue()
        {
            ArithmeticConverter converter = new ArithmeticConverter();

            converter.Operation = ArithmeticOperation.Addition;
            var result1 = converter.Convert("qw", typeof(double), 2, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1 == DependencyProperty.UnsetValue);

            var result2 = converter.Convert(12, typeof(double), "we", CultureInfo.InvariantCulture);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2 == DependencyProperty.UnsetValue);
        }

        [TestMethod]
        public void ShouldCannotConvertBack()
        {
            ArithmeticConverter converter = new ArithmeticConverter();

            converter.Operation = ArithmeticOperation.Addition;
            var result = converter.ConvertBack(11, typeof(double), 2, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == DependencyProperty.UnsetValue);
        }
    }
}
