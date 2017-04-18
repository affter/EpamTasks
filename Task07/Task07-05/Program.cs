using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task07_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите текст: ");
            string input = Console.ReadLine();
            Regex timePattern = new Regex(@"(?:[01]?[0-9]|2[0-3]):[0-5][0-9]");
            Console.WriteLine($"Время в тексте присутствует {timePattern.Matches(input).Count} раз");
        }
    }
}
