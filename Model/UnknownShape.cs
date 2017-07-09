using System;

namespace Model
{
    public class UnknownShape : IShape
    {
        private string message= string.Empty;
        public string TypeName { get; set; }
        public string Message { get { return message; }  set { message = value; } }

        public bool IsValid { get { return false; } set { } }

        public UnknownShape() { }
        public UnknownShape(string message)
        {
            this.message = message;
        }

        public void Excecute()
        {
            throw new NotImplementedException();
        }
    }
}
