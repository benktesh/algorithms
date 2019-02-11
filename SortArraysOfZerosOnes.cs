/*
 * Given an array A[] consisting 0s, 1s and 2s, write a function that sorts A[]. The functions should put all 0s first, then all 1s and all 2s in last.
 * The algorithm is also known as Dutch National Flag Algorithm or 3-way Partitioning
 * We split the array into four regions:
 *  Start to low
 *  low to mid,
 *  mid to high
 *  high to end
 * We consider region mid to high as unknown and incrementally shrink this region while maintaining the other three regions
 * We first initialize low, and mid to 0th index of an array and hi to end of the array.
 * We continue to look into region as long as index of mid <= high condition remains true and do the following:
 * Assuming a is array of numbers.
 * if a[mid] == 0:
 *      swap a[low] and a[mid]
 *      low = low + 1
 *      mid = mid + 1
 * else if a[mid] == 1:
 *      mid = mid+1;
 * else if a[mid] == 2:
 *      swap a[mid] and a[high]
 *      high = high -1 *
 */
using System; 
namespace algorithms
{
    public class SortArraysOfZerosOnes
    {
        public static void Sort(int [] arr) 
        {
          int size = arr.Length; 
          int low = 0;
          int high = size-1;
          int mid = 0;
          while(mid <= high)
          {
              int temp;
              switch (arr[mid]){
                  case 0:
                    temp = arr[low];
                    arr[low] = arr[mid];
                    arr[mid] = temp;
                    low++;
                    mid++;
                    break;

                  case 1:
                    mid++;
                    break;

                  case 2:
                    temp = arr[mid];
                    arr[mid] = arr[high];
                    arr[high] = temp;
                    high--;
                    break;
              }
          }
          Console.WriteLine(size);
        }
    }
}
