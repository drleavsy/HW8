using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Little_Jarvis
{
    class MyQueue<T> : MyQueueAbstr<T>
    {
        protected Command<string>[] commandArray;
        protected Command<string> commVal;
        private int head;
        private int tail;

        public MyQueue(Command<string>[] commandArr)
        {
            this.commandArray = commandArr;
            //arrayA = commandArray;
            sizeA = commandArr.Length;
            count = 0;
            head = 0;
            tail = 0;
        }

        public MyQueue(T[] TArray)
        {
            arrayA = TArray;
            sizeA = TArray.Length;
            count = 0;
            head = 0;
            tail = 0;
        }

        public override bool IsEmpty()
        {
            if (count <= sizeA && count > 0) // check if stack is not empty already
            {
                return false;
            }
            else
            {
               // Console.WriteLine("The queue is empty.");
                return true;
            }
        }

        public override bool IsFull()
        {
            if (count < sizeA)  // check if the buffer is not full yet
            {
                return false;
            }
            else
            {
                //Console.WriteLine("The queue is full.");
                return true;
            }
        }

        public override void Peek()
        {  }

        internal  void Enqueue(Command<string> newTop)
        {
            if (head < sizeA)  // check if head index is less than the array size
            {
                commandArray[head] = newTop; // adding new element
                head++; // move "writing" index one ste forward
                count++; // increase the size of buffer
            }
            else // if (head == sizeIn) , if head index reached the end of array
            {
                head = 0; // move the head "write index" to the beginning of the array
                commandArray[head] = newTop; // add new element to the beginning of the array
                count++; // increase the size of buffer
                head++; // move the head index to the 2nd cell of array, after the first one was already written
            }
        }

        public override void Dequeue()
        {
            if (tail < sizeA) // if the tail is less than the size of array
            {
                commVal = commandArray[tail];
                // remove element at the tail index (first index in the ring buffer)
                tail++; // move tail step forward
                count--; // reduce the size of the buffer
            }
            else // if (tail == sizeIn)
            {
                tail = 0; // if last remove was at the end of the array , then set tail to the beginning of the array
                commVal = commandArray[tail];
                // remove element under tail index
                count--;// reduce the size of buffer
                tail++; // move tail one step forward
            }
        }
        public override void Print()
        {
            //string temp = null;
            int i = tail;
            int count_print = count;
            if (count_print == 0) // if buffer is empty print [ ]
            {
                 Console.WriteLine("[ ]\n");
            }

            while (count_print > 0)
            {
                if (i < sizeA) // if printed element is less than the maximum of the array
                {
                    if (tail == i)
                    {
                        Console.WriteLine("[");
                        commandArray[i].Print();
                        i++;
                    }
                    else if (tail != i)
                    {
                        commandArray[i].Print();
                        i++;
                    }
                }
                else if (i >= sizeA) // if index exceed the size of the array
                {
                    i = 0;
                    if (tail == sizeA) // print start position of the buffer
                    {
                        Console.WriteLine("[\n");
                        commandArray[i].Print();
                        i++;
                    }
                    else // print the middle elements of the buffer
                    {
                        commandArray[i].Print();
                        i++;
                    }
                }
                else
                {
                    if (tail == i)
                    {
                        Console.WriteLine("[ ");
                        commandArray[i].Print(); // print the first element sof the buffer
                        i++;
                    }
                    else if (tail != i)
                    {
                        Console.Write(", "); // middle element
                        commandArray[i].Print();
                        i++;
                    }
                    else if (i >= sizeA) // if index exceed the size of the array
                    {
                        i = 0;
                        if (tail == sizeA) // print start position of the buffer
                        {
                            Console.WriteLine("[ ");
                            commandArray[i].Print(); // print the first element sof the buffer
                            i++;
                        }
                        else // print the middle elements of the buffer
                        {
                            Console.Write(", "); // middle element
                            commandArray[i].Print();
                            i++;
                        }

                    }
                }
                count_print--;
                if (count_print == 0)
                {
                    Console.WriteLine("]");
                }
            }
        }

        public override void Enqueue(T newTop)
        {
            throw new NotImplementedException();
        }
    }
}
