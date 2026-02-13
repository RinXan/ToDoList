using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ToDoList
{
    public class ConsoleInterface
    {
        private TaskManager _taskManager;

        public ConsoleInterface(TaskManager taskManager) 
        {
            _taskManager = taskManager;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*** Task manager ***");
                Console.WriteLine($"Total tasks count: {_taskManager.GetTotalTaskCount()} (Done: {_taskManager.GetComplitedTaskCount()})\n");
                Console.WriteLine("1. Show all tasks");
                Console.WriteLine("2. Add task");
                Console.WriteLine("3. Delete task");
                Console.WriteLine("4. Change task status");
                Console.WriteLine("5. Change task title");
                Console.WriteLine("6. Exit");
                Console.Write("\nChoice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ShowAllTasks();
                        break;
                    case 2:
                        AddTask();
                        break;
                    case 3:
                        DeleteTask();
                        break;
                    case 4:
                        ChangeStatus();
                        break;
                    case 5:
                        ChangeTitle();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("\nIncorrect option\nPress any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void NotImplementedYet()
        {
            Console.WriteLine("\nNot implemented yet.\nPress any key...");
            Console.ReadKey();
        }
        private Task FindTask()
        {
            Console.Write("\nEnter number: ");

            int number = int.Parse(Console.ReadLine());
            List<Task> tasks = _taskManager.GetAllTasks();

            if (number < 1 || number > _taskManager.GetTotalTaskCount())
            {
                return null;
            }
            else
            {
                return tasks[number - 1];
            }
        }
        private (string, bool) parse(string line)
        {
            string title = line.Split(';')[0];
            bool status = bool.Parse(line.Split(';')[1]);

            return (title, status);
        }
        private void ShowAllTasks()
        {
            Console.Clear();
            Console.WriteLine("*** All tasks ***\n");

            List<Task> tasks = _taskManager.GetAllTasks();

            if (tasks.Count == 0)
            {
                Console.WriteLine("Tasks list is empty(");
            }
            else
            {
                int i = 1;
                foreach (Task task in tasks)
                {
                    Console.WriteLine($"{i}. {task}");
                    i++;
                }
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
        private void AddTask()
        {
            Console.Clear();
            Console.WriteLine("*** New task ***");
            Console.Write("\nTitle: ");

            string title = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine($"Task title is empty. Title: {title}");
            }
            else
            {
                _taskManager.AddTask(title);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Task: {title} added!");
                Console.ResetColor();
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
        private void DeleteTask()
        {
            Console.Clear();
            Console.WriteLine("*** Delete task ***");

            Task task = FindTask();

            if (task == null)
            {
                Console.WriteLine($"Task is not exist");
            }
            else
            {
                _taskManager.RemoveTask(task);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task deleted!");
                Console.ResetColor();
            }
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
        private void ChangeStatus()
        {
            Console.Clear();
            Console.WriteLine("*** Change task status ***");

            Task task = FindTask();

            if (task == null)
            {
                Console.WriteLine($"Task is not exist");
            }
            else
            {
                _taskManager.ChangeStatus(task);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task status changed!");
                Console.ResetColor();
            }
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
        private void ChangeTitle()
        {
            Console.Clear();
            Console.WriteLine("*** Change task title ***");

            Task task = FindTask();

            if (task == null)
            {
                Console.WriteLine($"Task is not exist");
            }
            else
            {
                Console.WriteLine($"Current title: {task.Title}");
                Console.Write("Enter new title: ");
                string title = Console.ReadLine();

                _taskManager.ChangeTitle(task, title);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task title changed!");
                Console.ResetColor();
            }
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
        private List<Task> LoadTasks(string filePath)
        {
            List<Task> tasks = new List<Task>();

            foreach (string line in File.ReadAllLines(filePath))
            {
                (string title, bool status) task = parse(line);
                tasks.Add(new Task(task.title, task.status));
            }

            return tasks;
        }
    }
}
