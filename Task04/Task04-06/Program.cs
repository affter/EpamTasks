using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04_06
{
    internal class Program
    {
        private static bool ComparisonMethod(int x)
        {
            return x > 0;
        }

        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            var array = new int[200000000];
            var rnd = new Random();
            var arrayLength = array.Length;
            Predicate<int> predicate1 = delegate (int x) { return x > 0; };
            Predicate<int> predicate2 = (x) => x > 0;

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = rnd.Next(-arrayLength, arrayLength);
            }

            stopWatch.Start();
            array.FindAllPositive();
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
            stopWatch.Reset();
        }
    }
}
