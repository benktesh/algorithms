using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public class MaxSubArraySum
    {

        public int[] MaxSubArray(int[] arr)
        {
            var start = 0;
            var end = 1;
            int n = arr.Length;
            int maxSoFar = arr[0];
            int maxToI = arr[0];
            for (int i = 1; i < n; i++)
            {
                
                maxToI = Math.Max(maxToI + arr[i], arr[i]);

                if (maxToI == arr[i]) //need to reset the index
                {
                    maxToI = arr[i];
                    start = i; 
                }

                //maxSoFar = Math.Max(maxSoFar, maxToI);
                if (maxSoFar < maxToI)
                {
                    maxSoFar = maxToI;
                    end = i+1; //part of the subarray
                }
              
            }
            Console.WriteLine($"max is: {maxSoFar}");
            return arr.Skip(start).Take(Math.Abs(end - start)).ToArray();
        }
        public int SubArraySum(int[] arr, int l, int h)
        {
            //handle single element
            if (l == h)
            {
                return arr[l];
            }

            int m = (l + h) / 2;

            return Math.Max( Math.Max(
                SubArraySum(arr, l, m),
                SubArraySum(arr, m + 1, h)),
                CrossingSum(arr, l, m, h)
            );

        }

        public int CrossingSum(int[] arr, int l, int m, int h)
        {
            int sum = 0;
            int leftSum = int.MinValue;
            for (int i = m; i >= l ; i--)
            {
                sum = sum + arr[i];
                if (sum > leftSum)
                {
                    leftSum = sum;
                }
            }

            sum = 0;
            int rightSum = int.MinValue;
            for (int i = m+1; i <= h; i++)
            {
                sum = sum + arr[i];
                if (sum > rightSum)
                {
                    rightSum = sum;
                }
            }

            return leftSum + rightSum;

        }

        public void Run()
        {
            //int[] arr = { 2, 3, -5, 5, 7 };
            int[] arr = { -2, 1,-3, 4, -1, 2, 1, -5, 4}
            ;
            int n = arr.Length;
            int maxSum = SubArraySum(arr, 0, n - 1);
            Console.WriteLine("Maximum contiguous sum is " +
                          maxSum);

           var maxSumArr = MaxSubArray(arr);
            Console.WriteLine("Maximum contiguous sum is " + maxSumArr.Sum() + "\n And Elements Are " +
                         string.Join(' ', maxSumArr));
        }
    }
}
