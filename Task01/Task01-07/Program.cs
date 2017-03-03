using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task01_07
{
    class Program
    {
        static Random rand = new Random();
        static int[] GenerateArray(int n)
        {
            
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
            QuickSort(array, 0, array.Length - 1);
        }
        public static void QuickSort(int[] array, int first, int last)
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
                QuickSort(array, i, last);
            if (first < j)
                QuickSort(array, first, j);
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
