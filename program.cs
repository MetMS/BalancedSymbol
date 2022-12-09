using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsSymbolBalanced("({[()[]]})"));
            Console.WriteLine(IsSymbolBalanced("(/*{[()[]]}*/)"));
            Console.WriteLine(IsSymbolBalanced("(*/{[()[]]}*/)"));
            Console.WriteLine(IsSymbolBalanced("(a{[()ab[]]}c)"));
        }

        private static bool IsSymbolBalanced(string v)
        {
            if (string.IsNullOrWhiteSpace(v))
            {
                return false;
            }

            List<char> vChar = new List<char>();
            vChar.AddRange(v.ToCharArray());

            for(int i = 0; i < vChar.Count; i++)
            {
                i = 0;
                if(IsPairSymbolsBalanced(vChar[i], vChar[i+1]))
                {
                    vChar.RemoveAt(i);
                    vChar.RemoveAt(i);
                }
                else if (IsPairSymbolsBalanced(vChar[i], vChar[vChar.Count - 1]))
                {
                    vChar.RemoveAt(i);
                    vChar.RemoveAt(vChar.Count - 1);
                }
                else
                {
                    return false;
                }

            }
            if(vChar.Count == 0)
            {
                return true;
            }
            return false;
        }

        private static bool IsSymbolsBalancedAreLetters(char v1, char v2)
        {
            List<char> alphabet = new List<char>{ 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            return alphabet.Contains(Char.ToLower(v1)) && alphabet.Contains(Char.ToLower(v2));
        }

        private static bool IsPairSymbolsBalanced(char v1, char v2)
        {
            
            if(v1 == '(' && v2 == ')')
            {
                return true;
            }
            else if (v1 == '{' && v2 == '}')
            {
                return true;
            }
            else if (v1 == '[' && v2 == ']')
            {
                return true;
            }
            else if (v1== '*' && v2 == '*')
            {
                return true;
            }
            else if (v1 == '/' && v2 == '/')
            {
                return true;
            } else if (IsSymbolsBalancedAreLetters(v1, v2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
