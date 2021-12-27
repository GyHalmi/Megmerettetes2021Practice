using System;
using System.Collections.Generic;
using System.Linq;

namespace NyelvFuggetlen
{
    class Program
    {
        static void Main(string[] args)
        {
            //round1();
            //round2();
            Console.Read();
        }

        private static void round2()
        {
            //task2
            int code = 130023423;

            for (int i = 0; i < 20; i++)
            {
                code = (code - 1) / 2;
            }

            Console.WriteLine("code: " + code);


            //task3
            List<int> deck = Enumerable.Range(1, 100000).ToList();
           
            Console.WriteLine();

            void toTheBack()
            {
                deck.Add(deck[0]);
                deck.RemoveAt(0);
            }
            void removeFirst()
            {
                deck.RemoveAt(0);
            }

            while (deck.Count != 1)
            {
                toTheBack();
                removeFirst();
            }

            Console.WriteLine($"last card: {deck[0]}");

        }

        private static void round1()
        {
            //task1
            int sum1 = 0;
            for (int i = 2; i <= 10; i++)
            {
                sum1 += i;
            }
            Console.WriteLine("ex1: " + sum1);

            //task2
            int n = 123456789;
            int sum = 0;
            int count1 = 0;

            while (count1 == 0)
            {
                if (n == 1) count1++;
                sum += n;

                if (n % 2 == 0)
                {
                    n /= 2;
                }
                else
                {
                    n = n * 3 + 1;
                }
            }

            Console.WriteLine($"ex2\nn={n}, sum={sum}");
        }


    }
}
