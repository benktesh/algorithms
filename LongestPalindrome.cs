using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace algorithms
{
    /*
     * Given a string S, find the longest palindromic substring in S.
     * Substring of string S: S[ i . . . . j ] where 0 ≤ i ≤ j < len(S).
     * Palindrome string: A string which reads the same backwards.
     * More formally, S is palindrome if reverse(S) = S. In case of conflict,
     * return the substring which occurs first ( with the least starting index ).
     * https://practice.geeksforgeeks.org/problems/longest-palindrome-in-a-string/0/?ref=self
     */
    class LongestPalindrome
    {
        public static string LongestPalidrome(String data)
        {
            //a single character is palindrome of length
            int start = 0;
            int len = 1;

            int n = data.Length;
            //create an array to fill the truth
            //initialized to false for all the cells
            bool[,] isPalindrome = new bool[n, n]; 

            for (int i = 0; i < n; i++)
            {
                //a single character is palindrome of length
                isPalindrome[i, i] = true;
                if (i < n - 1 && data[i] == data[i + 1])
                {
                    isPalindrome[i, i + 1] = true;
                    //if the len is 1, then fix the start to the first palindrome string of length = 2
                    if (len == 1)
                    {
                        start = i;
                        len = 2;
                    }
                }
            }

            int j; //this is for column navigation
            for (int k = 2; k < n; k++) 
            {
                //this is for row navigation
                for (int i = 0; i < n - k; i++)
                {
                    //column index
                    j = i + k; 
                    if (isPalindrome[i + 1, j - 1] && data[i] == data[j])
                    {
                        if (k >= len)
                        {
                            start = i;
                            len = j - i + 1;
                        }
                        isPalindrome[i, j] = true;
                    }
                }
            }
            //Utilities.PrintArray(IsPalidrome);
            return data.Substring(start, len);
        }

        public static void RunMe()
        {

            IList<IList<int>> result = new List<IList<int>>();

            var data = "aaaabbaa";

            //Console.WriteLine(LongestPalidrome(data));
            //data = "rfkqyuqfjkxy";

            //Console.WriteLine(LongestPalidrome(data));
            data = "vnrtysfrzrmzlygfv";
            //Console.WriteLine(LongestPalidrome(data));
            //Console.WriteLine(LongestPalidrome("fyfvladzpbfudkklrwq"));
            //Console.WriteLine(LongestPalidrome("ssyoqcjomwufbdfxudzhiftak"));
            //Console.WriteLine(LongestPalidrome("jj876ykitt")); //jj
            //Console.WriteLine("qrrc");
        }
    
}
}
