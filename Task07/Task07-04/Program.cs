using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task07_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            string input = Console.ReadLine();
            Regex regular = new Regex(@"^-?[\d]+(?:\.\d+)?$");
            Regex scientific = new Regex(@"^(-?)[1-9](?:\.\d+)?e\1\d+$");
            if (regular.IsMatch(input))
            {
                Console.WriteLine("Это число в обычной нотации");
            }
            else if (scientific.IsMatch(input))
            {
                Console.WriteLine("Это число в научной нотации");
            }
            else
            {
                Console.WriteLine("Это не число");
            }
        }
    }
}
