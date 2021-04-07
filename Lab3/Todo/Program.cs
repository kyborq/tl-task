using System;
using System.Collections.Generic;
using TodoLib;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            ITodo MyTodo = new Todo();
                        
            MyTodo.AddTask("First task");
            MyTodo.AddTask("Second task");
            MyTodo.AddTask("Third task");

            MyTodo.ToggleTask(1);

            List<ITask> tasks = MyTodo.Get();

            foreach (Task task in tasks)
            {
                Console.WriteLine($"Todo: {task.Label}, {task.State}");  
            }
        }
    }
}
