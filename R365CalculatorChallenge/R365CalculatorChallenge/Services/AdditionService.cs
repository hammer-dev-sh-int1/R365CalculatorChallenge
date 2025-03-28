﻿using R365CalculatorChallenge.Exceptions;
using R365CalculatorChallenge.Helpers;
using R365CalculatorChallenge.Interfaces;
using R365CalculatorChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R365CalculatorChallenge.Services
{
    public class AdditionService : ICalculationService
    {
        // supported default delimiters, list format so we can append
        List<string> lstSupportedDelimiters = new List<string>() { ",", "\n" };

        public CalculationResult Calculate(string input, string delimiter = "", bool denyNegativeNumbers = true, 
                                                                                            double upperBoundLimit = 1000)
        {
            // we need to see if the user is supplying a custom character delimter
            (bool hasCustomInput, List<string> lstCustomDelimiter) = InputParser.ParseInputForCustomDelimter(input);

            // if it has a custom input, we want to append it to the list of acceptable delims
            if (hasCustomInput)
            {
                // merge our default list with anything returned from parsed input
                lstSupportedDelimiters.AddRange(lstCustomDelimiter);
            }

            // here we want to add the optional parameter for delimiter if it's not empty and/or in the list already
            if (!String.IsNullOrEmpty(delimiter) && !lstCustomDelimiter.Contains(delimiter))
                lstCustomDelimiter.Add(delimiter);

            // split the string on allowed delimiters (',' and '-'), changed to use a list so we can add (Req6)
            var numbers = input.Split(lstSupportedDelimiters.ToArray(), StringSplitOptions.None);

            // keep this for tracking total(s)
            double sum = 0;
            List<double> lstNumbersForCalculation = new();

            // keep this for tracking negative numbers
            List<double> lstNegativeNumbers = new();

            // iterate through the string array, convert our strings to numbers, perform the operation(s)
            foreach (string number in numbers)
            {
                // this will try to parse the number (default to 0 if cannot) 
                var currentNumber = double.TryParse(number, out var result) ? result : 0;

                // we need to treat any number > 1000 as 0 (invalid)
                currentNumber = currentNumber > upperBoundLimit ? 0 : currentNumber;

                // add to the list so that we can provide the formula used to calculate result
                lstNumbersForCalculation.Add(currentNumber);

                // we need to deny negative numbers here and store them to include in the exception
                // here we take the optional parameter and see if we want to exclude the negative numbers
                if (currentNumber < 0 && denyNegativeNumbers)
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

            // returning new object so we can display the sum and/
            return new CalculationResult(sum, String.Join('+', lstNumbersForCalculation));
        }
    }
}
