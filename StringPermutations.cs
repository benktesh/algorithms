using System;
using System.Collections.Generic;
using System.Linq;

namespace algorithms
{
    class StringPermutations
    {
        static HashSet<String> permutation = new HashSet<string>();
        static void Permutation(String data, String prefix)
        {
            //Console.WriteLine($"Permutation {counter}: {data} Prefix: {prefix}");
            if (data.Length == 0)
            {
                //Console.WriteLine($"Perms adding: {prefix}" );
                permutation.Add(prefix);
            }
            else
            {
                for (int i = 0; i < data.Length; i++)
                {
                    String rem = data.Substring(0, i) + data.Substring(i + 1);
                    Permutation(rem, prefix + data[i]);
                }
            }
        }

        public static void RunMe()
        {
            string word = "BAC";
            //Sort the characters
            word = String.Concat(word.OrderBy(c => c));
            Permutation(word, "");
            Console.WriteLine(string.Join(" ", permutation));  
        }

    }
}
