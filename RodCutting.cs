using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    public class RodCutting
    {
        //An iterative version with bottom up appraoch
        public int CutRod(int[] arr, int rod)
        {

            int[] s = new int[rod + 1];
            int[] dp = new int[rod + 1];
            dp[0] = 0;
            for (int i = 1; i < rod + 1; i++)
            {
                dp[i] = Int32.MinValue;
            }

            for (int j = 1; j <= rod; j++)
            {
                int curMax = Int32.MinValue;
                for (int i = 1; i <= j; i++)
                {

                    var temp = arr[i] + dp[j - i];
                    if (curMax < temp)
                    {
                        curMax = temp;
                        s[j] = i;
                    }
                }
                dp[j] = curMax;
            }
            Console.WriteLine("Max value: " + dp[rod]);

            PrintSolution(rod, s);
            return dp[rod];
        }

        private void PrintSolution(int rod, int[] s)
        {
            Console.Write("Solution(s): ");
            int k = rod;
            while (k > 0)
            {
                Console.Write(s[k] + " ");
                k = k - s[k];

            }
            Console.WriteLine();
        }

        //A recursive approach with memoization.
        public int CutRodMemozed(int[] arr, int rod, int[] dp)
        {
            if (dp[rod] >= 0)
            {
                return dp[rod];
            }
            int curMax = Int32.MinValue;
            if (rod == 0)
            {
                curMax = 0;
            }
            else
            {
                for (int i = 1; i <= rod; i++)
                {
                    curMax = Math.Max(curMax, arr[i] + CutRodMemozed(arr, rod - i, dp));
                }
            }
            dp[rod] = curMax;
            return curMax;
        }

        public void Run()
        {

            int[] arr = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };
            int cut = 4;


            int[] dp = new int[cut + 1];
            dp[0] = 0;
            for (int i = 0; i < cut + 1; i++)
            {
                dp[i] = Int32.MinValue;
            }

            Console.WriteLine(CutRodMemozed(arr, cut, dp));
            Console.WriteLine(CutRod(arr, cut));
        }
    }
}
