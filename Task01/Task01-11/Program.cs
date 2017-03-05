using System;

namespace Task01_11
{
    internal class Program
    {
        private static char[] AllSeparators()
        {
            var array = new char[char.MaxValue + 1];
            int j = 0;

            for (char i = (char)0; i < char.MaxValue; i++)
            {
                if (char.IsWhiteSpace(i) || char.IsSeparator(i) || char.IsPunctuation(i))
                {
                    array[j] = i;
                    j++;
                }
            }

            var output = new char[j];
            Array.Copy(array, output, j);
            return output;
        }

        private static void Main(string[] args)
        {
            var sum = 0.0;
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            string[] words = input.Split(AllSeparators());
            var wordsLength = words.Length;
            for (int i = 0; i < wordsLength; i++)
            {
                sum += words[i].Length;
            }

            Console.WriteLine($"Средняя длина слова во введенной строке: {sum / wordsLength}");
        }
    }
}
