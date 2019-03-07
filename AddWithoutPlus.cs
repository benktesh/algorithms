using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    public class AddWithoutPlus
    {

        public int Add(int a, int b)
        {
            while(b != 0)
            {
                Console.WriteLine($" a {a}: {Convert.ToString(a, 2).PadLeft(8, '0')}");
                Console.WriteLine($" b {b}: {Convert.ToString(b, 2).PadLeft(8, '0')}");
                int sum = a ^ b; //add without carrying
                int carry = (a & b) << 1; //carry, but dont add

                Console.WriteLine($" sum {sum}: {Convert.ToString(sum, 2).PadLeft(8, '0')}");
                Console.WriteLine($" carry {carry}: {Convert.ToString(carry, 2).PadLeft(8, '0')}");

                a = sum; b = carry;
            }

            return a; 
        }

        public void RunMe()
        {
            Console.WriteLine(Add(2, 3));
        }
    }
}
