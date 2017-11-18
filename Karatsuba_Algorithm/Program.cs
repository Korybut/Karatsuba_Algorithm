using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karatsuba_Algorithm
{
    public class Program
    {
        static void Main(string[] args)
        {
            int liczba = Karatsuba("12345", "23125");
            Console.WriteLine(liczba);
            Console.ReadKey();
        }

        public static int Karatsuba(String num1, String num2)
        {
            if(num1.Length<2|| num2.Length<2)
            {
                return Convert.ToInt32(num1) * Convert.ToInt32(num2);
            }

            if(num1.Length % 2 != 0)
            {
                num1 = "0" + num1;
                Console.WriteLine("num1 = " + num1);
            }

            if (num2.Length % 2 != 0)
            {
                num2 = "0" + num2;
                Console.WriteLine("num1 = " + num2);
            }

            /* Długość liczb */
            int n = Math.Max(num1.Length, num2.Length);
            int m = n / 2;

            /* H - high, L - low */
            int H1 = Convert.ToInt32(num1.Substring(0, m));
            int L1 = Convert.ToInt32(num1.Substring(m));

            int H2 = Convert.ToInt32(num2.Substring(0, m));
            int L2 = Convert.ToInt32(num2.Substring(m));

            int X = Karatsuba(H1.ToString(), H2.ToString());
            int Y = Karatsuba(L1.ToString(), L2.ToString());
            int Z = Karatsuba((L1 + H1).ToString(), (L2 + H2).ToString()) - X - Y;

            return (X * (int)Math.Pow(10, (2 * m))) + (Z * (int)Math.Pow(10, m)) + Y;
        }

    }

}
