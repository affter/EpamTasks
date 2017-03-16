using System;
using FigureLibrary;

namespace Task02_07
{
    internal class RectangleUI : FigureUI
    {
        private Rectangle rect;

        public RectangleUI(Rectangle rect)
        {
            this.rect = rect;
        }

        public override void Draw()
        {
            Console.WriteLine("Тип фигуры: Прямоугольник");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Левый верхний угол: ({rect.Point.X.ToString()},{rect.Point.Y.ToString()})");
            Console.WriteLine($"Ширина: {rect.Width.ToString()}");
            Console.WriteLine($"Высота: {rect.Heigth.ToString()}");
            Console.WriteLine($"Периметр: {rect.Perimeter.ToString()}");
            Console.WriteLine($"Площадь: {rect.Area.ToString()}");
        }
    }
}
