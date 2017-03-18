using System;
using FigureLibrary;

namespace Task02_07
{
    internal class DrawableRectangle : Rectangle, IDrawable
    {
        public DrawableRectangle(Point upperLeftCorner, double width, double height) : base(upperLeftCorner, width, height)
        {
        }

        public void Draw()
        {
            Console.WriteLine("Тип фигуры: Прямоугольник");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Левый верхний угол: ({this.Point.X.ToString()},{this.Point.Y.ToString()})");
            Console.WriteLine($"Ширина: {this.Width.ToString()}");
            Console.WriteLine($"Высота: {this.Height.ToString()}");
            Console.WriteLine($"Периметр: {this.Perimeter.ToString()}");
            Console.WriteLine($"Площадь: {this.Area.ToString()}");
        }
    }
}
