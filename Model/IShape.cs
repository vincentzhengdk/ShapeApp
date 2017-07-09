namespace Model
{
    public interface IShape
    {
        string TypeName { get; }

        bool IsValid { get; set; }
        void Excecute();

        string Message { get; set; }
    }
}
