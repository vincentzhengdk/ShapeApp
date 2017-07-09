using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Utilities
{
    public static class ErrorConst
    {
        public const string EXCEPTION_ARGUMENT_NULL_FACTORY = "Shape factory";
        public const string EXCEPTION_ARGUMENT_NULL_FACTORY_TEXT = "Valid shape factory must be supplied.";
        public const string EXCEPTION_ARGUMENT_NULL_FACTORY_UNKNOWNSHAPE_TEXT = "Unknonw shape factory must be supplied.";

        public const string EXCEPTION_ARGUMENT_NULL_SHAPEVALIDATOR = "Shape validator";
        public const string EXCEPTION_ARGUMENT_NULL_SHAPEVALIDATOR_GENERIC_TEXT = "Generic shape validator must be supplied.";
        public const string EXCEPTION_ARGUMENT_NULL_SHAPEVALIDATOR_TRIANGLE_TEXT = "Triangle shape validator must be supplied.";

        public const string SHAPESERVICE_SYSTEM_NOT_SUPPORT = "System does not support";

        public  const string UNKNOWN_SHAPE = "Unknown shape";

        public const string VALIDATION_ERROR_SIDE_VALUE_NOT_BIGGER_THAN_ZEROR = "Shape must not have negative length";
        public const string VALIDATION_ERROR_TRIANGLE_NUMBER_SIDE = "Triangle must have 3 and 3 only sides";
        public const string VALIDATION_ERROR_TRIANGLE_INEQUILITY = "Sum of tow side lengths must be greater than the third side length";

    }
}
