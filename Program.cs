using System;

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
            MissingNumberInArray.RunMe(); 
            //ReverseWords.RunMe();
            //StringPermutations.RunMe();
            //LongestPalindrome.RunMe();
            //RemoveDuplciatesRecursively.RunMe();
            //ReverseLinkedList.RunMe();
            //IdentiticalTree.RunMe();
            KLeafBinaryTree.RunMe();


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
    }
}
