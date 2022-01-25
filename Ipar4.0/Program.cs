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

            //round2();
            //round3();
            round4();
            round4officialSolution();
            Console.Read();
        }

        private static void round4officialSolution()
        {
            testFile = @"c:\Users\georg\Documents\codeAfterSoter\Megmerettetes2021 Feladatok\csatolt fajlok\r4\altalanos\4_fordulo_2_feladat_test.txt";
            actualFile = @"c:\Users\georg\Documents\codeAfterSoter\Megmerettetes2021 Feladatok\csatolt fajlok\r4\altalanos\4_fordulo_2_feladat.txt";


            var s = File.ReadAllText(actualFile);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (char c in s)
            {
                string key = c.ToString().ToLower();
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, 0);
                }
                if (char.IsUpper(c))
                {
                    dict[key]++;
                }
                else
                {
                    dict[key]--;
                }
            }

            List<string> keys = dict.Keys.OrderBy(d => d).ToList();
            IEnumerable<string> values = keys.Select(k => $"{k}:{dict[k]}");

            Console.WriteLine(string.Join(",",values));
        }

        private static void round4()
        {
            //task1 - heap and stack, memory management

            //task2
            testFile = @"c:\Users\georg\Documents\codeAfterSoter\Megmerettetes2021 Feladatok\csatolt fajlok\r4\altalanos\4_fordulo_2_feladat_test.txt";
            actualFile = @"c:\Users\georg\Documents\codeAfterSoter\Megmerettetes2021 Feladatok\csatolt fajlok\r4\altalanos\4_fordulo_2_feladat.txt";

            List<char> testedQuailties = readLettersFromFile(actualFile);
            SortedDictionary<char, int> evaluation = new SortedDictionary<char, int>();

            int caseToValue(char c)
            {
                if (Char.IsUpper(c)) return 1;
                else return -1;
            }

            foreach (char c in testedQuailties)
            {
                char key = Char.ToLower(c);
                if (evaluation.ContainsKey(key))
                {
                    evaluation[key] += caseToValue(c);
                }
                else
                {
                    evaluation.Add(key, caseToValue(c));
                }
            }

            foreach (var item in evaluation)
            {
                Console.Write($"{item.Key}:{item.Value},");
            }
            Console.WriteLine();

        }

        class intWrapper //: IEquatable<intWrapper>
        {
            public int N { get; set; }

            public intWrapper(int n)
            {
                N = n;
            }

            //public static bool operator ==(intWrapper n1, intWrapper n2)
            //{
            //    return n1.N == n2.N;
            //}
            //public static bool operator !=(intWrapper n1, intWrapper n2)
            //{
            //    return n1.N != n2.N;
            //}

            //quick actions - generate Equals and GetHashCode - implement IEquatable<intWrapper>
            //public override bool Equals(object obj)
            //{
            //    return Equals(obj as intWrapper);
            //}

            //public bool Equals(intWrapper other)
            //{
            //    return other != null &&
            //           N == other.N;
            //}

            //public override int GetHashCode()
            //{
            //    return HashCode.Combine(N);
            //}
        }
        private static void round3()
        {
            //task1

            List<int> numbers = new List<int> { 1, 2, 3, 3, 3, 4 };
            var result = numbers.Select(n => new intWrapper(n)).Distinct().ToList();
            //var result = numbers.Select(n => n+1).Distinct().ToList();
            Console.WriteLine("res.count: " + result.Count());

            var r2 = numbers.Select(n => n * 2).Distinct();
            Console.WriteLine("r2.count: " + r2.Count());
            Console.WriteLine("");

            //task2
            int[] waferSizes = { 1000, 541, 224, 25, 1 };

            int t = 1025;
            int getTotalWaferCount(int cpuCount)
            {
                int waferCount = 0;
                int sizeInd = 0;
                while (cpuCount > 0)
                {
                    waferCount += cpuCount / waferSizes[sizeInd];
                    cpuCount %= waferSizes[sizeInd];
                    sizeInd++;
                }
                return waferCount;
            }

            Console.WriteLine($"wafercount(t): {getTotalWaferCount(t)} \nt= {t}");

            actualFile = @"c:\Users\georg\Documents\codeAfterSoter\Megmerettetes2021 Feladatok\csatolt fajlok\r3\altalanos\3_fordulo_2_feladat.txt";
            testFile = @"c:\Users\georg\Documents\codeAfterSoter\Megmerettetes2021 Feladatok\csatolt fajlok\r3\altalanos\3_fordulo_2_feladat_test.txt";
            List<int> cpuRequests = readNumbersFromFile(actualFile);

            int totalWaferCount = 0;
            //foreach (int req in cpuRequests)
            //{
            //    totalWaferCount += getTotalWaferCount(req);
            //}

            totalWaferCount = cpuRequests.Sum(n => getTotalWaferCount(n));

            Console.WriteLine("totatl wafer count = " + totalWaferCount);



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
                Console.WriteLine($"chipCountRecursive({n}) = {result},  \t calcTime = {t2 - t1}");
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
        
        private static List<char> readLettersFromFile(string path)
        {
            return File.ReadAllText(path).ToList();
        }

    }
}
