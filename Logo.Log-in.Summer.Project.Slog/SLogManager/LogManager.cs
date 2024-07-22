using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Async;

namespace SLogManager
{
    public class LogManager
    {
        static ILogger logger;
        static AppSettings settings = new AppSettings();

        static LogManager()
        {
            LoadSettings();
            ConfigureLogger();
        }

        private static void ConfigureLogger()
        {
            string logLevel = settings.LogLevel;
            LogEventLevel minimumLogLevel = GetLogEventLevel(logLevel);
            logger = new LoggerConfiguration()
                .MinimumLevel.Is(minimumLogLevel)
               .WriteTo.Async(a => a.File(
            path: "C:\\Users\\umut.gur\\OneDrive - Logo\\Desktop\\Log.txt",
            shared: true))
                .CreateLogger();
            try
            {
                logger.Information("starting logmanager");
            }
            catch (Exception e)
            {
                logger.Error("error",e);
                throw;
            }
            finally 
            {
                logger.Information("finally");
                Log.CloseAndFlush();
            }
        }

        private static void LoadSettings()
        {
            try
            {
                string filePath = @"C:\Users\umut.gur\OneDrive - Logo\Desktop\AppSettings.xml";

                XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                serializer.UnknownElement += new XmlElementEventHandler(Serializer_UnknownElement);

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    settings = (AppSettings)serializer.Deserialize(fs);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error: XML file not found");
                LogError("Error: XML file not found", ex);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: Invalid operation while deserializing XML");
                LogError("Error: Invalid operation while deserializing XML", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: An error occurred while loading settings");
                LogError("Error: An error occurred while loading settings", ex);
            }
        }

        private static void Serializer_UnknownElement(object sender, XmlElementEventArgs e)
        {
            // Bilinmeyen elemanı yoksaymak için 
        }

        private static LogEventLevel GetLogEventLevel(string logLevel)
        {
            switch (logLevel.ToUpper())
            {
                case "FATAL":
                    return LogEventLevel.Fatal;
                case "ERROR":
                    return LogEventLevel.Error;
                case "WARNING":
                    return LogEventLevel.Warning;
                case "INFORMATION":
                    return LogEventLevel.Information;
                default:
                    return LogEventLevel.Information;
            }
        }
        private static string GetLogLevelString()
        {
            return settings.LogLevel.ToUpper();
        }

        public static void LogInformation(string message)
        {
            logger.Information(message);
        }

        public static void LogWarning(string message)
        {
            logger.Warning(message);
        }

        public static void LogError(string message, Exception exception)
        {
            logger.Error(exception, message);
        }

        public static void LogFatal(string message)
        {
            logger.Fatal(message);
        }
    }
}


