using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01_02
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
                Console.WriteLine(new string('*', i));
        }
    }
}
