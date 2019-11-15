using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsGraphAssignments.Week3
{
    class Bfs
    {
        private int Distance(List<int>[] adj, int s, int t)
        {
            if (s == t)
                return 0;

            int[] dist = Enumerable.Repeat(-1, adj.Length).ToArray();
            //int[] prev = Enumerable.Repeat(-1, adj.Length).ToArray();
            dist[s] = 0;

            Queue<int> q = new Queue<int>();
            q.Enqueue(s);

            while (q.Count > 0)
            {
                int u = q.Dequeue();
                for (int i = 0; i < adj[u].Count; i++)
                {
                    int v = adj[u][i];
                    if (dist[v] == -1)
                    {
                        q.Enqueue(v);
                        dist[v] = dist[u] + 1;
                        //prev[v] = u;
                    }
                }
            }

            return dist[t];
        }

        public void Start()
        {
            int n;
            int m;
            n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            m = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            List<int>[] adj = new List<int>[n];
            for (int i = 0; i < n; i++)
                adj[i] = new List<int>();

            for (int i = 0; i < m; i++)
            {
                int x;
                int y;
                x = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                y = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                adj[x - 1].Add(y - 1);
                adj[y - 1].Add(x - 1);
            }
            int s;
            int e;
            s = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            e = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            Console.Write(Distance(adj, s - 1, e - 1));
        }
    }
}
