using System;
using System.ComponentModel;

namespace algorithms.BitManipulation
{
    /*
     * You are given two 32-bit numbers, N and M, and two bit positions, i and
       j. Write a method to insert M into N such that M starts at bit j and ends at bit i. You
       can assume that the bits j through i have enough space to fit all of M. That is, if
       M = 10011, you can assume that there are at least 5 bits between j and i. You would not, for
       example, have j = 3 and i = 2, because M could not fully fit between bit 3 and bit 2.
       EXAMPLE
       Input: N = 10000000000j M = 10011, i = 2, j = 6
       Output: N = 10001001100
     */
    public class Insertion
    {
        public void Insert(String N, String M, int i, int j)
        {
            var n = Convert.ToInt32(N,2);
            var m = Convert.ToInt32(M, 2);


            Console.WriteLine($"n:       {GetBitString(n)}");
            Console.WriteLine($"m:       {GetBitString(m)}");

            int allOnes = ~0;
            Console.WriteLine($"AllOnes: {GetBitString(allOnes)}");
            
            var left = allOnes << (j + 1);
            Console.WriteLine($"Left:    {GetBitString(left)}");

            var right = ((1 << i) - 1);
            Console.WriteLine($"Right:   {GetBitString(right)}");

            var mask = left | right;
            Console.WriteLine($"Mask:    {GetBitString(mask)}");

            var nCleared = n & mask;

            Console.WriteLine($"nCleared:{GetBitString(nCleared)}");

            var mShifted = m << i;
            Console.WriteLine($"mShifted:{GetBitString(mShifted)}");

            var final = nCleared | mShifted;

            Console.WriteLine($"Final:   {GetBitString(final)}");
        }

        public String GetBitString(int x)
        {
            return Convert.ToString(x, 2).PadLeft(32, '0');
        }
        public void Run()
        {
            String N = "10000000000";
            String M = "10011";
            int i = 2;
            int j = 6;

            Console.WriteLine($"{N}=>{Convert.ToInt32(N,2)}");
            Insert(N, M, 2, 6);

        }
    }
}
