using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    //This class implments a function to find the next node in the BST
    //There are two variations of the implementation, one uses recursion using InOrder Traversal and another looking at the tree.
    public class FindNextInBST
    {
        public class Node
        {
            public Node Left;
            public Node Right;
            public Node Parent;
            public int Data;

            public Node(int value)
            {
                Data = value;
            }

            public override string ToString()
            {
                return Data + " ";
            }
        }

        public class BinaryTree
        {
            public Node Root;

            public void PrintInOrder(Node node)
            {
                if (node != null)
                {
                    PrintInOrder(node.Left);
                    Console.Write(node.ToString());
                    PrintInOrder(node.Right);
                }
            }


            public void FindSuccessor(Node node)
            {
                Console.Write(node.ToString());
            }

            bool Cancel = false;
            int RecurrCount = 0; 
            public Node FindSuccessor(Node root, Node node)
            {
                if (Cancel)
                {
                    return null;
                }
                if(node != null && root != null )
                {
                    if(node == root.Left || node == root.Right)
                    {
                        Cancel = true;
                        FindSuccessor(root);
                    }
                    if (!Cancel)
                    {
                        FindSuccessor(root.Left, node);
                        FindSuccessor(root.Right, node);
                    }
                    
                }
                return null; 
            }

            private Node LeftMostChild(Node node)
            {
                if(node == null)
                {
                    return null;
                }
                while(node.Left != null)
                {
                    node = node.Left;
                }

                return node; 

            }
          
            public Node FindNextBST(Node node)
            {
                if(node == null)
                {
                    return null; 
                }

                if(node.Right != null)
                {
                    return LeftMostChild(node.Right);
                }
                else
                {
                    var cur = node;
                    var next = node.Parent; 
                    while(next != null && next.Left != cur)
                    {
                        cur = next;
                        next = next.Parent; 
                    }
                    return next;
                }
            }

           
        }

        public void Run()
        {
            BinaryTree tree = new BinaryTree();
            tree.Root = new Node(4);

            tree.Root.Left = new Node(2);
            tree.Root.Left.Parent = tree.Root;

            tree.Root.Right = new Node(5);
            tree.Root.Right.Parent = tree.Root;



            tree.Root.Left.Left = new Node(1);
            tree.Root.Left.Left.Parent = tree.Root.Left;
            tree.Root.Left.Right = new Node(3);
            tree.Root.Left.Right.Parent = tree.Root.Left;

            var testNode = tree.Root.Left.Left;

            var parent = tree.FindNextBST(testNode);
            if(parent != null)
            {
                Console.WriteLine(parent.ToString());
            }
            else
            {
                
                Console.WriteLine("Not Found");
                
            }

           var x =  tree.FindSuccessor(tree.Root, testNode);
        }

    }
}
