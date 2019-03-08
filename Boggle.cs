using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    public class Boggle
    {
        private static int SIZE = 26;
        private static int M = 3;
        private static int N = 3;

        public class TrieNode
        {
            public TrieNode[] Child = new TrieNode[SIZE];
            public bool Leaf;

            public TrieNode()
            {
                Leaf = false;
                for (int i = 0; i < SIZE; i++)
                {
                    Child[i] = null; 
                }
            }
        }

        public static void Insert(TrieNode root, String key)
        {
            int n = key.Length;
            TrieNode pChild = root;
            for (int i = 0; i < n; i++)
            {
                int index = key[i] - 'A';

                if (pChild.Child[index] == null)
                {
                    pChild.Child[index] = new TrieNode();
                }

                pChild = pChild.Child[index];
            }

            pChild.Leaf = true;
        }
    }
}
