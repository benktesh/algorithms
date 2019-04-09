using System;
using System.Collections.Generic;
using System.Linq;
using algorithms;

namespace Algorithms.Graph
{
    public class Graph
    {
        private int V; //number of verticies
        public LinkedList<int>[] Adj;
        private int[,] EdgeWeight;
        public Vertex[] Vertices;

        public int[,] GetEdgeWeights()
        {
            return EdgeWeight;
        }

        public Graph() { }
        public Graph(int v)
        {
            V = v;
            Adj = new LinkedList<int>[v];
            EdgeWeight = new int[v, v];
            Vertices = new Vertex[v];
            for (int i = 0; i < v; i++)
            {
                Vertices[i] = new Vertex(i);
                Adj[i] = new LinkedList<int>();
                for (int j = 0; j < v; j++)
                {
                    EdgeWeight[i, j] = Int32.MaxValue; //Int32.MinValue; //initilize with negative weight
                }
            }
        }

        public void AddEdge(int v, int w, int weight = 1)
        {
            Adj[v].AddLast(w);
            EdgeWeight[v, w] = weight;
        }


        public void DFS(Graph g)
        {
            foreach (var u in g.Vertices)
            {
                u.Color = Color.WHITE;
                u.Pi = null;
            }

            int time = 0;
            foreach (var u in g.Vertices)
            {
                if (u.Color == Color.WHITE)
                {
                    DFSVisit(g, u, ref time);
                }
                
            }

            Console.WriteLine(string.Join(' ', g.Vertices.OrderBy(k => k.F).Select(y => y.Id + "(" + y.D + "," + y.F + ")")));

        }

        public void DFSVisit(Graph g, Vertex u, ref int time)
        {
            time = time + 1;
            u.D = time;
            u.Color = Color.GREY;

            foreach (var vi in g.Adj[u.Id])
            {
                var v = g.Vertices[vi];
                if (v.Color == Color.WHITE)
                {
                    v.Pi = u.Id;
                    DFSVisit(g, v, ref time);
                }
            }

            u.Color = Color.BLACK;
            time = time + 1;
            u.F = time;

        }

        public void BFS(Graph g, Vertex s)
        {
            for(int i = 0; i < g.Vertices.Length; i++)
            {
                var cur = g.Vertices[i];
                cur.Color = Color.WHITE;
                cur.D = Int32.MaxValue;
                cur.Pi = null;
            }

            s.Color = Color.GREY;
            s.D = 0;
            s.Pi = null;

            Queue<Vertex> queue = new Queue<Vertex>();
            queue.Enqueue(s);
            while (queue.Count > 0)
            {
                var u = queue.Dequeue();
                var i = g.Adj[u.Id].GetEnumerator();
                while (i.MoveNext())
                {
                    var t = i.Current;
                    var v = g.Vertices[t];   
                    if (v.Color == Color.WHITE)
                    {
                        v.Color = Color.GREY;
                        v.D = u.D + 1;
                        v.Pi = u.Id;
                        queue.Enqueue(v);
                    }
                }
                u.Color = Color.BLACK;
            }
            Console.WriteLine(string.Join(' ', g.Vertices.OrderBy(k=>k.D).Select(y=>y.Id)));
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

            Console.WriteLine("Working on BFS: ");
            BFS(g, g.Vertices[1]);
            Console.WriteLine();

            Console.WriteLine("Working on DFS: ");
            DFS(g);
            Console.WriteLine();
        }

    }
}