namespace module33
{
    public interface ILoger
    {
        void CreateLogDir();
        Task WriteError(string errorMessage);
        Task WriteEvent(string eventMessage);
    }
}