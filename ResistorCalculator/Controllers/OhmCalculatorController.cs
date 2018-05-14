using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OhmCalculator.Interfaces;
using OhmCalculator.BusinessLogic;
using OhmCalculator.Enums;
using OhmCalculator.Models;
namespace OhmCalculator.Controllers
{
    public class OhmCalculatorController : Controller
    {
        private IOhmValueCalculator ohmCalculator;

        public OhmCalculatorController(IOhmValueCalculator ohmValueCalculator)
        {
            ohmCalculator = ohmValueCalculator;
        }

        public ActionResult Index()
        {
            CalculatorColors colors = ohmCalculator.GetValidCalculatorColors();
            return View(colors);
        }

        [HttpPost]
        public JsonResult CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            int ohmValue = ohmCalculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);
            string result;
            if (ohmValue != 0)
            {
                result = ohmCalculator.DecodeOhmValue(ohmValue);
            }
            else
            {
                result = "An unexpected input was received, please try again";
            }
           
            return Json(result);
        }
      
    }
}