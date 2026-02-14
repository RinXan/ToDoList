using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Exceptions
{
    public class TaskOperationException : ToDoListException
    {
        public string Operation { get; }
        public TaskOperationException(string message) : base(message) { }
        public TaskOperationException(string operation, string message) : base(message) { Operation = operation; }
    }
}
