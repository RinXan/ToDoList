using System;

namespace ToDoList.Exceptions
{
    public class TaskOperationException : ToDoListException
    {
        public string Operation { get; }
        public TaskOperationException(string message) : base(message) { }
        public TaskOperationException(string operation, string message) : base(message) { Operation = operation; }
        public TaskOperationException(string operation, string message, Exception innerException) : base(message, innerException) 
        { 
            Operation = operation;
        }
    }
}
