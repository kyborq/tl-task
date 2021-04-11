namespace TodoLib
{
    public class Task : ITask
    {
        public bool State { get; set; }
        public string Label { get; set; }

        public Task(string taskLabel)
        {
            State = false;
            Label = taskLabel;
        }

        public void Set(bool NewState)
        {
            State = NewState;
        }
        public void Toggle()
        {
            State = !State;
        }
    }
}
