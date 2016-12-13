using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Little_Jarvis
{
    interface IMyQueue<T> : IBuffer<T>
    {
        void Enqueue(T newTop);
        //T Dequeue();
        void Dequeue();
    }
}
