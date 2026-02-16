using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Exceptions;
using ToDoList.Infrastructure;
using ToDoList.Logger;

namespace ToDoList
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "data.json";
            string logfilePath = "log.txt";

            ILogger logger = new FileLogger(logfilePath);

            TaskManager taskManager = new TaskManager(logger);

            LoadData(taskManager, filePath, logger);

            ConsoleInterface consoleInterface = new ConsoleInterface(taskManager);
            
            consoleInterface.ShowMenu();

            SaveData(taskManager, filePath, logger);
        }
    
        static void SaveData(TaskManager taskManager, string filePath, ILogger logger)
        {
            try
            {
                taskManager.SaveToFile(filePath);
                Console.WriteLine("Tasks saved succesfully!");
            }
            catch (TaskOperationException ex)
            {
                logger.Log(LogLevel.WARNING, ex.InnerException.Message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[WARNING] {ex.Message}");
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.ERROR, ex.Message);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("System error");
            }
            Console.ResetColor();
        }
        static void LoadData(TaskManager taskManager, string filePath, ILogger logger)
        {
            try
            {
                taskManager.LoadFromFile(filePath);
                Console.WriteLine("Tasks loaded succesfully!");
            }
            catch (TaskOperationException ex)
            {
                logger.Log(LogLevel.WARNING, ex.InnerException.Message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[WARNING] {ex.Message}");
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.ERROR, ex.Message);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("System error");
            }
            Console.ResetColor();
        }
    }
}
