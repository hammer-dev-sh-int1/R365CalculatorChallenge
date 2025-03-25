using R365CalculatorChallenge.Exceptions;
using R365CalculatorChallenge.Services;
using System.Text.RegularExpressions;

namespace R365CalculatorChallenge
{
    internal class Program
    {
        // we want this so we can
        static bool userWantsExit = false;
        static void Main(string[] args)
        {
            AdditionService additionService = new AdditionService();

            // Register a Control+C handler
            Console.CancelKeyPress += new ConsoleCancelEventHandler(CancelKeyPressHandler);

            while (!userWantsExit)
            {
                try
                {
                    if (userWantsExit)
                        break; // exit here to prevent any validations on input

                    Console.Write("Enter Delimited List of Numbers for Calculation: ");
                    string userInput = Console.ReadLine();

                    if (string.IsNullOrEmpty(userInput) && (userWantsExit==false))
                    {
                        Console.WriteLine("No input - please retry.");
                        continue;
                    }

                    // call the calculation function
                    // we want to make sure we unescape the userinput so eliminate the escape characters added automatically
                    var result = additionService.Calculate(Regex.Unescape(userInput));

                    // display full formula
                    Console.WriteLine($"Result: {result.FormulaWithAnswer}");
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

        static void CancelKeyPressHandler(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            userWantsExit = true;
            Console.WriteLine("\nCtrl+C pressed. Exiting Calculation Application.");
            //Environment.Exit(0);
        }
    }
}
