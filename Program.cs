using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Program
    {
        static void Main(string[] args)
        {
            var app = new Tasks("Main tasks");
            app.Run();
        }
    }
}
