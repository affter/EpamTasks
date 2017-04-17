using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task07_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку: ");
            string input = Console.ReadLine();
            string pattern = "(?:(?:0[1-9]|[1-2][0-9])-(?:0[1-9]|1[0-2])-|30-(?:0[469]|11)-|31-(?:0[13578]|1[02])-)\\d{4}";
            if (Regex.IsMatch(input, pattern))
            {
                Console.WriteLine("В строке есть дата в формате dd-mm-yyyy");
            }
            else
            {
                Console.WriteLine("В строке нет даты в формате dd-mm-yyyy");
            }
        }
    }
}
