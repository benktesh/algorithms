using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    /// <summary>
    /// Ways of transforming one string to other by removing 0 or more characters
    /// Given two sequences A, B, find out number of unique ways in sequence A, to form a subsequence of A that is identical to the sequence B. Transformation is meant by converting string A (by removing 0 or more characters) to string B.
    /// 
    /// Examples:
    /// 
    /// Input : A = "abcccdf", B = "abccdf"
    /// Output : 3
    /// Explanation : Three ways will be -&gt; "ab.ccdf", 
    /// "abc.cdf" &amp; "abcc.df" .
    /// "." is where character is removed. 
    /// </summary>
    public class StringTransformation
    {
        public int CountTransformation(string a, string b)
        {
            int lenA = a.Length;
            int lenB = b.Length;
            if (lenB == 0)
            {
                return 1;
            }
            int[,] dp = new int[lenB+1, lenA+1];

            for (int r = 0; r < lenB; r++)
            {
                //the bottom half of the matrix can be ignored. 
                for (int c = r; c < lenA; c++)
                {
                    //handle first row differently.
                    if (r == 0)
                    {
                        if (a[c] == b[r] && c == 0)
                            dp[r, c] = 1;
                        else if (a[c] == b[r])
                            dp[r, c] = dp[r, c - 1] + 1;
                        else
                            dp[r, c] = dp[r, c - 1];
                    }

                    //for rest of the rows
                    else
                    {
                        if (a[c] == b[r])
                            dp[r, c] = dp[r, c - 1] + dp[r - 1, c - 1];
                        else
                            dp[r, c] = dp[r, c - 1];
                    }
                }
            }

            Utilities.PrintArray(dp);
            return dp[lenB-1, lenA-1]; 
        }

        public void Run()
        {
            string a = "abcccdf", b = "abccdf";
            Console.Write(CountTransformation(a, b));

        }
    }
}
