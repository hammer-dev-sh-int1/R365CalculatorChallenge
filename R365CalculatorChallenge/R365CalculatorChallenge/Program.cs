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
                //Console.WriteLine(additionService.Calculate("1,2,3,4,5,6,7,8,9,10,11,12"));
                Console.WriteLine(additionService.Calculate("//[*][!!][r9r]\n11r9r22*hh*33!!44"));
                
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
