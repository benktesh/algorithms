using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class MaxAreaContainerWithWater
    {
        public int MaxArea(int[] height)
        {
            return MaxAreaShrinking(height);
            //return MaxAreaIteratively(height);
        }

        private int MaxAreaShrinking(int[] height)
        {
            int l = 0;
            int n = height.Length - 1;
            int r = n;
            int maxArea = Int32.MinValue;
            while (l < r)
            {
                int q = height[l] > height[r] ? height[r] : height[l];
                maxArea = Math.Max(maxArea, q * (r - l));
                if (height[l] < height[r])
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }

            return maxArea;
        }

        private int MaxAreaIteratively(int[] height)
        {
            int maxArea = Int32.MinValue;
            int n = height.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int curMin = Math.Min(height[i], height[j]);
                    int maxFromI = curMin * (j - i);
                    maxArea = Math.Max(maxArea, maxFromI);
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
