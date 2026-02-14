using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Exceptions
{
    public class InvalidTaskDataException : ToDoListException
    {
        public string FieldName { get; }
        public InvalidTaskDataException(string message) : base(message) { }
        public InvalidTaskDataException(string fieldName, string message) : base(message)
        {
            FieldName = fieldName;
        }
    }
}
