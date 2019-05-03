using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using algorithms.BitManipulation;
using Algorithms;
using Algorithms.Graph;

namespace algorithms
{

    public class ResultSet : IEquatable<ResultSet>, IComparable<ResultSet>
    {
        public List<int> ResultList { get; set; }
        public bool Equals(ResultSet other)
        {
            var x = ResultList;
            var y = other.ResultList;

            if (x.Count != y.Count)
            {
                return false;
            }

            x = x.OrderBy(p => p).ToList();
            y = y.OrderBy(p => p).ToList();

            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }

            return true;
        }

        public int CompareTo(ResultSet other)
        {
            if (this.Equals(other))
            {
                return 0;
            }
            else return 1;
        }
    }
    public class ListComparer : IEqualityComparer<List<int>>
    {

        public bool Equals(List<int> x, List<int> y)
        {
            if (x.Count != y.Count)
            {
                return false;
            }

            x = x.OrderBy(p => p).ToList();
            y = y.OrderBy(p => p).ToList();

            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }

            return true;

        }

        public int GetHashCode(List<int> obj)
        {
            return obj.GetHashCode();
        }

    }
    class Program
    {
        static List<IList<int>> Permute(int[] arr)
        {
            var lst = new List<IList<int>>();
            GetPerm(arr, arr.Length, lst);
            return lst;
        }

        static void Swap(int i, int j, int[] arr)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;


        }

        static void GetPerm(int[] arr, int size, List<IList<int>> lst)
        {

            if (size == 1)
            {
                lst.Add(arr.Clone() as IList<int>);
            }

            for (int i = 0; i < size; i++)
            {
                GetPerm(arr, size - 1, lst);
                if (size % 2 == 1)
                {
                    Swap(0, size - 1, arr);
                }
                else
                {
                    Swap(i, size - 1, arr);
                }
            }
        }

        static void Main(string[] args)
        {

            #region done
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
            // new LongestValidSubstring().Run();
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
            //new WordBreak().Run();
            //new NonRepeatingElements().Run();
            //new ConnectNodeSameLevel().Run();
            // new AssignmentOfObjects().Run();
            //new KnapSackUnbounded().Run();
            //new MergeOverlappingInterval().Run();
            //new SubArraySum().Run();
            //new CountBSTNode().Run();
            //new BinaryTreeSumTree().Run();
            //new NumberExpressedAsPower().Run();
            //new AddTwoNumbers().Run();
            //new NumberExpressedAsPower().Run();
            //new DivideTwoIntegers().Run();
            //new MedianTwoSortedArrays().Run();
            //new RemoveDuplicates().Run();
            //new RemoveElements().Run();
            //new RemoveLinkedListElements().Run();
            //new LengthOfLongestSubstring().Run();
            //new RemoveLinkedListElements().Run();
            //new LengthOfLongestSubstring().Run();
            //new Subset().Run();
            // new SecondLargestBST().Run();
            //new MaxSubArraySum().Run();  

            //new MaxAreaContainerWithWater().Run();
            //new IntToRoman().Run();

            #endregion

            //new SumSet().Run();

            new Permutations().Run(); 



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
                var data = rawinput.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);


                //var rawinput = Console.ReadLine();
                // var data = rawinput.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                //     .Select(x => Int32.Parse(x)).ToArray();
                //Console.WriteLine(FindMissingHash(data, size));
                //call the process 
            }
        }
    }
}
