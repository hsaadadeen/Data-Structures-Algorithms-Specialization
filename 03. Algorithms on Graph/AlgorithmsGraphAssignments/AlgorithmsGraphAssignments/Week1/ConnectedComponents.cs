using System;
using System.Collections.Generic;

namespace AlgorithmsGraphAssignments.Week1
{
    class ConnectedComponents
    {
        private int NumberComponents(List<int>[] adj)
        {
            int res = 0;
            bool[] visited = new bool[adj.Length];

            for (int i = 0; i < adj.Length; i++)
            {
                if (!visited[i])
                {
                    Explore(i, adj, visited);
                    res++;
                }
            }

            return res;
        }

        private void Explore(int v, List<int>[] adj, bool[] visited)
        {
            visited[v] = true;

            for (int i = 0; i < adj[v].Count; i++)
            {
                if (!visited[adj[v][i]]) 
                    Explore(adj[v][i], adj, visited);
            }
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
            Console.Write(NumberComponents(adj));
        }
    }
    
}