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
