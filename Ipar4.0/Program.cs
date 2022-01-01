using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ipar4._0
{
    class Program
    {
        static string testFile;
        static string actualFile;
        static void Main(string[] args)
        {
            //round1();
            //Console.WriteLine("study delegates by select(int.Parse) ");
            //Func<string, int> parser = int.Parse;

            round2();
            Console.Read();
        }

        private static void round2()
        {
            //task1
            int callFibo = 0;
            int Fibo(int n)
            {
                callFibo++;
                if (n == 0) return 1;
                if (n == 1) return 7;
                return Fibo(n - 1) + Fibo(n - 2);
            }
            int res = Fibo(15);

            Console.WriteLine($"calls: {callFibo} //result: {res}");

            //task2
            int calls = 0;
            int chipCountRecursive(int n)
            {
                if (n == 0) return 0;
                if (n == 1) return 7;
                calls++;
                return (chipCountRecursive(n - 1) + chipCountRecursive(n - 2)) % 42;
            }


            int m = 8;
            calls = 0;
            Console.WriteLine($"f({m}) = {chipCountRecursive(m)}, calls: {calls}");
            m = 15;
            calls = 0;
            Console.WriteLine($"f({m}) = {chipCountRecursive(m)}, calls: {calls}");


            //task3
            //m = 1000;
            //callF = 0;
            //Console.WriteLine($"f({m}) = {f(m)}, calls: {callF}");

            int chipCountCache(int n)
            {
                if (n == 0) return 0;  

                int[] cache = new int[n + 1];
                cache[0] = 0;
                cache[1] = 7;
                for (int i = 2; i <= n; i++)
                {
                    cache[i] = (cache[i - 1] + cache[i - 2]) % 42;
                }
                return cache[n];
            }
            Console.WriteLine($"f(1000) = {chipCountCache(1000)}");

            //task4Practice

            void logRecursive(int n)
            {
                DateTime t1 = DateTime.Now;
                int result = chipCountRecursive(n);
                DateTime t2 = DateTime.Now;
                Console.WriteLine($"chipCountRecursive({n}) = {result},  \t calcTime = {t2-t1}");
            }
            void logCache(int n)
            {
                DateTime t1 = DateTime.Now;
                int result = chipCountCache(n);
                DateTime t2 = DateTime.Now;
                Console.WriteLine($"chipCountCache({n}) = {result},  \t calcTime = {t2 - t1}");
            }

            Console.WriteLine();
            //26 is critical
            //40 significant difference
            int tester = 30;
            logCache(tester);
            logRecursive(tester);
           
        }

        private static void round1()
        {
            //task1
            List<int> nums = Enumerable.Range(1, 10).ToList();
            List<int> nums2 = nums.Where(n => n % 2 == 0).ToList();
            Console.WriteLine();

            //task2
            actualFile = @"c:\Users\georg\Documents\codeAfterSoter\Megmerettetes2021 Feladatok\csatolt fajlok\r1\altalanos\1_fordulo_2_feladat.txt";
            testFile = @"c:\Users\georg\Documents\codeAfterSoter\Megmerettetes2021 Feladatok\csatolt fajlok\r1\altalanos\1_fordulo_2_feladat_test.txt";

            List<int> numbers = readNumbersFromFile(actualFile);
            //int sum = 0;
            //foreach (int n in numbers)
            //{
            //    sum += n;
            //}
            //Console.WriteLine("sum of measuring times: " + (sum*30));
            Console.WriteLine("sum of measuring times: " + numbers.Sum() * 30);
        }
        private static List<int> readNumbersFromFile(string path)
        {
            return File.ReadAllText(path).Split(',').Select(int.Parse).ToList();
        }

    }
}
