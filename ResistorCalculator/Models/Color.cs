using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OhmCalculator.Enums;

namespace OhmCalculator.Models
{
    public class Color
    {
        public int DigitValue { get; set; }
        public int MultiplierExponentValue { get; set; }
        public float TolerancePercentageValue { get; set; }

        public static Color GetColor(ColorType type)
        {
            Color color = new Color();
            switch (type)
            {
                case ColorType.Black:
                    color.DigitValue = 0;
                    color.MultiplierExponentValue = 0;
                    break;
                case ColorType.Brown:
                    color.DigitValue = 1;
                    color.MultiplierExponentValue = 1;
                    color.TolerancePercentageValue = 1;
                    break;
                case ColorType.Red:
                    color.DigitValue = 2;
                    color.MultiplierExponentValue = 2;
                    color.TolerancePercentageValue = 2;
                    break;
                case ColorType.Orange:
                    color.DigitValue = 3;
                    color.MultiplierExponentValue = 3;
                    break;
                case ColorType.Yellow:
                    color.DigitValue = 4;
                    color.MultiplierExponentValue = 4;
                    break;
                case ColorType.Green:
                    color.DigitValue = 5;
                    color.MultiplierExponentValue = 5;
                    color.TolerancePercentageValue = 0.5F;
                    break;
                case ColorType.Blue:
                    color.DigitValue = 6;
                    color.MultiplierExponentValue = 6;
                    color.TolerancePercentageValue = 0.25F;
                    break;
                case ColorType.Violet:
                    color.DigitValue = 7;
                    color.MultiplierExponentValue = 7;
                    color.TolerancePercentageValue = 0.1F;
                    break;
                case ColorType.Grey:
                    color.DigitValue = 8;
                    color.MultiplierExponentValue = 8;
                    color.TolerancePercentageValue = 0.05F;
                    break;
                case ColorType.White:
                    color.DigitValue = 9;
                    color.MultiplierExponentValue = 9;
                    break;
                case ColorType.Gold:
                    color.MultiplierExponentValue = -1;
                    color.TolerancePercentageValue = 5;
                    break;
                case ColorType.Silver:
                    color.MultiplierExponentValue = -2;
                    color.TolerancePercentageValue = 10;
                    break;
                case ColorType.Pink:
                    color.MultiplierExponentValue = -3;
                    break;          
                    
            }
            return color;
        }
    }

}