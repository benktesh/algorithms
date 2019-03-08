using System;
using System.Linq;

namespace algorithms
{
    //Given an array A of N positive numbers. The task is to find the position where equilibrium first occurs in the array.
    //Equilibrium position in an array is a position such that the sum of elements before it is equal to the sum of elements after it.
    public class EquilibriumPoint
    {
        public static void FindEquilibrium(int[] arr, int len)
        {
            int start = 1;
            int end = len - 2;
            if (len == 1)
            {
                Console.WriteLine(1);
                return;
            }

            if (len == 2)
            {
                Console.WriteLine(-1);
                return;
            }

            //1 3 5 2 2
            int sumL = arr[0];
            int sumR = arr[len - 1];

            while (start < end)
            {
                if (sumL == sumR)
                {
                    sumL = sumL + arr[start];
                    sumR = sumR + arr[end];
                    start++;
                    end--;
                }
                else if (sumL < sumR)
                {
                    sumL = sumL + arr[start];
                    start++;
                }
                else if (sumL > sumR)
                {
                    sumR = sumR + arr[end];
                    end--;
                }
            }

            if (sumL == sumR)
            {
                Console.WriteLine(start + 1);
                return;
            }
            Console.WriteLine(-1);
        }
        public void Run()
        {
            var tc = "43 34 2 8 17 5 11 8";
            //tc = "27 4 25 6 6 1 27 22 19 29 6 9 36 24 6 15 5";
            tc = "20 17 42 25 32 32 30 32 37 9 2 33 31 17 14 40 9 12 36 21 8 33 6 6 10 37 12 26 21 3";
            var data = tc.Split(' ').Select(k => Int32.Parse(k)).ToArray();
            FindEquilibrium(data, data.Length);
        }

    }
}
