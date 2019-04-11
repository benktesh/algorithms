using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    //Given an unsorted array A of size N of non-negative integers,
    //find a continuous sub-array which adds to a given number.
    public class SubArraySum
    {

        /// <summary>
        /// pick the first element as starting point and call it a current sum
        /// iterate through the array begining from the second element (i.e. at index 1)
        /// intialize start as index to 0
        /// if cur == sum, then a solution has been found [start and i] where i is exclusive
        /// while cur greater than sum and start is smaller than i -1,
        /// keep increasing the index of start until i and start are at same index
        /// if i is less than l, keep adding current element to cur sum.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sum"></param>
        /// <param name="l"></param>
        public void GetSubArray(int[] arr, int sum, int l = 0)
        {
            int cur = arr[0];
            int start = 0;
            l = arr.Length;

            for (int i = 1; i <= l; i++)
            {
               
                while (cur > sum && start < i - 1)
                {
                    cur = cur - arr[start];
                    start++;
                }

                if (cur == sum)
                {
                    Console.WriteLine($"Index {start}, {i-1}");
                    return;
                }


                if (i < l)
                {
                    cur = cur + arr[i];
                }
                

            }

        }
        public void Run()
        {
            int sum = 15;
            var rawInput = "1 2 3 4 5 6 7 8 9 10";

            rawInput = "1 2 3 7 5";
            sum = 12;

            //rawInput = @"135 101 170 125 79 159 163 65 106 146 82 28 162 92 196 143 28 37 192 5 103 154 93 183 22 117 119 96 48 127 172 139 70 113 68 100 36 95 104 12 123 134";
            //sum = 468;
            var data = rawInput.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(k => Int32.Parse(k)).ToArray();
            GetSubArray(data, sum);

        }
    }
}
