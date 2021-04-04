using System;
using TodoLib;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Todo MyTodo = new Todo();

            MyTodo.Add("First task");
            MyTodo.Add("Second task");
            MyTodo.Add("Third task");

            MyTodo.ToggleTask(1);
            
            for (int i = 0; i < MyTodo.Tasks.Count; i++)
            {
                Console.WriteLine($"Todo: {MyTodo.Tasks[i].Label}, {MyTodo.Tasks[i].State}");
            }
        }
    }
}
