using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_06
{
    class Program
    {
        static void Main(string[] args)
        {
            Ring ring = new Ring(0,0,2,3);
            Console.WriteLine("Создано кольцо со следующими параметрами:");
            Console.WriteLine($"Внутренний радиус: {ring.InnerRadius.ToString()}");
            Console.WriteLine($"Внешний радиус: {ring.OuterRadius.ToString()}");
            Console.WriteLine($"Центр: ({ring.centerX.ToString()},{ring.centerY.ToString()})");
            Console.WriteLine($"Площадь: {ring.Area.ToString()}");
            Console.WriteLine($"Сумма окружностей: {ring.SumOfCircumferences.ToString()}");
        }
    }
}
