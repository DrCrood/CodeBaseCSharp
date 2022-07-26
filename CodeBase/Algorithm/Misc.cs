using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algorithm
{
    public class Misc
    {
         /// <summary>
         /// 
         /// </summary>
         /// <param name="num"></param>
         /// <returns></returns>
        public static int ReverseNumber(int num)
        {
            if (num < 0)
            {
                return 0;
            }
            int r = 0;
            while (num > 0)
            {
                int d = num % 10;
                r = r * 10 + d;
                num = (num - d) / 10;
            }
            return r;
        }

        /// <summary>
        /// Count the 1 digit in binary of a number
        /// </summary>
        /// <param name="num"></param>
        /// <returns>number of 1's</returns>
        public int CountBitByDivide(int num)
        {
            int bits = 0;
            while (num != 0)
            {
                int n = num % 2;
                bits += n;
                num = (num - n) / 2;
            }
            return bits;
        }

        /// <summary>
        /// Count the 1 digit in binary of a number
        /// </summary>
        /// <param name="num"></param>
        /// <returns>number of 1's</returns>
        public int CountBitByBitShift(int num)
        {
            int bits = 0;
            while (num != 0)
            {
                bits += num & 1;
                num >>= 1;
            }
            return bits;
        }

        /// <summary>
        /// Test if a number is with sequential digits like 123.
        /// </summary>
        /// <param name="num"></param>
        /// <returns>bool</returns>
        public static bool DigitsIsSequentialInNumber(int num)
        {
            if (num < 11)
            {
                return false;
            }
            int predig = -1;
            while (num > 0)
            {
                int d = -1;
                d = num % 10;
                num = (num - d) / 10;
                if (predig < 0)
                {
                    predig = d;
                }
                else
                {
                    if (predig - d != 1)
                    {
                        return false;
                    }
                    predig = d;
                }
            }
            return true;
        }

        /// <summary>
        /// Convert integer to Roman number
        /// </summary>
        /// <param name="num"></param>
        /// <returns>string</returns>
        public string IntToRoman(int num)
        {
            StringBuilder sb = new StringBuilder();
            string[] chars = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] value = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            int i = 0;
            while (num > 0)
            {
                while (num >= value[i])
                {
                    num -= value[i];
                    sb.Append(chars[i]);
                }
                i++;
            }
            return sb.ToString();
        }

    }
}
