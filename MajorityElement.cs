using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    public class MajorityElement
    {

        public void PrintMajority(int[] arr)
        {
            int i = findCandidate(arr);
            if(IsMajority(arr, i))
            {
                Console.WriteLine(arr[i]);
            }
            else
            {
               Console.WriteLine("not found");
            }
            

        }

        public bool IsMajority(int[] a, int mi)
        {
            var majority = a[mi];
            int count = 0;
            for(int i = 0; i < a.Length; i++)
            {
                if(majority == a[i])
                {
                    count++;
                }
            }

            return count >= a.Length / 2; 

        }

        public int findCandidate(int[] a)
        {
            int size = a.Length;
            int mi = 0;
            int count = 1;
            for(int i = 1; i < size; i++)
            {
                if(a[mi] == a[i])
                {
                    count++;
                }
                else
                {
                    count--;
                }
                if(count == 0)
                {
                    mi = i;
                    count = 1; 
                }
            }

            return mi;
        }
        public void RunMe()
        {
            int[] a = { 1, 3, 3, 3, 1, 2 };
            
            PrintMajority(a);
        }
    }
}
