using System;
using System.Collections.Generic;
using FigureLibrary;

namespace Task02_07
{
    internal class VectorGraphicsEditor
    {
        private HashSet<Figure> createdFigures = new HashSet<Figure>();

        public HashSet<Figure> CreatedFigures { get => this.createdFigures; }

        public void Draw(Figure figure)
        {
            switch (figure.GetType().ToString())
            {
                case "FigureLibrary.Line":
                    {
                        this.Draw((Line)figure);
                        break;
                    }

                case "FigureLibrary.Circle":
                    {
                        this.Draw((Circle)figure);
                        break;
                    }

                case "FigureLibrary.Round":
                    {
                        this.Draw((Round)figure);
                        break;
                    }

                case "FigureLibrary.Ring":
                    {
                        this.Draw((Ring)figure);
                        break;
                    }

                case "FigureLibrary.Rectangle":
                    {
                        this.Draw((Rectangle)figure);
                        break;
                    }
            }
        }
        
        public void Create(Line line)
        {
            this.createdFigures.Add(line);
        }

        public void Create(Circle circle)
        {
            this.createdFigures.Add(circle);
        }

        public void Create(Round round)
        {
            this.createdFigures.Add(round);
        }

        public void Create(Ring ring)
        {
            this.createdFigures.Add(ring);
        }

        public void Create(Rectangle rect)
        {
            this.createdFigures.Add(rect);
        }

        private void Draw(Line line)
        {
            Console.WriteLine("Тип фигуры: Линия");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Точка начала: ({line.Start.X},{line.Start.Y})");
            Console.WriteLine($"Точка конца: ({line.End.X},{line.End.Y})");
        }

        private void Draw(Circle circle)
        {
            Console.WriteLine("Тип фигуры: Окружность");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Центр: ({circle.Center.X},{circle.Center.Y})");
            Console.WriteLine($"Радиус: {circle.Radius}");
            Console.WriteLine($"Длина окружности: {circle.Circumference}");
        }

        private void Draw(Round round)
        {
            Console.WriteLine("Тип фигуры: Круг");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Центр: ({round.Center.X},{round.Center.Y})");
            Console.WriteLine($"Радиус: {round.Radius}");
            Console.WriteLine($"Длина окружности: {round.Circumference}");
            Console.WriteLine($"Площадь: {round.Area}");
        }

        private void Draw(Ring ring)
        {
            Console.WriteLine("Тип фигуры: Кольцо");
            Console.WriteLine("Параметры:");
            Console.WriteLine($"Центр: ({ring.Center.X},{ring.Center.Y})");
            Console.WriteLine($"Внешний радиус: {ring.Radius}");
            Console.WriteLine($"Внутренний радиус: {ring.InnerRadius}");
            Console.WriteLine($"Сумма длин окружностей: {ring.SumOfCircumferences}");
            Console.WriteLine($"Площадь: {ring.Area}");
        }

        private void Draw(Rectangle rect)
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