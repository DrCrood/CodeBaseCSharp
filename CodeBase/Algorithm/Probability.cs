using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Algorithm
{
    public class Probability
    {
        public ((string, int),(string, int)) HeadTailProbCheck()
        {
            Random ran = new Random();
            int hh = 0;
            int h = 0;
            int h1 = 0;
            int h2 = 0;
            for (int i = 0; i < 1000000; i++)
            {
                int a = ran.Next(1, 3);
                int b = ran.Next(1, 3);
                int c = ran.Next(1, 3);

                if (a == 1 || b == 1)
                {
                    h1++;
                    if (a == 1 && b == 1)
                    {
                        h2++;
                    }
                }

                if (c == 1)
                {
                    if (a == 1)
                    {
                        h++;
                        if (b == 1)
                        {
                            hh++;
                        }
                    }
                }
                else
                {
                    if (b == 1)
                    {
                        h++;
                        if (a == 1)
                        {
                            hh++;
                        }
                    }
                }
            }

            return (("One is head known", (int)Math.Round(100.0 * h2 / h1)), ("Random check and found one is head", (int)Math.Round(100.0 * hh / h)));
        }
    }
}
