using Microsoft.VisualStudio.TestTools.UnitTesting;
using OhmCalculator.Controllers;
using OhmCalculator.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using OhmCalculator.Enums;
namespace OhmCalculator.Controllers.Tests
{
    [TestClass()]
    public class OhmCalculatorControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            OhmValueCalculator ohmValueCalculator = new OhmValueCalculator();
            OhmCalculatorController controller = new OhmCalculatorController(ohmValueCalculator);
            var result = controller.Index();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CalculateOhmValueTest()
        {
            OhmValueCalculator ohmValueCalculator = new OhmValueCalculator();
            OhmCalculatorController controller = new OhmCalculatorController(ohmValueCalculator);
            var bandAColor = Enum.GetName(typeof(ColorType), ColorType.Brown);
            var bandBColor = Enum.GetName(typeof(ColorType), ColorType.Brown);
            var bandCColor = Enum.GetName(typeof(ColorType), ColorType.Brown);
            var bandDColor = Enum.GetName(typeof(ColorType), ColorType.Brown);
            var result = controller.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);
            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }
    }
}