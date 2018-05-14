using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OhmCalculator.Interfaces;
using OhmCalculator.Models;
using OhmCalculator.Enums;

namespace OhmCalculator.BusinessLogic
{
    public class OhmValueCalculator: IOhmValueCalculator
    {
        /// <summary>
        /// Calculates ohm value/tolerance given 4 band color strings
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band</param>
        /// <param name="bandBColor">The color of the second significant figure band</param>
        /// <param name="bandCColor">The color of the decimal multiplier</param>
        /// <param name="bandDColor">The color of the tolerance band</param>
        /// <returns>OhmValue as an integer. First 2 digits represent first 2 significant digits. 
        /// The 3rd value represents the multiplier (decimal represented as negative overall value). 
        /// Last digits represents tolerance value </returns>
        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {

            if (!validateInputValues(bandAColor, bandBColor, bandCColor, bandDColor))
            { 
                return 0;
            }
            //Get color type enum from string
            ColorType aColorType = (ColorType) Enum.Parse(typeof(ColorType), bandAColor);
            ColorType bColorType = (ColorType) Enum.Parse(typeof(ColorType), bandBColor);
            ColorType cColorType = (ColorType) Enum.Parse(typeof(ColorType), bandCColor);
            ColorType dColorType = (ColorType) Enum.Parse(typeof(ColorType), bandDColor);

            //Get color objects from colortype
            Color a = Color.GetColor(aColorType);
            Color b = Color.GetColor(bColorType);
            Color c = Color.GetColor(cColorType);
            //Create coded ohm value
            int codedOhmValue = Convert.ToInt32(string.Format("{0}{1}{2}{3}", a.DigitValue, b.DigitValue, Math.Abs(c.MultiplierExponentValue), (int)dColorType));
            if(c.MultiplierExponentValue < 0)
            {
                codedOhmValue *= -1;
            }
            return codedOhmValue;
        }

        //Decodes coded ohm value into a readable resistance/tolerance string
        public string DecodeOhmValue(int codedOhmValue)
        {
            int decimalMultipler = 1;
            if(codedOhmValue < 0)
            {
                //Decimal multiplier
                codedOhmValue = Math.Abs(codedOhmValue);
                decimalMultipler = -1;
            }
            int firstDigit = (int)(codedOhmValue.ToString()[0]) - 48;
            int secondDigit = (int)(codedOhmValue.ToString()[1]) - 48;
            int significantDigits = Convert.ToInt32(string.Format("{0}{1}", firstDigit, secondDigit));
            int multiplierExponent = (int)(codedOhmValue.ToString()[2]) - 48;
            multiplierExponent = decimalMultipler * multiplierExponent;
            int toleranceDigits = Convert.ToInt32((codedOhmValue.ToString().Substring(3)));
            string formatedOhmValue = formatValue(significantDigits, multiplierExponent);
            string toleranceValue = Color.GetColor((ColorType)toleranceDigits).TolerancePercentageValue.ToString();
            string ohmValue = string.Format("{0} ±{1}%", formatedOhmValue, toleranceValue);
            return ohmValue;
        }

