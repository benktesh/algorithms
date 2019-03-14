using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    public class HelperMethods
    {
        
        public static int RandomInRange(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
