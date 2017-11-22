using System;

namespace Karatsuba_Algorithm
{
    public class Program

    {

        static public int count = 0;

        static void Main(string[] args)
        {
            BigInteger liczba = Karatsuba(
                "1234191123419112341911242342342424342342342334191234191123419112341911242342342424342342342334191112341911234191123419112423423424243423423423341912341911234191123419112423423424243423423423341911",
                "1234191123419112341911242342342424342342342334191234191123419112341911242342342424342342342334191112341911234191123419112423423424243423423423341912341911234191123419112423423424243423423423341911");

            Console.WriteLine(liczba);
            Console.WriteLine("ilosc rekurencji: " + count);

            BigInteger liczba2 = Karatsuba(
                "1234191123419112341911242342342424342342342334191234191123419112341911242342342424342342342334191112341911234191123419112423423424243423423423341912341911234191123419112423423424243423423423341911",
                "1234191123419112341911242342342424342342342334191234191123419112341911242342342424342342342334191112341911234191123419112423423424243423423423341912341911234191123419112423423424243423423423341911");

            Console.WriteLine(liczba2);
            Console.WriteLine("ilosc rekurencji: " + count);

            BigInteger liczba3 = Karatsuba(
                "1234191123419112341911242342342424342342342334191234191123419112341911242342342424342342342334191112341911234191123419112423423424243423423423341912341911234191123419112423423424243423423423341911",
                "1234191123419112341911242342342424342342342334191234191123419112341911242342342424342342342334191112341911234191123419112423423424243423423423341912341911234191123419112423423424243423423423341911");

            Console.WriteLine(liczba3);
            Console.WriteLine("ilosc rekurencji: " + count);

            BigInteger liczba4 = Karatsuba(
                "1234191123419112341911242342342424342342342334191234191123419112341911242342342424342342342334191112341911234191123419112423423424243423423423341912341911234191123419112423423424243423423423341911",
                "1234191123419112341911242342342424342342342334191234191123419112341911242342342424342342342334191112341911234191123419112423423424243423423423341912341911234191123419112423423424243423423423341911");

            Console.WriteLine(liczba4);
            Console.WriteLine("ilosc rekurencji: " + count);

            BigInteger liczba5 = Karatsuba(
                "1234191123419112341911242342342424342342342334191234191123419112341911242342342424342342342334191112341911234191123419112423423424243423423423341912341911234191123419112423423424243423423423341911",
                "1234191123419112341911242342342424342342342334191234191123419112341911242342342424342342342334191112341911234191123419112423423424243423423423341912341911234191123419112423423424243423423423341911");

            Console.WriteLine(liczba5);
            Console.WriteLine("ilosc rekurencji: " + count);

            BigInteger liczba6 = Karatsuba(
                "1234191123419112341911242342342424342342342334191234191123419112341911242342342424342342342334191112341911234191123419112423423424243423423423341912341911234191123419112423423424243423423423341911",
                "1234191123419112341911242342342424342342342334191234191123419112341911242342342424342342342334191112341911234191123419112423423424243423423423341912341911234191123419112423423424243423423423341911");

            Console.WriteLine(liczba6);
            Console.WriteLine("ilosc rekurencji: " + count);

            Console.ReadKey();
        }

        public static BigInteger Karatsuba(string num1, string num2)
        {
            count++;

            if(num1.Length<2 || num2.Length<2)
            {
                return new BigInteger(num1,10) * new BigInteger(num2, 10);
            }

            if(num1.Length % 2 != 0 & new BigInteger(num1,10)!=0)
            {
                num1 = "0" + num1;
               // Console.WriteLine("num1 = " + num1);
            }

            if (num2.Length % 2 != 0 & new BigInteger(num2, 10) != 0)
            {
                num2 = "0" + num2;
               // Console.WriteLine("num1 = " + num2);
            }

            /* Długość liczb */
            int n = Math.Max(num1.Length, num2.Length);
            int m = n / 2;

            /* H - high, L - low */
            string H1 = num1.Substring(0, m);
            string L1 = num1.Substring(m);

            string H2 = num2.Substring(0, m);
            string L2 = num2.Substring(m);

            BigInteger X = Karatsuba(H1, H2);
            BigInteger Y = Karatsuba(L1, L2);
            BigInteger Z = Karatsuba((new BigInteger(L1,10) + new BigInteger(H1,10)).ToString(), (new BigInteger(L2,10) + new BigInteger(H2,10)).ToString()) - X - Y;


            // (X * 10 ^ (2 * m)) + ((Z) * 10 ^ (m)) + (Y)
            BigInteger sum1 = Pow(new BigInteger("10", 10), new BigInteger((2 * m).ToString(), 10));
            BigInteger sum2 = Pow(new BigInteger("10", 10), new BigInteger(m.ToString(), 10));

            return (X * sum1) + (Z * sum2) + Y;
        }

        public static BigInteger Pow(BigInteger num, BigInteger pow)
        {
            BigInteger result = 1;

            for(BigInteger i = 0; i<pow; i++)
            {
                result *= num;
            }
            return result;
        }

    }

}
