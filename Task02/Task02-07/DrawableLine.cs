using System;
using FigureLibrary;

namespace Task02_07
{
    internal class DrawableLine : Line, IDrawable
    {
        public DrawableLine(Point start, Point end) : base(start, end)
        {
        }

        public void Draw()
        {
            Console.WriteLine("Тип фигуры: Линия");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Точка начала: ({this.Point.X.ToString()},{this.Point.Y.ToString()})");
            Console.WriteLine($"Точка конца: ({this.End.X.ToString()},{this.End.Y.ToString()})");
        }
    }
}
