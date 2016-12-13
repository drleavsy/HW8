using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Little_Jarvis
{
    public abstract class Buffer<T> : IBuffer<T>
    {
        protected int sizeA;
        protected int count; // 
        protected T TValue; //
        protected T [] arrayA;

        public abstract bool IsEmpty();
        public abstract bool IsFull();
        public abstract void Peek();
        public abstract void Print();
        //public abstract void Dequeue();
    }
}
