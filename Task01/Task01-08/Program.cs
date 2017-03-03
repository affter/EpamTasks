using System;

namespace Task01_08
{
    internal class Program
    {
        private static Random rand = new Random();

        public static void Fill3DArray(int[,,] array)
        {
            for (int i = 0; i < array.GetUpperBound(0); i++)
            {
                for (int j = 0; j < array.GetUpperBound(1); j++)
                {
                    for (int k = 0; k < array.GetUpperBound(2); k++)
                    {
                        array[i, j, k] = rand.Next(-50, 50);
                    }
                }
            }
        }

        public static void NullifyPositive(int[,,] array)
        {
            for (int i = 0; i < array.GetUpperBound(0); i++)
            {
                for (int j = 0; j < array.GetUpperBound(1); j++)
                {
                    for (int k = 0; k < array.GetUpperBound(2); k++)
                    {
                        if (array[i, j, k] > 0)
                        {
                            array[i, j, k] = 0;
                        }
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            int[,,] array = new int[10, 10, 10];
            Fill3DArray(array);
            NullifyPositive(array);
        }
    }
}