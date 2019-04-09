using System;
using algorithms;

namespace Algorithms.Graph
{
    public class Vertex
    {
        public int Id { get; set; }
        public int? Pi { get; set; }
        public int D { get; set; }
        public Color Color { get; set; }
        public int F { get; set;  } // finish time

        public Vertex(int id)
        {
            Id = id;
            Pi = null;
            D = Int32.MaxValue;
            Color = Color.WHITE;
            F = 0; 
        }

    }
}