using R365CalculatorChallenge.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R365CalculatorChallenge.Tests
{
    [TestClass]

    public class InputParserTests
    {
        [TestMethod]
        public void ParseInputForCustomDelimter_ValidInputWithCustomDelimiter_ReturnsTrueAndDelimiter()
        {
            // here we're supplying the custom delimiter

            string input = "//#\n2#5";
            var result = InputParser.ParseInputForCustomDelimter(input);

            // make asserts based on tuple return
            Assert.IsTrue(result.Item1);        
            Assert.AreEqual("#", result.Item2);
        }

        [TestMethod]
        public void ParseInputForCustomDelimter_InputWithoutCustomDelimiter_ReturnsFalseAndDefaultDelimiter()
        {
            // here we're NOT supplying the custom delimiter

            string input = "1,2,3";
            var result = InputParser.ParseInputForCustomDelimter(input);

            // make asserts based on tuple return
            Assert.IsFalse(result.Item1);
            Assert.AreEqual(String.Empty, result.Item2);
        }

        [TestMethod]
        public void ParseInputForCustomDelimter_EmptyInput_ReturnsFalseAndDefaultDelimiter()
        {
            // here we're NOT supplying anything, should return default delim

            string input = "1,2,3";
            var result = InputParser.ParseInputForCustomDelimter(input);

            // make asserts based on tuple return
            Assert.IsFalse(result.Item1);
            Assert.AreEqual(String.Empty, result.Item2);
        }

        [TestMethod]
        public void ParseInputForCustomDelimter_InputWithCustomDelimiterButNoNumbers_ReturnsTrueAndDelimiter()
        {
            // this has a custom delim, no data, will return 0 in calculation
            string input = "//&";
            var result = InputParser.ParseInputForCustomDelimter(input);

            // make asserts based on tuple return
            Assert.IsTrue(result.Item1);      
            Assert.AreEqual("&", result.Item2);
        }

        [TestMethod]
        public void ParseInputForCustomDelimter_InputWithMoreThanOneCharacterForDelimiter_ReturnsTrueAndFirstCharacter()
        {
            // this has delim char after clarifying, will be treated as 0 in calc
            string input = "//;;3,4,5";
            var result = InputParser.ParseInputForCustomDelimter(input);

            // make asserts based on tuple return
            Assert.IsTrue(result.Item1); 
            Assert.AreEqual(";", result.Item2);
        }

        [TestMethod]
        public void ParseInputForCustomDelimter_InputWithCustomDelimiter_String_ReturnsTrueAndDelimiter()
        {
            // this has a custom delim with multiple chars (string)
            string input = "//[***]\n11***22***33";
            var result = InputParser.ParseInputForCustomDelimter(input);

            // make asserts based on tuple return
            Assert.IsTrue(result.Item1);
            Assert.AreEqual("***", result.Item2);
        }
    }
}
