using System;
using FigureLibrary;

namespace Task02_07
{
    internal class LineUI : FigureUI
    {
        private Line line;

        public LineUI(Line line)
        {
            this.line = line;
        }

        public override void Draw()
        {
            Console.WriteLine("Тип фигуры: Линия");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Точка начала: ({line.Point.X.ToString()},{line.Point.Y.ToString()})");
            Console.WriteLine($"Точка конца: ({line.End.X.ToString()},{line.End.Y.ToString()})");
        }
    }
}
