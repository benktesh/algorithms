using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Algorithms
{
    public class RemoveDuplicates
    {
        public int RemoveDuplicate(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            

            if (nums.Length == 1)
            {
                return 1;
            }

       
            int count = 1;

            for (int i = 1; i < nums.Length - 1; i++)
            {
                while (i < nums.Length - 1 && nums[i] == nums[i - 1])
                {
                    i++;
                }

                if (i < nums.Length - 1)
                {
                    nums[count] = nums[i];
                    count++;
                }

            }

            if (nums[nums.Length - 1] != nums[nums.Length - 2])
            {
                nums[count] = nums[nums.Length - 1];
                count++;
            }
            return count;

        }
        public void Run()
        {
            int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            nums = new int[] { 1, 1, 1, 1 };


            var length = RemoveDuplicate(nums);
            for (int i = 0; i < length; i++)
            {
                Console.Write(nums[i] + " ");
            }
        }
    }
}
