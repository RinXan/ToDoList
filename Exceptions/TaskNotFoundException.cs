using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Exceptions
{
    public class TaskNotFoundException : ToDoListException
    {
        public int TaskNumber { get; }

        public TaskNotFoundException(int taskNumber) : base($"Task with number {taskNumber} not found")
        {
            TaskNumber = taskNumber;
        }

        public TaskNotFoundException(string message) : base(message) { }
    }
}
