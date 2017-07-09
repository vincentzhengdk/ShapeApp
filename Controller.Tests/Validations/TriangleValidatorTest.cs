using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller.Validations;
using Controller.Utilities;

namespace Controller.Tests.Validations
{
    [TestClass]
    public class TriangleValidatorTest
    {
        IShapeValidator target = null;
   
        [TestInitialize]
        public void TestInitialize()
        {
            target = new TriangleValidator();
        }

        [TestMethod]
        public void TEST_NumberOfSides_GIVEN_Not3_THEN_ItFailsWithErrorMessage()
        {
            // Arrange
            var lengths = new double[] { 2, 3 };
            var expectedResult = false;

            // Act
            string errorMessage;
            var testResult = target.Validate(lengths,out errorMessage);

            // Assert
            Assert.AreEqual(expectedResult, testResult);
            Assert.AreEqual(ErrorConst.VALIDATION_ERROR_TRIANGLE_NUMBER_SIDE, errorMessage);
        }

        [TestMethod]
        public void TEST_Inequality_GIVEN_WrongValues_THEN_ItFailsWithErrorMessage()
        {
            // Arrange
            var lengths = new double[] { 1,3,5 };
            var expectedResult = false;

            // Act
            string errorMessage;
            var testResult = target.Validate(lengths, out errorMessage);

            // Assert
            Assert.AreEqual(expectedResult, testResult);
            Assert.AreEqual(ErrorConst.VALIDATION_ERROR_TRIANGLE_INEQUILITY, errorMessage);
        }
    }
}
