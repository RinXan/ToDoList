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
