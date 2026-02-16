using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoList.Exceptions;

namespace ToDoList
{
    public class TaskManager
    {
        private List<Task> tasks;

        public TaskManager() 
        {
            tasks = new List<Task>();
        }
    
        public void AddTask(string title)
        {
            tasks.Add(new Task(title));
        }
        public void RemoveTask(Task task)
        {
            if (task == null || !tasks.Contains(task)) throw new TaskNotFoundException("Task not found in the list");
            tasks.Remove(task);
        }
        public void ChangeStatus(Task task)
        {
            if (task == null || !tasks.Contains(task)) throw new TaskNotFoundException("Task not found in the list");
            task.isDone = !task.isDone;
        }
        public void ChangeTitle(Task task, string newTitle)
        {
            if (task == null || !tasks.Contains(task)) throw new TaskNotFoundException("Task not found in the list");
            task.ChangeTitle(newTitle);
        }
        public List<Task> GetAllTasks()
        {
            return new List<Task>(tasks);
        }
        public int GetTotalTaskCount()
        {
            return tasks.Count;
        }
        public int GetComplitedTaskCount()
        {
            return tasks.Count(t =>  t.isDone);
        }
        public Task GetTaskByIndex(int number)
        {
            if (number < 1 || number > tasks.Count) throw new TaskNotFoundException(number);
            return tasks[number - 1];
        }
        // saving tasks in JSON file
        public void SaveToFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("File path cannot be empty", nameof(filePath));
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonedTasks = JsonSerializer.Serialize(tasks, options);
                File.WriteAllText(filePath, jsonedTasks);
            }
            catch (Exception ex)
            {
                throw new TaskOperationException("SaveToFile", "Failed to save tasks to json file", ex);
            }
        }
        //loading tasks from JSON file
        public void LoadFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("File path cannot be empty", nameof(filePath));

            try
            {
                if (!File.Exists(filePath))
                {
                    tasks.Clear();
                    return;
                }

                string json = File.ReadAllText(filePath);
                tasks = JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
            }
            catch (Exception ex)
            {
                throw new TaskOperationException("LoadFromFile", "Failed to load tasks from json file", ex);
            }
        }

        // saving tasks in text file function
        /*public void SaveToFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("File path cannot be empty", nameof(filePath));
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Task task in tasks)
                    {
                        writer.WriteLine($"{task.Title};{task.isDone}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new TaskOperationException("SaveToFile", "Failed to save tasks to file", ex);
            }
        }*/

        // loading tasks from text file
        /* public void LoadFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("File path cannot be empty", nameof(filePath));

            try
            {
                if (!File.Exists(filePath))
                {
                    tasks.Clear();
                    return;
                }

                string[] lines = File.ReadAllLines(filePath);
                List<Task> loadedTasks = new List<Task>();

                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length >= 2 && bool.TryParse(parts[1], out bool status))
                    {
                        try
                        {
                            loadedTasks.Add(new Task(parts[0], status));
                        }
                        catch (InvalidTaskDataException) { }
                    }
                }

                tasks = loadedTasks;
            }
            catch (Exception ex)
            {
                throw new TaskOperationException("LoadFromFile", "Failed to load tasks from file", ex);
            }
        } */
    }
}
