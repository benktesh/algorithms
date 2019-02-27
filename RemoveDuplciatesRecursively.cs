using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    class RemoveDuplciatesRecursively
    {
        public static void RemoveDuplicates(String data)
        {
            var reduced = data;
            int n = data.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int count = 0;
                //we need to check the length of the duplicates.

     
                while (data.Substring(i, 1) == data.Substring(i + 1, 1))
                {
                    count++; i++;
                    if (i == n - 1)
                        break;
                }
                if (count != 0)
                {
                    reduced = data.Remove(i - count, count + 1);
                    continue;
                }
            }
            //by now we should have reduced the str1 by removing duplicates
            //if they both are same, we are done.
            if (data == reduced)
            {
                Console.WriteLine(reduced);
            }
            else //we try again
            {
                RemoveDuplicates(reduced);
            }
        }


        public static void RunMe()
        {
            var inputs = new String[] { "geeksforgeek", "acaaabbbacdddd", "mississipie" };


            RemoveDuplicates("mississipie");

            foreach (var inp in inputs)
            {
                RemoveDuplicates(inp);

            }
        }
    }
}
