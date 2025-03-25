using Microsoft.Extensions.DependencyInjection;
using R365CalculatorChallenge.Exceptions;
using R365CalculatorChallenge.Interfaces;
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
                // stretch goal for implementing DI
                // this makes it easy to swap out for future implementations of subtractionService, multiplyService, etc.
                var serviceProvider = new ServiceCollection()
                    .AddSingleton<ICalculationService, AdditionService>()
                    .BuildServiceProvider();

                var calculationService = serviceProvider.GetService<ICalculationService>();

                Console.WriteLine(calculationService.Calculate("//[*][!!][r9r]\n11r9r22*hh*33!!44").FormulaWithAnswer);
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
