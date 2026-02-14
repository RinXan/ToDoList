using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            tasks.Remove(task);
        }
        public void ChangeStatus(Task task)
        {
            task.isDone = !task.isDone;
        }
        public void ChangeTitle(Task task, string newTitle)
        {
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
    }
}
