using System;
using FigureLibrary;

namespace Task02_07
{
    internal class VectorGraphicsEditor
    {
        public static void Draw(Line line)
        {
            Console.WriteLine("Тип фигуры: Линия");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Точка начала: ({line.Start.X},{line.Start.Y})");
            Console.WriteLine($"Точка конца: ({line.End.X},{line.End.Y})");
        }

        public static void Draw(Circle circle)
        {
            Console.WriteLine("Тип фигуры: Окружность");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Центр: ({circle.Center.X},{circle.Center.Y})");
            Console.WriteLine($"Радиус: {circle.Radius}");
            Console.WriteLine($"Длина окружности: {circle.Circumference}");
        }

        public static void Draw(Round round)
        {
            Console.WriteLine("Тип фигуры: Круг");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Центр: ({round.Center.X},{round.Center.Y})");
            Console.WriteLine($"Радиус: {round.Radius}");
            Console.WriteLine($"Длина окружности: {round.Circumference}");
            Console.WriteLine($"Площадь: {round.Area}");
        }
        
        public static void Draw(Ring ring)
        {
            Console.WriteLine("Тип фигуры: Кольцо");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Центр: ({ring.Center.X},{ring.Center.Y})");
            Console.WriteLine($"Внешний радиус: {ring.Radius}");
            Console.WriteLine($"Внутренний радиус: {ring.InnerRadius}");
            Console.WriteLine($"Сумма длин окружностей: {ring.SumOfCircumferences}");
            Console.WriteLine($"Площадь: {ring.Area}");
        }

        public static void Draw(Rectangle rect)
        {
            Console.WriteLine("Тип фигуры: Прямоугольник");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Левый верхний угол: ({rect.UpperLeftCorner.X},{rect.UpperLeftCorner.Y})");
            Console.WriteLine($"Ширина: {rect.Width}");
            Console.WriteLine($"Высота: {rect.Heigth}");
            Console.WriteLine($"Периметр: {rect.Perimeter}");
            Console.WriteLine($"Площадь: {rect.Area}");
        }
    }
}