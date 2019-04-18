using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Algorithms
{
    public class SecondLargestBST
    {
        public int FindSecondLargest(Node root)
        {
            int secondLargst = 0;
            while (root != null)
            {
                if (root.Left != null && root.Right != null)
                {
                    secondLargst = root.Data;
                    root = root.Right;
                    continue;
                }

                if (root.Left != null && root.Right == null)
                {
                    secondLargst = root.Left.Data;
                    root = root.Left;
                    continue;
                }

                secondLargst = root.Data;
                
                root = root.Right;

            }

            return secondLargst;



        }
        public void Run()
        {

            var root = new Node(50);
            root.Left = new Node(30);
            root.Left.Left = new Node(20);
            root.Left.Right = new Node(40);

            var result = FindSecondLargest(root);
            Console.WriteLine("Second Largest = " + result);

        }
    }
}
