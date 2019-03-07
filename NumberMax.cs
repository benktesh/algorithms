using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    public class NumberMax
    {
        public int GetMax(int a, int b)
        {
            return (a + b) / 2 + Math.Abs((a - b) / 2);
        }

        public int GetMin(int a, int b)
        {
            return (a + b) / 2 - Math.Abs((a - b) / 2);
        }

        public void RunMe()
        {
            int a = 18,  b = 14;


            Console.WriteLine($"Max value of ({a}, {b}) pair is => {GetMax(a, b)}");
            Console.WriteLine($"Min value of ({a}, {b}) pair is => {GetMin(a, b)}");

        }

    }
}
