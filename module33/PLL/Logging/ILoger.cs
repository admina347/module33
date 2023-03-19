namespace module33
{
    public interface ILoger
    {
        //void CreateLogDir();
        void WriteError(string errorMessage);
        void WriteEvent(string eventMessage);
    }
}