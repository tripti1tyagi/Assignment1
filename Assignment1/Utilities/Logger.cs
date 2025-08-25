

using System;
using System.IO;
using System.Web;

namespace Assignment1.Utilities
{
    public static class Logger
    {
        private static string LogDirectory = HttpContext.Current.Server.MapPath("~/Logs");

        public static void LogError(string message)
        {
            string filePath = Path.Combine(LogDirectory, "ErrorLog.txt");
            LogToFile(filePath, message);
        }

        public static void LogEvent(string message)
        {
            string filePath = Path.Combine(LogDirectory, "EventLog.txt");
            LogToFile(filePath, message);
        }

        private static void LogToFile(string path, string message)
        {
            try
            {
                Directory.CreateDirectory(LogDirectory); // Ensure folder exists
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine($"[{DateTime.Now}] {message}");
                }
            }
            catch (Exception)
            {
                // Ignore logging errors for now
            }
        }
    }
}
