using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsonStrings.Week1
{
    class suffix_tree
    {
        //static void Main(string[] args)
        //{
        //    string text = Console.ReadLine();

        //    List<string> answers = ComputeSuffixTreeEdges(text);
        //    string answersLine = string.Join("\n", answers);
        //    Console.WriteLine(answersLine);
        //}

        // Build a suffix tree of the string text and return a list
        // with all of the labels of its edges (the corresponding 
        // substrings of the text) in any order.
        public static List<String> ComputeSuffixTreeEdges(String text)
        {
            List<string> result = new List<string>();
            List<Node> tree = TextToTree(text);
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                Node currentNode = tree[queue.Dequeue()];
                if (currentNode.Offset != -1)
                {
                    if (currentNode.Start + currentNode.Start + currentNode.Offset + 1 > text.Length)
                        result.Add(text.Substring(currentNode.Start));
                    else
                        result.Add(text.Substring(currentNode.Start, currentNode.Start + currentNode.Offset + 1));
                }
                for (int i = 0; i < Letters; i++)
                {
                    if (currentNode.Next[i] > 0) queue.Enqueue(currentNode.Next[i]);
                }
            }
            return result;
        }

        static List<Node> TextToTree(string text)
        {
            List<Node> tree = new List<Node>();
            int count = 0;
            tree.Add(new Node(0, -1, count++));
            int length = text.Length;

            for (int j = 0; j < length; j++)
            {
                int initialStart = length - 1 - j;
                int initialOffset = j;
                Node currentNode = tree[0];
                while (currentNode.Next[LetterToIndex(text[initialStart])] > 0)
                {
                    currentNode = tree[currentNode.Next[LetterToIndex(text[initialStart])]];
                    int currentStart = currentNode.Start;
                    int currentOffset = currentNode.Offset;
                    int removeIndex = 1;
                    for (int i = 1; i < currentOffset + 1; i++)
                    {
                        if (text[currentStart + i] != text[initialStart + i])
                        {
                            break;
                        }
                        removeIndex++;
                    }

                    if (currentOffset + 1 - removeIndex > 0)
                    {
                        Node newNode = new Node(currentStart + removeIndex, currentOffset - removeIndex, count++);
                        currentNode.Start = initialStart;
                        currentNode.Offset = removeIndex - 1;
                        tree.Add(newNode);
                        if (currentNode.HaveNeighbours)
                        {
                            Array.Copy(currentNode.Next, newNode.Next, currentNode.Next.Length);
                            newNode.HaveNeighbours = true;
                            currentNode.InitNext();
                        }
                        currentNode.Next[LetterToIndex(text[newNode.Start])] = newNode.Id;
                        currentNode.HaveNeighbours = true;
                    }
                    initialStart += removeIndex;
                    initialOffset -= removeIndex;
                }
                Node newNode2 = new Node(initialStart, initialOffset, count++);
                tree.Add(newNode2);
                currentNode.Next[LetterToIndex(text[initialStart])] = newNode2.Id;
                currentNode.HaveNeighbours = true;
            }
            return tree;
        }

        public static readonly int Letters = 5;
        public static readonly int NA = -1;

        static int LetterToIndex(char letter)
        {
            switch (letter)
            {
                case 'A':
                    return 0;
                case 'C':
                    return 1;
                case 'G':
                    return 2;
                case 'T':
                    return 3;
                case '$':
                    return 4;
                default:
                    return NA;
            }
        }


        public class Node
        {
            public int[] Next;
            public int Start;
            public int Offset;
            public int Id;
            public bool HaveNeighbours;

            public Node()
            {
                Next = Enumerable.Repeat(NA, Letters).ToArray();
            }


            public Node(int start, int offset, int id)
            {
                Next = Enumerable.Repeat(NA, Letters).ToArray();
                this.Start = start;
                this.Offset = offset;
                this.Id = id;
            }

            public void InitNext()
            {
                Next = Enumerable.Repeat(NA, Letters).ToArray();
                HaveNeighbours = false;
            }
        }
    }
}
