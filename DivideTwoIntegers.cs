using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class DivideTwoIntegers
    {
        public int Divide(int dividend, int divisor)
        {
            if (dividend == 0)
            {
                return 0;
            }

            //edge case. When divisor is -1 and divident is Minvalue, return the max value;
            if (dividend == Int32.MinValue && divisor == -1)
            {
                return Int32.MaxValue;
            }

            //if only one is negative the reuslt is negative
            bool isNegative = (dividend ^ divisor) < 0;

            //Forcing numbers to be negative.
            int dd = dividend < 0 ? dividend : ~dividend + 1; 
            int dr = divisor < 0 ? divisor : ~divisor + 1;
            
            int result = 0;

            while (dr >= dd)
            {
                int n = dr, count = 1;
                while (dd - n <= n)
                {
                    n <<= 1;
                    count <<= 1;
                }
                dd -= n;
                result += count;
            }
            return isNegative ? ~result + 1 : result;

        }

        public void Run()
        {
            int a = -10, b = 3, expected = 3; 
            int result = Divide(a, b);// expected out put is 3;
            Console.WriteLine($"Input {a}, {b}. Expected output is {expected}. Returnd output:{result}");
        }
    }
}
