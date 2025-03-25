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
            // split the string on allowed delimiters (',' and '\n')
            var numbers = input.Split(new[] { ',', '\n' }, StringSplitOptions.None);

            // keep this for tracking total(s)
            double sum = 0;

            // keep this for tracking negative numbers
            List<double> lstNegativeNumbers = new();

            // iterate through the string array, convert our strings to numbers, perform the operation(s)
            foreach (string number in numbers)
            {
                // this will try to parse the number (default to 0 if cannot) 
                var currentNumber = double.TryParse(number, out var result) ? result : 0;

                // we need to treat any number > 1000 as 0 (invalid)
                currentNumber = currentNumber > 1000 ? 0 : currentNumber;

                // we need to deny negative numbers here and store them to include in the exception
                if (currentNumber < 0)
                {
                    // store the negative numbers in a list - we will store them all as it does not specify only unique
                    lstNegativeNumbers.Add(currentNumber);
                }
                else
                {
                    // add only the positive numbers
                    sum += currentNumber;
                }
            }

            if (lstNegativeNumbers.Count > 0)
            {
                // throw an exception here because the list contained negative numbers
                throw new InvalidInputException($"Cannot contain negative numbers: {String.Join(',', lstNegativeNumbers)}");
            }

            return sum;
        }
    }
}
