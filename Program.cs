using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            ConsoleInterface consoleInterface = new ConsoleInterface(taskManager);
            consoleInterface.ShowMenu();
        }
    }
}
