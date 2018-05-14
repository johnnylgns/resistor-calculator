using Microsoft.VisualStudio.TestTools.UnitTesting;
using OhmCalculator.BusinessLogic;
using OhmCalculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmCalculator.BusinessLogic.Tests
{
    [TestClass()]
    public class OhmValueCalculatorTest
    {
        [TestMethod()]
        public void CalculateOhmValueTest()
        {
            //Valid input values
            OhmValueCalculator ohmValueCalculator = new OhmValueCalculator();
            string colorA = Enum.GetName(typeof(ColorType), ColorType.Brown);
            string colorB = Enum.GetName(typeof(ColorType), ColorType.Black);
            string colorC = Enum.GetName(typeof(ColorType), ColorType.Black);
            string colorD = Enum.GetName(typeof(ColorType), ColorType.Brown);
            int ohmValue = ohmValueCalculator.CalculateOhmValue(colorA, colorB, colorC, colorD);
            Assert.AreEqual(1001, ohmValue);
            colorA = Enum.GetName(typeof(ColorType), ColorType.Red);
            colorB = Enum.GetName(typeof(ColorType), ColorType.Brown);
            colorC = Enum.GetName(typeof(ColorType), ColorType.Brown);
            colorD = Enum.GetName(typeof(ColorType), ColorType.Red);
            ohmValue = ohmValueCalculator.CalculateOhmValue(colorA, colorB, colorC, colorD);
            Assert.AreEqual(2112, ohmValue);
            colorA = Enum.GetName(typeof(ColorType), ColorType.Violet);
            colorB = Enum.GetName(typeof(ColorType), ColorType.Orange);
            colorC = Enum.GetName(typeof(ColorType), ColorType.Blue);
            colorD = Enum.GetName(typeof(ColorType), ColorType.Violet);
            ohmValue = ohmValueCalculator.CalculateOhmValue(colorA, colorB, colorC, colorD);
            Assert.AreEqual(7367, ohmValue);
            colorA = Enum.GetName(typeof(ColorType), ColorType.White);
            colorB = Enum.GetName(typeof(ColorType), ColorType.White);
            colorC = Enum.GetName(typeof(ColorType), ColorType.Silver);
            colorD = Enum.GetName(typeof(ColorType), ColorType.Silver);
            ohmValue = ohmValueCalculator.CalculateOhmValue(colorA, colorB, colorC, colorD);
            Assert.AreEqual(-99211, ohmValue);

            //Invalid input values
            colorA = Enum.GetName(typeof(ColorType), ColorType.Pink);
            colorB = Enum.GetName(typeof(ColorType), ColorType.Pink);
            colorC = Enum.GetName(typeof(ColorType), ColorType.Pink);
            colorD = Enum.GetName(typeof(ColorType), ColorType.Pink);
            ohmValue = ohmValueCalculator.CalculateOhmValue(colorA, colorB, colorC, colorD);
            Assert.AreEqual(0, ohmValue);

            colorA = "An invalid string";
            colorB = "An invalid string";
            colorC = "An invalid string";
            colorD = "An invalid string";
            ohmValue = ohmValueCalculator.CalculateOhmValue(colorA, colorB, colorC, colorD);
            Assert.AreEqual(0, ohmValue);
        }

        [TestMethod()]
        public void DecodeOhmValueTest()
        {

            OhmValueCalculator ohmValueCalculator = new OhmValueCalculator();
            int codedOhmValue = 1001;
            string result = ohmValueCalculator.DecodeOhmValue(codedOhmValue);
            string expectedString = "10 Ω ±1%";
            Assert.AreEqual(expectedString, result);

            codedOhmValue = 2112;
            result = ohmValueCalculator.DecodeOhmValue(codedOhmValue);
            expectedString = "210 Ω ±2%";
            Assert.AreEqual(expectedString, result);

            codedOhmValue = 7367;
            result = ohmValueCalculator.DecodeOhmValue(codedOhmValue);
            expectedString = "73 MΩ ±0.1%";
            Assert.AreEqual(expectedString, result);

            codedOhmValue = -99211;
            result = ohmValueCalculator.DecodeOhmValue(codedOhmValue);
            expectedString = "0.99 Ω ±10%";
            Assert.AreEqual(expectedString, result);

        }
    }
}