﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoLib
{
    public class Todo : ITodo
    {
        public List<ITask> Tasks = new List<ITask>();
       
        public void Add(string task)
        {
            ITask NewTask = new Task();
            NewTask.Label = task;
            NewTask.State = false;
            Tasks.Add(NewTask);
        }
        public void ToggleTask(int TaskID)
        {
            Tasks[TaskID].State = true;       
        }
    }
}