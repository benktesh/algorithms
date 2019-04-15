using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class LengthOfLongestSubstring
    {
        public int LengthOfSubstring(string s)
        {
            if (s.Length == 0)
            {
                return 0;
            }

            Dictionary<char, int> map = new Dictionary<char, int>();
            int len = 1;
            int start = 0;
            map.Add(s[0], 0);
            for (int i = 1; i < s.Length; i++)
            {
                var cur = s[i];

                if (map.ContainsKey(cur))
                {
                    map[cur] = i;
                    start++;
                }
                else
                {
                    map.Add(cur, i);
                    len++;
                }
            }
            return len;
        }

        public void Run()
        {
            //expect 3
            int result = LengthOfSubstring("\"abcabcbb\"");
            Console.WriteLine($"Expected 3. Obtained {result} + pass? = {result==3}");
        }
    }
}
