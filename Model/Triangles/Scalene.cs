
namespace Model.Triangles
{
    public class Scalene : Triangle
    {
        public override string TypeName { get { return this.GetType().Name.ToString(); } }

        public Scalene(double sideA, double sideB, double sideC) :base(sideA,sideB,sideC)
        {

        }

        public override void Excecute()
        {
            // Do specific validate if any
        }

    }

}