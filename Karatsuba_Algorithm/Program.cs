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
            string liczba = Karatsuba("1234567890", "1234567890");
            Console.WriteLine(liczba);
            Console.ReadKey();
        }

        public static string Karatsuba(string num1, string num2)
        {
            if(num1.Length<2 || num2.Length<2)
            {
                return Convert.ToString(Convert.ToInt32(num1) * Convert.ToInt32(num2));
            }

            if(num1.Length % 2 != 0 & Convert.ToDecimal(num1)!=0)
            {
                num1 = "0" + num1;
                Console.WriteLine("num1 = " + num1);
            }
            
            if (num2.Length % 2 != 0 & Convert.ToDecimal(num2) != 0)
            {
                num2 = "0" + num2;
                Console.WriteLine("num1 = " + num2);
            }

            /* Długość liczb */
            int n = Math.Max(num1.Length, num2.Length);
            int m = n / 2;

            /* H - high, L - low */
            string H1 = num1.Substring(0, m);
            string L1 = num1.Substring(m);

            string H2 = num2.Substring(0, m);
            string L2 = num2.Substring(m);

            Decimal X = Convert.ToDecimal(Karatsuba(H1, H2));
            Decimal Y = Convert.ToDecimal(Karatsuba(L1, L2));
            Decimal Z = Convert.ToDecimal(Karatsuba((Convert.ToDecimal(L1) + Convert.ToDecimal(H1)).ToString(), (Convert.ToDecimal(L2) + Convert.ToDecimal(H2)).ToString())) - X - Y;

            string lol = Convert.ToString(Decimal.Add(Decimal.Add(Decimal.Multiply(X, (Decimal)Math.Pow(10, (2 * m))), Decimal.Multiply(Z, (Decimal)Math.Pow(10, m))), Y));
            return lol;
        }

    }

}
