using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    //this class implements a function to validate if a tree is BST is not. 
    //In addition, tree traversal is demonstrated by an example. 
    public class ValidateBST
    {

        public class Node
        {
            public Node Left;
            public Node Right;
            public int Value;

            public Node(int value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return Value + " ";  
            }
        }

        public class Tree
        {
            public Node Root;

            private bool IsBST(Node root, int? minValue, int? maxValue)
            {
                if(root == null)
                {
                    return true;
                }

                if(root.Value >= maxValue || root.Value <= minValue)
                {
                    return false;
                }
                
                return IsBST(root.Left, minValue, root.Value ) && IsBST(root.Right, root.Value, maxValue);
            }

            public void PrintInOrder(Node node)
            {
                if(node != null)
                {
                    PrintInOrder(node.Left);
                    Console.Write(node.ToString());
                    PrintInOrder(node.Right);
                }
            }

            public void PrintPreOrder(Node node)
            {
                if(node != null)
                {
                    Console.Write(node.ToString());
                    PrintPreOrder(node.Left);
                    PrintPreOrder(node.Right);
                }
            }

            public void PrintPostOrder(Node node)
            {
                if (node != null)
                {
                    
                    PrintPostOrder(node.Left);
                    PrintPostOrder(node.Right);
                    Console.Write(node.ToString());
                }
            }

            public bool CheckBST()
            {
                return IsBST(Root, int.MinValue, int.MaxValue);
            }
            
        }

        

        public void Run()
        {
            Tree tree = new Tree();
            tree.Root = new Node(4);


            var x = tree.Root.ToString(); 

            tree.Root.Left = new Node(2);
            tree.Root.Right = new Node(5);
            tree.Root.Left.Left = new Node(1);
            tree.Root.Left.Right = new Node(3);

            Console.Write("In Order: \n");
            tree.PrintInOrder(tree.Root);

            Console.Write("Pre Order: \n");
            tree.PrintPreOrder(tree.Root);

            Console.Write("Post Oder: \n");
            tree.PrintPostOrder(tree.Root);

            Console.WriteLine(tree.CheckBST());
         


        }
    }
}
