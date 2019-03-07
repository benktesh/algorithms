using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms
{
    //Find all pairs of intergers within an array which sum to a specified value
    public class PairWithSum
    {
        public class Pair
        {
            public int first { get; set;  }
            public int second { get; set;  }

            public Pair(int f, int s)
            {
                first = f;
                second = s;
            }

          
        }

        public IList<Pair> GetPairCountAlternate(int[] arr, int sum)
        {
            var pairs = new List<Pair>();
            Array.Sort(arr);
            int first = 0;
            int last = arr.Length - 1;

            while(first < last)
            {
                int s = arr[first] + arr[last];
                if(s == sum)
                {
                    pairs.Add(new Pair(arr[first], arr[last]));
                    first++;
                    last--;
                }
                else if(s < sum)
                {
                    first++;
                }
                else
                {
                    last--;
                }
            }
            return pairs; 
        }
        public IList<Pair> GetPairCount(int[] arr, int sum)
        {
            var pairs = new List<Pair>();

            Dictionary<int, int> unpairedCount = new Dictionary<int, int>();

            foreach(var x in arr)
            {
                int completement = sum - x;
                if(unpairedCount.GetValueOrDefault(completement, 0) > 0)
                {
                    pairs.Add(new Pair(x, completement));
                    unpairedCount[completement] = unpairedCount[completement] - 1;
                }
                else
                {
                    if(unpairedCount.ContainsKey(x))
                    {
                        unpairedCount[x] = unpairedCount[x] + 1;
                    }
                    else
                    {
                        unpairedCount.Add(x, unpairedCount.GetValueOrDefault(x, 0) + 1);
                    }
                    
                     
                }
            }

            return pairs; 
        }

        public void RunMe()
        {
            int[] arr = new int[] { 1, 5, 7, -1, 5 };
            int sum = 6;

            var pairs = GetPairCount(arr, sum);

            foreach(var pair in pairs)
            {
                Console.WriteLine($"{pair.first},{pair.second}");
            }

            pairs = GetPairCountAlternate(arr, sum);

            foreach (var pair in pairs)
            {
                Console.WriteLine($"{pair.first},{pair.second}");
            }

        }
    }
}
