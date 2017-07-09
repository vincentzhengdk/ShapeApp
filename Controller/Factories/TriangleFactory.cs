using Controller.Utilities;
using Controller.Validations;
using Model;
using Model.Triangles;
using System;
using System.Linq;


namespace Controller.Factories
{
    public class TriangleFactory : IShapeFactory
    {
        private readonly IShapeValidator triangleValidator;
        public string ShapeName { get { return ShapeCategory.Triangle.ToString(); } set { ShapeName = value; } }

        public TriangleFactory(IShapeValidator triangleValidator)
        {
            this.triangleValidator = triangleValidator ?? throw new ArgumentNullException(ErrorConst.EXCEPTION_ARGUMENT_NULL_SHAPEVALIDATOR, ErrorConst.EXCEPTION_ARGUMENT_NULL_SHAPEVALIDATOR_TRIANGLE_TEXT);
        }

        
        private bool Validate(double[] sideLengthParameters,out string errorMessage)
        {
            return triangleValidator.Validate(sideLengthParameters,out errorMessage); 
        }

       
        public IShape CreateShapeConcreteType(double[] sideLengthParameters)
        {
            var errorMessage= string.Empty;
            if(!Validate(sideLengthParameters,out errorMessage))
            {
                return new UnknownShape(errorMessage);
            }

            var uniqueLengthNumber = sideLengthParameters.Distinct().Count();       // counting sides with same length

            switch (uniqueLengthNumber)
            {
                case 1:
                    return new Equilateral(sideLengthParameters[0], sideLengthParameters[1], sideLengthParameters[2]);
                case 2:
                    return new Isosceles(sideLengthParameters[0], sideLengthParameters[1], sideLengthParameters[2]);
                default:
                    return new Scalene(sideLengthParameters[0], sideLengthParameters[1], sideLengthParameters[2]);
            }
        }

    }
}
