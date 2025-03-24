using R365CalculatorChallenge.Exceptions;
using R365CalculatorChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R365CalculatorChallenge.Services
{
    public class AdditionService : ICalculationService
    {
        public double Calculate(string input)
        {
            // parse/split the input based on comma delim
            string[] numbers = input.Split(',');

            // force max constraint on input of 2 numbers
            if (numbers.Length > 2)
            {
                throw new InvalidInputException("Input must contain 2 numbers.");
            }

            // keep this for tracking total(s)
            double sum = 0;

            // iterate through the string array, convert our strings to numbers, perform the operation(s)
            foreach (string number in numbers)
            {
                // this will try to parse the number (default to 0 if cannot) and incremement our couter (sum)
                // this handles invalid numbers and empty/missing inputs
                sum += double.TryParse(number, out var result) ? result : 0;
            }

            return sum;
        }
    }
}
