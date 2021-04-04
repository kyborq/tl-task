using System;
using System.Collections.Generic;

namespace TodoLib
{
    public interface ITodo
    {
        void Add(string task);
        void ToggleTask(int TaskID);
    }
}
