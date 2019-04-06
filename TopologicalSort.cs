using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    public class TopologicalSort
    {
        public class Graph
        {
            private int V; //no of verticies
            private LinkedList<int>[] Adj;

            public Graph(int v)
            {
                V = v;
                Adj = new LinkedList<int>[v];
                for (int i = 0; i < v; i++)
                {
                    Adj[i] = new LinkedList<int>();
                }
            }

            public void AddEdge(int v, int w)
            {
                Adj[v].AddLast(w);
            }

            public void DFSUtil(int v, bool[] visited)
            {
                visited[v] = true;
                Console.Write($"{v} ");
                var i = Adj[v].GetEnumerator();

                while (i.MoveNext())
                {
                    int n = i.Current;
                    if (!visited[n])
                    {
                        DFSUtil(n, visited);
                    }
                }
            }

            public void DFS(int v)
            {
                var visited = new bool[V];

                DFSUtil(v, visited);
            }

            private void TopologicalSortUtil(int v, bool[] visited, Stack stack)
            {
                visited[v] = true;
                var i = Adj[v].GetEnumerator();
                while (i.MoveNext())
                {
                    var cur = i.Current;
                    if (!visited[cur])
                    {
                        TopologicalSortUtil(cur, visited, stack);
                    }
                }
                stack.Push(v);
            }

            public void ToplogicalSort()
            {
                var stack = new Stack();
                var visited = new bool[V];

                for (int i = 0; i < V; i++)
                {
                    if (!visited[i])
                    {
                        TopologicalSortUtil(i, visited, stack);
                    }
                }

                while (stack.Count > 0)
                {
                    Console.Write($"{stack.Pop()} ");
                }
            }

            public void BFS(int v)
            {
                var visited = new bool[V];

                Queue<int> queue = new Queue<int>();
                visited[v] = true;
                queue.Enqueue(v);

                while (queue.Count > 0)
                {
                    v = queue.Dequeue();
                    Console.Write($"{v} ");
                    var i = Adj[v].GetEnumerator();
                    while (i.MoveNext())
                    {
                        var t = i.Current;
                        if (!visited[t])
                        {
                            visited[t] = true;
                            queue.Enqueue(t);
                        }
                    }
                }
            }
        }

        public void Run()
        {
            Graph g = new Graph(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.WriteLine("Working on DFS: ");
            g.DFS(2);
            Console.WriteLine();
            
            g = new Graph(4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.WriteLine("Working on BFS: ");
            g.BFS(2);
            Console.WriteLine();

            Console.WriteLine("Working on Topoligical Sort: ");

            g = new Graph(6);
            g.AddEdge(5, 2);
            g.AddEdge(5, 0);
            g.AddEdge(4, 0);
            g.AddEdge(4, 1);
            g.AddEdge(2, 3);
            g.AddEdge(3, 1);

            Console.WriteLine("BFS");
            g.DFS(5);
            g.ToplogicalSort();
            Console.WriteLine();
        }
    }
}
