using System;
using System.Collections.Generic;

namespace Task03_01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = 0;
            n = GetNumber(n);
            var people = new List<int>(n);
            FillList(n, people);
            RemoveEverySecond(people);
            Console.WriteLine($"Останется человек под номером {people[0].ToString()}");
        }

        private static void RemoveEverySecond(List<int> people)
        {
            int removeIndex = 0;
            while (people.Count != 1)
            {
                for (int i = 0; i < people.Count; i++)
                {
                    removeIndex = (removeIndex + 1) % people.Count;
                    people.RemoveAt(removeIndex);
                }
            }
        }

        private static void FillList(int n, List<int> people)
        {
            for (int i = 1; i <= n; i++)
            {
                people.Add(i);
            }
        }

        private static int GetNumber(int n)
        {
            do
            {
                try
                {
                    Console.Write("Введите N: ");
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
