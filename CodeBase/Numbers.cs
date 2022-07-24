using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CodeBase
{
    class Numbers
    {
        public void  FindArmStrongNumbers()
        {
            for (int i = 0; i < 100000; i++)
            {
                int n = i;
                int sum = 0;
                while(true)
                {
                    if (n == 0)
                    {
                        if (sum == i)
                        {
                            Console.WriteLine($"ArmStrongNumber : {i}");
                        }
                        break;
                    }
                    int digit = n % 10;
                    n = n / 10;
                    sum += digit * digit * digit;
                }
            }
        }

        public void FindpalindromicNumbers()
        {
            for (int i = 1000; i < 10000; i++)
            {
                int n = i;
                int m = 0;
                while (n > 0)
                {
                    int digit = n % 10;
                    n = n / 10;
                    m = m * 10 + digit;
                    if ( n ==0 && m == i)
                    {
                        Console.WriteLine($"Palindromic Number : {i}");
                    }
                }
            }
        }

        public void factorialA(int n)
        {
            BigInteger BI = new BigInteger(1);
            for(int i=2; i<=n; i++)
            {
                BI = BigInteger.Multiply(BI, i);
            }

            Console.WriteLine(BI.ToString());
        }

        public void factorialB(int n)
        {
            int[] arr = new int[100];
            arr[99] = 1;

            for(int i=2; i<=n; i++)
            {
                for (int m = 0; m < 100; m++)
                {
                    arr[m] = i * arr[m];
                }

                for (int m = 99; m>0; m--)
                {
                    if(arr[m]>10)
                    {
                        int temp = arr[m];
                        arr[m] = arr[m] % 10;
                        arr[m - 1] += temp / 10;
                    }
                }
            }

            int sindex = 0;
            for (sindex = 0; sindex < 100; sindex++)
            {
                if (arr[sindex] > 0)
                {
                    break;
                }
            }

            StringBuilder builder = new StringBuilder();
            for (int s = sindex; s< 100; s++)
            {
                builder.Append(arr[s].ToString());
            }

            Console.WriteLine(builder.ToString());
        }



    }
}
