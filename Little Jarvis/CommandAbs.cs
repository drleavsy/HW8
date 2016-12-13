using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Little_Jarvis
{
    public abstract class CommandAbs<T> : ICommand<T> 
    {
        protected T [] commandName;
        protected T[] items;
        protected T [] address;
        protected string [] message;

        protected int ind;
        protected string CurrentCommand;
        protected string CurrentItem;
        protected string CurrentAddr;
        protected string CurrentMessage;
        //private bool SplitInput(string StringIn);

        public abstract bool CanExec(T execComm);
        public abstract void DoSomething();
        public abstract void Print();
        // public abstract bool CompareComm(T obj);
    }
}
