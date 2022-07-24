using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBase
{
    static class ExtensionMethods
    {
        public static string ReverseStringWithExtension(this string s)
        {
            char[] c = s.ToCharArray();
            Array.Reverse(c);
            return new String(c);
        }

        public static int CountStringSpaces(this string s)
        {
            int spaces = 0;
            foreach (char c in s)
            {
                if (c == ' ')
                {
                    spaces++;
                }
            }
            return spaces;
        }

        public static int CountBookValues(this IEnumerable<Book> books)
        {
            int val = 0;
            foreach (Book b in books)
            {
                val += b.Price;
            }
            return val;
        }

        public static Tiger Fly(this Tiger tiger)
        {
            Console.WriteLine("Help the tiger to fly.");
            return tiger;
        }

        public static Tiger Swim(this Tiger tiger)
        {
            Console.WriteLine("Help the tiger to swim.");
            return tiger;
        }

    }
}
