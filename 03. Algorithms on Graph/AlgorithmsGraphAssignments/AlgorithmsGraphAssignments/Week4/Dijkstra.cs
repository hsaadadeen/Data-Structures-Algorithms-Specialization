using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSKicksCollection;

namespace AlgorithmsGraphAssignments.Week4
{
    class Dijkstra
    {
        private int Distance(List<int>[] adj, List<int>[] cost, int s, int t)
        {
            int[] dist = Enumerable.Repeat(int.MaxValue, adj.Length).ToArray();
            dist[s] = 0;

            PriorityQueue<Node> pq = new PriorityQueue<Node>();

            pq.Enqueue(new Node(s, dist[s]));
            while (pq.Count > 0)
            {
                Node u = pq.Dequeue();

                for (int i = 0; i < adj[u.Index].Count; i++)
                {
                    int v = adj[u.Index][i];
                    if (dist[v] > dist[u.Index] + cost[u.Index][i])
                    {
                        dist[v] = dist[u.Index] + cost[u.Index][i];
                        pq.Enqueue(new Node(v, dist[v]));
                    }
                }
            }

            if(dist[t] == int.MaxValue)
                return -1;

            return dist[t];
        }

        public void Start()
        {
            int n;
            int m;
            n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            m = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            List<int>[] adj = new List<int>[n];
            List<int>[] cost = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                adj[i] = new List<int>();
                cost[i] = new List<int>();
            }

            for (int i = 0; i < m; i++)
            {
                int x;
                int y;
                int w;
                x = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                y = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                w = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                adj[x - 1].Add(y - 1);
                cost[x - 1].Add(w);
            }
            int s;
            int e;
            s = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            e = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            Console.Write(Distance(adj, cost, s - 1, e - 1));
        }

    }
}

public class Node : IComparable
{
    public int Index;
    public int Distance;
    public Node(int index = 0, int distance = 0)
    {
        this.Index = index;
        this.Distance = distance;
    }

    public int CompareTo(object obj)
    {
        Node n = obj as Node;
        return this.Distance.CompareTo(n.Distance);
    }
}