using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsGraphAssignments.Week4
{
    class ShortestPaths
    {
        private void FindShortesPath(List<int>[] adj, List<int>[] cost, int s, long[] distance, int[] reachable, int[] shortest)
        {
            distance[s] = 0;
            reachable[s] = 1;

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < adj.Length; i++)
            {
                for (int u = 0; u < adj.Length; u++)
                {
                    for (int j = 0; j < adj[u].Count; j++)
                    {
                        int v = adj[u][j];
                        if (distance[u] != long.MaxValue && distance[v] > distance[u] + cost[u][j])
                        {
                            distance[v] = distance[u] + cost[u][j];
                            reachable[v] = 1;
                            if(i == adj.Length - 1)
                                queue.Enqueue(v);
                        }
                    }
                }
            }

            int[] visited = new int[adj.Length];
            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                visited[u] = 1;
                if (u != s)
                    shortest[u] = 0;
                foreach (var v in adj[u])
                {
                    if (visited[v] == 0)
                    {
                        queue.Enqueue(v);
                        visited[v] = 1;
                        shortest[v] = 0;
                    }
                }
            }
        }

        public void Start()
        {
            int n;
            int m;
            int s;
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
            s = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            s--;
            long[] distance = new long[n];
            int[] reachable = new int[n];
            int[] shortest = new int[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = Int64.MaxValue;
                reachable[i] = 0;
                shortest[i] = 1;
            }

            FindShortesPath(adj, cost, s, distance, reachable, shortest);
            for (int i = 0; i < n; i++)
            {
                if (reachable[i] == 0)
                {
                    Console.WriteLine('*');
                }
                else if (shortest[i] == 0)
                {
                    Console.WriteLine('-');
                }
                else
                {
                    Console.WriteLine(distance[i]);
                }
            }

        }

    }
}

