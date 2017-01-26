using System;
using Windows.UI.Xaml.Controls;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using CalculatorWin10;

namespace Tests
{
    public class Vars
    {
        //static Random rnd = new Random();
        
    }
    [TestClass]
    public class MathControlsTests
    {
        double arg0 = Math.PI;
        double arg1 = Math.E; 
        [TestMethod]
        public void AdditionTest()
        {
            //Random rnd = new Random();
            //var arg0 = rnd.Next();
            //var arg1 = rnd.Next();
            
            DisplayInfo.firstVarValue = arg0.ToString();
            DisplayInfo.secondVarValue = arg1.ToString();
            MathControls.Addition();
            var actual = (Math.Round(DisplayInfo.expressionValue, 9)).ToString();
            var expected = (Math.Round((arg0 + arg1), 9)).ToString();
            Assert.AreEqual(expected: expected, actual: actual);
        }
        [TestMethod]
        public void SubtractionTest()
        {
            
            DisplayInfo.firstVarValue = arg0.ToString();
            DisplayInfo.secondVarValue = arg1.ToString();
            MathControls.Subtraction();
            var actual = (Math.Round(DisplayInfo.expressionValue, 10)).ToString();
            var expected = (Math.Round((arg0 - arg1), 10)).ToString();
            Assert.AreEqual(expected: expected, actual: actual);
        }
        [TestMethod]
        public void MultiplicationTest()
        {
            DisplayInfo.firstVarValue = arg0.ToString();
            DisplayInfo.secondVarValue = arg1.ToString();
            MathControls.Multiplication();
            var actual = (Math.Round(DisplayInfo.expressionValue,10)).ToString();
            var expected = (Math.Round((arg0 * arg1), 10)).ToString();
            Assert.AreEqual(expected: expected, actual: actual);
        }
        [TestMethod]
        public void DivisionTest()
        {
            DisplayInfo.firstVarValue = null;
            DisplayInfo.secondVarValue = null;
            DisplayInfo.firstVarValue = arg0.ToString();
            DisplayInfo.secondVarValue = arg1.ToString();
            MathControls.Division();
            var actual = (Math.Round(DisplayInfo.expressionValue, 10)).ToString();
            var expected = (Math.Round((arg0 / arg1), 10)).ToString();
            Assert.AreEqual(expected: expected, actual: actual);
        }
        [TestMethod]
        public void PecentageTest()
        {
            DisplayInfo.firstVarValue = null;
            
            DisplayInfo.firstVarValue = arg0.ToString();
            
            MathControls.Percentage(arg0.ToString());
            var actual = (Math.Round(DisplayInfo.expressionValue, 9)).ToString();
            var expected = (Math.Round(arg0*arg0 / 100f, 9)).ToString();
            Assert.AreEqual(expected: expected, actual: actual);
        }
        [TestMethod]
        public void SquareRootTest()
        {
            DisplayInfo.firstVarValue = null;
            DisplayInfo.secondVarValue = null;
            DisplayInfo.firstVarValue = arg0.ToString();
            DisplayInfo.secondVarValue = arg1.ToString();
            MathControls.SquareRoot(arg0.ToString());
            var actual = (Math.Round(DisplayInfo.expressionValue, 10)).ToString();
            var expected = (Math.Round(Math.Sqrt(arg0), 10)).ToString();
            Assert.AreEqual(expected: expected, actual: actual);
        }
        [TestMethod]
        public void PowerOfTwoTest()
        {
            DisplayInfo.firstVarValue = null;
            
            DisplayInfo.firstVarValue = arg0.ToString();
            
            MathControls.PowerOfTwo(arg0.ToString());
            var actual = (Math.Round(DisplayInfo.expressionValue, 10)).ToString();
            var expected = (Math.Round(arg0*arg0, 10)).ToString();
            Assert.AreEqual(expected: expected, actual: actual);
        }
        [TestMethod]
        public void OneOverTest()
        {
            DisplayInfo.firstVarValue = null;

            DisplayInfo.firstVarValue = arg0.ToString();

            MathControls.OneOver(arg0.ToString());
            var actual = (Math.Round(DisplayInfo.expressionValue, 10)).ToString();
            var expected = (Math.Round(1/arg0, 10)).ToString();
            Assert.AreEqual(expected: expected, actual: actual);
        }

        [TestMethod]
        public void WriteOperatorTest()
        {
            MathControls.WriteOperator("multiplication");
            var actual = MathControls.mathFunction;
            var expected = "*";
            Assert.AreEqual(expected: expected, actual: actual);
        }
    }

    [TestClass]
    public class DisplayInfoTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
    [TestClass]
    public class ClickHandlerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
    [TestClass]
    public class MemoryHandlerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
