using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller.Factories;
using Controller.Validations;
using Model;
using Model.Triangles;
using Moq;
using Controller.Utilities;

namespace Controller.Tests.Factories
{
    [TestClass]
    public class TriangleFactoryTest
    {
        IShapeFactory target ;
        Mock<IShapeValidator> mockTriangleValidator ;

        [TestInitialize]
        public void TestInitialize()
        {
            mockTriangleValidator = new Mock<IShapeValidator>();
            target = new TriangleFactory(mockTriangleValidator.Object);          
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TEST_CreateTriangleFactory_GIVEN_NullTriangleValidator_THEN_ItReturnsException()
        {
            // Arrange

            // Act 
            new TriangleFactory(null);

            // Asset
        }

        [TestMethod]
        public void TEST_CreateType_GIVEN_3SameSideLengths_THEN_ItReturnsEquilateral()
        {
            // Arrange
            var expectedResult = typeof(Equilateral).Name.ToString();
            double[] sideLengths = new double[] { 3, 3, 3 };
            string errorMessage = string.Empty;
            mockTriangleValidator.Setup(validator => validator.Validate(sideLengths, out errorMessage)).Returns(true);

            // Act 
            IShape shape = target.CreateShapeConcreteType(sideLengths);

            // Asset
            Assert.AreEqual(expectedResult, shape.TypeName);
        }

        [TestMethod]
        public void TEST_CreateType_GIVEN_2SameSideLengths_THEN_ItReturnsIsosceles()
        {
            // Arrange
            var expectedResult = typeof(Isosceles).Name.ToString();
            double[] sideLengths = new double[] { 2, 3, 3 };
            string errorMessage = string.Empty;
            mockTriangleValidator.Setup(validator => validator.Validate(sideLengths, out errorMessage)).Returns(true);

            // Act 
            IShape shape = target.CreateShapeConcreteType(sideLengths);

            // Asset
            Assert.AreEqual(expectedResult, shape.TypeName);
        }

        [TestMethod]
        public void TEST_CreateType_GIVEN_NoSameSideLengths_THEN_ItReturnsScalene()
        {
            // Arrange
            var expectedResult = typeof(Scalene).Name.ToString();
            double[] sideLengths = new double[] { 3, 4, 5 };
            string errorMessage = string.Empty;
            mockTriangleValidator.Setup(validator => validator.Validate(sideLengths, out errorMessage)).Returns(true);

            // Act 
            IShape shape = target.CreateShapeConcreteType(sideLengths);

            // Asset
            Assert.AreEqual(expectedResult, shape.TypeName);
        }

        [TestMethod]
        public void TEST_CreateType_GIVEN_NotValidLengths_THEN_ItReturnsUnknownShape()
        {
            // Arrange
            double[] sideLengths = new double[] { 9, 2, 3 };
            string errorMessage = string.Empty;
            mockTriangleValidator.Setup(validator => validator.Validate(sideLengths, out errorMessage)).Returns(false);

            // Act 
            IShape testResult = target.CreateShapeConcreteType(sideLengths);

            // Asset
            mockTriangleValidator.Verify(validator => validator.Validate(sideLengths,out errorMessage));
            Assert.IsInstanceOfType(testResult, typeof(UnknownShape));
        }

    }
}
