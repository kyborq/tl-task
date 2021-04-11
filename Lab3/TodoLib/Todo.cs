using System.Collections.Generic;

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
            ITask NewTask = new Task(taskTitle);
            NewTask.Label = taskTitle;
            NewTask.State = false;
            Tasks.Add(NewTask);
        }
        public void ToggleTask(int TaskID)
        {
            Tasks[TaskID].State = true;       
        }
        public List<ITask> GetTasks()
        {
            return Tasks;
        }
    }
}
