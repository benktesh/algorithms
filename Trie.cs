using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    public class Trie
    {
        private static readonly int SIZE = 26;

        public class TrieNode
        {
            public TrieNode[] children = new TrieNode[SIZE];

            public bool isEndOfWord;

            public TrieNode()
            {
                isEndOfWord = false;
                for (int i = 0; i < SIZE; i++)
                {
                    children[i] = null;
                }
            }
        };

        private static TrieNode root;

        static void insert(String key)
        {
            int level;
            int length = key.Length;
            int index;

            TrieNode pCrawl = root;
            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                if (pCrawl.children[index] == null)
                {
                    pCrawl.children[index] = new TrieNode();
                }
                
            }

        }

        static bool search(String key)
        {
            int level;
            int length = key.Length;
            int index;

            TrieNode pCrawl = root;
            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                if (pCrawl.children[index] == null)
                    return false;

                pCrawl = pCrawl.children[index];
            }

            return (pCrawl != null && pCrawl.isEndOfWord);
        }

        public static void RunMe()
        {
            // Input keys (use only 'a'  
            // through 'z' and lower case) 
            String[] keys = {"the", "a", "there", "answer",
                "any", "by", "bye", "their"};

            String[] output = { "Not present in trie", "Present in trie" };


            root = new TrieNode();

            // Construct trie 
            int i;
            for (i = 0; i < keys.Length; i++)
            {
                insert(keys[i]);
            }
                

            // Search for different keys 
            if (search("the") == true)
                Console.WriteLine("the --- " + output[1]);
            else Console.WriteLine("the --- " + output[0]);

            if (search("these") == true)
                Console.WriteLine("these --- " + output[1]);
            else Console.WriteLine("these --- " + output[0]);

            if (search("their") == true)
                Console.WriteLine("their --- " + output[1]);
            else Console.WriteLine("their --- " + output[0]);

            if (search("thaw") == true)
                Console.WriteLine("thaw --- " + output[1]);
            else Console.WriteLine("thaw --- " + output[0]);

        }

    }
}
