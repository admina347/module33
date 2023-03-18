namespace module33
{
    public class Loger : ILoger
    {
        string logDirName = DateTime.Now.ToString();
        string logsDir = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

        public void CreateLogDir()
        {
            string newlogDir = Path.Combine(logsDir, logDirName);
            Directory.CreateDirectory(newlogDir);
        }

        public async Task WriteEvent(string eventMessage)
        {
            Console.WriteLine(eventMessage);
            // Строка для публикации в лог
            string logMessage = $"[{DateTime.Now}]: New event: {eventMessage}";

            // Путь до лога (опять-таки, используем свойства IWebHostEnvironment)
            string logFilePath = Path.Combine(logsDir, logDirName, "events.txt");

            // Используем асинхронную запись в файл
            await File.AppendAllTextAsync(logFilePath, logMessage);

        }

        public async Task WriteError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
            // Строка для публикации в лог
            string logMessage = $"[{DateTime.Now}]: New error: {errorMessage}";

            // Путь до лога (опять-таки, используем свойства IWebHostEnvironment)
            string logFilePath = Path.Combine(logsDir, logDirName, "errors.txt");

            // Используем асинхронную запись в файл
            await File.AppendAllTextAsync(logFilePath, logMessage);
        }
    }
}