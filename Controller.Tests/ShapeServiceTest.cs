using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controller.Factories;
using Controller.Validations;
using Moq;
using Model;
using Controller.Utilities;
using Model.Triangles;

namespace Controller.Tests
{
    [TestClass]
    public class ShapeServiceTest
    {
        Mock<IShapeValidator> mockShapeValidator = null;
        Mock<IShapeFactory> mockShapeFactory = null;
        Mock<IShapeFactory> mockUnknownShapeFactory = null;
        string supportShapeName = "Triangle";
        double[] lengths = new double[] { 3, 3, 3 };

        [TestInitialize]
        public void TestInitialize()
        {
            mockShapeValidator = new Mock<IShapeValidator>();
            mockShapeFactory = new Mock<IShapeFactory>();
            mockUnknownShapeFactory = new Mock<IShapeFactory>();
            mockShapeFactory.SetupAllProperties();
            mockShapeFactory.Object.ShapeName = supportShapeName;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TEST_CreateShapeService_GIVEN_NullFactory_THEN_ItReturnsException()
        {
            // Arrange

            // Act
            var target = new ShapeService(null,null, null);

            // Assert
        }

        [TestMethod]
        public void TEST_GetConcreteTypeName_GIVEN_UnsupportedShape_THEN_ItReturnsUnknownShape()
        {
            // Arrange
            var unSupportedShapeName = "Unsupported";                     
            var unknownshpae = new UnknownShape(ErrorConst.UNKNOWN_SHAPE);
            mockUnknownShapeFactory.Setup(f =>f.CreateShapeConcreteType(lengths)).Returns(unknownshpae);
            var target = new ShapeService(mockShapeFactory.Object, mockUnknownShapeFactory.Object, mockShapeValidator.Object);

            // Act
            var testResult = target.GetShapeConcreteTypeName(unSupportedShapeName, lengths);

            // Assert
            mockUnknownShapeFactory.Verify(factory => factory.CreateShapeConcreteType(lengths));
            Assert.AreEqual(ErrorConst.UNKNOWN_SHAPE,testResult);
        }

    }
}
