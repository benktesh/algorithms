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

            //Dictionary contains the previously found characters and latest index.
            Dictionary<char, int> map = new Dictionary<char, int>();

            //two tracking varaibles for start and end. 
            //fs is start of the longest substring
            //fe is the end of the longest substring.
            int fs = 0;
            int fe = fs + 1;


            //temporary start and end of the string (which may or may not be longest)
            int ts = 0;
            int te = 1;

            //At the beginning, we will assumed that the fs=ts=0 and fe=te=1 i.e. first letter is added
            //1 is going to be default lenght i.e. (fe-fs)
            map.Add(s[0], 0);
            for (int i = 1; i < s.Length; i++)
            {
                //get the current character
                var cur = s[i];

                //check if the map already contains the character
                if (map.ContainsKey(cur))
                {
                    //get the previous index of this chracter.
                    int ind = map[cur];

                    //handle some edge cases here.
                    //if the current character was at the beginning of the substing, we move the start by one.
                    if (ind == ts)
                    {
                        ts = ts + 1;
                    }
                    //else if ind is greater than ts, then we are in the middle
                    //then the ts would be one greater than the current index.
                    else if (ind > ts)
                    {
                        ts = ind + 1;
                    }

                    //if the ind is < ts, i.e. that is already been considered so it is not part of current substring.
                    //update the index of current character for future iterations.
                    map[cur] = i;
                }
                //if the chracter is not in map, we add it and replace the index to current index.
                else
                {
                    map.Add(cur, i);
                }
                //te is goign to be one plus the currnt i.
                te = i + 1;

                //update final start and end if the lenght is going to be greater.
                if ((te - ts) >= (fe - fs))
                {
                    fs = ts;
                    fe = te;
                }
            }
            //return the lenght of the string as difference between fe and fs
            return fe - fs;
        }

        public void Run()
        {
            //expect 3
            int result = 0;
            //result = LengthOfSubstring("abcabcbb");
            // result = LengthOfSubstring("dvdf");


            //result = LengthOfSubstring("abba");
            result = LengthOfSubstring("tmmzuxt");
            //result = LengthOfSubstring("pwwkew");
            //result = LengthOfSubstring("ohvhjdml");
            Console.WriteLine($"Expected 2. Obtained {result} + pass? = {result == 2}");
        }
    }
}
