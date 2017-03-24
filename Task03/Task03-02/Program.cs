using System;
using System.Collections.Generic;

namespace Task03_02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string text;
            char[] separators = { ' ', '.' };
            var wordsFrequency = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);

            Console.WriteLine("Введите текст:");
            text = Console.ReadLine();
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            CalculateFrequency(wordsFrequency, words);
            int wordsCount = wordsFrequency.Count;

            foreach (var word in wordsFrequency)
            {
                Console.WriteLine($"Частота, с которой слово {word.Key} встречается в тексте: {((double)word.Value / wordsCount).ToString()}");
            }
        }

        private static void CalculateFrequency(Dictionary<string, int> wordsFrequency, string[] words)
        {
            double length = words.Length;
            for (int i = 0; i < length; i++)
            {
                int value = 0;
                if (wordsFrequency.TryGetValue(words[i], out value))
                {
                    wordsFrequency[words[i]] = value++;
                }
                else
                {
                    wordsFrequency.Add(words[i], 1);
                }
            }
        }
    }
}
