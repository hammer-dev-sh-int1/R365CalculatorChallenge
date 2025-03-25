using R365CalculatorChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R365CalculatorChallenge.Interfaces
{
    public interface ICalculationService
    {
        CalculationResult Calculate(string input, string delimiter = "", bool denyNegativeNumbers = true,
                                                                                            double upperBoundLimit = 1000);
    }
}
