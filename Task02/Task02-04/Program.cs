using System;

namespace Task02_04
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MyString first;
            MyString second;
            Console.Write("Введите первую строку: ");
            first = new MyString(Console.ReadLine());
            Console.Write("Введите вторую строку: ");
            second = new MyString(Console.ReadLine());
            MyString concat = first + second;
            Console.WriteLine($"Конкатенация строк: {concat.ToString()}");
            Console.WriteLine($"Подстрока конкатенации, начиная с индекса 2: {concat.Substring(2).ToString()}");
            Console.WriteLine($"Подстрока конкатенации длины 4, начиная с индекса 2: {concat.Substring(2, 4).ToString()}");
            Console.Write("Введите строку или символ, индекс которого вы хотите найти в конкатенации строк: ");
            string find = Console.ReadLine();
            int index = concat.IndexOf(new MyString(find));
            if (index == -1)
            {
                Console.WriteLine("Данный символ или подстрока не найден");
            }
            else
            {
                Console.WriteLine($"Заданный вами символ или строка находится в позиции {index}");
            }

            Console.Write("Введите строку или символ, который нужно заменить в данной строке: ");
            string oldReplace = Console.ReadLine();
            Console.Write("Введите строку или символ, на который нужно заменить введенный: ");
            string newReplace = Console.ReadLine();
            Console.WriteLine($"Результат замены: {concat.Replace(new MyString(oldReplace), new MyString(newReplace))}");
        }
    }
}