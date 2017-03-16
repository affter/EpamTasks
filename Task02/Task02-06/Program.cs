using System;
using FigureLibrary;

namespace Task02_06
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Ring ring = new Ring(new Point(0, 0), 2, 3);
            Console.WriteLine("Создано кольцо со следующими параметрами:");
            Console.WriteLine($"Внутренний радиус: {ring.InnerRadius.ToString()}");
            Console.WriteLine($"Внешний радиус: {ring.Radius.ToString()}");
            Console.WriteLine($"Центр: ({ring.Point.X.ToString()},{ring.Point.Y.ToString()})");
            Console.WriteLine($"Площадь: {ring.Area.ToString()}");
            Console.WriteLine($"Сумма окружностей: {ring.Circumference.ToString()}");
        }
    }
}