using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Triangle triangle = new Triangle(3, 4, 5);
            Console.WriteLine($"Создан треугольник со сторонами {triangle.A.ToString()},{triangle.B.ToString()},{triangle.C.ToString()}");
            Console.WriteLine($"Периметр треугольника равен {triangle.Perimeter.ToString()}");
            Console.WriteLine($"Площадь треугольника равна {triangle.Area.ToString()}");
            triangle.A = 2;
            Console.WriteLine($"Длина стороны a изменена. а = {triangle.A.ToString()}");
            triangle.B = 3;
            Console.WriteLine($"Длина стороны b изменена. b = {triangle.B.ToString()}");
            triangle.C = 4;
            Console.WriteLine($"Длина стороны c изменена. c = {triangle.C.ToString()}");
            Console.WriteLine($"Периметр треугольника равен {triangle.Perimeter.ToString()}");
            Console.WriteLine($"Площадь треугольника равна {triangle.Area.ToString()}");
        }
    }
}
