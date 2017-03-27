using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04_03
{
    internal class Program
    {
        private static bool ComparisonMethod(int x1, int x2)
        {
            if (x1 > x2)
            {
                return true;
            }

            return false;
        }
        
        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }

            Console.WriteLine();
        }

        private static void Main(string[] args)
        {
            var sortingUnit = new SortingUnit();
            var array = new int[20];
            var rnd = new Random();
            var arrayLength = array.Length;

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = rnd.Next(-arrayLength, arrayLength);
            }

            Console.WriteLine("Массив: ");
            PrintArray(array);
            Console.WriteLine("Сортировка начата");
            sortingUnit.SortComplete += () =>
            {
                Console.WriteLine("Закончена сортировка в отдельном потоке");
                PrintArray(array);
            };

            sortingUnit.ThreadedSort(array, comparisonMethod);
        }
    }
}
