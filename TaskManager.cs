using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoList.Exceptions;
using ToDoList.Logger;

namespace ToDoList
{
    public class TaskManager
    {
        private List<Task> _tasks;
        private readonly ILogger _logger;

        public TaskManager(ILogger logger) 
        {
            _tasks = new List<Task>();
            _logger = logger;
        }
    
        public void AddTask(string title)
        {
            _tasks.Add(new Task(title));
            _logger.Log(LogLevel.INFO, $"Task: {title} added");
        }
        public void RemoveTask(Task task)
        {
            if (task == null || !_tasks.Contains(task)) throw new TaskNotFoundException("Task not found in the list");
            _tasks.Remove(task);
            _logger.Log(LogLevel.INFO, $"Task: {task.Title} removed");
        }
        public void ChangeStatus(Task task)
        {
            if (task == null || !_tasks.Contains(task)) throw new TaskNotFoundException("Task not found in the list");
            task.isDone = !task.isDone;
            _logger.Log(LogLevel.INFO, $"Task: {task.Title} - status changed: {task.isDone}");
        }
        public void ChangeTitle(Task task, string newTitle)
        {
            if (task == null || !_tasks.Contains(task)) throw new TaskNotFoundException("Task not found in the list");
            task.ChangeTitle(newTitle);
            _logger.Log(LogLevel.INFO, $"Task title changed: {task.Title}");
        }
        public List<Task> GetAllTasks()
        {
            return new List<Task>(_tasks);
        }
        public int GetTotalTaskCount()
        {
            return _tasks.Count;
        }
        public int GetComplitedTaskCount()
        {
            return _tasks.Count(t =>  t.isDone);
        }
        public Task GetTaskByIndex(int number)
        {
            if (number < 1 || number > _tasks.Count) throw new TaskNotFoundException(number);
            return _tasks[number - 1];
        }
        // saving tasks in JSON file
        public void SaveToFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("File path cannot be empty", nameof(filePath));
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonedTasks = JsonSerializer.Serialize(_tasks, options);
                File.WriteAllText(filePath, jsonedTasks);
                _logger.Log(LogLevel.INFO, $"{_tasks.Count} tasks saved to JSON file");
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
                    _tasks.Clear();
                    return;
                }

                string json = File.ReadAllText(filePath);
                _tasks = JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
                _logger.Log(LogLevel.INFO, $"{_tasks.Count} tasks loaded from JSON file");
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
                    foreach (Task task in _tasks)
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
                    _tasks.Clear();
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

                _tasks = loadedTasks;
            }
            catch (Exception ex)
            {
                throw new TaskOperationException("LoadFromFile", "Failed to load tasks from file", ex);
            }
        } */
    }
}
