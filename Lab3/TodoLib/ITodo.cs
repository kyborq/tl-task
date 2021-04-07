using System;
using System.Collections.Generic;

namespace TodoLib
{
    public interface ITodo
    {
        void AddTask(string taskTitle);
        List<ITask> Get();
        void ToggleTask(int TaskID);
    }
}
