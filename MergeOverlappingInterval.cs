using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Algorithms
{
    public class MergeOverlappingInterval
    {
        public class Interval
        {
            public int Start { get; set; }
            public int End { get; set; }

            public Interval(int s, int e)
            {
                Start = s;
                End = e;

            }
        }

        public void MergeInterval(Interval[] arr)
        {
            var n = arr.Length;
            arr = arr.OrderBy(k => k.Start).ToArray();
            Stack<Interval> stack = new Stack<Interval>();
            stack.Push(arr[0]);
            for (int i = 1; i < n; i++)
            {
                var next = arr[i];
                var curTop = stack.Peek();
                if(curTop.End < next.Start) //no overlap,
                {
                    stack.Push(next);
                }
                else if(curTop.End < next.End) //we have overlap here
                {
                    stack.Pop();
                    curTop.End = next.End;
                    stack.Push(curTop);
                }
            }

            foreach (var s in stack)
            {
                Console.Write($"[{s.Start}, {s.End}] ");  
            }
            Console.WriteLine(" ");
        }
        public void Run()
        {

            Interval[] arr = new Interval[4];  

            arr[0] = new Interval(6, 8);
            arr[1] = new Interval(1, 9);
            arr[2] = new Interval(2, 4);
            arr[3] = new Interval(4, 7);
            MergeInterval(arr);
            

        }
    }
}
