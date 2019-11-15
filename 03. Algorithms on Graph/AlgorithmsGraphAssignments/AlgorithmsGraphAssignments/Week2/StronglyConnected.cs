using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsGraphAssignments.Week2
{
    class StronglyConnected
    {
        private int NumberOfStronglyConnectedComponents(List<int>[] adj)
        {
            int result = 0;
            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[adj.Length];

            // Fill vertices in stack according to their finishing times
            for (int i = 0; i < adj.Length; i++)
            {
                if (!visited[i])
                    Dfs(adj, i, visited, stack);
            }

            // get the reversed adj list
            List<int>[] rAdj = ReverseEdges(adj);
            // Mark all the vertices as not visited (For second DFS)
            visited = new bool[rAdj.Length];

            // Now process all vertices in order defined by Stack
            while (stack.Count > 0)
            {
                int x = stack.Pop();

                // get one strongly connected component of the popped vertex
                if (!visited[x])
                {
                    Dfs(rAdj, x, visited, new Stack<int>());
                    result++;
                }
            }

            return result;
        }

        private void Dfs(List<int>[] adj, int x, bool[] visited, Stack<int> stack)
        {
            visited[x] = true;

            for (int i = 0; i < adj[x].Count; i++)
            {
                if(!visited[adj[x][i]])
                    Dfs(adj, adj[x][i], visited, stack);
            }

            stack.Push(x);
        }

        private List<int>[] ReverseEdges(List<int>[] adj)
        {
            List<int>[] rAdj = new List<int>[adj.Length];
            for (int i = 0; i < adj.Length; i++)
            {
                rAdj[i] = new List<int>();
            }

            for (int i = 0; i < adj.Length; i++)
            {
                // Recur for all the vertices adjacent to this vertex
                for (int j = 0; j < adj[i].Count; j++)
                {
                    rAdj[adj[i][j]].Add(i);
                }
            }
            return rAdj;
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
            Console.Write(NumberOfStronglyConnectedComponents(adj));
        }
    }
}
