using Controller.Factories;
using Controller.Utilities;
using Controller.Validations;
using Model;
using System;

namespace Controller
{
    public class ShapeService: IShapeService
    {
        private readonly IShapeFactory _availableShapeFactory;
        private readonly IShapeFactory _unknownShapeFactory;
        private readonly IShapeValidator _genericShapeValidator;

        private IShapeFactory _requiredShapeFacotry;
        private IShape _concreteType;
        private string _errorMessage;

        public ShapeService(IShapeFactory availableShapeFactory,IShapeFactory unknownShapeFacotry, IShapeValidator genericShapeValidator)
        {
            _availableShapeFactory = availableShapeFactory ?? throw new ArgumentNullException(ErrorConst.EXCEPTION_ARGUMENT_NULL_FACTORY, ErrorConst.EXCEPTION_ARGUMENT_NULL_FACTORY_TEXT);
            _unknownShapeFactory = unknownShapeFacotry ?? throw new ArgumentNullException(ErrorConst.EXCEPTION_ARGUMENT_NULL_FACTORY, ErrorConst.EXCEPTION_ARGUMENT_NULL_FACTORY_UNKNOWNSHAPE_TEXT);
            _genericShapeValidator = genericShapeValidator ?? throw new ArgumentNullException(ErrorConst.EXCEPTION_ARGUMENT_NULL_SHAPEVALIDATOR, ErrorConst.EXCEPTION_ARGUMENT_NULL_SHAPEVALIDATOR_GENERIC_TEXT);
        }

        public string GetShapeConcreteTypeName(string requiredShapeName, double[] args)
        {

            SetRequiredShapeFactory(requiredShapeName);

            ValidateSideValueBiggerThanZero(args);
            if (!string.IsNullOrEmpty(_errorMessage))
            {
                return _errorMessage;
            }

            CreateShapeConcreteType(args);

            if (!_concreteType.IsValid)
            {
                return _concreteType.Message;
            }
            return _concreteType.TypeName;
        }

        private void CreateShapeConcreteType(double[] args)
        {
            _concreteType= _requiredShapeFacotry.CreateShapeConcreteType(args);
        }

        private void ValidateSideValueBiggerThanZero(double[] args)
        {
            _genericShapeValidator.Validate(args, out _errorMessage);
        }

        private void SetRequiredShapeFactory(string shapeName)
        {
            if (_availableShapeFactory.ShapeName.ToLower().Equals(shapeName.ToLower()))
            {
                _requiredShapeFacotry = _availableShapeFactory;
            }
            else
            {
                _requiredShapeFacotry = _unknownShapeFactory;
            }        
            
        }

    }
}
