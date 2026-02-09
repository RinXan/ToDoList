using System;
using System.Collections.Generic;

namespace ToDoList
{
    public class Task
    {
        public string Title { get; set; }
        public bool isDone { get; protected set; }

        public Task(string title) 
        {
            Title = title;
            isDone = false;
        }
        public Task(string title, bool status) 
        {
            Title = title;
            isDone = status;
        }

        public void ChangeStatus()
        {
            isDone = !isDone;
        }
    
        public override string ToString()
        {
            string status = isDone ? "[+]" : "[ ]";
            return $"{status} {Title}";
        }
    }
}