using Controller.Utilities;
using System;

namespace Controller.Validations
{
    public class TriangleValidator:IShapeValidator
    {
        private const int NUMBER_OF_SIDE = 3;
 
        public bool Validate(double[] sideLengthParameters,out string errorMessage)
        {
            errorMessage = string.Empty;
            if (!ValidateNumberOfSide(sideLengthParameters,out errorMessage))
            {
                return false;
            }
          
            if (!ValidateInequaility(sideLengthParameters,out errorMessage))
            {
                return false;
            }
            return true;
        }
        public bool ValidateNumberOfSide(double[] sideLengthParameters,out string errorMessage)
        {
            errorMessage = string.Empty;
            if (sideLengthParameters.Length != NUMBER_OF_SIDE)
            {
                errorMessage = string.Format(ErrorConst.VALIDATION_ERROR_TRIANGLE_NUMBER_SIDE);
                return false;
            }
            return true;
        }
        public bool ValidateInequaility(double[] sideLengthParameters, out string errorMessage)
        {
            errorMessage = string.Empty;

            Array.Sort(sideLengthParameters);
            if (sideLengthParameters[0] + sideLengthParameters[1] < sideLengthParameters[2])
            {
                errorMessage = ErrorConst.VALIDATION_ERROR_TRIANGLE_INEQUILITY;
                return false;
            }
            return true;
        }
    }
}
