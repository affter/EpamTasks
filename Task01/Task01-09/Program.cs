using System;

namespace Task01_09
{
    internal class Program
    {
        private static Random rand = new Random();

        public static void FillArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-50, 50);
            }
        }

        public static int NonNegativeSum(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    sum += array[i];
                }
            }

            return sum;
        }

        public static void WriteArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }

            Console.WriteLine();
        }

        private static void Main(string[] args)
        {
            int[] array = new int[20];
            FillArray(array);
            WriteArray(array);
            Console.WriteLine($"Сумма неотрицательных элементов массива равна {NonNegativeSum(array)}");
        }
    }
}
