using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsGraphAssignments.Week4
{
    class NegativeCycle
    {
        private int IsNegativeCycle(List<int>[] adj, List<int>[] cost)
        {
            int[] dist = Enumerable.Repeat(int.MaxValue, adj.Length).ToArray();
            dist[0] = 0;

            for (int i = 0; i < adj.Length; i++)
            {
                for (int u = 0; u < adj.Length; u++)
                {
                    for (int k = 0; k < adj[u].Count; k++)
                    {
                        int v = adj[u][k];
                        if (dist[v] > (long)dist[u] + cost[u][k])
                        {
                            dist[v] = dist[u] + cost[u][k];
                            if (i == adj.Length - 1)
                            {
                                return 1;
                            }
                        }
                    }
                }
            }
            return 0;

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
            Console.Write(IsNegativeCycle(adj, cost));
        }
    }
}
