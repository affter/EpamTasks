using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04_06
{
    public class Program
    {
        private static Random rnd = new Random();

        private static double CalculateAverageTime(int[] array, Func<int[], IEnumerable<int>> func)
        {
            int calculationCount = 50;
            double[] measures = new double[calculationCount];
            Stopwatch stopWatch = new Stopwatch();

            for (int i = 0; i < calculationCount; i++)
            {
                stopWatch.Start();
                var a = func(array);
                a.Count();
                stopWatch.Stop();
                measures[i] = stopWatch.Elapsed.TotalMilliseconds;
                stopWatch.Reset();
            }

            Array.Sort(measures);
            return measures[measures.Length / 2];
        }

        private static double CalculateAverageTime(int[] array, Predicate<int> predicate, Func<int[], Predicate<int>, IEnumerable<int>> func)
        {
            int calculationCount = 50;
            double[] measures = new double[calculationCount];
            var stopWatch = new Stopwatch();

            for (int i = 0; i < calculationCount; i++)
            {
                stopWatch.Start();
                var a = func(array, predicate);
                a.Count();
                stopWatch.Stop();
                measures[i] = stopWatch.Elapsed.TotalMilliseconds;
                stopWatch.Reset();
            }

            Array.Sort(measures);
            return measures[measures.Length / 2];
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

        public static void Main(string[] args)
        {
            int[] array = new int[2000000];
            int arrayLength = array.Length;
            int numberOfTests = 5;
            double[] firstMethodResults = new double[numberOfTests];
            double[] secondMethodResults = new double[numberOfTests];
            double[] thirdMethodResults = new double[numberOfTests];
            double[] fourthMethodResults = new double[numberOfTests];
            double[] fifthMethodResults = new double[numberOfTests];
            Predicate<int> predicate1 = delegate(int x) { return x > 0; };
            Predicate<int> predicate2 = (x) => x > 0;

            for (int i = 0; i < numberOfTests; i++)
            {
                FillArray(array);
                firstMethodResults[i] = CalculateAverageTime(array, TestedMethods.FindAllPositive);
                secondMethodResults[i] = CalculateAverageTime(array, ComparisonMethod, TestedMethods.FindAll);
                thirdMethodResults[i] = CalculateAverageTime(array, predicate1, TestedMethods.FindAll);
                fourthMethodResults[i] = CalculateAverageTime(array, predicate2, TestedMethods.FindAll);
                fifthMethodResults[i] = CalculateAverageTime(array, TestedMethods.FindAllPositiveLinq);
            }

            Array.Sort(firstMethodResults);
            Array.Sort(secondMethodResults);
            Array.Sort(thirdMethodResults);
            Array.Sort(fourthMethodResults);
            Array.Sort(fifthMethodResults);

            Console.WriteLine($"Среднее время работы метода, непосредственно реализующего поиск: {firstMethodResults[firstMethodResults.Length / 2].ToString()} мс.");
            Console.WriteLine($"Среднее время работы метода, которому условие поиска передаётся через экземпляр делегата: {secondMethodResults[secondMethodResults.Length / 2].ToString()} мс.");
            Console.WriteLine($"Среднее время работы метода, которому условие поиска передаётся через делегат в виде анонимного метода: {thirdMethodResults[thirdMethodResults.Length / 2].ToString()} мс.");
            Console.WriteLine($"Среднее время работы метода, которому условие поиска передаётся через делегат в виде лямбда-выражения: {fourthMethodResults[fourthMethodResults.Length / 2].ToString()} мс.");
            Console.WriteLine($"Среднее время работы LINQ выражения: {fifthMethodResults[fifthMethodResults.Length / 2].ToString()} мс.");
        }
    }
}
