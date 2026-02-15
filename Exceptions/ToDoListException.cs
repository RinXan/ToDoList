using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Exceptions
{
    public abstract class ToDoListException : Exception
    {
        public ToDoListException(string message) : base(message) { }
        public ToDoListException(string message, Exception innerException) : base(message, innerException) { }
    }
}
