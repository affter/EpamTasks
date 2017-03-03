using System;

namespace Task01_02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int N;
            do
            {
                Console.Write("Введите целое неотрицательное N: ");
                if (!int.TryParse(Console.ReadLine(), out N) || N <= 0)
                    Console.WriteLine("Некорректный ввод");
            }
            while (N <= 0);

            for (int i = 1; i <= N; i++)
                Console.WriteLine(new string('*', i));
        }
    }
}