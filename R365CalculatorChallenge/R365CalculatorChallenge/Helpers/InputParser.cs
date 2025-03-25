using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R365CalculatorChallenge.Helpers
{
    public static class InputParser
    {
        public static (bool, char) ParseInputForCustomDelimter(string input)
        {
            // here we want to return if it has the format, and if so, the custom delimiter set by the user
            if (input.StartsWith("//"))
            {
                return (true, input[2]);
            }
            else
            {
                return (false, '\0');
            }
        }
    }
}
