using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAssignments
{
    public class Bracket
    {
        public Bracket(char type, int position)
        {
            this.type = type;
            this.position = position;
        }

        public bool Matchc(char c)
        {
            if (type == '[' && c == ']')
            {
                return true;
            }
            if (type == '{' && c == '}')
            {
                return true;
            }
            if (type == '(' && c == ')')
            {
                return true;
            }
            return false;
        }

        public char type;
        public int position;
    }

    public static class GlobalMembers
    {
        public static void print_stack(Stack<Bracket> st)
        {
            char c;
            while (st.Count != 0)
            {
                c = st.Peek().type;
                Console.Write(c);
                st.Pop();
            }
            Console.Write("\n");
        }

        //static int Main()
        //{
        //    string text;
        //    text = Console.ReadLine();
        //    int faulty_position = -1;

        //    Stack<Bracket> opening_brackets_stack = new Stack<Bracket>();
        //    for (int position = 0; position < text.Length; ++position)
        //    {
        //        char next = text[position];

        //        if (next == '(' || next == '[' || next == '{')
        //        {
        //            // Process opening bracket, write your code here
        //            Bracket b = new Bracket(next, position + 1);
        //            opening_brackets_stack.Push(b);
        //        }

        //        if (next == ')' || next == ']' || next == '}')
        //        {
        //            // Process closing bracket, write your code here
        //            if (opening_brackets_stack.Count == 0)
        //            {
        //                faulty_position = position + 1;
        //                break;
        //            }
        //            else if (opening_brackets_stack.Peek().Matchc(next))
        //            {
        //                // pop it
        //                opening_brackets_stack.Pop();
        //            }
        //            else
        //            {
        //                faulty_position = position + 1;
        //                break;
        //            }
        //        }
        //    }

        //    // Printing answer, write your code here
        //    if (opening_brackets_stack.Count == 0 && faulty_position == -1)
        //    {
        //        Console.Write("Success");
        //        Console.Write("\n");
        //    }
        //    else
        //    {
        //        if (opening_brackets_stack.Count != 0 && faulty_position == -1)
        //        {
        //            faulty_position = opening_brackets_stack.Peek().position;
        //        }
        //        Console.Write(faulty_position);
        //        Console.Write("\n");
        //    }

        //    return 0;
        //}
    }
}