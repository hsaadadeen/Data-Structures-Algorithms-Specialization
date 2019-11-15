using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsGraphAssignments.Week3
{
    class Bipartite
    {
        private int bipartite(List<int>[] adj)
        {
            int[] color = Enumerable.Repeat(-1, adj.Length).ToArray();
            color[0] = 1;

            Queue<int> q = new Queue<int>();
            q.Enqueue(0);

            while (q.Count > 0)
            {
                int u = q.Dequeue();

                for (int i = 0; i < adj[u].Count; i++)
                {
                    int v = adj[u][i];
                    if (color[v] == color[u])
                        return 0;

                    if (color[v] == -1)
                    {
                        color[v] = 1 - color[u];
                        q.Enqueue(v);
                    }
                }
            }

            return 1;
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
            Console.Write(bipartite(adj));
        }
    }
}
