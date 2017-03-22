using System;
using System.Collections.Generic;
using System.Linq;

namespace Task03_01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = 0;
            n = GetNumber(n);
            var people = new LinkedList<int>();
            FillList(n, people);
            CountOut(people, n);
            Console.WriteLine($"Останется человек под номером {people.First.Value.ToString()}");
        }

        private static void CountOut(LinkedList<int> people, int n)
        {
            var currentNode = people.First;
            while (people.Count != 1)
            {
                var nodeForRemove = currentNode.Next ?? people.First;
                people.Remove(nodeForRemove);
                currentNode = currentNode.Next ?? people.First;
            }
        }

        private static void FillList(int n, LinkedList<int> people)
        {
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
