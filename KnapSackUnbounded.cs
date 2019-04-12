using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    /// <summary>
    ///  Unbounded Knapsack (Repetition of items allowed)
    ///  Given a knapsack weight W and a set of n items with certain value vali and weight wti,
    /// we need to calculate minimum amount that could make up this quantity exactly.
    /// This is different from classical Knapsack problem, here we are allowed to use unlimited number of instances of an item.
    /// </summary>
    public class KnapSackUnbounded
    {
        public int UnboundedKnapsack(int W, int[] val, int[] wt)
        {
            //dp[i] is table that stores maximum value with capacity of i
            //In dp the value is stored from 1 to Max Capacity (i.e. W)
            int[] dp = new int[W + 1];
            int n = val.Length;

            //We have two loops.
            //The first lopps runs from 0 to Capacity (i.e. W).
            //  For each capacity from 0 to W, we check at weight and the value at that weight.
            //  The dp[] element will contains the value that is maximum possible for the weight. 
            //  This is acheived by putting the maximum from (dp[i], dp[i - wt[j]] + val[j])
            for (int i = 0; i <= W; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (wt[j] <= i)
                    {
                        dp[i] = Math.Max(dp[i], dp[i - wt[j]] + val[j]);
                    }
                }
            }
            return dp[W];
            
        }
        public void Run()
        {
            int W = 100; //capacity
            int[] val = { 10, 30, 20 };
            int[] wt = { 5, 10, 15 };
            int n = val.Length;
            Console.WriteLine(UnboundedKnapsack(W, val, wt));
        }
    }
}
