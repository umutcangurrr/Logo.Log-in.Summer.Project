using System;
using System.IO;



namespace Application.Logo.RestApi
{
    public class Logger
    {
        private string logFilePath;

        public Logger()
        {
            // Log dosya yolunu doğrudan burada belirtin
            logFilePath = @"C:\Users\umut.gur\OneDrive - Logo\Desktop\Log.txt";
        }

        public void Log(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logging error: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();

            logger.Log("This is a test log message.");
            logger.Log("Another log entry.");

            Console.WriteLine("Log messages have been written to the file.");
        }
    }
}
