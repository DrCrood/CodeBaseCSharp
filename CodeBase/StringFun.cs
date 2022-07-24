using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBase
{
    class StringFun
    {

        static long substrCount(string s)
        {
            //this function is use to count all substrings in a string
            //substring has to meet one of two conditions: 1, all chars are the same, 2, all chars are the same except the middle one
            //example of substring: a OR b OR aa OR ccc OR aabaa OR cbc

            int n = s.Length;
            long res = n;

            //count same types of letters
            int length = 1;
            for (int i = 1; i < n; i++)
            {
                if (s[i] == s[i - 1])
                {
                    length++;
                }
                else
                {
                    res += length > 1 ? length * (length - 1) / 2 : 0;
                    length = 1;
                }

                if (i == n - 1)
                {
                    res += length * (length - 1) / 2;
                }
            }

            length = 1;
            int postlength = 0;
            for (int i = 1; i < n; i++)
            {
                if (s[i] == s[i - 1])
                {
                    length++;
                    continue;
                }
                int k = i + 1;
                postlength = 0;
                while (k < n && s[k] == s[i - 1])
                {
                    postlength++;
                    k++;
                }

                int minLength = length < postlength ? length : postlength;
                res += minLength;
                length = 1;
            }

            return res;
        }


        public static void BitsOperationDemo()
        {
            int a = 1204801;
            int b = 990990;
            int c = a >> 1;
            int d = b << 1;
            Console.WriteLine($"Number a : {a}, b: {b}");
            Console.WriteLine(GetIntBinaryString(~a) + "   a's complement  ~a");
            Console.WriteLine(GetIntBinaryString(a) + "   a");
            Console.WriteLine(GetIntBinaryString(b) + "   b");
            Console.WriteLine(GetIntBinaryString(a & b) + "   AND a&b ");
            Console.WriteLine(GetIntBinaryString(a | b) + "   OR a|b");
            Console.WriteLine(GetIntBinaryString(a ^ b) + "   XOR a^b");
            Console.WriteLine(GetIntBinaryString(c) + $"   a left shift  a>>1  value={c}");
            Console.WriteLine(GetIntBinaryString(d) + $"   b right shift b<<1 value={d}");
            Console.WriteLine(GetIntBinaryString(a & 1) + $"   a AND 1 a&1");

            Console.WriteLine();
        }

        static string GetIntBinaryString(int n)
        {
            char[] b = new char[32];
            int pos = 31;

            while (pos >=0 )
            {
                if ((n & 1 ) == 1)
                {
                    b[pos] = '1';
                }
                else
                {
                    b[pos] = '0';
                }
                pos--;
                n = n >> 1;
            }
            return new string(b);
        }

        public static void CheckStringMatch(string a, string b)
        {
            //Check if string b can be made of a by: delete lowcase letters or make capitalize lower case letters
            int na = a.Length;
            int nb = b.Length;
            if (na < nb)
            {
                Console.WriteLine("NO");
            }

            if (stringMatches(a, b, na - 1, nb - 1))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }


        }

        static bool stringMatches(string a, string b, int ai, int bi)
        {
            if (ai < bi)
            {
                return false;
            }

            if (bi < 0)
            {
                //check if all left in a are lower cases
                for(int k=ai; k>=0; k--)
                {
                    if(a[k] < 96)
                    {
                        return false;
                    }
                }
                
                return true;
            }

            if (a[ai] == b[bi])
            {
                if(ai ==0 && bi == 0)
                {
                    return true;
                }

                if (stringMatches(a, b, ai-1, bi-1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (a[ai] < 96)
            {
                return false;
            }

            if (a[ai] > 96 && a[ai] - 32 != b[bi])
            {
                while( ai > 0 && a[ai] > 96 && a[ai] - 32 != b[bi])
                {
                    ai--;
                }

                if (stringMatches(a, b, ai, bi))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (a[ai] - 32 == b[bi])
            {
                if (stringMatches(a, b, ai-1, bi))
                {
                    return true;
                }
                else
                {
                    if (stringMatches(a, b, ai-1, bi-1))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }


            return false;
        }

    }
}
