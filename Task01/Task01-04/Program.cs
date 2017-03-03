using System;

namespace Task01_04
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
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(new string(' ', n - j));
                    Console.WriteLine(new string('*', (2 * j) - 1));
                }
            }        
        }
    }
}