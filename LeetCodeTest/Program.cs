using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCodeTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(s);
            IsValid(s);
            Console.WriteLine(s);
            Console.ReadLine();


        }

        private static bool IsValid(string s)         {
            
            
            s.ToCharArray();
            bool output = false;
            Stack<char> myStack = new Stack<char>();

            IDictionary<char, char> parovi = new Dictionary<char, char>()
            {
                { '(',')' },
                { '[',']' },
                { '{','}' },
            };

            foreach(char c in s)
            {
                if (s.Contains(c))
                {
                    myStack.Push(c);
                }
                else if (myStack.Count != 0)
                {
                    char top = myStack.Pop();

                    if (parovi[top] != c)

                        return false;
                }
                else
                {
                    return false;
                }

            }

            Console.WriteLine(output);
            return output;
        }
    }
}
