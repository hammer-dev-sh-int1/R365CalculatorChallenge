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
        public static (bool, List<string>) ParseInputForCustomDelimter(string input)
        {
            // regex pattern to match on spec:  //[{delimiter}]\n{numbers}
            // new addition of:  //[{delimiter1}][{delimiter2}]...\n{numbers}
            // we also need to accomodate previous format of:  //{delimiter}\n{numbers}

            string pattern = @"^//(\[[^\]]+\])+(?=\n)";
            List<string> lstDelimiters = new();

            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                // extract all the delimiters from the matched sequence
                foreach (Match delimiterMatch in Regex.Matches(match.Value, @"\[[^\]]+\]"))
                {
                    string delimiter = delimiterMatch.Value.Trim('[', ']'); // Remove brackets
                    lstDelimiters.Add(delimiter);
                }
            }
            else
            {
                // lets see if the user has specified the old char delimiter format
                if (input.StartsWith("//"))
                {
                    // grab character after //
                    lstDelimiters.Add(input[2].ToString());
                }                
            }

            return (lstDelimiters.Count > 0, lstDelimiters);
        }
    }
}
