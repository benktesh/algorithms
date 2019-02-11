using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    class KeyPair
    {
        public static String SumTwoElements(int[] a, int x)
        {
            int N = a.Length;
            //Create a hashtable with the following specification:
            //key is value of array
            //value is index of array
            var hash = new Hashtable();
            for (int i = 0; i < N; i++)
            {
                if (!hash.ContainsKey(a[i]))
                {
                    hash.Add(a[i], i);
                }
            }

            try
            {
                for (int i = 0; i < N; i++)
                {
                    //if there exist an element which is equal to the different and currentelement, then
                    //there is an element that would make the sum.
                    int diff = x - a[i];
                    if (hash.ContainsKey(diff) && Convert.ToInt32(hash[diff]) != i)
                    {
                        //Console.WriteLine("Pairs: " + a[i] + ", " + a[(int) hash[diff]]);
                        return "Yes";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Logic: " + ex.Message);
            }

            return "No";
        }

        public static void RunMe()
        {
            //run sum of two items:
            var specs = "42 468";
            var arrs = "335 501 170 725 479 359 963 465 706 146 282 828 962 492 996 943 828 437 392 605 903 154 293 383 422 717 719 896 448 727 772 539 870 913 668 300 36 895 704 812 323 334";

            specs = "5 4";
            arrs = "1 2 5 6 7";
            var spec = Utilities.PraseToIntArray(specs);
            var arr = Utilities.PraseToIntArray(arrs);
            Console.WriteLine(algorithms.KeyPair.SumTwoElements(arr, spec[1]));
        }

    }
}
