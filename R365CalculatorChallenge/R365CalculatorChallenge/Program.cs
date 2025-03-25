using R365CalculatorChallenge.Exceptions;
using R365CalculatorChallenge.Services;
using System.Text.RegularExpressions;

namespace R365CalculatorChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdditionService additionService = new AdditionService();

            try
            {
                // in this stretch goal, we want to allow the user to send in arguments to:
                //  add an alternative delimiter (step #3)
                //  toggle whether to deny negative numbers (step #4)
                //  change/remove upper bound limit (step #5)

                

                // call the calculation function
                // we want to make sure we unescape the userinput so eliminate the escape characters added automatically
                // we will also use named parameters to show we can supply any optional parameter we want, having
                //  the rest be their default values (per the original spec)

                var resultUpperDefault = additionService.Calculate(Regex.Unescape("2,1001,6"));   // upper bound=1000 (default)
                var resultUpperIncreased = additionService.Calculate(Regex.Unescape("2,1001,6"), upperBoundLimit: 4000);   // upper bound=4000

                // commenting below out because it throws an exception
                //var resultDenyNegative = additionService.Calculate(Regex.Unescape("4,-3"));
                var resultAllowNegative = additionService.Calculate(Regex.Unescape("4,-3"), denyNegativeNumbers: false);

                // display full formula
                Console.WriteLine($"Result (UpperLimitRestraintDefault): {resultUpperDefault.FormulaWithAnswer}");
                Console.WriteLine($"Result (UpperLimitRestraintIncreased): {resultUpperIncreased.FormulaWithAnswer}");
                Console.WriteLine($"Result (AllowNegative): {resultAllowNegative.FormulaWithAnswer}");
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine($"Input Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }        
    }
}
