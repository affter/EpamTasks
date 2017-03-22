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
            var wordsFrequency = new Dictionary<string, double>();

            Console.WriteLine("Введите текст:");
            text = Console.ReadLine().ToLower();
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            CalculateFrequency(wordsFrequency, words);

            foreach (var word in wordsFrequency)
            {
                Console.WriteLine($"Частота, с которой слово {word.Key} встречается в тексте: {word.Value.ToString()}");
            }
        }

        private static void CalculateFrequency(Dictionary<string, double> wordsFrequency, string[] words)
        {
            double length = words.Length;
            for (int i = 0; i < length; i++)
            {
                double value = 0;
                double increment = 1 / length;
                if (wordsFrequency.TryGetValue(words[i], out value))
                {
                    wordsFrequency[words[i]] = value + increment;
                }
                else
                {
                    wordsFrequency.Add(words[i], increment);
                }
            }
        }
    }
}
