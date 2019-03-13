using System;
namespace algorithms
{

    public class IdentiticalTree
    {
        public static bool IdenticalTrees(Node a, Node b)
        {
            //if both empty
            if (a == null && b == null)
            {
                return true;
            }

            //if none empty, then compare
            if (a != null && b != null)
            {
                return (a.Data == b.Data
                    && IdenticalTrees(a.Left, b.Left)
                        && IdenticalTrees(a.Right, b.Right));
            }

            //if one is empty and other is not then return
            return false;
        }


        public static void RunMe()
        {
            BinaryTree tree = new BinaryTree();

            tree.root1 = new Node(1);
            tree.root1.Left = new Node(2);
            tree.root1.Right = new Node(3);
            tree.root1.Left.Left = new Node(4);
            tree.root1.Left.Right = new Node(5);

            tree.root2 = new Node(1);
            tree.root2.Left = new Node(2);
            tree.root2.Right = new Node(3);
            tree.root2.Left.Left = new Node(4);
            tree.root2.Left.Right = new Node(5);

            //must be identical
            Console.WriteLine("Are Identical: " + IdenticalTrees(tree.root1, tree.root2));

            Print(tree.root1);
           // Print(tree.root2);

            //Console.WriteLine("Are Identical: " + IdenticalTrees(tree.root1.Right, tree.root2));


        }


        public static void Print(Node a)
        {
           if(a == null)
            {
                return;
            }

            Console.Write(a.Data + " ");

            Print(a.Left);
            Print(a.Right);   
        }




    }
}
