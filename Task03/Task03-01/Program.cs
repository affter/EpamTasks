using System;
using System.Collections.Generic;

namespace Task03_01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var people = new LinkedList<int>();
            int n = 0;
            n = GetNumber(n);

            for (int i = 1; i <= n; i++)
            {
                people.AddLast(i);
            }
        }

        private static int GetNumber(int n)
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите N: ");
                    n = int.Parse(Console.ReadLine());
                    if (n <= 0)
                    {
                        Console.WriteLine("Некорректный ввод");
                    }
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            while (n <= 0);
            return n;
        }
    }
}
