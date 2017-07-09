using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller.Validations;
using Controller.Utilities;

namespace Controller.Tests.Validations
{
    [TestClass]
    public class GenericShapeValidatorTest
    {
        IShapeValidator target;
    
        [TestInitialize]
        public void TestInitialize()
        {
            target = new GenericShapeValidator();
        }

        [TestMethod]
        public void TEST_ValidateLengthsValue_GIVEN_NegativeValue_THEN_ItFailsWithErrorMessage()
        {
            // Arrange
            var lengths = new double[] { -1, -3, -5 };
            var expectedResult = false;

            // Act
            string errorMessage;
            var testResult = target.Validate(lengths,out errorMessage);

            // Assert
            Assert.AreEqual(expectedResult, testResult);
            Assert.AreEqual(ErrorConst.VALIDATION_ERROR_SIDE_VALUE_NOT_BIGGER_THAN_ZEROR, errorMessage);
        }

        [TestMethod]
        public void TEST_ValidateLengthsValue_GIVEN_ValueAsZero_THEN_ItFailsWithErrorMessage()
        {
            // Arrange
            var lengths = new double[] { 0, 3, 5 };
            var expectedResult = false;

            // Act
            string errorMessage;
            var testResult = target.Validate(lengths, out errorMessage);

            // Assert
            Assert.AreEqual(expectedResult, testResult);
            Assert.AreEqual(ErrorConst.VALIDATION_ERROR_SIDE_VALUE_NOT_BIGGER_THAN_ZEROR, errorMessage);
        }
    }
}
