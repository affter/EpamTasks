using System;
using System.Linq;

namespace Task01_12
{
    internal class Program
    {
        private static char[] Duplicate(char[] input, char[] duplicators)
        {
            int length = input.Length;
            char[] output = new char[length * 2];
            int j = 0;

            for (int i = 0; i < length; i++)
            {
                if (duplicators.Contains(input[i]))
                {
                    output[j] = input[i];
                    output[j + 1] = input[i];
                    j += 2;
                }
                else
                {
                    output[j] = input[i];
                    j++;
                }
            }

            return output;
        }

        private static void Main(string[] args)
        {
            Console.Write("Введите первую строку: ");
            char[] input = Console.ReadLine().ToCharArray();
            Console.Write("Введите вторую строку: ");
            char[] duplicators = Console.ReadLine().Distinct().ToArray();
            char[] output = Duplicate(input, duplicators);
            Console.WriteLine($"Результирующая строка: {new string(output)}");
        }
    }
}
