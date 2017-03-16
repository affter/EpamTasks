using System;
using FigureLibrary;

namespace Task02_07
{
    internal class RoundUI : FigureUI
    {
        private Round round;

        public RoundUI(Round round)
        {
            this.round = round;
        }

        public override void Draw()
        {
            Console.WriteLine("Тип фигуры: Круг");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Центр: ({round.Point.X.ToString()},{round.Point.Y.ToString()})");
            Console.WriteLine($"Радиус: {round.Radius.ToString()}");
            Console.WriteLine($"Длина окружности: {round.Circumference.ToString()}");
            Console.WriteLine($"Площадь: {round.Area.ToString()}");
        }
    }
}
