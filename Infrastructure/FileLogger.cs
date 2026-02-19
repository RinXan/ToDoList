using System;
using System.IO;
using ToDoList.Logger;

namespace ToDoList.Infrastructure
{
    public class FileLogger : ILogger
    {
        private readonly string _filePath;
        public FileLogger(string filePath)
        {
            _filePath = string.IsNullOrWhiteSpace(filePath) ? throw new ArgumentException("Log file path is not correct") : filePath;
        }
    
        public void Log(LogLevel level, string message)
        {
            string line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}][{level}] {message}";
            File.AppendAllText(_filePath, line + Environment.NewLine);
        }
    }
}
