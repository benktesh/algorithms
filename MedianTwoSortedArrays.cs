using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class MedianTwoSortedArrays
    {
        public double GetMedian(int[] nums1, int[] nums2) { 
        
            double result = 0.0;
            
            var l1 = nums1.Length;
            var l2 = nums2.Length;
            var l = l1 + l2;
            var arr = new int[l];

            //copy the second array here
            for (int i = 0; i < l2; i++)
            {
                arr[i + l1] = nums2[i];
            }

            bool keep = true;
            int f = 0;
            int s = 0;
            int r = 0;
            while (f < l1 && s < l2 && r < l)
            {
                if (nums1[f] > nums2[s] )
                {
                    arr[r] = nums2[s];
                    s++;

                }
                else
                {
                    arr[r] = nums1[f];
                    f++;
                }
                r++;

            }

            while(f < l1)
            {
                arr[r] = nums1[f];
                f++;
                r++;
            }

            if (l % 2 == 0 && l >= 2)
            {

                result = (arr[(int) l / 2 - 1] + arr[(int)l / 2]) / 2.0;
            }
            else
            {
                result = arr[l / 2];
            }
            return result;




        }
        public void Run()
        {
            int[] arr1 = {1,2};
            int[] arr2 = {3,4 };
            Console.WriteLine($"Median is: {GetMedian(arr1, arr2)}");
        }
    }
}
