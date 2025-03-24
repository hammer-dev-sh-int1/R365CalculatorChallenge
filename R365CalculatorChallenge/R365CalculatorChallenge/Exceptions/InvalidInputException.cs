using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R365CalculatorChallenge.Exceptions
{
    public class InvalidInputException : Exception
    {
        private const string exceptionPrefix = "Invalid Input for Calculation";
        public InvalidInputException() : base($"{exceptionPrefix}:  Invalid input provided for calculation.") { }

        public InvalidInputException(string message) : base($"{exceptionPrefix}:  {message}") { }

        public InvalidInputException(string message, Exception innerException)
            : base($"{exceptionPrefix}:  {message}", innerException) { }
    }
}
