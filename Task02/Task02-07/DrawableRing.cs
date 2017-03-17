using System;
using FigureLibrary;

namespace Task02_07
{
    internal class DrawableRing : Ring, IDrawable
    {
        public DrawableRing(Point center, double innerRadius, double outerRadius) : base(center, innerRadius, outerRadius)
        {
        }

        public void Draw()
        {
            Console.WriteLine("Тип фигуры: Кольцо");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Центр: ({this.Point.X.ToString()},{this.Point.Y.ToString()})");
            Console.WriteLine($"Внешний радиус: {this.Radius.ToString()}");
            Console.WriteLine($"Внутренний радиус: {this.InnerRadius.ToString()}");
            Console.WriteLine($"Сумма длин окружностей: {this.Circumference.ToString()}");
            Console.WriteLine($"Площадь: {this.Area.ToString()}");
        }
    }
}
