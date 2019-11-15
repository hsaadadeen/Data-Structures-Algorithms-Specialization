//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace AdvancedAlgorithmsAssignments.Week1
//{
//    public class Edge
//    {
//        public int From;
//        public int To;
//        public int Capacity;
//        public int Flow;

//        public Edge(int from, int to, int capacity)
//        {
//            From = from;
//            To = to;
//            Capacity = capacity;
//            Flow = 0;
//        }
//    }

//    /* This class implements a bit unusual scheme to store the graph edges, in order
//     * to retrieve the backward edge for a given edge quickly. */
//    public class FlowGraph
//    {
//        private List<Edge> edges;   // List of all - forward and backward - edges
//        private List<int>[] graph;  // These adjacency lists store only indices of edges in the edges list

//        public int Size { get { return graph.Length; } }

//        public FlowGraph(int n)
//        {
//            graph = new List<int>[n];
//            for (int i = 0; i < n; ++i)
//                graph[i] = new List<int>();
//            edges = new List<Edge>();
//        }

//        public void AddEdge(int from, int to, int capacity)
//        {
//            /* Note that we first append a forward edge and then a backward edge,
//             * so all forward edges are stored at even indices (starting from 0),
//             * whereas backward edges are stored at odd indices in the list edges */
//            Edge forwardEdge = new Edge(from, to, capacity);
//            Edge backwardEdge = new Edge(to, from, 0);
//            graph[from].Add(edges.Count);
//            edges.Add(forwardEdge);
//            graph[to].Add(edges.Count);
//            edges.Add(backwardEdge);
//        }

//        public List<int> GetIds(int from)
//        {
//            return graph[from];
//        }

//        public Edge GetEdge(int id)
//        {
//            return edges[id];
//        }

//        public void AddFlow(int id, int flow)
//        {
//            /* To get a backward edge for a true forward edge (i.e id is even), we should get id + 1
//             * due to the described above scheme. On the other hand, when we have to get a "backward"
//             * edge for a backward edge (i.e. get a forward edge for backward - id is odd), id - 1
//             * should be taken.
//             *
//             * It turns out that id ^ 1 works for both cases. Think this through! */
//            edges[id].Flow += flow;
//            edges[id ^ 1].Flow -= flow;
//        }
//    }

//    public static class Evacuation
//    {
//        //public static int Main()
//        //{
//        //    FlowGraph graph = ReadData();

//        //    Console.Write(GetMaxFlow(graph, 0, graph.Size - 1));
//        //    Console.Write("\n");
//        //    return 0;
//        //}

//        public static FlowGraph ReadData()
//        {
//            int vertexCount = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
//            int edgeCount = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
//            FlowGraph graph = new FlowGraph(vertexCount);
//            for (int i = 0; i < edgeCount; ++i)
//            {
//                int from = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
//                int to = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
//                int capacity = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
//                graph.AddEdge(from - 1, to - 1, capacity);
//            }

//            return graph;
//        }

//        public static int GetMaxFlow(FlowGraph graph, int from, int to)
//        {
//            int flow = 0;

//            // Contains predecessors of a vertex to get the path and calculate minimum flow thereon.
//            List<int> pred;

//            do
//            {
//                pred = Enumerable.Repeat(-1, graph.Size).ToList();
//                Bfs(graph, from, to, pred);

//                if (pred[to] != -1)
//                {
//                    int minFlow = int.MaxValue;

//                    // Find minimal flow on the path from BFS.
//                    for (int u = pred[to]; u != -1; u = pred[graph.GetEdge(u).From])
//                    {
//                        minFlow = Math.Min(minFlow, graph.GetEdge(u).Capacity - graph.GetEdge(u).Flow);
//                    }

//                    // Update flow in original and residual graphs along the path from BFS
//                    for (int u = pred[to]; u != -1; u = pred[graph.GetEdge(u).From])
//                    {
//                        graph.AddFlow(u, minFlow);
//                    }

//                    flow += minFlow;
//                }

//            } while (pred[to] != -1);

//            return flow;
//        }

//        private static void Bfs(FlowGraph graph, int s, int t, List<int> pred)
//        {
//            Queue<int> q = new Queue<int>();
//            q.Enqueue(s);

//            while (q.Count > 0)
//            {

//                int cur = q.Peek();
//                q.Dequeue();

//                foreach (var id in graph.GetIds(cur))
//                {

//                    Edge e = graph.GetEdge(id);

//                    if (pred[e.To] == -1 && e.Capacity > e.Flow && e.To != s)
//                    {
//                        pred[e.To] = id;
//                        q.Enqueue(e.To);
//                    }
//                }
//            }
//        }
//    }
//}
