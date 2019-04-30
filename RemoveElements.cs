using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using algorithms;

namespace Algorithms
{
    /*
     * Given an array nums and a value val, remove all instances of that value in-place and return the new length.
       Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
       The order of elements can be changed. It doesn't matter what you leave beyond the new length.
       Given nums = [3,2,2,3], val = 3,
       Your function should return length = 2, with the first two elements of nums being 2.
       It doesn't matter what you leave beyond the returned length.
     */
    public class RemoveElements
    {
        private void Shift(int[] nums, int pos)
        {
       
            for (int i = pos; i < nums.Length-1; i++)
            {
                nums[i] = nums[i+1];
            }
            nums[nums.Length - 1] = Int32.MinValue;
            //Utilities.PrintArray(nums,nums.Length);
        }
        public int RemoveElement(int[] nums, int val)
        {
           
            int iter = 0;
            int count = 0; 
            while (iter < nums.Length)
            {
                if (nums[iter] == val )
                {
                    count++;
                    Shift(nums, iter);
                    continue;
                }

                iter++;
            }

            return nums.Length - count;

        }

        public int RemoveElementSwap(int[] nums, int val)
        {
            int l = 0;
            int r = nums.Length - 1;
            int count = 0;

            while (l <= r)
            {
                if (nums[l] == val)
                {
                    nums[l] = nums[r];
                    r--;
                    count++;
                }
                else
                {
                    l++;
                }
            }

            return nums.Length - count;

        }

        public void Run()
        {
            int[] arr = new[] {1 };
            int val = 1;
            var length = RemoveElement(arr, val);
            //Utilities.PrintArray(arr, length);

            length = RemoveElementSwap(arr, val);
            Utilities.PrintArray(arr, length);
        }
    }
}
