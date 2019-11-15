using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAssignments.Week1
{

    public class Node
    {
        public int value;
        public List<int> children = new List<int>();

        public Node(int value)
        {
            this.value = value;
        }

        public void add_child(int child)
        {
            this.children.Add(child);
        }

        public int get_size()
        {
            return this.children.Count;
        }
    }

    public class Tree
    {
        private int number_of_nodes;
        private Node root;
        private List<int> parents = new List<int>();
        private SortedDictionary<int, Node> nodes = new SortedDictionary<int, Node>();

        private void construct_tree()
        {
            for (int i = 0; i < this.number_of_nodes; i++)
            {
                this.nodes[i] = new Node(i);
            }

            for (int i = 0; i < this.number_of_nodes; i++)
            {
                int parent = this.parents[i];
                if (parent == -1)
                {
                    // root node
                    this.root = this.nodes[i];
                }
                else
                {
                    // add child
                    this.nodes[parent].add_child(i);
                }
            }
        }

        private int get_max_height(Node node)
        {
            if (node == null)
            {
                return 0; // this ain't shit
            }
            if (node.get_size() == 0)
            {
                return 1; // no children
            }

            int height = 0;
            for (int i = 0; i < node.get_size(); i++)
            {
                int height_of_this_child = this.get_max_height(this.nodes[node.children[i]]);
                height = Math.Max(height, height_of_this_child);
            }

            return height + 1;
        }
        

        // reading the tree
        public void read()
        {
            this.number_of_nodes = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            this.parents.Resize(this.number_of_nodes);
            for (int i = 0; i < this.number_of_nodes; i++)
            {
                this.parents[i] = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
            }
        }

        public int get_height()
        {
            this.construct_tree();
            return this.get_max_height(this.root);
        }

        public void print_tree()
        {
            for (int i = 0; i < number_of_nodes; i++)
            {
                if (nodes.ContainsKey(i))
                {
                    Console.Write(nodes[i].value);
                    Console.Write(": ");
                    for (int j = 0; j < nodes[i].get_size(); ++j)
                    {
                        Console.Write(nodes[i].children[j]);
                        Console.Write(" ");
                    }
                    Console.Write("\n");
                }
            }
        }
    }

    public static class TreeHeight
    {
        //static int Main()
        //{
        //    Tree tree = new Tree();
        //    tree.read();
        //    // tree->print_tree();
        //    Console.Write(tree.get_height());
        //    Console.Write("\n");

        //    return 0;
        //}
    }

    //----------------------------------------------------------------------------------------
    //	Copyright © 2006 - 2019 Tangible Software Solutions, Inc.
    //	This class can be used by anyone provided that the copyright notice remains intact.
    //
    //	This class is used to convert some of the C++ std::vector methods to C#.
    //----------------------------------------------------------------------------------------

    internal static class VectorHelper
    {
        public static void Resize<T>(this List<T> list, int newSize, T value = default(T))
        {
            if (list.Count > newSize)
                list.RemoveRange(newSize, list.Count - newSize);
            else if (list.Count < newSize)
            {
                for (int i = list.Count; i < newSize; i++)
                {
                    list.Add(value);
                }
            }
        }

        public static void Swap<T>(this List<T> list1, List<T> list2)
        {
            List<T> temp = new List<T>(list1);
            list1.Clear();
            list1.AddRange(list2);
            list2.Clear();
            list2.AddRange(temp);
        }

        public static List<T> InitializedList<T>(int size, T value)
        {
            List<T> temp = new List<T>();
            for (int count = 1; count <= size; count++)
            {
                temp.Add(value);
            }

            return temp;
        }

        public static List<List<T>> NestedList<T>(int outerSize, int innerSize)
        {
            List<List<T>> temp = new List<List<T>>();
            for (int count = 1; count <= outerSize; count++)
            {
                temp.Add(new List<T>(innerSize));
            }

            return temp;
        }

        public static List<List<T>> NestedList<T>(int outerSize, int innerSize, T value)
        {
            List<List<T>> temp = new List<List<T>>();
            for (int count = 1; count <= outerSize; count++)
            {
                temp.Add(InitializedList(innerSize, value));
            }

            return temp;
        }
    }

    //----------------------------------------------------------------------------------------
    //	Copyright © 2006 - 2019 Tangible Software Solutions, Inc.
    //	This class can be used by anyone provided that the copyright notice remains intact.
    //
    //	This class provides the ability to convert basic C++ 'cin' and C 'scanf' behavior.
    //----------------------------------------------------------------------------------------
    internal static class ConsoleInput
    {
        private static bool goodLastRead = false;
        public static bool LastReadWasGood
        {
            get
            {
                return goodLastRead;
            }
        }

        public static string ReadToWhiteSpace(bool skipLeadingWhiteSpace)
        {
            string input = "";

            char nextChar;
            while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
            {
                //accumulate leading white space if skipLeadingWhiteSpace is false:
                if (!skipLeadingWhiteSpace)
                    input += nextChar;
            }
            //the first non white space character:
            input += nextChar;

            //accumulate characters until white space is reached:
            while (!char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
            {
                input += nextChar;
            }

            goodLastRead = input.Length > 0;
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
                        while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
                        {
                        }
                    }
                    else
                    {
                        //ensure each character matches the expected character in the sequence:
                        nextChar = (char)System.Console.Read();
                        if (nextChar != unwantedSequence[charIndex])
                            return null;
                    }
                }

                input = nextChar.ToString();
                if (maxFieldLength == 1)
                    return input;
            }

            while (!char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
            {
                input += nextChar;
                if (maxFieldLength == input.Length)
                    return input;
            }

            return input;
        }
    }

}
