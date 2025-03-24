using R365CalculatorChallenge.Exceptions;
using R365CalculatorChallenge.Interfaces;
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
        public void Calculate_ValidInput_ReturnsCorrectSum()
        {
            string input = "2,3";
            double result = _calculationService.Calculate(input);

            // make assert(s)
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Calculate_InputWithMoreThanTwoNumbers_ThrowsInvalidInputException()
        {
            // should trip the constraint of 2
            string input = "2,3,4";

            // make assert(s)
            var exception = Assert.ThrowsException<InvalidInputException>(() => _calculationService.Calculate(input));
            Assert.AreEqual("Invalid Input for Calculation:  Input must contain 2 numbers.", exception.Message);
        }

        [TestMethod]
        public void Calculate_InputWithNonNumericValues_ReturnsZeroForNonNumeric()
        {
            // should ignore abc and treat as 0
            string input = "2,abc";
            double result = _calculationService.Calculate(input);

            // make assert(s)
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Calculate_InputWithEmptyString_ReturnsZero()
        {
            // basically passing in nothing, but should default to 0s
            string input = ",";
            double result = _calculationService.Calculate(input);

            // make assert(s)
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Calculate_InputWithEmptyValue_ReturnsCorrectSum()
        {
            string input = "5,";
            double result = _calculationService.Calculate(input);

            // make assert(s)
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Calculate_ValidInputWithZero_ReturnsZero()
        {
            string input = "0,0";
            double result = _calculationService.Calculate(input);

            // make assert(s)
            Assert.AreEqual(0, result);
        }
    }
}
