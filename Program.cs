using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using algorithms.BitManipulation;

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
            new FindNearestSmallerLeftElement().Run();
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

    public class FindNearestSmallerLeftElement
    {
        // Find the nearest smaller numbers on left side in an array
        //Given an array of integers, find the nearest smaller number for every element such that the smaller element is on left side.
        //Input:  arr[] = {1, 6, 4, 10, 2, 5}
        //Output:         {_, 1, 1,  4, 1, 2}
        public void FindSmallerLeft(int[] arr)
        {
            Stack<int> S = new Stack<int>();
            List<String> result = new List<String>();
        
            for (int i = 0; i < arr.Length; i++)
            {
                if (S.Count == 0)
                {
                    result.Add("_");
                    
                }
                else
                {
                    while (S.Count > 0)
                    {
                        int top = S.Peek();
                        if (top >= arr[i])
                        {
                            S.Pop();
                        }
                        else
                        {
                            result.Add(top.ToString());
                            break;
                        }
                    }
                }
                S.Push(arr[i]);
            }
            Console.WriteLine(String.Join(' ', result));
        }
        public void Run()
        {
            int[] arr = new[] { 1, 6, 4, 10, 2, 5 };
            FindSmallerLeft(arr);

        }
    }
}
