using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    /// <summary>
    /// Find the two non-repeating elements in an array of repeating elements.
    /// </summary>
    public class NonRepeatingElements
    {

        public int[] GetNonRepeating(int[] arr)
        {
            var map = new HashSet<int>();
            foreach (var x in arr)
            {
                if (map.Contains(x))
                {
                    map.Remove(x);
                }
                else
                {
                    map.Add(x);
                } 
            }
            return map.Select(p => p).ToArray();
        }
        public void Run()
        {
            int[] arr = { 2, 3, 7, 9, 11, 2, 3, 11 };
            //7 and 9 are non repeating
            var result = GetNonRepeating(arr);
            Console.WriteLine(string.Join(' ', result));
        }
    }
}
