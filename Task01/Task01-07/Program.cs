using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task01_07
{
    class Program
    {
        static int[] GenerateArray(int n)
        {
            Random rand = new Random();
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(-100, 100);
            }
            return array;
        }
        static void WriteArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }
        static int Min(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }
            return min;
        }
        static int Max(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return max;
        }
        public static void QuickSort(int[] array)
        {
            QSort(array, 0, array.Length - 1);
        }
        public static void QSort(int[] array, int first, int last)
        {
            int temp;
            int x = array[first + (last - first) / 2];
            int i = first;
            int j = last;
            while (i <= j)
            {
                while (array[i] < x) i++;
                while (array[j] > x) j--;
                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }
            if (i < last)
                QSort(array, i, last);
            if (first < j)
                QSort(array, first, j);
        }
        static void Main(string[] args)
        {
            int[] array = GenerateArray(20);
            Console.WriteLine("Сгенерированный массив:");
            WriteArray(array);
            Console.WriteLine($"Максимальный элемент: {Max(array)}");
            Console.WriteLine($"Минимальный элемент: {Min(array)}");
            QuickSort(array);
            Console.WriteLine("Отсортированный массив массив:");
            WriteArray(array);
        }
    }
}
