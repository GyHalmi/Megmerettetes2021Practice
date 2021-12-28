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
            round1();

            Console.Read();
        }

       
        private static void round1()
        {
            //task1
            List<int> nums = Enumerable.Range(1, 10).ToList();
            List<int> nums2 =  nums.Where(n => n % 2 == 0).ToList();
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
            Console.WriteLine("sum of measuring times: " + numbers.Sum()*30);

            Func<string, int> parser = int.Parse;

        }
        private static List<int> readNumbersFromFile(string path)
        {
            return File.ReadAllText(path).Split(',').Select(int.Parse).ToList();
        }

    }
}
