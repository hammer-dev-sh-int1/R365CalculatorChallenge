using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace R365CalculatorChallenge.Helpers
{
    public static class InputParser
    {
        public static (bool, string) ParseInputForCustomDelimter(string input)
        {
            // regex pattern to match on spec:  //[{delimiter}]\n{numbers}
            // we also need to accomodate previous format of:  //{delimiter}\n{numbers}

            string pattern = @"^//\[(.*?)\]";

            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                // the user has specified the new string delimiter
                return (true, match.Groups[1].Value);
            }
            else
            {
                // lets see if the user has specified the old char delimiter format
                if (input.StartsWith("//"))
                    return (true, input[2].ToString());

                return (false, String.Empty);
            }            
        }
    }
}
