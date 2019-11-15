using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSKicksCollection;

namespace AlgorithmsGraphAssignments.Week5
{
    
    class ConnectingPoints
    {
        class Node
        {
            public int X;
            public int Y;
            public int Parent;
            public int Rank;

            public Node(int a, int b, int c)
            {
                X = a;
                Y = b;
                Parent = c;
                Rank = 0;
            }
        }

        class Edge : IComparable
        {
            public int U;
            public int V;
            public double Weight;

            public Edge(int a, int b, double c)
            {
                U = a;
                V = b;
                Weight = c;
            }

            public int CompareTo(object obj)
            {
                Edge e = (Edge)obj;
                return this.Weight < e.Weight ? -1 : 1;
            }
        }

        void MakeSet(int i, Node[] nodes, int[] x, int[] y)
        {
            nodes[i] = new Node(x[i], y[i], i);
        }

        int Find(int i, Node[] nodes)
        {
            if (i != nodes[i].Parent)
            {
                nodes[i].Parent = Find(nodes[i].Parent, nodes);
            }
            return nodes[i].Parent;
        }

        void Union(int u, int v, Node[] nodes)
        {
            int r1 = Find(u, nodes);
            int r2 = Find(v, nodes);
            if (r1 != r2)
            {
                if (nodes[r1].Rank > nodes[r2].Rank)
                {
                    nodes[r2].Parent = r1;
                }
                else
                {
                    nodes[r1].Parent = r2;
                    if (nodes[r1].Rank == nodes[r2].Rank)
                    {
                        nodes[r2].Rank++;
                    }
                }
            }
        }

        double Weight(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        private double GetMinimumDistance(int[] x, int[] y)
        {
            double result = 0;

            int n = x.Length;
            Node[] nodes = new Node[n];
            for (int i = 0; i < n; i++)
                MakeSet(i, nodes, x, y);

            PriorityQueue<Edge> edges = new PriorityQueue<Edge>();

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    edges.Enqueue(new Edge(i, j, Weight(x[i], y[i], x[j], y[j])));

            while (edges.Count > 0)
            {
                Edge currentEdge = edges.Dequeue();
                int u = currentEdge.U;
                int v = currentEdge.V;

                if (Find(u, nodes) != Find(v, nodes))
                {
                    result += currentEdge.Weight;
                    Union(u, v, nodes);
                }
            }

            return result;
        }

        public void Start()
        {
            int n;
            n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            int[] x = new int[n];
            int[] y = new int[n];

            for (int i = 0; i < n; i++)
            {
                x[i] = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                y[i] = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            }
            Console.Write(Math.Round(GetMinimumDistance(x, y), 9));
        }

    }
}

