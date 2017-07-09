using System;

namespace Model.Triangles
{
    public class Triangle : IShape
    { 
        public double SideA { get; private set; }

        public double SideB { get; private set; }

        public double SideC { get; private set; }
        public virtual string TypeName { get { return this.GetType().Name.ToString(); } }    // Override by sub class

        public bool IsValid { get ; set; }
        public string Message { get ; set ; }

        public Triangle(double sideA, double sideB ,double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            IsValid = true;
        }
       
        public virtual void Excecute()
        {
            // Do something 
        }
    }
}
