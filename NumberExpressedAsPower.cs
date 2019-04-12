using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    /*
     * Check if a number can be expressed as x^y (x raised to power y)
       Given a positive integer n, find if it can be expressed as xy where y > 1 and x > 0. x and y both are integers.
       Examples :
       
       Input:  n = 8
       Output: true
       8 can be expressed as 23
       
       Input:  n = 49
       Output: true
       49 can be expressed as 72
       
       Input:  n = 48
       Output: false
       48 can't be expressed as xy
     */
    public class NumberExpressedAsPower
    {
        public void CheckPower(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                int p = i;
                int raise = 1; 
                while (p <= n)
                {
                    if (p == n)
                    {
                        Console.WriteLine($"Expressed as {i}^{raise}");
                        return;
                    }

                    p = p * i;
                    raise++;
                }
            }
        }
        public void Run()
        {
            CheckPower(49);

        }
    }
}
