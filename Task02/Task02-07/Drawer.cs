using System;
using FigureLibrary;

namespace Task02_07
{
    internal class Drawer
    {
        public static void Draw(Figure figure)
        {
            switch (figure.GetType().ToString())
            {
                case "FigureLibrary.Line":
                    {
                        var tempFigure = (Line)figure;
                        Console.WriteLine("Тип фигуры: Линия");
                        Console.WriteLine("Параметры:");
                        Console.WriteLine($"Точка начала: ({tempFigure.Start.X},{tempFigure.Start.Y})");
                        Console.WriteLine($"Точка конца: ({tempFigure.End.X},{tempFigure.End.Y})");
                        break;
                    }

                case "FigureLibrary.Circle":
                    {
                        var tempFigure = (Circle)figure;
                        Console.WriteLine("Тип фигуры: Окружность");
                        Console.WriteLine("Параметры:");
                        Console.WriteLine($"Центр: ({tempFigure.Center.X},{tempFigure.Center.Y})");
                        Console.WriteLine($"Радиус: {tempFigure.Radius}");
                        Console.WriteLine($"Длина окружности: {tempFigure.Circumference}");
                        break;
                    }

                case "FigureLibrary.Round":
                    {
                        var tempFigure = (Round)figure;
                        Console.WriteLine("Тип фигуры: Круг");
                        Console.WriteLine("Параметры:");
                        Console.WriteLine($"Центр: ({tempFigure.Center.X},{tempFigure.Center.Y})");
                        Console.WriteLine($"Радиус: {tempFigure.Radius}");
                        Console.WriteLine($"Длина окружности: {tempFigure.Circumference}");
                        Console.WriteLine($"Площадь: {tempFigure.Area}");
                        break;
                    }

                case "FigureLibrary.Ring":
                    {
                        var tempFigure = (Ring)figure;
                        Console.WriteLine("Тип фигуры: Кольцо");
                        Console.WriteLine("Параметры:");
                        Console.WriteLine($"Центр: ({tempFigure.Center.X},{tempFigure.Center.Y})");
                        Console.WriteLine($"Внешний радиус: {tempFigure.Radius}");
                        Console.WriteLine($"Внутренний радиус: {tempFigure.InnerRadius}");
                        Console.WriteLine($"Сумма длин окружностей: {tempFigure.SumOfCircumferences}");
                        Console.WriteLine($"Площадь: {tempFigure.Area}");
                        break;
                    }

                case "FigureLibrary.Rectangle":
                    {
                        var tempFigure = (Rectangle)figure;
                        Console.WriteLine("Тип фигуры: Прямоугольник");
                        Console.WriteLine("Параметры:");
                        Console.WriteLine($"Левый верхний угол: ({tempFigure.UpperLeftCorner.X},{tempFigure.UpperLeftCorner.Y})");
                        Console.WriteLine($"Ширина: {tempFigure.Width}");
                        Console.WriteLine($"Высота: {tempFigure.Heigth}");
                        Console.WriteLine($"Периметр: {tempFigure.Perimeter}");
                        Console.WriteLine($"Площадь: {tempFigure.Area}");
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Невозможно определить тип фигуры");
                        break;
                    }
            }
        }
    }
}