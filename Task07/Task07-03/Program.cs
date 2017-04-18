using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task07_03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Иван: ivan@mail.ru Петр: p_ivanov@mail.rol.ru
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();
            Regex regex = new Regex(@"[^\W_](?:[\w\.-]*[^\W_])*@(?:(?:[^\W_]|-)*\.)*(?:[^\W_]|-){2,6}");
            var emails = regex.Matches(input);
            Console.WriteLine("Найденные адреса электронной почты:");
            for (int i = 0; i < emails.Count; i++)
            {
                Console.WriteLine(emails[i]);
            }
        }
    }
}
