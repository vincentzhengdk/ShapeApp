
namespace Controller.Validations
{
    public interface IShapeValidator
    {
        bool Validate(double[] sideLengthParameters,out string errorMessage);
    }
}
