using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        public void SaveToFile(string filePath) 
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
        }
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

                string[] lines = File.ReadAllLines(filePath);
                List<Task> loadedTasks = new List<Task>();

                foreach(string line in lines)
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
        }
    }
}
