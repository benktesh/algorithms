using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace algorithms
{
    /*
     * Given a String of length S, reverse the whole string without reversing the individual words in it. Words are separated by dots.
     */
    public class ReverseWords
    {
        public static String Reverse(String data)
        {
            String reversed = null;

            try
            {
                var reversedArray =  data.Split(new char[] {'.', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => (x)).ToArray().Reverse();
                reversed = String.Join(".", reversedArray);
            }
            catch (Exception ex)
            {
                Console.WriteLine("parseToInt: " + ex.StackTrace);
                return null;
            }
            return reversed;
        }

        public static void RunMe()
        {
            string words = "i.like.this.program.very.much";
            var reversed = Reverse(words);
            Console.WriteLine(reversed);
        }
        

    }
}
