using System;
using FigureLibrary;
namespace Task02_07
{
    class CircleUI : FigureUI
    {
        Circle circle;

        public CircleUI(Circle circle)
        {
            this.circle = circle;
        }

        public override void Draw()
        {
            Console.WriteLine("Тип фигуры: Окружность");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Центр: ({circle.Point.X.ToString()},{circle.Point.Y.ToString()})");
            Console.WriteLine($"Радиус: {circle.Radius.ToString()}");
            Console.WriteLine($"Длина окружности: {circle.Circumference.ToString()}");
        }
    }
}
