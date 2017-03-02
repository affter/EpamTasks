using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            do
            {
                Console.Write("Введите целое неотрицательное a: ");
                a = int.Parse(Console.ReadLine());
                if (a <= 0)
                    Console.WriteLine("Некорректный ввод.");
            }
            while (a <= 0);
            do
            {
                Console.Write("Введите целое неотрицательное b: ");
                b = int.Parse(Console.ReadLine());
                if (b <= 0)
                    Console.WriteLine("Некорректный ввод.");
            }
            while (b <= 0);
            Console.WriteLine($"Площадь прямоугольника S = {a * b}");
        }
    }
}
