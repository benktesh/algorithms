using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.BitManipulation
{
    /*
     * Binary to String: Given a real number between 0 and 1 (e.g., 0.72) that is passed in as a double, print
       the binary representation. If the number cannot be represented accurately in binary with at most 32
       characters, print "ERROR."
     */
    public class BinaryToString
    {
        public String PrintBinary(double num)
        {
            if (num >= 1 || num <= 0)
            {
                return "ERROR";
            }

            var binary = new StringBuilder();
            var frac = 0.5;

            binary.Append(".");
            while (num > 0)
            {
                if (binary.Length >= 32)
                {
                    return "ERROR";
                }

                if (num >= frac)
                {
                    binary.Append(1);
                    num = num - frac;
                }
                else
                {
                    binary.Append(0);
                }

                frac = frac / 2;
            }

            return binary.ToString();

        }

        public String GetBitString(int x)
        {
            return Convert.ToString(x, 2).PadLeft(32, '0');
        }
        public void Run()
        {
            var binaryString = PrintBinary(.125);
            Console.WriteLine(binaryString);
        }
    }
}
