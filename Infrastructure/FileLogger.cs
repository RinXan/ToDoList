using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
