using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.BitManipulation
{
    /*
     * Next Number: Given a positive integer, print the next smallest and the next largest number that
       have the same number of 1 bits in their binary representation.

        Given a binary array of bits for a number, we want to flip ith bit from 1 to 0 and jth bit from 0 to 1.
        The number will be large if i > j and number will be small if i < j. That is the number will be bigger
        if zero to one bit is to the left of one to zero bit.



     */
    public class NextNumber
    {
        public String GetBitString(int x)
        {
            return Convert.ToString(x, 2).PadLeft(4, '0');
        }

        public void PrintBitString(int x)
        {
            Console.WriteLine(GetBitString(x));
        }

        public int GetNext(int n)
        {
            int c = n;
            int c0 = 0;
            int c1 = 0;
            PrintBitString(c);
            while (((c & 1) == 0) && (c != 0))
            {
                c0++;
                c = c >> 1;
                PrintBitString(c);
            }

            return 0; 
        }
        public void Run()
        {
            GetNext(19);
        }
    }
}
