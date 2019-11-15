using System;
using System.Collections.Generic;

namespace AlgorithmsGraphAssignments.Week1
{
    class Reachability
    {
        private int Reach(List<int>[] adj, int x, int y, bool[] visited)
        {
            visited[x] = true;

            for (int i = 0; i < adj[x].Count; i++)
            {
                if (visited[adj[x][i]]) continue;

                if (adj[x][i] == y)
                    return 1;

                if (Reach(adj, adj[x][i], y, visited) == 1)
                    return 1;
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
            bool[] visited = new bool[n];
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
            Console.Write(Reach(adj, s - 1, e - 1, visited));
        }
    }
}
