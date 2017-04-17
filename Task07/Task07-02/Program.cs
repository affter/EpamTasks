using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task07_02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Введите текст: ");
            string input = Console.ReadLine();
            Regex regex = new Regex("<(.+?)>");
            string output = regex.Replace(input, "_");
            Console.WriteLine($"Результат замены: {output}");
        }
    }
}
