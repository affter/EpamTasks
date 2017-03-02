using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            do
            {
                Console.Write("Введите целое неотрицательное N: ");
                if (!int.TryParse(Console.ReadLine(), out N) || N <= 0)
                    Console.WriteLine("Некорректный ввод");
            }
            while (N <= 0);
            
            for (int i = 1; i <= N; i++)
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(new string(' ', N - j));
                    Console.WriteLine(new string('*', 2 * j - 1));
                }
        }
    }
}
