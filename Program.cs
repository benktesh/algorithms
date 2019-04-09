using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using algorithms.BitManipulation;
using Algorithms;
using Algorithms.Graph;

namespace algorithms
{
    class Program
    {

        static void Main(string[] args)
        {
            /* To test these algorithms, uncomment */
            //SortArraysOfZerosOnes.RunMe();
            //KeyPair.RunMe(); 
            //BinaryMultiple.RunMe();
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
            //new SumSet().Run();
            //new PairWithSum().RunMe();
            //new LRUCache().RunMe();
            //new AddWithoutPlus().RunMe();
            //new MajorityElement().RunMe(); 
            //new ValidateBST().Run(); 
            //new FindNextInBST().Run(); 
            //new CommonAncestor().Run(); 
            // new BstSequence().Run();
            //new PathWithSum().Run();
            //new Insertion().Run();
            //new BinaryToString().Run(); 
            //new FlipBit().Run(); 
            //new DeckOfCards().Run();
            //new CircularArrayEnumerable().Run();




            // new NextNumber().Run();
            //new MaxTreeHeight().Run();
            //new PrintNodeKDistance().Run();
            //new DifferencSumOddEvenLevel().Run();
            //new StringRotation().Run();
            //new FindNearestSmallerLeftElement().Run();
            //new MaxIndexDiff().Run();
            //new TopologicalSort().Run();
            //new BooleanMatrixQuestion().Run();
            //new CountWords().Run();
            //new ArrangeElements().Run();
            //new StringTransformation().Run();
            // new TopologicalSort().Run();
            // new LRU().Run();
            //new LongestValidSubstring().Run();
            //new AllocateNumberOfPages().Run();
            //new SumToValue().Run();
            //new RodCutting().Run();
            //new LongestCommonSubsequence().Run();
            //new GCD().Run();
            //new ActiveInActiveCell().Run();
            //new Dijkstra().Run();

            //var x = MaxHeap();
            //new MedianStreaming().Run();
            //new Algorithms.Graph.Graph().Run();
            new AssignmentOfObjects().Run();




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
