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

        public void CountTwice(string[] arr)
        {
            List<String> result = new List<string>();

            Dictionary<string, int> data = new Dictionary<string, int>();
            foreach (var elem in arr)
            {
                if (data.ContainsKey(elem))
                {
                    data[elem] = data[elem] + 1; 
                }
                else
                {
                    data.Add(elem, 1);
                }
            }

            foreach (var d in data)
            {
                if (d.Value == 2)
                {
                    Console.Write(d.Key + " ");
                }
            }
            Console.WriteLine();
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