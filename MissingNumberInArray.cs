using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    /*
     * Given an array C of size N-1 and given that there are numbers from 1 to N with one element missing, the missing number is to be found.
     * 
     * Solution 1:
     * We will use iterative divide and conquer algorithm.
     * We will look at element of array at begining, middle and end. We iteratively shrink the region to look from both sides
     * When the difference in value between high and low is greater than 1, we know we have not looked at all the region
     * When the difference in value between high and low is equal to 1, then there is no missing missing number
     * 
     * We first initilize high to number of elements in array, and low and mid to 0.
     * if high - low > 1, 
     
     */
    public class MissingNumberInArray
    {
        public static int FindMissingHash(int[] arr, int N)
        {
            HashSet<int> map = new HashSet<int>(arr);

            for (int i = 1; i <= N; i++)
            {
                if (!map.Contains(i))
                {
                    return i;
                }
            }

            return -1;

        }
        public static int FindMissing(int [] arr, int flag = 0)
        {

            int size = arr.Length;
            int low = 0;
            int mid = 0; 
            int high = size - 1;
            int diff = (arr[high] - arr[low]) / size; //this has to be 1 for successive elements
            if(flag == 0) //use iterative version 
            {
                //search until all the elements are looked.
                while (low <= high)
                {
                    mid = (low + high) / 2;

                    //check if the difference is to the right of the mid
                    if(mid+1 < size && arr[mid+1] - arr[mid] != diff)
                    {
                        return arr[mid + 1] - diff;
                    }

                    //check if the difference is to the left of the mid
                    if (mid - 1 >= 0 && arr[mid] - arr[mid-1] != diff)
                    {
                        return arr[mid - 1] + diff;
                    }
                    if ((arr[mid] - arr[0]) != (mid - 0) * diff)
                    {
                        high = mid - 1;
                    }
                    else 
                    {
                        low = mid;
                    }

                }
                return arr[mid + 1] - diff;  
            }

            return -1; //not imprlmented.
            
        }

        public static void RunMe()
        {
            //Input: arr[] = [1, 2, 3, 4, 6, 7, 8]
            //Output: 5

            //Input: arr[] = [1, 2, 3, 4, 5, 6, 8, 9]
            //Output: 7
            var arrs = "1 2 3 4 5 6 8 9";
            int size = 2;
            arrs = "1";
            var arr = Utilities.PraseToIntArray(arrs);

            
            //Console.WriteLine(FindMissing(arr));
            Console.WriteLine(FindMissingHash(arr,2));
        }
    }
}
