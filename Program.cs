﻿using System;
using System.Linq;

namespace algorithms
{
    class Program
    {

        static void Main(string[] args)
        {
            /* To test these algorithms, uncomment */
            //SortArraysOfZerosOnes.RunMe();
            //KeyPair.RunMe(); 
            BinaryMultiple.RunMe();
            //MissingNumberInArray.RunMe();
            //ReverseWords.RunMe();
            //StringPermutations.RunMe();
            //LongestPalindrome.RunMe();
            //RemoveDuplciatesRecursively.RunMe();
            //ReverseLinkedList.RunMe();
            //IdentiticalTree.RunMe();
            //KLeafBinaryTree.RunMe();
           //new SumSet().Run();
            //MultiplicationRecursive.RunMe();
            //GraphBuidOrder.main(null);

            //new FactorialZeros().RunMe();

            // new NumberMax().RunMe();
            //new PondSize().RunMe(); 
            //Trie.RunMe();
            //MissingNumberInArray.RunMe();
            //new SubArraySum().Run();
            //new EquilibriumPoint().Run();
            //new SumLinkedList().Run();
           // new CheckBST().Run();
           new SumSet().Run();
            //new PairWithSum().RunMe();
            //new LRUCache().RunMe();
            //new AddWithoutPlus().RunMe();
            //new MajorityElement().RunMe(); 
            //new ValidateBST().Run(); 
            //new FindNextInBST().Run(); 
            new CommonAncestor().Run(); 
        }

        /* This is template for making test cases **/
        static void Template()
        {
            var first = Console.ReadLine();
            int tests = 0;
            bool success = Int32.TryParse(first, out tests);

            if (!success)
            {
                return;
            }

            for (int i = 0; i < tests; i++)
            {
                var words = Console.ReadLine();
               //call the process 
            }


        }

        static void AnotherTemplate()
        {
            var first = Console.ReadLine();
            int tests = 0;
            bool success = Int32.TryParse(first, out tests);

            if (!success)
            {
                return;
            }

            for (int i = 0; i < tests; i++)
            {
                int size = 0;
                success = Int32.TryParse(Console.ReadLine(), out size);
                if (!success)
                {
                    continue;
                }
                var rawinput = Console.ReadLine();
                var data = rawinput.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => Int32.Parse(x)).ToArray();
                //Console.WriteLine(FindMissingHash(data, size));
                //call the process 
            }
        }
    }
}
