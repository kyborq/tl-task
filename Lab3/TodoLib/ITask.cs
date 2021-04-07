namespace TodoLib
{
    public interface ITask
    {
        string Label { get; set; }
        bool State { get; set; }
        void Set(bool NewState);
        void Toggle();
    }
}
