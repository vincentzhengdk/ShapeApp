using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Triangles;

namespace Model.Tests
{
    [TestClass]
    public class ModelTest
    {

        [TestMethod]
        public void TEST_GetEquilateralTypeName_GIVEN_InheritTriangle_THEN_ItReturnsEquilateral()
        {
            // Arrange
            Triangle target = new Equilateral(3, 3, 3);
            string expectedResult = (typeof(Equilateral)).Name.ToString();

            // Act

            // Asset
            Assert.AreEqual(target.TypeName, expectedResult);
        }

        [TestMethod]
        public void TEST_GetGenericTriangleTypeName_THEN_ItReturnsTriangle()
        {
            // Arrange
            Triangle target = new Triangle(3, 3, 3);
            string expectedResult = (typeof(Triangle)).Name.ToString();

            // Act

            // Asset
            Assert.AreEqual(target.TypeName, expectedResult);
        }


        [TestMethod]
        public void TEST_GetUnknowShapeTypeName_GIVEN_NoCustomMessage_THEN_ItReturnsUnknownType()
        {
            // Arrange
            IShape target = new UnknownShape();
            string expectedResult = string.Empty;

            // Act

            // Asset
            Assert.AreEqual(target.Message, expectedResult);
        }

        [TestMethod]
        public void TEST_GetUnknowShapeTypeName_GIVEN_CustomMessage_THEN_ItReturnsCustomMessage()
        {
            // Arrange
            IShape target = new UnknownShape("Test");
            string expectedResult = "Test";

            // Act

            // Asset
            Assert.AreEqual(target.Message, expectedResult);
        }
    }
}
