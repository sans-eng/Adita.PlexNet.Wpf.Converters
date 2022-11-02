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
    public class ArithmeticMultiConverterTest
    {
        [TestMethod]
        public void CanMultiply()
        {
            double operand1 = 5;
            double operand2 = 2;
            double operand3 = 3;

            ArithmeticMultiConverter converter = new();

            converter.Operation = ArithmeticOperation.Multiplication;
            var result = converter.Convert(new object[] { operand1, operand2, operand3 }, typeof(double), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result is double);
            Assert.IsTrue((double)result == 30);
        }

        [TestMethod]
        public void CanDivide()
        {
            double operand1 = 20;
            double operand2 = 4;
            double operand3 = 2;

            ArithmeticMultiConverter converter = new();

            converter.Operation = ArithmeticOperation.Division;
            var result = converter.Convert(new object[] { operand1, operand2, operand3 }, typeof(double), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result is double);
            Assert.IsTrue((double)result == 2.5);
        }

        [TestMethod]
        public void CanAdd()
        {
            double operand1 = 20;
            double operand2 = 4;
            double operand3 = 2;

            ArithmeticMultiConverter converter = new();

            converter.Operation = ArithmeticOperation.Addition;
            var result = converter.Convert(new object[] { operand1, operand2, operand3 }, typeof(double), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result is double);
            Assert.IsTrue((double)result == 26);
        }

        [TestMethod]
        public void CanSubstract()
        {
            double operand1 = 20;
            double operand2 = 5;
            double operand3 = 2;

            ArithmeticMultiConverter converter = new();

            converter.Operation = ArithmeticOperation.Subtraction;
            var result = converter.Convert(new object[] { operand1, operand2, operand3 }, typeof(double), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result is double);
            Assert.IsTrue((double)result == 13);
        }

        [TestMethod]
        public void ShouldReturnUnsetValue()
        {
            string operand1 = "as";
            double operand2 = 4;
            double operand3 = 2;

            ArithmeticMultiConverter converter = new();

            converter.Operation = ArithmeticOperation.Addition;
            var result = converter.Convert(new object[] { operand1, operand2, operand3 }, typeof(double), 0, CultureInfo.InvariantCulture);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == DependencyProperty.UnsetValue);
        }

        [TestMethod]
        public void ShouldCannotConvertBack()
        {
            ArithmeticMultiConverter converter = new();

            converter.Operation = ArithmeticOperation.Subtraction;
            var result = converter.ConvertBack(23, new[] { typeof(double), typeof(double), typeof(double) }, 0, CultureInfo.InvariantCulture);
            Assert.IsNull(result);
        }
    }
}
