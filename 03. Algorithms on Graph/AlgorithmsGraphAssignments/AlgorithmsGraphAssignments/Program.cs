using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmsGraphAssignments.Week1;
using AlgorithmsGraphAssignments.Week2;
using AlgorithmsGraphAssignments.Week3;
using AlgorithmsGraphAssignments.Week4;
using AlgorithmsGraphAssignments.Week5;

namespace AlgorithmsGraphAssignments
{
    class Program
    {
        static void Main(string[] args)
        {
            Clustering r = new Clustering();
            r.Start();
        }
    }

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
