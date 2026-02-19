using System;

namespace ToDoList.Exceptions
{
    public abstract class ToDoListException : Exception
    {
        public ToDoListException(string message) : base(message) { }
        public ToDoListException(string message, Exception innerException) : base(message, innerException) { }
    }
}
