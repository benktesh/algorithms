using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.BitManipulation
{
    /*
     *  A monochrome screen is stored as a single array of bytes, allowing eight consecutive
        pixels to be stored in one byte.The screen has width w, where w is divisible by 8 (that is, no byte will
        be split across rows). The height of the screen, of course, can be derived from the length of the array
        and the width. Implement a function that draws a horizontal line from (xl, y) to (x2, y).
        The method signature should look something like:
        drawLine(byte[] screen, int width, int x l , int x2, int y)
     * */
    public class DrawLine
    {
        private void Drawline(byte[] screen, int width, int x1, int x2, int y)
        {
            var startOffest = x1 % 8;
            var firstFullByte = x1 / 8;

            if(startOffest != 0)
            {
                firstFullByte++;
            }

            var endOffset = x2 % 8;
            var lastFullByte = x2 / 8;

            if(endOffset != 7)
            {
                lastFullByte++; 
            }

            for (var b = firstFullByte; b <= lastFullByte; b++)
            {
                screen[(width / 8) * y + b] = (byte)0xFF;
            }

            var startMask = (byte)(0xFF >> startOffest);
            var endMask = (byte)~(0xFF >> (endOffset + 1));

            if ((x1 / 8) == (x2 / 8))
            {
                var mask = (byte)(startMask & endMask);
                screen[(width / 8) * y + (x1 / 8)] |= mask;
            }
            else
            {
                if (startOffest != 0)
                {
                    var byteNumber = (width / 8) * y + firstFullByte - 1;
                    screen[byteNumber] |= startMask;
                }
                if (endOffset != 7)
                {
                    var byteNumber = (width / 8) * y + lastFullByte + 1;
                    screen[byteNumber] |= endMask;
                }
            }
        }

        private int ComputeByteNum(int width, int r, int c)
        {
            return (width * c + r) / 8;

        }
        private void Print(byte[] screen, int width)
        {
            int height = screen.Length * 8 / width;
            for(var r=0; r < height; r++)
            {
                for(var c =0; c< width; c++)
                {
                    var b = screen[ComputeByteNum(width, c, r)];

                    for (var i = 7; i >= 0; i--)
                    {
                        Console.Write((b >> i) & 1);
                    }
                    Console.WriteLine();
                }
            }
        }
        public void Run()
        {
            const int width = 8 * 4;
            const int height = 15;
            var screen = new byte[width * height / 8];
            Drawline(screen, width, 8, 10, 2);
            Print(screen, width);
        }
    }
}
