using System;
namespace Algorithms
{
    public class KLeafBinaryTree
    {
        public KLeafBinaryTree()
        {

        }

        public static void KDistanceFromLeaf(Node node, int[] path,
        bool[] visited, int pathLen, int k)
        {
            if (node == null)
            {
                return;
            }

            path[pathLen] = node.Data;
            visited[pathLen] = false;
            pathLen++;

            if (node.Left == null && node.Right == null
             && pathLen - k - 1 >= 0 && visited[pathLen - k - 1] == false)
            {
                Console.Write(path[pathLen - k - 1] + " ");
                visited[pathLen - k - 1] = true;
            }

            KDistanceFromLeaf(node.Left, path, visited, pathLen, k);
            KDistanceFromLeaf(node.Right, path, visited, pathLen, k);


        }


        public static void RunMe()
        {
            BinaryTree tree = new BinaryTree();

            tree.root = new Node(1);
            tree.root.Left = new Node(2);
            tree.root.Right = new Node(3);
            tree.root.Left.Left = new Node(4);
            tree.root.Left.Right = new Node(5);
            tree.root.Right.Left = new Node(6);
            tree.root.Right.Right = new Node(7);
            tree.root.Right.Left.Right = new Node(8);

            int[] path = new int[1000];
            bool[] visited = new bool[1000];
            int k = 1;
            KDistanceFromLeaf(tree.root, path, visited, 0, k);

        }
    }
}
