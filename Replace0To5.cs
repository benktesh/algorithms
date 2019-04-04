using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    public class Replace0To5
    {

        public int Convert0To5(int num)
        {
            if (num == 0)
                return 5;
            else
                return Convert0To5Rec(num);

        }

        public int Convert0To5Rec(int num)
        {
            if (num == 0)
            {
                return 0;
            }

            int digit = num % 10;
            if (digit == 0)
            {
                digit = 5;
            }

            return Convert0To5Rec(num / 10) * 10 + digit;
        }

        public void Run()
        {
            Console.Write(Convert0To5(10120));
        }
    }
}
