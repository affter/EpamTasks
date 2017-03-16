using System;
using FigureLibrary;

namespace Task02_07
{
    internal class RingUI : FigureUI
    {
        private Ring ring;

        public RingUI(Ring ring)
        {
            this.ring = ring;
        }

        public override void Draw()
        {
            Console.WriteLine("Тип фигуры: Кольцо");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Центр: ({ring.Point.X.ToString()},{ring.Point.Y.ToString()})");
            Console.WriteLine($"Внешний радиус: {ring.Radius.ToString()}");
            Console.WriteLine($"Внутренний радиус: {ring.InnerRadius.ToString()}");
            Console.WriteLine($"Сумма длин окружностей: {ring.Circumference.ToString()}");
            Console.WriteLine($"Площадь: {ring.Area.ToString()}");
        }
    }
}
