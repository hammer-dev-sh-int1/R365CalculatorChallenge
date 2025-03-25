using R365CalculatorChallenge.Exceptions;
using R365CalculatorChallenge.Services;

namespace R365CalculatorChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdditionService additionService = new AdditionService();

            try
            {
                var result = additionService.Calculate("2,,4,rrrr,1001,6");
                Console.WriteLine(result.FormulaWithAnswer);
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine($"InputEx:  {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ex:  {ex.Message}");
            }
        }
    }
}
