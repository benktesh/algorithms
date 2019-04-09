using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//code obtained from http://blog.bodurov.com/Median-From-a-Stream-of-Numbers/
namespace algorithms
{
    public class MedianStreaming
    {
        public class MaxHeap : Heap { protected override bool Compare(int a, int b) { return a > b; } }
        public class MinHeap : Heap { protected override bool Compare(int a, int b) { return a < b; } }

        public abstract class Heap
        {
            private readonly List<int> _array = new List<int>(128);
            private int _heapSize = -1;

            protected abstract bool Compare(int a, int b);

            public virtual void Insert(int key)
            {
                _heapSize++;
                if (_array.Count <= _heapSize)
                {
                    _array.AddRange(
                        Enumerable.Range(0, _heapSize - (_array.Count - 1))
                                  .Select(i => 0));
                }
                _array[_heapSize] = key;
                Heapify(_heapSize);
            }
            public virtual int GetTop()
            {
                int max = -1;

                if (_heapSize >= 0)
                {
                    max = _array[0];
                }

                return max;
            }
            public virtual int ExtractTop()
            {
                var del = -1;

                if (_heapSize > -1)
                {
                    del = _array[0];

                    Swap(_array, 0, _heapSize);
                    _heapSize--;
                    Heapify(GetParent(_heapSize + 1));
                }

                return del;
            }
            public virtual int GetCount()
            {
                return _heapSize + 1;
            }
            public override string ToString()
            {
                return "{" + string.Join(";", _array) + "}";
            }


            private static void Swap(IList<int> array, int aIndex, int bIndex)
            {
                var aux = array[aIndex];
                array[aIndex] = array[bIndex];
                array[bIndex] = aux;
            }

            private int GetParent(int i)
            {
                if (i <= 0)
                {
                    return -1;
                }

                return (i - 1) / 2;
            }

            private void Heapify(int i)
            {
                int p = GetParent(i);

                if (p >= 0 && Compare(_array[i], _array[p]))
                {
                    Swap(_array, i, p);
                    Heapify(p);
                }
            }

        }


        public int GetMedian(int e, int prevMedian, Heap left, Heap right)
        {

            String x = "Hello ";
            
            var leftCount = left.GetCount();    //max
            var rightCount = right.GetCount();  //min

            if (leftCount > rightCount)
            {
                if (e < prevMedian)
                {
                    right.Insert(left.ExtractTop());
                    left.Insert(e);
                }
                else
                {
                    right.Insert(e);
                }

                return Average(left.GetTop(), right.GetTop());
            }

            if (leftCount == rightCount)
            {
                if (e < prevMedian)
                {
                    left.Insert(e);
                    return left.GetTop();
                }
                right.Insert(e);
                return right.GetTop();
            }
            //left < right
            if (e < prevMedian)
            {
                left.Insert(e);
            }
            else
            {
                left.Insert(right.ExtractTop());
                right.Insert(e);
            }

            return Average(left.GetTop(), right.GetTop());
        }

        int Average(int a, int b)
        {
            return (a + b) / 2; 

        }
   
    public void Run()
        {

            var array = new[] { 5, 15, 1, 3, 2, 8, 7, 9, 10, 6, 11, 4 };
            var expectMedian = new[] { 5, 10, 5, 4, 3, 4, 5, 6, 7, 6, 7, 6 };
            var median = array[0];

            var left = new MedianStreaming.MaxHeap();  //root contains the highest or equal value than children 
            var right = new MedianStreaming.MinHeap(); //root contains the smaller than the value of the children 

            for (var i = 0; i < array.Length; ++i)
            {
                median = GetMedian(array[i], median, left, right);
                Console.WriteLine(i + " => " + median);
            }

        }
    }
}
