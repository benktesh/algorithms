using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Algorithms
{
    public class PathWithSum
    {

        void PrintKPathUtil(Node root, List<int> path, int k)
        {
            if (root == null)
            {
                return;
            }

            path.Add(root.Data);

            PrintKPathUtil(root.Left, path, k);
            PrintKPathUtil(root.Right, path, k);

            int f = 0;
            for (int j = path.Count - 1; j >= 0; j--)
            {
                f = f + path[j];
                if (f == k)
                {
                    PrintPath(path, j);
                }
            }

            path.RemoveAt(path.Count - 1);
        }

        void PrintPath(List<int> path, int start)
        {
            for (int i = start; i < path.Count; i++)
            {
                Console.Write(path[i] + " ");
            }
            Console.WriteLine();
        }
        void PrintPath(Node root, int k)
        {
            List<int> path = new List<int>();
            PrintKPathUtil(root, path, k);
        }

        public void Run()
        {

            Node root = new Node(1);
            root.Left = new Node(3);
            root.Left.Left = new Node(2);
            root.Left.Right = new Node(1);
            root.Left.Right.Left = new Node(1);
            root.Right = new Node(-1);
            root.Right.Left = new Node(4);
            root.Right.Left.Left = new Node(1);
            root.Right.Left.Right = new Node(2);
            root.Right.Right = new Node(5);
            root.Right.Right.Right = new Node(2);

            int k = 5;
            PrintPath(root, k);
        }
    }
}
