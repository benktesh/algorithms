using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace algorithms
{
    /*
     * Circular Array: Implement a CircularArray class that supports an array-like data structure which
       can be efficiently rotated. If possible, the class should use a generic type (also called a template), and
       should support iteration via the standard for (Obj o : c i r c u l a r A r r a y ) notation
     */
    public class CircularArrayEnumerable
    {

        public class CirularArray<T>
        {

            private T[] array;
            private int head = -1;

            public CirularArray(int size)
            {
                array = new T[size];
            }

            private int Convert(int index)
            {
                if (index < 0)
                {
                    index = index + array.Length;
                }

                if (head <= 0)
                {
                    head = 0;
                }
                return (head + index) % array.Length;
            }

            public void Rotate(int shiftRight)
            {
                head = Convert(shiftRight);
            }

            public T Get(int i)
            {
                if (i < 0 || i >= array.Length)
                {
                    throw new IndexOutOfRangeException("Too big or too small");
                }

                return array[Convert(i)];
            }

            public void Set(int i, T item)
            {
                array[Convert(i)] = item;
            }

            public IEnumerator<T> GetEnumerator()
            {
                foreach (var item in array)
                {
                    yield return item;
                }
            }

            public bool HasNext()
            {
                return head >= 0; 
            }

           
            public T Next()
            {
                Console.WriteLine(head);
                if (head >= array.Length)
                {
                    head = head % array.Length;
                };
                var d = array[head];
                head = (head+1);
                return d;
            }
        }

        public void Run()
        {
            int[] nums = { 4, 3, 6, 4, 7, 9 };
            CirularArray<int> mc = new CirularArray<int>(5);

            Console.WriteLine("Has Next " + mc.HasNext());

            mc.Set(0, 4);
            mc.Set(1, 3);
            mc.Set(2, 6);
            mc.Set(3, 4);
            mc.Set(4, 7);
            mc.Set(5, 9);

            Console.WriteLine("Has Next " + mc.HasNext());

            


            foreach (int x in mc)
                Console.Write(x + " ");

            Console.WriteLine();



        }
    }

}
