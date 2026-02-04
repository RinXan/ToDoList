using System;
using System.Collections.Generic;

namespace ToDoList
{
    public class Tasks
    {
        protected string tableName { get; set; }
        protected List<string> tasks { get; set; }

        public Tasks(string name)
        {
            tableName = name;
            tasks = new List<string>();
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"=== {tableName} ===");
                if (tasks.Count < 1) 
                {
                    Console.WriteLine("No tasks, add one)");
                } else
                {
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {tasks[i]}");
                    }
                }
                Console.WriteLine($"=== {tableName} ===");
                Console.WriteLine();
                Console.WriteLine("1) Add task");
                Console.WriteLine("2) Remove task");
                Console.WriteLine("3) Mark task");
                Console.WriteLine("4) Exit");

                Console.Write("Choise: ");
                int choise = int.Parse( Console.ReadLine() );

                Console.WriteLine();

                switch (choise)
                {
                    case 1:
                        AddTask();
                        break;
                    case 2:
                        RemoveTask();
                        break;
                    case 3:
                        MarkTask();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("No such option. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AddTask()
        {
            Console.Write("Enter task name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Task name is not correct - " + name);
            }
            else 
            {
                tasks.Add(name);
            }
        }
        private void RemoveTask()
        {
            Console.Write("Enter task number u want to remove: ");
            int taskNum = int.Parse(Console.ReadLine());

            tasks.RemoveAt(taskNum - 1);
        }
        private void MarkTask()
        {
            Console.Write("Enter task number u have done: ");
            int taskNum = int.Parse(Console.ReadLine());

            tasks[taskNum - 1] = tasks[taskNum - 1] + "(done!)";
        }
    }
}