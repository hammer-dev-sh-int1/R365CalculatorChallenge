using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R365CalculatorChallenge.Models
{
    public class CalculationResult
    {
        public double Sum { get; set; }
        public string Formula { get; set; }

        public string FormulaWithAnswer
        {
            get { return $"{this.Formula} = {this.Sum}"; }
        }

        public int TotalNumbersInFormula
        {
            get { return this.Formula.Split('+').Length; }
        }

        public CalculationResult(double sum, string formula)
        {
            Sum = sum;
            Formula = formula;
        }
    }
}
