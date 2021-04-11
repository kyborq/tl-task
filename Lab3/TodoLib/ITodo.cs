using System.Collections.Generic;

namespace TodoLib
{
    public interface ITodo
    {
        void AddTask(string taskTitle);
        List<ITask> GetTasks();
        void ToggleTask(int TaskID);
    }
}
