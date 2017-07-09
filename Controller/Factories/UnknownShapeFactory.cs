using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Controller.Utilities;

namespace Controller.Factories
{
    public class UnknownShapeFactory : IShapeFactory
    {
        public string ShapeName { get ; set; }

        public IShape CreateShapeConcreteType(double[] args)
        {
            return new UnknownShape(ErrorConst.UNKNOWN_SHAPE);
        }
    }
}
