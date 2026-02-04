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
            //Console.WriteLine("Not implemented yet.\nPress any key to close...");
            //Console.ReadKey();
            while (true)
            {
                Console.WriteLine($"=== {tableName} ===");
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
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
            Console.WriteLine("Not Impemented yet. Press any key...");
            Console.ReadKey();
        }
        private void RemoveTask()
        {
            Console.WriteLine("Not Impemented yet. Press any key...");
            Console.ReadKey();
        }
        private void MarkTask()
        {
            Console.WriteLine("Not Impemented yet. Press any key...");
            Console.ReadKey();
        }
    }
}