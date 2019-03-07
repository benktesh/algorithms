using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    /// <summary>
    /// This is recursive implementation of Al Khwarizmi's mutliplicaiton algorithm
    /// The basic algorithm is:
    /// 
    /// x.y = 2(x . (int) y/2) if y is even. 
    ///       x + 2(x. (int) y/2) otherwise.
    /// </summary>

    public class MultiplicationRecursive
    {
        static int level;
        
        public static int Multiply(int x, int y)
        {
            
            if (y == 0)
            {
                Print(level, x, y, 0);
                return 0;
            }

            int result = Multiply(x, (int) (y / 2));

            int returndata = 0; 
            if (y%2 == 0)
            {
                returndata = 2 * result;
            }
            else
            {
                returndata = x + 2 * result; 
            }
            level++;
            Print(level, x, y, returndata);
            return returndata;

        }

        public static void Print(int level, int x, int y, int returnData)
        {
           
            var print = "".PadLeft(level * 5, '\xA0');
            print = $"{level}{print} Multiply({x},{y}), {returnData}";
            Console.WriteLine(print);
        }

        public static void RunMe()
        {
            int x = 13, y = 11;
            var result = Multiply(x, y);
            Console.WriteLine(result == (x * y) ? "Done" : "Something Wrong");
        }
    }
}
