using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OhmCalculator.Models;

namespace OhmCalculator.Interfaces
{
    public interface IOhmValueCalculator
    {
        int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);

        string DecodeOhmValue(int codedOhmValue);

        CalculatorColors GetValidCalculatorColors();
    }
}