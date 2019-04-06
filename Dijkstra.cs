using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace algorithms
{
    public class Dijkstra
    {
        public class Vertex
        {
            public int Id { get; set; }
            public int? Pi { get; set; }
            public int D { get; set; }

            public Vertex(int id)
            {
                Id = id;
                Pi = null;
                D = Int32.MaxValue;
            }

        }
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

            public void AddEdge(int v, int w, int weight)
            {
                Adj[v].AddLast(w);
                EdgeWeight[v, w] = weight;
            }


        }

        public void RunDijkstra(Graph g, int s)
        {
            var S = new Dictionary<int, Vertex>();
            List<Vertex> Q = new List<Vertex>();

            g.Vertices[0].D = 0;

            foreach (var v in g.Vertices)
            {
                Q.Add(v);
            }

            while (Q.Count > 0)
            {
                Vertex u = Q.OrderBy(k => k.D).First();
                Q.Remove(u);

                if (!S.ContainsKey(u.Id))
                {
                    S.Remove(u.Id);
                }
                S.Add(u.Id, u);

                var al = g.Adj[u.Id];
                foreach (var a in al)
                {

                    var v = g.Vertices[a];
                    var ew = g.GetEdgeWeights()[u.Id, v.Id];
                    if (v.D > u.D + ew)
                    {
                        v.D = u.D + ew;
                        v.Pi = u.Id;
                    }
                }
            }
            Console.WriteLine(String.Join(' ', S.OrderBy(k => k.Value.Pi).Select(k => k.Value.Pi + "=>(" + k.Value.Id + ")").ToArray()));
            //Console.WriteLine(String.Join(' ', S.Select(k=> $"{k.Value.Id} => {k.Value.Pi} ({k.Value.D})").ToArray()));
        }

        public void Run()
        {
            Graph g = new Graph(5);
            g.AddEdge(0, 1, 10);
            g.AddEdge(0, 4, 5);

            g.AddEdge(1, 2, 1);
            g.AddEdge(1, 4, 2);

            g.AddEdge(2, 3, 6);

            g.AddEdge(3, 2, 4);
            g.AddEdge(3, 0, 7);


            g.AddEdge(4, 2, 9);
            g.AddEdge(4, 3, 2);
            g.AddEdge(4, 1, 3);

            Utilities.PrintArray(g.GetEdgeWeights());

            RunDijkstra(g, 0);


        }
    }
}
