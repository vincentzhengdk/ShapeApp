using Model;

namespace Controller.Factories
{
    public interface IShapeFactory
    {
        string ShapeName { get; set; }
        IShape CreateShapeConcreteType(double[] args);
    }
}
