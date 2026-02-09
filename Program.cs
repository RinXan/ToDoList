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
        static List<Task> tasks = new List<Task>();
        static void Main(string[] args)
        {
            ShowMenu();
        }

        static void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*** Task manager ***");
                Console.WriteLine($"Total tasks count: {tasks.Count} (Done: {tasks.Count(t => t.isDone)})\n");
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

        static public void NotImplementedYet()
        {
            Console.WriteLine("\nNot implemented yet.\nPress any key...");
            Console.ReadKey();
        }
        static Task FindTask()
        {
            Console.Write("\nEnter number: ");

            int number = int.Parse(Console.ReadLine());

            if (number < 1 || number > tasks.Count)
            {
                return null;
            }
            else
            {
                return tasks[number - 1];
            }
        }
        static (string, bool) parse(string line)
        {
            string title = line.Split(';')[0];
            bool status = bool.Parse(line.Split(';')[1]);

            return (title, status);
        }
        static public void ShowAllTasks()
        {
            Console.Clear();
            Console.WriteLine("*** All tasks ***\n");

            if (tasks.Count == 0)
            {
                Console.WriteLine("Tasks list is empty(");
            }
            else
            {
                int i = 1; 
                foreach(Task task in tasks)
                {
                    Console.WriteLine($"{i}. {task}");
                    i++;
                }
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
        static public void AddTask()
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
                tasks.Add(new Task(title));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Task: {title} added!");
                Console.ResetColor();
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
        static public void DeleteTask()
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
                tasks.Remove(task);
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("Task deleted!");
                Console.ResetColor();
            }
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
        static public void ChangeStatus()
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
                task.ChangeStatus();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task status changed!");
                Console.ResetColor();
            }
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
        static public void ChangeTitle()
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

                task.Title = title;
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task title changed!");
                Console.ResetColor();
            }
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
        static public List<Task> LoadTasks(string filePath)
        {
            List<Task> tasks = new List<Task>();

            foreach(string line in File.ReadAllLines(filePath))
            {
                (string title, bool status) task = parse(line);
                tasks.Add(new Task(task.title, task.status));
            }

            return tasks;
        }    
    }
}
