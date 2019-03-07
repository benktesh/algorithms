using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    class FactorialZeros
    {
        public Int32 FactorsOf5(int i)
        {
            int count = 0; 
            while (i%5==0)
            {
                count++;
                i = i / 5;
            }
            return count;
        }

        public int countFactoZeros(int num)
        {
            int tcount = 0; 
            for (int i = 2; i <= num; i++)
            {
                tcount += FactorsOf5(i);
            }
            return tcount;
        }

        public Int32 GetFactorial(int n)
        {
            Int32 sum = 0; 
            if(n <= 2)
            {
                return n; 
            }

            sum = n * GetFactorial(n - 1);

            return sum;
            
        }

        public void RunMe()
        {
            int n = 25; 
            Console.WriteLine(GetFactorial(n));
            Console.WriteLine(countFactoZeros(n));
        }
    }
}
