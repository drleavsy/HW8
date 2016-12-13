using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Little_Jarvis
{
    interface ICommand<T> //: IPrintable
    {
        bool CanExec(T execComm);
        void DoSomething();
    }
}
