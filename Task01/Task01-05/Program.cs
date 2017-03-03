using System;

namespace Task01_05
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int a1 = 3,
                            b1 = 5,
                            n = 1000,
                            c1 = a1 * b1,
                            n1 = (n - 1) / a1,
                            n2 = (n - 1) / b1,
                            n3 = (n - 1) / c1,
                            sum1 = a1 * (n1 + 1) * n1,
                            sum2 = b1 * (n2 + 1) * n2,
                            sum3 = c1 * (n3 + 1) * n3;
            Console.WriteLine($"Сумма чисел, меньших тысячи, и кратных 3 или 5 равна {((sum1 + sum2 - sum3) / 2)}");
        }
    }
}