using System;
using System.Linq;

namespace algorithms
{
    /// <summary>
    /// Given number of pages in n different books and m students. The books are arranged in ascending order of number of pages. Every student is assigned to read some consecutive books. The task is to assign books in such a way that the maximum number of pages assigned to a student is minimum.
    /// 
    /// Example :
    /// 
    /// Input : pages[] = {12, 34, 67, 90}
    /// m = 2
    /// Output : 113
    /// </summary>
    public class AllocateNumberOfPages
    {
        public bool IsPossible(int[] arr, int m, int currMin)
        {
            Console.WriteLine("IS Possible: " + currMin);
            int n = arr.Length;
            int studentsRequired = 1;
            int currSum = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > currMin)
                {
                    return false; 
                }

                if (currSum + arr[i] > currMin)
                {
                    studentsRequired++;

                    currSum = arr[i];

                    if (studentsRequired > m)
                    {
                        return false;
                    }
                }
                else
                {
                    currSum = currSum + arr[i];
                }
            }
            return true;
        }
        public int Assign(int[] arr, int m)
        {
            int n = arr.Length;
            int sum = arr.Sum(k => k); //sum the total number of pages

            //if number of books is smaller then number of assignee, it is an error
            if (n < m)
            {
                return -1;
            }

            //start with 0 and end with total page
            int start = 0;
            int end = sum;

            int result = int.MaxValue;

            //iterate until start <= end
            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (IsPossible(arr,m, mid))
                {
                    result = Math.Min(result, mid);
                    end = mid - 1; 
                }
                else
                {
                    start = mid + 1; 
                }
            }
            return result;

        }
        public void Run()
        {
            var pages = new[] {12, 34, 67, 90};
            int m = 2; 
            Console.WriteLine(Assign(pages, m));
        }
    }
}