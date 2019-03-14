using System;

namespace algorithms
{

    public class MyStack<T>
    {
        int stackTop = 0;
        T[] items = new T[100];
        public void Push(T item)
        {
            if (stackTop == items.Length)
            {
                throw new Exception("Stack Full");
            }
            items[stackTop] = item;
            stackTop++;
        }

        public T Pop()
        {
            if (stackTop == 0)
            {
                throw new Exception("Stack Empty");
            }
            stackTop--;
            return items[stackTop];
        }
    }


}
