using Controller.Utilities;

namespace Controller.Validations
{
    public class GenericShapeValidator : IShapeValidator
    {
       
        public bool Validate(double[] sideLengthParameters,out string errorMessage)
        {
            errorMessage= string.Empty;

            foreach (var length in sideLengthParameters)
            {
                if (length <= 0)
                {
                    errorMessage = ErrorConst.VALIDATION_ERROR_SIDE_VALUE_NOT_BIGGER_THAN_ZEROR;
                    return false;
                }
            }
            return true;
        }
    }
}
