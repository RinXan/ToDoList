using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Exceptions;

namespace ToDoList
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "data.txt";

            TaskManager taskManager = new TaskManager();

            LoadData(taskManager, filePath);

            ConsoleInterface consoleInterface = new ConsoleInterface(taskManager);
            
            consoleInterface.ShowMenu();

            SaveData(taskManager, filePath);
        }
    
        static void SaveData(TaskManager taskManager, string filePath)
        {
            try
            {
                taskManager.SaveToFile(filePath);
                Console.WriteLine("Tasks saved succesfully!");
            }
            catch (TaskOperationException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[WARNING] Saving tasks failed: {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERROR] Unexpected error: {ex.Message}");
                Console.ResetColor();
            }
        }
        static void LoadData(TaskManager taskManager, string filePath)
        {
            try
            {
                taskManager.LoadFromFile(filePath);
                Console.WriteLine("Tasks loaded succesfully!");
            }
            catch (TaskOperationException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[WARNING] Loading tasks failed: {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERROR] Unexpected error: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