        //Gets the valid colors for each band 
        public CalculatorColors GetValidCalculatorColors()
        {
            //Return color types
            List<string> AColors = new List<string>();
            AColors.Add(Enum.GetName(typeof(ColorType), ColorType.Brown));
            AColors.Add(Enum.GetName(typeof(ColorType), ColorType.Red));
            AColors.Add(Enum.GetName(typeof(ColorType), ColorType.Orange));
            AColors.Add(Enum.GetName(typeof(ColorType), ColorType.Yellow));
            AColors.Add(Enum.GetName(typeof(ColorType), ColorType.Green));
            AColors.Add(Enum.GetName(typeof(ColorType), ColorType.Blue));
            AColors.Add(Enum.GetName(typeof(ColorType), ColorType.Violet));
            AColors.Add(Enum.GetName(typeof(ColorType), ColorType.Grey));
            AColors.Add(Enum.GetName(typeof(ColorType), ColorType.White));
            List<string> BColors = new List<string>();
            BColors.Add(Enum.GetName(typeof(ColorType), ColorType.Black));
            BColors.Add(Enum.GetName(typeof(ColorType), ColorType.Brown));
            BColors.Add(Enum.GetName(typeof(ColorType), ColorType.Red));
            BColors.Add(Enum.GetName(typeof(ColorType), ColorType.Orange));
            BColors.Add(Enum.GetName(typeof(ColorType), ColorType.Yellow));
            BColors.Add(Enum.GetName(typeof(ColorType), ColorType.Green));
            BColors.Add(Enum.GetName(typeof(ColorType), ColorType.Blue));
            BColors.Add(Enum.GetName(typeof(ColorType), ColorType.Violet));
            BColors.Add(Enum.GetName(typeof(ColorType), ColorType.Grey));
            BColors.Add(Enum.GetName(typeof(ColorType), ColorType.White));
            List<string> CColors = new List<string>();
            CColors.Add(Enum.GetName(typeof(ColorType), ColorType.Black));
            CColors.Add(Enum.GetName(typeof(ColorType), ColorType.Brown));
            CColors.Add(Enum.GetName(typeof(ColorType), ColorType.Red));
            CColors.Add(Enum.GetName(typeof(ColorType), ColorType.Orange));
            CColors.Add(Enum.GetName(typeof(ColorType), ColorType.Yellow));
            CColors.Add(Enum.GetName(typeof(ColorType), ColorType.Green));
            CColors.Add(Enum.GetName(typeof(ColorType), ColorType.Blue));
            CColors.Add(Enum.GetName(typeof(ColorType), ColorType.Violet));
            CColors.Add(Enum.GetName(typeof(ColorType), ColorType.Grey));
            CColors.Add(Enum.GetName(typeof(ColorType), ColorType.White));
            CColors.Add(Enum.GetName(typeof(ColorType), ColorType.Gold));
            CColors.Add(Enum.GetName(typeof(ColorType), ColorType.Silver));
            CColors.Add(Enum.GetName(typeof(ColorType), ColorType.Pink));
            List<string> DColors = new List<string>();
            DColors.Add(Enum.GetName(typeof(ColorType), ColorType.Brown));
            DColors.Add(Enum.GetName(typeof(ColorType), ColorType.Red));
            DColors.Add(Enum.GetName(typeof(ColorType), ColorType.Green));
            DColors.Add(Enum.GetName(typeof(ColorType), ColorType.Blue));
            DColors.Add(Enum.GetName(typeof(ColorType), ColorType.Violet));
            DColors.Add(Enum.GetName(typeof(ColorType), ColorType.Grey));
            DColors.Add(Enum.GetName(typeof(ColorType), ColorType.Gold));
            DColors.Add(Enum.GetName(typeof(ColorType), ColorType.Silver));
            CalculatorColors colors = new CalculatorColors()
            {
                AColors = AColors,
                BColors = BColors,
                CColors = CColors,
                DColors = DColors
            };
            return colors;
        }

        //Formats Ohm value from format (significantDigits) X 10 ^(multiplerExponent) 
        private string formatValue(int significantDigits, int multiplierExponent)
        {
            if (multiplierExponent >= 8)
                return (significantDigits * Math.Pow(10, multiplierExponent - 9)).ToString() + " GΩ";
            else if (multiplierExponent >= 5)
                return (significantDigits * Math.Pow(10, multiplierExponent - 6)).ToString() + " MΩ";
            else if (multiplierExponent >= 2)
                return (significantDigits * Math.Pow(10, multiplierExponent - 3)).ToString() + " KΩ";
            else
                return (significantDigits * (double)Math.Pow(10, multiplierExponent)).ToString() + " Ω";
        }

        //Validates input values
        private bool validateInputValues(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            //check validity of color strings for each band
            CalculatorColors calculatorColors = GetValidCalculatorColors();
            if (!calculatorColors.AColors.Contains(bandAColor))
                return false;
            if (!calculatorColors.BColors.Contains(bandBColor))
                return false;
            if (!calculatorColors.CColors.Contains(bandCColor))
                return false;
            if (!calculatorColors.DColors.Contains(bandDColor))
                return false;

            //Check if we can parse strings to colortypes
            ColorType aColorType;
            ColorType bColorType;
            ColorType cColorType;
            ColorType dColorType;
            if (!Enum.TryParse(bandAColor, out aColorType))
                return false;
            if (!Enum.TryParse(bandBColor, out bColorType))
                return false;
            if (!Enum.TryParse(bandCColor, out cColorType))
                return false;
            if (!Enum.TryParse(bandDColor, out dColorType))
                return false;

            return true;

        }
    }
}