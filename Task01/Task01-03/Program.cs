using System;

namespace Task01_03
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
            {
                Console.Write(new string(' ', N - i));
                Console.WriteLine(new string('*', 2 * i - 1));
            }
        }
    }
}