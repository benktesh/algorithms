using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class MaxAreaContainerWithWater
    {
        public int MaxArea(int[] height)
        {

            int maxArea = Int32.MinValue;
            int n = height.Length;
            int[,] dp = new int[n + 1, n + 1];
            for (int i = 0; i < n; i++)
            {
                dp[i, i] = height[i];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {

                    
                }
            }
            return maxArea;

        }

        public void Run()
        {
            int[] arr = {1, 8, 6, 2, 5, 4, 8, 3, 7};
            Console.WriteLine(MaxArea(arr));

        }
    }
}
