using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedAlgorithmsAssignments.Week1
{
    class MaxMatching
    {
        //public static void Main()
        //{
        //    Solve();
        //}

        public static void Solve()
        {
            FlowGraph graph = ReadData();
            GetMaxFlow(graph, 0, graph.Size - 1);
            WriteResponse(graph, graph.Flights);
        }

        private static FlowGraph ReadData()
        {
            var n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            var m = int.Parse(ConsoleInput.ReadToWhiteSpace(true));

            var graph = new FlowGraph(n + m + 2, m + n + 2, n);

            // Construct FlowGraph from data given for bipartite graph by adding source and sink

            // Edges from vertices on the left of bipartite graph to the source
            for (int i = 0; i <= n; i++)
            {
                graph.AddEdge(0, i + 1, 1);
            }

            // Edges of verteces from left to right of bipartite graph
            for (int i = 1; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    var bit = int.Parse(ConsoleInput.ReadToWhiteSpace(true)) != 0;
                    if (bit)
                        graph.AddEdge(i, n + j + 1, 1);
                }
            }

            // Edges from vertices on the right of bipartite graph to the sink
            for (int i = n + 1; i <= n + m; i++)
            {
                graph.AddEdge(i, n + m + 1, 1);
            }

            return graph;
        }

        private static void WriteResponse(FlowGraph graph, int flights)
        {
            for (int i = 0; i < flights; ++i)
            {
                int job = -1;
                foreach (var id in graph.GetIds(i+1))
                {
                    Edge e = graph.GetEdge(id);
                    if (e.Flow == 1)
                        job = e.To - flights;
                    break;
                }
                Console.Write("{0} ", job);
            }
            Console.Write("\n");
        }
        
        public static int GetMaxFlow(FlowGraph graph, int from, int to)
        {
            int flow = 0;

            // Contains predecessors of a vertex to get the path and calculate minimum flow thereon.
            List<int> pred;

            do
            {
                pred = Enumerable.Repeat(-1, graph.Size).ToList();
                Bfs(graph, from, to, pred);

                if (pred[to] != -1)
                {
                    int minFlow = int.MaxValue;

                    // Find minimal flow on the path from BFS.
                    for (int u = pred[to]; u != -1; u = pred[graph.GetEdge(u).From])
                    {
                        minFlow = Math.Min(minFlow, graph.GetEdge(u).Capacity - graph.GetEdge(u).Flow);
                    }

                    // Update flow in original and residual graphs along the path from BFS
                    for (int u = pred[to]; u != -1; u = pred[graph.GetEdge(u).From])
                    {
                        graph.AddFlow(u, minFlow);
                    }

                    flow += minFlow;
                }

            } while (pred[to] != -1);

            return flow;
        }

        private static void Bfs(FlowGraph graph, int s, int t, List<int> pred)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(s);

            while (q.Count > 0)
            {

                int cur = q.Peek();
                q.Dequeue();

                foreach (var id in graph.GetIds(cur))
                {

                    Edge e = graph.GetEdge(id);

                    if (pred[e.To] == -1 && e.Capacity > e.Flow && e.To != s)
                    {
                        pred[e.To] = id;
                        q.Enqueue(e.To);
                    }
                }
            }
        }
    }

    #region Graph
    public class Edge
    {
        public int From;
        public int To;
        public int Capacity;
        public int Flow;

        public Edge(int from, int to, int capacity)
        {
            From = from;
            To = to;
            Capacity = capacity;
            Flow = 0;
        }
    }

    // This class implements a bit unusual scheme to store the graph edges, in order to retrieve the backward edge for a given edge quickly. 
    public class FlowGraph
    {
        private List<Edge> edges;   // List of all - forward and backward - edges
        private List<int>[] graph;  // These adjacency lists store only indices of edges in the edges list

        public int Size { get { return graph.Length; } }
        public int Flights { get; }

        public FlowGraph(int n, int m, int f)
        {
            graph = new List<int>[n];
            for (int i = 0; i < n; ++i)
                graph[i] = new List<int>();
            edges = new List<Edge>();
            Flights = f;
        }

        public void AddEdge(int from, int to, int capacity)
        {
            /* Note that we first append a forward edge and then a backward edge,
             * so all forward edges are stored at even indices (starting from 0),
             * whereas backward edges are stored at odd indices in the list edges */
            Edge forwardEdge = new Edge(from, to, capacity);
            Edge backwardEdge = new Edge(to, from, 0);
            graph[from].Add(edges.Count);
            edges.Add(forwardEdge);
            graph[to].Add(edges.Count);
            edges.Add(backwardEdge);
        }

        public List<int> GetIds(int from)
        {
            return graph[from];
        }

        public Edge GetEdge(int id)
        {
            return edges[id];
        }

        public void AddFlow(int id, int flow)
        {
            /* To get a backward edge for a true forward edge (i.e id is even), we should get id + 1
             * due to the described above scheme. On the other hand, when we have to get a "backward"
             * edge for a backward edge (i.e. get a forward edge for backward - id is odd), id - 1
             * should be taken.
             *
             * It turns out that id ^ 1 works for both cases. Think this through! */
            edges[id].Flow += flow;
            edges[id ^ 1].Flow -= flow;
        }
    }

    #endregion
    #region Console

    //Helper class added by C++ to C# Converter:
    //----------------------------------------------------------------------------------------
    //	Copyright © 2006 - 2019 Tangible Software Solutions, Inc.
    //	This class can be used by anyone provided that the copyright notice remains intact.
    //
    //	This class provides the ability to convert basic C++ 'cin' and C 'scanf' behavior.
    //----------------------------------------------------------------------------------------
    internal static class ConsoleInput
    {
        private static bool _goodLastRead = false;
        public static bool LastReadWasGood
        {
            get
            {
                return _goodLastRead;
            }
        }

        public static string ReadToWhiteSpace(bool skipLeadingWhiteSpace)
        {
            string input = "";

            char nextChar;
            while (char.IsWhiteSpace(nextChar = (char)Console.Read()))
            {
                //accumulate leading white space if skipLeadingWhiteSpace is false:
                if (!skipLeadingWhiteSpace)
                    input += nextChar;
            }
            //the first non white space character:
            input += nextChar;

            //accumulate characters until white space is reached:
            while (!char.IsWhiteSpace(nextChar = (char)Console.Read()))
            {
                input += nextChar;
            }

            _goodLastRead = input.Length > 0;
            return input;
        }

        public static string ScanfRead(string unwantedSequence = null, int maxFieldLength = -1)
        {
            string input = "";

            char nextChar;
            if (unwantedSequence != null)
            {
                nextChar = '\0';
                for (int charIndex = 0; charIndex < unwantedSequence.Length; charIndex++)
                {
                    if (char.IsWhiteSpace(unwantedSequence[charIndex]))
                    {
                        //ignore all subsequent white space:
                        while (char.IsWhiteSpace(nextChar = (char)Console.Read()))
                        {
                        }
                    }
                    else
                    {
                        //ensure each character matches the expected character in the sequence:
                        nextChar = (char)Console.Read();
                        if (nextChar != unwantedSequence[charIndex])
                            return null;
                    }
                }

                input = nextChar.ToString();
                if (maxFieldLength == 1)
                    return input;
            }

            while (!char.IsWhiteSpace(nextChar = (char)Console.Read()))
            {
                input += nextChar;
                if (maxFieldLength == input.Length)
                    return input;
            }

            return input;
        }
    }
    #endregion
}

