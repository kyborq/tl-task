using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoLib
{
    public class Todo : ITodo
    {
        private List<ITask> Tasks;
       
        public Todo()
        {
            Tasks = new List<ITask>();
        }
        public void AddTask(string taskTitle)
        {
            ITask NewTask = new Task();
            NewTask.Label = taskTitle;
            NewTask.State = false;
            Tasks.Add(NewTask);
        }
        public void ToggleTask(int TaskID)
        {
            Tasks[TaskID].State = true;       
        }
        public List<ITask> Get()
        {
            return Tasks;
        }
    }
}
