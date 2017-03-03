using System;

namespace Task01_03
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("Введите целое неотрицательное N: ");
                if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            while (n <= 0);
            for (int i = 1; i <= n; i++)
            {
                Console.Write(new string(' ', n - i));
                Console.WriteLine(new string('*', (2 * i) - 1));
            }
        }
    }
}