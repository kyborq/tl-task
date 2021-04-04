using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoLib
{
    public interface ITask
    {
        int ID { get; set; }
        string Label { get; set; }
        bool State { get; set; }
        void Set(bool NewState);
        void Toggle();
    }
}
