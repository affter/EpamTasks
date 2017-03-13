using System;
using FigureLibrary;

namespace Task02_01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Round round = new Round(new Point(0,0), 3);
            Console.WriteLine($"Длина окружности круга с радиусом {round.Radius.ToString()} равна {round.Circumference.ToString()}");
            Console.WriteLine($"Площадь круга с радиусом {round.Radius.ToString()} равна {round.Area.ToString()}");
            round.Radius = 2;
            Console.WriteLine($"Длина окружности круга с радиусом {round.Radius.ToString()} равна {round.Circumference.ToString()}");
            Console.WriteLine($"Площадь круга с радиусом {round.Radius.ToString()} равна {round.Area.ToString()}");
        }
    }
}
