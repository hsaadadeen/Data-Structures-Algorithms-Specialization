using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsGraphAssignments.Week2
{
    class Toposort
    {
        private List<int> toposort(List<int>[] adj)
        {
            bool[] used = new bool[adj.Length];
            List<int> order = new List<int>();

            for (int i = 0; i < adj.Length; i++)
            {
                if(!used[i])
                    dfs(adj, used, order, i);
            }

            return order;
        }
        private void dfs(List<int>[] adj, bool[] used, List<int> order, int x)
        {
            used[x] = true;
            for (int i = 0; i < adj[x].Count; i++)
            {
                if(!used[adj[x][i]])
                    dfs(adj, used, order, adj[x][i]);
            }

            order.Insert(0, x+1);
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

            Console.WriteLine(string.Join(" ", toposort(adj)));

        }
    }
}
