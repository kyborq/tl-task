using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoLib
{
    public class Task : ITask
    {
        private bool _State;
        private string _Label;
        private int _ID;

        public int ID { get => _ID; set => _ID = value; }
        public bool State { get => _State; set => _State = value; }
        public string Label { get => _Label; set => _Label = value; }

        public void Set(bool NewState)
        {
            _State = NewState;
        }
        public void Toggle()
        {
            _State = !_State;
        }
    }
}
