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
        private static Random rnd = new Random();

        private static double CalculateAverageTime(int[] array, Func<int[], IEnumerable<int>> func)
        {
            double sumOfResults = 0;
            int calculationCount = 10;
            var stopWatch = new Stopwatch();

            for (int i = 0; i < calculationCount; i++)
            {
                stopWatch.Start();
                var a = func(array);
                a.Count();
                stopWatch.Stop();
                sumOfResults += stopWatch.Elapsed.TotalMilliseconds;
                stopWatch.Reset();
            }

            return sumOfResults / calculationCount;
        }

        private static double CalculateAverageTime(int[] array, Predicate<int> predicate, Func<int[], Predicate<int>, IEnumerable<int>> func)
        {
            double sumOfResults = 0;
            int calculationCount = 10;
            var stopWatch = new Stopwatch();

            for (int i = 0; i < calculationCount; i++)
            {
                stopWatch.Start();
                var a = func(array, predicate);
                a.Count();
                stopWatch.Stop();
                sumOfResults += stopWatch.Elapsed.TotalMilliseconds;
                stopWatch.Reset();
            }

            return sumOfResults / calculationCount;
        }

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

        private static void FillArray(int[] array)
        {
            int arrayLength = array.Length;
            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = rnd.Next(-arrayLength, arrayLength);
            }
        }

        private static void Main(string[] args)
        {
            int[] array = new int[2000000];
            int arrayLength = array.Length;
            int numberOfTests = 5;
            double sumOfFirstMethodResults = 0;
            double sumOfSecondMethodResults = 0;
            double sumOfThirdMethodResults = 0;
            double sumOfFourthMethodResults = 0;
            double sumOfFifthMethodResults = 0;
            Predicate<int> predicate1 = delegate (int x) { return x > 0; };
            Predicate<int> predicate2 = (x) => x > 0;

            for (int i = 0; i < numberOfTests; i++)
            {
                FillArray(array);
                sumOfFirstMethodResults += CalculateAverageTime(array, TestedMethods.FindAllPositive);
                sumOfSecondMethodResults += CalculateAverageTime(array, ComparisonMethod, TestedMethods.FindAll);
                sumOfThirdMethodResults += CalculateAverageTime(array, predicate1, TestedMethods.FindAll);
                sumOfFourthMethodResults += CalculateAverageTime(array, predicate2, TestedMethods.FindAll);
                sumOfFifthMethodResults += CalculateAverageTime(array, TestedMethods.FindAllPositiveLinq);
            }


            Console.WriteLine($"Среднее время работы метода, непосредственно реализующего поиск: {(sumOfFirstMethodResults / numberOfTests).ToString()} мс.");
            Console.WriteLine($"Среднее время работы метода, которому условие поиска передаётся через экземпляр делегата: {(sumOfSecondMethodResults / numberOfTests).ToString()} мс.");
            Console.WriteLine($"Среднее время работы метода, которому условие поиска передаётся через делегат в виде анонимного метода: {(sumOfThirdMethodResults / numberOfTests).ToString()} мс.");
            Console.WriteLine($"Среднее время работы метода, которому условие поиска передаётся через делегат в виде лямбда-выражения: {(sumOfFourthMethodResults / numberOfTests).ToString()} мс.");
            Console.WriteLine($"Среднее время работы LINQ выражения: {(sumOfFifthMethodResults / numberOfTests).ToString()} мс.");
        }
    }
}
