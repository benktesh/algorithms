using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    public class SumOfBitDifference
    {
        public void Run()
        {
            int[] arr = { 1, 3, 5 };
            int n = arr.Length;

            Console.Write(SumBitDifferences(arr));
        }

        private int SumBitDifferences(int[] arr)
        {
            int ans = 0;
            int n = arr.Length;
            for (int i = 0; i < 32; i++)
            {
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if ((arr[j] & (1 << i)) == 0)
                    {
                        count++;
                    }

                    ans = ans + count * (n - count) * 2;
                }
            }

            return ans;
        }
    }
}
