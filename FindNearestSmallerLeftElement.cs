using System;
using System.Collections.Generic;

namespace algorithms
{
    // Find the nearest smaller numbers on left side in an array
    //Given an array of integers, find the nearest smaller number for every element such that the smaller element is on left side.
    //Input:  arr[] = {1, 6, 4, 10, 2, 5}
    //Output:         {_, 1, 1,  4, 1, 2}
    public class FindNearestSmallerLeftElement
    {
        public void FindSmallerLeft(int[] arr)
        {
            Stack<int> S = new Stack<int>();
            List<String> result = new List<String>();
        
            for (int i = 0; i < arr.Length; i++)
            {
                if (S.Count == 0)
                {
                    result.Add("_");
                    
                }
                else
                {
                    while (S.Count > 0)
                    {
                        int top = S.Peek();
                        if (top >= arr[i])
                        {
                            S.Pop();
                        }
                        else
                        {
                            result.Add(top.ToString());
                            break;
                        }
                    }
                }
                S.Push(arr[i]);
            }
            Console.WriteLine(String.Join(' ', result));
        }
        public void Run()
        {
            int[] arr = new[] { 1, 6, 4, 10, 2, 5 };
            FindSmallerLeft(arr);

        }
    }
}