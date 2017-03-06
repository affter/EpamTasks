using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01_10
{
    internal class Program
    {
        private static Random rand = new Random();

        private static void Fill2DArray(int[,] array)
        {
            for (int i = 0; i <= array.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= array.GetUpperBound(1); j++)
                {
                    array[i, j] = rand.Next(-50, 50);
                }
            }
        }

        private static void Write2DArray(int[,] array)
        {
            for (int i = 0; i <= array.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= array.GetUpperBound(1); j++)
                {
                    Console.Write($"{array[i, j]}\t");
                }

                Console.WriteLine();
            }
        }

        private static int Sum(int[,] array)
        {
            int sum = 0;
            int rowsCount = array.GetUpperBound(0);

            for (int i = 0; i <= rowsCount; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j <= rowsCount; j += 2)
                    {
                        sum += array[i, j];
                    }
                }
                else
                {
                    for (int j = 1; j <= array.GetUpperBound(1); j += 2)
                    {
                        sum += array[i, j];
                    }
                }
            }

            return sum;
        }

        private static void Main(string[] args)
        {
            int[,] array = new int[5, 5];
            Fill2DArray(array);
            Write2DArray(array);
            Console.WriteLine($"Сумма элементов, стоящих на четных позициях равна {Sum(array)}");
        }
    }
}
