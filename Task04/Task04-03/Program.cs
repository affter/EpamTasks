using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04_03
{
    internal class Program
    {
        private static int ComparisonMethod(int x1, int x2)
        {
            return x1 - x2;
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

            Console.WriteLine("Массив:");
            PrintArray(array);
            Console.WriteLine("Сортировка начата");
            sortingUnit.SortComplete += (object sender, EventArgs e) =>
            {
                Console.WriteLine("Отсортированный массив:");
                PrintArray(array);
            };

            sortingUnit.ThreadedSort(array, ComparisonMethod);
        }
    }
}
