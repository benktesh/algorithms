using System;

namespace algorithms
{
    class Program
    {
        static void Main(string[] args)
        { 
            var arr = new int[] {0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1 };
            SortArraysOfZerosOnes.Sort(arr);
            Utilities.PrintArray(arr);
        }
    }
}
