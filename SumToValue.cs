using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    /// <summary>
    /// Find four elements that sum to a given value | Set 2 ( O(n^2Logn) Solution)
    /// Given an array of integers, find any one combination of four elements in the array whose sum is equal to a given value X.
    /// For example, if the given array is {10, 2, 3, 4, 5, 9, 7, 8} and X = 23, then your function should print “3 5 7 8” (3 + 5 + 7 + 8 = 23).
    /// </summary>
    public class SumToValue
    {
        public class PairSum
        {
            public int Sum { get; set; }
            public int First { get; set; }
            public int Second { get; set; }

            public PairSum(int s, int i, int j)
            {
                Sum = s;
                First = i;
                Second = j;
            }
        }
        public void SumToValue4(int[] arr, int x)
        {
            
            var n = arr.Length;
            var lst = new List<PairSum>();
            for (int i = 0; i < n; i++)
            {
                for (int j = i+1; j < n; j++)
                {

                    lst.Add(new PairSum(arr[i]+arr[j], arr[i], arr[j]));
                }
            }

            lst = lst.OrderBy(k => k.Sum).ToList();

            int l = 0;
            int r = lst.Count - 1;

            var result = new List<int>();
            while (l < r)
            {
                if (lst[l].Sum + lst[r].Sum == x)
                {
                    result.Add(lst[l].First);
                    result.Add(lst[l].Second);
                    result.Add(lst[r].First);
                    result.Add(lst[r].Second);
                    break;
                }
                else if (lst[l].Sum + lst[r].Sum < x)
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
            Utilities.PrintArray(result.ToArray());
        }
        public void Run()
        {
            var arr = new[] {10, 2, 3, 4, 5, 9, 7, 8};
            int val = 23;
            SumToValue4(arr, val);
        }
    }
}
