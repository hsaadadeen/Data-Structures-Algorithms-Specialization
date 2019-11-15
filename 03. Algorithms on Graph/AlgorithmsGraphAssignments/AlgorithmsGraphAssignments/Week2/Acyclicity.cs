using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsGraphAssignments.Week2
{
    class Acyclicity
    {
        private int Acyclic(List<int>[] adj)
        {
            // Mark all the verticies as not visited and not part of the recursion stack
            bool[] visited = new bool[adj.Length];
            bool[] recStack = new bool[adj.Length];

            for (int i = 0; i < adj.Length; i++)
                if(!visited[i])
                    if (Dfs(adj, i, visited, recStack))
                        return 1;

            return 0;
        }

        private bool Dfs(List<int>[] adj, int x, bool[] visited, bool[] recStack)
        {
            visited[x] = true;
            recStack[x] = true;

            // recur for all the vertices adjacent to this vertex
            for (int i = 0; i < adj[x].Count; i++)
            {
                if (!visited[adj[x][i]] && Dfs(adj, adj[x][i], visited, recStack))
                    return true;
                else if (recStack[adj[x][i]])
                    return true;
            }

            recStack[x] = false;
            return false;
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
            }
            Console.Write(Acyclic(adj));
        }
    }
}
