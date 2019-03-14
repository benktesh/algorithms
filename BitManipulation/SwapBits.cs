using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.BitManipulation
{
    /*
     * Given an unsigned integer, swap all odd bits with even bits. For example, if the given number is 23 (00010111), 
     * it should be converted to 43 (00101011). Every even position bit is swapped with adjacent bit on right side
     * (even position bits are highlighted in binary representation of 23), and every odd position bit is swapped with adjacent on left side.
    */
    public class SwapBits
    {
        public void Swap(int number)
        {
            var even = number & 0xAAAAAAAA; //mask with 101010101010...
            var odd = number & 0x55555555;  //mask with 010101010101...
            var shiftEven = even >> 1; //the even bits will be shifted to right
            var shiftOdd = odd << 1; //the odd bits will be shifted to left

            //Utilities.PrintBitString(number, "number");
            //Utilities.PrintBitString(0xAAAAAAAA, "evenmask");
            //Utilities.PrintBitString(even, "even");
            //Utilities.PrintBitString(0x55555555, "oddmask");
            //Utilities.PrintBitString(odd, "odd");
            //Utilities.PrintBitString(shiftEven, "shiftEven");
            //Utilities.PrintBitString(shiftOdd, "shiftOdd");

            long final = shiftOdd | shiftEven;
            Utilities.PrintBitString(final, "final");
            Console.WriteLine(final);
        }

        public void Run()
        {
            Swap(23);
        }
    }
}
