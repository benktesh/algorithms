using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace algorithms.BitManipulation
{
    public class FlipBit
    {
        public static int flipBit(int a)
        {
            /* If all 1s, this is already the longest sequence. */
            if (~a == 0) return BitConverter.GetBytes(a).Sum(p=>p);

            int currentLength = 0;
            int previousLength = 0;
            int maxLength = 1; // We can always have a sequence of at least one 1
            while (a != 0)
            {
                if ((a & 1) == 1)
                {
                    currentLength++;
                }
                else if ((a & 1) == 0)
                {
                    /* Update to 0 (if next bit is 0) or currentLength (if next bit is 1). */
                    previousLength = (a & 2) == 0 ? 0 : currentLength;
                    currentLength = 0;
                }
                maxLength = Math.Max(previousLength + currentLength + 1, maxLength);
                a >>= 1;
            }
            return maxLength;
        }

        public void Run()
        {
            Console.WriteLine(flipBit(1));

        }
    }
}
