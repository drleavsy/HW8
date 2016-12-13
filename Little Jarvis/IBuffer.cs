using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Little_Jarvis
{
    interface IBuffer<T> : IPrintable
    {
        bool IsFull();
        bool IsEmpty();
        void Peek();
        //string Print();
    }
}
