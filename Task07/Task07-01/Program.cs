using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task07_01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Введите текст, содержащий дату в формате dd-mm-yyyy: ");
            string input = Console.ReadLine();
            string pattern = "(?:(?:0[1-9]|[1-2][0-9])-(?:0[1-9]|1[0-2])-|30-(?:0[469]|11)-|31-(?:0[13578]|1[02])-)\\d{4}";
            if (Regex.IsMatch(input, pattern))
            {
                Console.WriteLine($"В тексте \"{input}\" содержится дата");
            }
            else
            {
                Console.WriteLine($"В тексте \"{input}\" не содержится дата");
            }
        }
    }
}
