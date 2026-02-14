using System;
using System.Collections.Generic;
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
    }
}
