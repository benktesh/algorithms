using System;
using System.Collections.Generic;

namespace algorithms
{
    /// <summary>
    /// Given an array of n words. Some words are repeated twice, we need count such words.
    /// Examples:
    /// 
    /// Input : s[] = {"hate", "love", "peace", "love", 
    /// "peace", "hate", "love", "peace", 
    /// "love", "peace"};
    /// Output : 1
    /// There is only one word "hate" that appears twice
    /// 
    /// Input : s[] = {"Om", "Om", "Shankar", "Tripathi", 
    /// "Tom", "Jerry", "Jerry"};
    /// Output : 2
    /// There are two words "Om" and "Jerry" that appear
    /// twice.
    /// </summary>
    public class CountWords
    {

        public List<String> CountTwice(string[] arr)
        {

            var result = new List<String>();
            var map = new Dictionary<String, int>();
            foreach (var a in arr)
            {
                if (map.ContainsKey(a))
                {
                    map[a] = map[a] + 1;
                }
                else
                {
                    map[a] = 1; 
                }
                
            }

            foreach (var d in map)
            {
                if (d.Value == 2)
                {
                    result.Add(d.Key);
                }
            }

            Console.WriteLine(string.Join(' ', result.ToArray()));
            return result;
        }
        public void Run()
        {
            var s = new[] {"hate", "love", "peace", "love", 
                "peace", "hate", "love", "peace", 
                "love", "peace"};

            CountTwice(s);

            CountTwice(new [] {
                "Om", "Om", "Shankar", "Tripathi", 
                "Tom", "Jerry", "Jerry"});

        }
    }
}