using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    /// <summary>
    //Given a valid sentence without any spaces between the words and a dictionary of valid English words, find all possible ways to break the sentence in individual dictionary words.
    //
    //Example
    //
    //Consider the following dictionary 
    //{ i, like, sam, sung, samsung, mobile, ice, 
    //cream, icecream, man, go, mango
    //}

    //Input: "ilikesamsungmobile"
    //Output: i like sam sung mobile
    //i like samsung mobile

    //Input: "ilikeicecreamandmango"
    //Output: i like ice cream and man go
    //i like ice cream and mango
    //i like icecream and man go
    //i like icecream and mango
    /// </summary>
    public class WordBreak
    {
        public bool DictionaryContainsWord(string[] dictionary, string word)
        {
            return dictionary.Contains(word); 
        }
        public void BreakWord(string[] dictionary, string str)
        {
            BreakWordUtil(dictionary, str, "");
        }

        //We start with the first character of the string.
        //if the first character as a prefix,
        // if the prfix is word, then we append that to result.
        // we generate next prefix by 
        //if that is not a word, we create substring adding additional character.
        public void BreakWordUtil(string[] dictionary, string str, string result)
        {
            int size = str.Length;
            for (int i = 1; i <= size; i++)
            {
                string preFix = str.Substring(0, i);
                if (dictionary.Contains(preFix))
                {
                    if (i == size)
                    {
                        result += preFix;
                        Console.WriteLine(result);
                        return;
                    }
                    BreakWordUtil(dictionary, str.Substring(i, size - i), result + preFix + " ");
                }
                
            }

        }
        public void Run()
        {
            var dictionary = new[]
            {
                "mobile", "samsung", "sam", "sung",
                "man", "mango", "icecream", "and",
                "go", "i", "love", "ice", "cream"
            };

            var str = "iloveicecreamandmango";
            BreakWord(dictionary,str);
            BreakWord(dictionary, "ilovesamsungmobile");
            

        }
    }
}
