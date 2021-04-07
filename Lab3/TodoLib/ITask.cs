namespace TodoLib
{
    public interface ITask
    {
        string Label { get; set; }
        bool State { get; set; }
    }
}
