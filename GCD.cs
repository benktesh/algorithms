using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    public class GCD
    {
        public int GetGCD(int[] arr)
        {
            int num = arr.Length;
            var gcd = arr[0];

            for (int i = 1; i < num; i++)
            {

                gcd = GetGCD(gcd, arr[i]);

            }
            return gcd;
        }

        public int GetGCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return GetGCD(b, a % b);
            }
        }

        public void Run()
        {
            int[] arr = {2, 4, 6, 8, 10};
            Console.WriteLine(GetGCD(arr));
        }
    }
}
