using System;

namespace Task01_11
{
    internal class Program
    {
        private static char[] FindSeparators(string input)
        {
            var array = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsSeparator(input[i]) || char.IsPunctuation(input[i]))
                {
                    array[i] = input[i];
                }
            }

            return array;
        }

        private static void Main(string[] args)
        {
            var sum = 0;
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            string[] words = input.Split(FindSeparators(input), StringSplitOptions.RemoveEmptyEntries);
            var wordsLength = words.Length;
            for (int i = 0; i < wordsLength; i++)
            {
                sum += words[i].Length;
            }

            Console.WriteLine($"Средняя длина слова во введенной строке: {(double)sum / wordsLength}");
        }
    }
}
