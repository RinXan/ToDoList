namespace ToDoList
{
    public class Task
    {
        public string Title { get; set; }
        public bool isDone { get; set; }

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
        public override string ToString()
        {
            string status = isDone ? "[+]" : "[ ]";
            return $"{status} {Title}";
        }
    }
}