using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class SumSet
    {
        public void Sum(List<int> numbers, int target, List<int> partial)
        {
            int s = 0;
            foreach (int p in partial)
            {
                s = s + p;
            }

            if (s == target)
            {
                Console.WriteLine("Sum: " + String.Join(" ", partial));
            }

            if (s >= target)
            {
                return;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                List<int> remaining = new List<int>();
                int n = numbers[i];
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    remaining.Add(numbers[j]);
                }
                var partialRec = new List<int>(partial);
                partialRec.Add(n);
                Sum(remaining, target, partialRec);
            }
        }

        public void Run()
        {
            int[] numbers = { 2,6, 4,8 };
            Array.Sort(numbers);
            int target = 8;

            Sum(numbers.ToList(), target, new List<int>() );

        }
    }
}
