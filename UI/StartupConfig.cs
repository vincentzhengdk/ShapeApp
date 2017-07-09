using Controller;
using Controller.Factories;
using Controller.Validations;

namespace UI
{
    // ******************************************************************************************************************************
    // This class serves as RootComposition where we define dependencies for main application. 
    // Shape factory(in this case, TriangleFactory) is inject into ShapeService to create concrete triangle type
    // Generic shape validation is inject into ShapeService to enforce generic validation that could be applied to any polygon shapes
    // Triangle validation is injected into TriangleFactory to enforce specific triangle validation rule
    // * PS: Since it is such a small application, DI container is not necessary, here dependencies are manually injected (poor man)
    // ******************************************************************************************************************************
    public class StartupConfig
    {
        public static IShapeService GetShapeService()
        {
            IShapeValidator typeValidator = new TriangleValidator();
            IShapeFactory shapeFactory = new TriangleFactory(typeValidator);             // Compose shape factory
            IShapeFactory UnknownShapeFacotry = new UnknownShapeFactory();

            var genericShapeValidator = new GenericShapeValidator();
            return new ShapeService(shapeFactory, UnknownShapeFacotry,genericShapeValidator);          // Compose shape service
        }

    }
}
