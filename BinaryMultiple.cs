using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace algorithms
{
    /*
     * Given a binary number, write a program that prints 1 if given binary number is a multiple of 3.
     * Else prints 0. The given number can be big upto 2^100. It is recommended to finish the task using one traversal of input binary string.
     */
    class BinaryMultiple
    {
        public static int IsMultiple3Bit(int n)
        {
            int oddCount = 0;
            int evenCount = 0;

            if (n < 0)
            {
                n = -n;
            }

            if (n == 0)
            {
                return 1;
            }

            if (n <= 2)
            {
                return 0;
            }

            while (n != 0)
            {
                if ((n & 1) != 0)
                {
                    oddCount++;
                }

                n = n >> 1;

                if ((n & 1) != 0)
                {
                    evenCount++;
                }

                n = n >> 1;
            }

            return IsMultiple3Bit(Math.Abs(oddCount - evenCount));
        }

        public static void CheckMultiple3(char[] c)
        {
            int size = c.Length; 
            char currentState = '0';

            foreach (var digit in c)
            {
                switch (currentState)
                {
                    case '0':
                        if (digit == '1')
                        {
                            currentState = '1';
                        }
                        break;
                    case '1':
                        if (digit == '0')
                        {
                            currentState = '2';
                        }
                        else
                        {
                            currentState = '0';
                        }
                        break;
                    case '2':
                        if (digit == '0')
                        {
                            currentState = '1';
                        }
                        break;
                }   
            }

            Console.WriteLine(currentState == '0' ? "1" : "0");
        }

        static char[] ParseInput(String input)
        {
            input = Regex.Replace(input, @"[\s+]", "");
            return input.ToCharArray();
        }

        public static void RunMe()
        {
            //CheckMultiple3(ParseInput("0 1 1"));
            //CheckMultiple3(ParseInput("1 0 0"));

            Console.WriteLine(IsMultiple3Bit(24) == 1 ? "True" : "False");
        }

    }
}
