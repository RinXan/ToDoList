using System.Text.Json.Serialization;
using ToDoList.Exceptions;

namespace ToDoList
{
    public class Task
    {
        public string Title { get; set; }
        public bool isDone { get; set; }

        [JsonConstructor]
        private Task() { }
        public Task(string title) 
        {
            ValidateTitle(title);
            Title = title.Trim();
            isDone = false;
        }
        public Task(string title, bool status) 
        {
            ValidateTitle(title);
            Title = title.Trim();
            isDone = status;
        }

        public void ChangeTitle(string title)
        {
            ValidateTitle(title);
            Title = title;
        }
        public override string ToString()
        {
            string status = isDone ? "[+]" : "[ ]";
            return $"{status} {Title}";
        }
        
        private void ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new InvalidTaskDataException(nameof(title), "Title cannot be empty");
        }
    }
}