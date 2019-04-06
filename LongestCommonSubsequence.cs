using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    public class LongestCommonSubsequence
    {
        public void LCS(string[] x, string[] y)
        {
            int m = x.Length;
            int n = y.Length;
            int[,] dp = new int[m, n];
            int[,] s = new int[m, n];

            int i = 0;
            int j = 0;
            //handle first row
            bool firstRow = false;
            for (j = 0; j < n; j++)
            {
                if (x[0] == y[j])
                {
                    firstRow = true;
                }
                if (firstRow)
                {
                    dp[0, j] = 1;
                }
            }

            //handle firstColumn 
            bool firstCol = false;
            for (i = 0; i < m; i++)
            {
                if (x[i] == y[0])
                {
                    firstCol = true;
                }
                if (firstCol)
                {
                    dp[i, 0] = 1;
                }
            }

            for (i = 1; i < m; i++)
            {
                for (j = 1; j < n; j++)
                {
                    if (x[i] == y[j])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]);
                    }
                }
            }

            Utilities.PrintArray(dp, x, y);

        }

        public void Run()
        {
            string[] x = { "A", "B", "C", "B", "D", "A", "B" };
            string[] y = { "B", "D", "C", "A", "B", "A" };

            LCS(x, y);


        }
    }
}
