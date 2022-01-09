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
            //round3t2();
            round3t3(); //not interpretable
            Console.Read();
        }
        private static void round3t3()
        {
            int[][] pyramid = new int[25][];
                int lastNum = 0;
            for (int row = 0; row < pyramid.Length; row++)
            {
                pyramid[row] = new int[row + 1];
                for (int i = 0; i < pyramid[row].Length; i++)
                {
                    pyramid[row][i] = ++lastNum;
                }
            }
            Console.WriteLine("");
        }
        private static void round3t2()
        {
            /*
             * cache miss when block to read is not in cache
             * cache hit when block to read is in cache
            */

            int[] cache = { -1, -1, -1 };
            int cacheMissCount = 0;

            for (int i = 1; i <= 5; i++)
            {
                readBlockN((i * 2) % 5);
                readBlockN(i % 5);
            }

            Console.WriteLine($"cacheMissCount: {cacheMissCount}");

            void readBlockN(int i)
            {
                if (cacheMiss(i))
                {
                    cacheMissCount++;
                    storeNew(i);
                }
                else
                {
                    storeRearrange(i);
                }
            }

            void storeNew(int block)
            {
                for (int i = cache.Length - 1; i >= 1; i--)
                {
                    cache[i] = cache[i - 1];
                }
                cache[0] = block;
            }
            void storeRearrange(int block)
            {
                int ind = 0;
                while (ind < cache.Length && cache[ind] != block)
                {
                    ind++;
                }
                for (int i = ind; i >= 1; i--)
                {
                    cache[i] = cache[i - 1];
                }
                cache[0] = block;
            }

            bool cacheMiss(int n)
            {
                int i = 0;
                while (i < cache.Length && cache[i] != n)
                {
                    i++;
                }
                return i >= cache.Length;
            }
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
