using R365CalculatorChallenge.Exceptions;
using R365CalculatorChallenge.Interfaces;
using R365CalculatorChallenge.Models;
using R365CalculatorChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R365CalculatorChallenge.Tests
{

    [TestClass]
    public class AdditionServiceTests
    {
        private ICalculationService _calculationService;

        [TestInitialize]
        public void SetUp()
        {
            _calculationService = new AdditionService();
        }

        [TestMethod]
        public void Calculate_ValidInput_ReturnsCorrectSum_CommaDelimiter()
        {
            string input = "2,3";
            CalculationResult result = _calculationService.Calculate(input);

            // make assert(s)
            Assert.AreEqual(5, result.Sum);
        }

        [TestMethod]
        public void Calculate_ValidInput_ReturnsCorrectSum_NewLineDelimiter()
        {
            string input = "3\n6";
            CalculationResult result = _calculationService.Calculate(input);

            // make assert(s)
            Assert.AreEqual(9, result.Sum);
        }

        [TestMethod]
        public void Calculate_InputWithMoreThanTwoNumbers_ReturnsCorrectSum()
        {
            string input = "1,2,3,4";
            CalculationResult result = _calculationService.Calculate(input);

            // make assert(s)
            Assert.AreEqual(10, result.Sum);
        }

        [TestMethod]
        public void Calculate_InputWithNonNumericValues_ReturnsZeroForNonNumeric()
        {
            // should ignore abc and treat as 0
            string input = "2,abc";
            CalculationResult result = _calculationService.Calculate(input);

            // make assert(s)
            Assert.AreEqual(2, result.Sum);
        }

        [TestMethod]
        public void Calculate_InputWithEmptyString_ReturnsZero()
        {
            // basically passing in nothing, but should default to 0s
            string input = ",";
            CalculationResult result = _calculationService.Calculate(input);

            // make assert(s)
            Assert.AreEqual(0, result.Sum);
        }

        [TestMethod]
        public void Calculate_InputWithEmptyValue_ReturnsCorrectSum()
        {
            string input = "5,";
            CalculationResult result = _calculationService.Calculate(input);

            // make assert(s)
            Assert.AreEqual(5, result.Sum);
        }

        [TestMethod]
        public void Calculate_ValidInputWithZero_ReturnsZero()
        {
            string input = "0,0";
            CalculationResult result = _calculationService.Calculate(input);

            // make assert(s)
            Assert.AreEqual(0, result.Sum);
        }

        [TestMethod]
        public void Calculate_DenyNegativeNumbers_ThrowsInvalidInputException_CommaDelim()
        {
            // should trip the constraint of 2
            string input = "1,-2,3,-4";

            // make assert(s)
            var exception = Assert.ThrowsException<InvalidInputException>(() => _calculationService.Calculate(input));
            Assert.AreEqual("Invalid Input for Calculation:  Cannot contain negative numbers: -2,-4", 
                                                        exception.Message);
        }

        [TestMethod]
        public void Calculate_DenyNegativeNumbers_ThrowsInvalidInputException_NewLine()
        {
            // should trip the constraint of 2
            string input = "1\n2\n-6";

            // make assert(s)
            var exception = Assert.ThrowsException<InvalidInputException>(() => _calculationService.Calculate(input));
            Assert.AreEqual("Invalid Input for Calculation:  Cannot contain negative numbers: -6",
                                                        exception.Message);
        }

        [TestMethod]
        public void Calculate_ValidInput_ContainsNumberOver1000_ReturnsCorrectSum_CommaDelimiter()
        {
            string input = "2,1001,6";
            CalculationResult result = _calculationService.Calculate(input);

            // make assert(s)
            Assert.AreEqual(8, result.Sum);
        }

        [TestMethod]
        public void Calculate_ValidInput_CustomDelimiter_ReturnsCorrectSum_CommaDelimiter()
        {
            string input = "//#\n2#5";
            CalculationResult result = _calculationService.Calculate(input);

            // make assert(s)
            Assert.AreEqual(7, result.Sum);
        }

        [TestMethod]
        public void Calculate_ValidInput_CustomDelimiter_AnyLength_ReturnsCorrectSum_CommaDelimiter()
        {
            string input = "//[***]\n11***22***33";
            CalculationResult result = _calculationService.Calculate(input);

            // make assert(s)
            Assert.AreEqual(66, result.Sum);
        }

        [TestMethod]
        public void Calculate_ValidInput_MultipleCustomDelimiter_AnyLength_ReturnsCorrectSum()
        {
            string input = "//[*][!!][r9r]\n11r9r22*hh*33!!44";
            CalculationResult result = _calculationService.Calculate(input);

            // make assert(s)
            Assert.AreEqual(110, result.Sum);
        }        

        [TestMethod]
        public void Calculate_ValidInput_ValidatesStepsInFormula()
        {
            string input = "2,,4,rrrr,1001,6";
            CalculationResult result = _calculationService.Calculate(input);

            // make assert(s)
            Assert.AreEqual(6, result.TotalNumbersInFormula);
        }
    }
}
