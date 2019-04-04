using System;

namespace algorithms
{
    //Given an array arr[], find the maximum j – i such that arr[j] > arr[i].
    //Examples :

    //Input: {34, 8, 10, 3, 2, 80, 30, 33, 1}
    //Output: 6  (j = 7, i = 1)
    public class MaxIndexDiff
    {
        public void FindMaxDiff(int[] arr)
        {
            var len = arr.Length;
            var LMin = new int[len];
            var RMax = new int[len];

            LMin[0] = arr[0];
            RMax[len-1] = arr[len-1];

            int i = 0;
            int j = 0;

            for (i = 1; i < len; i++)
            {
                LMin[i] = Math.Min(arr[i], LMin[i - 1]);  
            }

            for (j = len-2; j >= 0; j--)
            {
                RMax[j] = Math.Max(arr[j], RMax[j + 1]);
            }


            i = 0;
            j = 0; 
            int maxDiff = -1;

            while (j < len && i < len)
            {
                if (LMin[i] < RMax[j])
                {
                    maxDiff = Math.Max(maxDiff, j - 1);
                    j = j + 1;
                }
                else
                {
                    i = i + 1; 
                }
            }

            Console.WriteLine(maxDiff);
        }
        public void Run()
        {
            var arr = new int[] {34, 8, 10, 3, 2, 80, 30, 33, 1};
            FindMaxDiff(arr);
        }
    }
}