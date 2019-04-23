using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public class Subset
    {
        public IList<IList<int>> Subsets(int[] nums)
        {

            if (nums.Length == 0)
            {
                return new List<IList<int>> { };
            }
            var temp = new List<List<IList<int>>>(nums.Length);

            for (int i = 0; i < nums.Length; i++)
            {
                temp.Add(new List<IList<int>> { });
                temp[i].Add(new List<int> { });
                temp[i][0].Add(nums[i]);
            }
            for (int i = 1; i < temp.Count; i++)
            {
                var prev = temp[i - 1];
                var cur = temp[i];
                var ttemp = new List<IList<int>>();

                //ttemp.AddRange(cur);
                ttemp.AddRange(prev);
                foreach (var c in cur)
                {
                    foreach (var p in prev)
                    {
                        var tr = new List<int>();
                        tr.AddRange(p);
                        tr.AddRange(c);
                        ttemp.Add(tr);
                    }
                }
                temp[i].AddRange(ttemp);
            }
            temp[nums.Length - 1].Add(new List<int> { });

            return temp[nums.Length - 1];


        }

        public void Run()
        {
            var arr = new int[] {1, 1, 2};
            var result = Subsets(arr);
            foreach (var rr in result)
            {
                Console.WriteLine($"[{string.Join(',', rr)}]");
                

            }
        }
    }
}
