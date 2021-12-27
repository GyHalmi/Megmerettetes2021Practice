using System;
using System.Collections.Generic;
using System.Linq;

namespace Ipar4._0
{
    class Program
    {
        static void Main(string[] args)
        {
            round1();

            Console.Read();
        }

        private static void round1()
        {
            List<int> numbers = Enumerable.Range(1, 10).ToList();
            List<int> nums2 =  numbers.Where(n => n % 2 == 0).ToList();
            Console.WriteLine();
        }
    }
}
