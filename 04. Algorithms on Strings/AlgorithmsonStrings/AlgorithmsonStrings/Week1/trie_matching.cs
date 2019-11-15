using System;
using System.Collections.Generic;

namespace AlgorithmsonStrings.Week1
{
    class trie_matching
    {
        //static void Main(string[] args)
        //{
        //    string text = Console.ReadLine();
        //    int n = int.Parse(Console.ReadLine());
        //    List<string> patterns = new List<string>();
        //    for (int i = 0; i < n; i++)
        //    {
        //        string s = Console.ReadLine();
        //        patterns.Add(s);
        //    }

        //    List<int> answers = Solve(text, n, patterns);
        //    string answersLine = string.Join(" ", answers);
        //    Console.WriteLine(answersLine);
        //}

        static List<int> Solve(string text, int n, List<string> patterns)
        {
            List<int> result = new List<int>();

            List<Node> t = new List<Node>();
            BuildTrie(patterns, t);
            int count = 0;
            while (!string.IsNullOrEmpty(text))
            {
                int match = MatchPrefixTrie(count++, text, t);
                if (match != -1)
                    result.Add(match);

                text = text.Substring(1);
            }

            return result;
        }

        private static int MatchPrefixTrie(int rem, string text, List<Node> t)
        {
            char currentLetter = text[0];
            Node currentNode = t[0];
            int indexCurrChar = 0;

            while (true)
            {
                if (currentNode.isLeaf())
                    return rem;
                else if (currentNode.next[LetterToIndex(currentLetter)] != NA)
                {
                    currentNode = t[currentNode.next[LetterToIndex(currentLetter)]];
                    if (indexCurrChar + 1 < text.Length)
                        currentLetter = text[++indexCurrChar];
                    else
                    {
                        if (currentNode.isLeaf())
                            return rem;
                        break;
                    }
                }
                else
                    break;
            }

            return -1;
        }

        public class Node
        {
            public int[] next = new int[Letters];

            public Node()
            {
                next[0] = NA;
                next[1] = NA;
                next[2] = NA;
                next[3] = NA;
            }

            public bool isLeaf()
            {
                foreach (int i in next)
                {
                    if (i != NA) return false;
                }
                return true;
            }
        }

        public static readonly int Letters = 4;
        public static readonly int NA = -1;

        public static int LetterToIndex(char letter)
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
                default:
                    return -1;
            }
        }

        public static void BuildTrie(List<string> patterns, List<Node> trie)
        {
            trie.Add(new Node());

            foreach (var pattern in patterns)
            {
                Node currentNode = trie[0];
                for (int i = 0; i < pattern.Length; i++)
                {
                    char currentLetter = pattern[i];
                    int index = currentNode.next[LetterToIndex(currentLetter)];

                    if(index != NA)
                    {
                        currentNode = trie[index];
                    }
                    else
                    {
                        Node newNode = new Node();
                        trie.Add(newNode);
                        currentNode.next[LetterToIndex(currentLetter)] = trie.Count - 1;
                        currentNode = newNode;
                    }
                }
            }

        }

    }
}
