using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsonStrings
{
    class trie
    {
        //static void Main(string[] args)
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    List<string> patterns = new List<string>();
        //    for (int i = 0; i < n; i++)
        //    {
        //        string s = Console.ReadLine();
        //        patterns.Add(s);
        //    }

        //    var trie = BuildTrie(patterns);

        //    for (int i = 0; i < trie.Count(); i++)
        //    {
        //        foreach (var edge in trie[i])
        //        {
        //            if (edge.Key != '$')
        //                Console.WriteLine("{0}->{1}:{2}", i, edge.Value.ToString(), edge.Key);
        //        }
        //    }
        //}

        static List<Dictionary<char, int>> BuildTrie(List<string> patterns)
        {
            var trie = new List<Dictionary<char, int>>();

            foreach (var pattern in patterns)
            {
                int x = 0;
                foreach (var p in pattern)
                {
                    bool isFound = false;

                    if (x < trie.Count)
                    {
                        foreach (var k in trie[x])
                        {
                            if (k.Key == p)
                            {
                                x = k.Value;
                                isFound = true;
                                break;
                            }
                        }
                        if (!isFound)
                        {
                            trie[x].Add(p, trie.Count);
                            x = trie.Count;
                        }
                    }
                    else
                    {
                        Dictionary<char, int> d = new Dictionary<char, int>();
                        d.Add(p, trie.Count + 1);
                        trie.Add(d);
                        x = trie.Count;
                    }
                }
                Dictionary<char, int> dt = new Dictionary<char, int>();
                dt.Add('$', -1);
                trie.Add(dt);
            }

            return trie;
        }
    }
}
