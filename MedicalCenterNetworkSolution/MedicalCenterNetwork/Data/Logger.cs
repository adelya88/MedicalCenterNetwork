using System;
using System.IO;

namespace MedicalCenterNetwork.Data
{
    public static class Logger
    {
        private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_log.txt");

        public static void LogInfo(string message)
        {
            Log("INFO", message);
        }

        public static void LogWarning(string message)
        {
            Log("WARNING", message);
        }

        public static void LogError(string message)
        {
            Log("ERROR", message);
        }

        public static void LogException(Exception ex, string additionalInfo = "")
        {
            string message = $"Exception: {ex.GetType().Name}: {ex.Message}";
            if (!string.IsNullOrEmpty(additionalInfo))
            {
                message += $" | Additional Info: {additionalInfo}";
            }
            message += $"\nStack Trace: {ex.StackTrace}";
            Log("EXCEPTION", message);
        }

        private static void Log(string level, string message)
        {
            try
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine(logEntry);
                }
            }
            catch
            {
                // Если не удалось записать в лог, игнорируем ошибку
            }
        }

        public static string GetLogContent()
        {
            try
            {
                if (File.Exists(logFilePath))
                {
                    return File.ReadAllText(logFilePath);
                }
                return "Лог файл не найден.";
            }
            catch (Exception ex)
            {
                return $"Ошибка при чтении лога: {ex.Message}";
            }
        }

        public static void ClearLog()
        {
            try
            {
                if (File.Exists(logFilePath))
                {
                    File.Delete(logFilePath);
                }
            }
            catch
            {
                // Игнорируем ошибку при очистке лога
            }
        }
    }
}