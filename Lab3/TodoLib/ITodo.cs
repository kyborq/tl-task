using System;
using System.Collections.Generic;

namespace TodoLib
{
    public interface ITodo
    {
        void Add(string task);
        List<ITask> Get();
        void ToggleTask(int TaskID);
    }
}
