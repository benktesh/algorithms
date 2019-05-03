using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    /*
     * Given a collection of distinct integers, return all possible permutations.
       Example:
       Input: [1,2,3]
       Output:
       [
       [1,2,3],
       [1,3,2],
       [2,1,3],
       [2,3,1],
       [3,1,2],
       [3,2,1]
       ]
     */
    
    public class Permutations
    {
        public IList<IList<object>> Permute(object[] objects)
        {
            
            var result = new List<IList<object>> { };
            GetPerm(objects, objects.Length, result);
            return result;

        }


        private void GetPerm(object[] arr, int size, List<IList<object>> lst)
        {
            if (size == 1)
            {
                lst.Add(arr.Clone() as IList<object>);
            }

            for (int i = 0; i < size; i++)
            {
                GetPerm(arr, size - 1, lst);
                if (size % 2 == 1)
                {
                    Swap(0, size - 1, arr);
                }
                else
                {
                    Swap(i, size - 1, arr);
                }
            }


        }


        private void Swap(int i, int j, object[] arr)
        {
            object temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>> { };
            GetPerm(nums, nums.Length, result);
            return result;
        }

        private void Swap(int i, int j, int[] arr)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        //using heap's algorithm
        //https://en.wikipedia.org/wiki/Heap%27s_algorithm#cite_note-3
        private void GetPerm(int[] arr, int size, List<IList<int>> lst)
        {
            if (size == 1)
            {
                lst.Add(arr.Clone() as IList<int>);
            }

            for (int i = 0; i < size; i++)
            {
                GetPerm(arr, size - 1, lst);
                if (size % 2 == 1)
                {
                    Swap(0, size - 1, arr);
                }
                else
                {
                    Swap(i, size - 1, arr);
                }
            }
        }

        public void Run()
        {
            int[] arr = { 1, 2, 3 };
            var x = Permute(arr);

            foreach (var e in x)
            {
                Console.WriteLine(string.Join(" ", e));
            }
        }
    }
}
