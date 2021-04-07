using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoLib
{
    public class Task : ITask
    {
        public int ID { get; set; }
        public bool State { get; set; }
        public string Label { get; set; }

        public Task()
        {
            State = false;
            Label = "";
            ID = 0;
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
