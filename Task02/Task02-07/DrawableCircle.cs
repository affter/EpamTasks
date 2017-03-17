using System;
using FigureLibrary;

namespace Task02_07
{
    internal class DrawableCircle : Circle, IDrawable
    {
        public DrawableCircle(Point center, double radius) : base(center, radius)
        {
        }

        public void Draw()
        {
            Console.WriteLine("Тип фигуры: Окружность");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Центр: ({this.Point.X.ToString()},{this.Point.Y.ToString()})");
            Console.WriteLine($"Радиус: {this.Radius.ToString()}");
            Console.WriteLine($"Длина окружности: {this.Circumference.ToString()}");
        }
    }
}
