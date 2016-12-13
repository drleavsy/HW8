using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Little_Jarvis
{
    public abstract class MyQueueAbstr<T> : Buffer<T>
    {
        public abstract void Dequeue();
        public abstract void Enqueue(T newTop);
    }
}
