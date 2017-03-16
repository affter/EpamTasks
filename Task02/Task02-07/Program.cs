using System;
using System.Collections.Generic;
using FigureLibrary;

namespace Task02_07
{
    internal class Program
    {
        private static void GetCircleInfo(out Point point, out double radius)
        {
            Console.Write("Введите координату x центра окружности: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Введите координату y центра окружности: ");
            double y = double.Parse(Console.ReadLine());
            point = new Point(x, y);
            do
            {
                Console.Write("Введите радиус: ");
                radius = double.Parse(Console.ReadLine());

                if (radius <= 0)
                {
                    Console.WriteLine("Некорректный ввод: радиус должен быть больше нуля");
                }
            }
            while (radius <= 0);
        }

        private static void Main(string[] args)
        {
            var editor = new VectorGraphicsEditor();
            ConsoleKeyInfo input;

            while (true)
            {
                Console.WriteLine("Выберите режим работы:");
                Console.WriteLine("Введите: ");
                Console.WriteLine("\t 1: Создать объект");
                Console.WriteLine("\t 2: Нарисовать все созданные объекты");
                Console.WriteLine("\t Esc: Выход");

                input = Console.ReadKey();
                Console.WriteLine();
                if (input.Key == ConsoleKey.Escape)
                {
                    break;
                }

                switch (input.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Выберите, какую фигуру создать:");
                        Console.WriteLine("Введите:");
                        Console.WriteLine("\t 1: Линия");
                        Console.WriteLine("\t 2: Окружность");
                        Console.WriteLine("\t 3: Круг");
                        Console.WriteLine("\t 4: Кольцо");
                        Console.WriteLine("\t 5: Прямоугольник");
                        Console.WriteLine("\t Esc: Назад");

                        input = Console.ReadKey();
                        Console.WriteLine();
                        if (input.Key == ConsoleKey.Escape)
                        {
                            break;
                        }

                        switch (input.KeyChar)
                        {
                            case '1':
                                try
                                {
                                    Console.Write("Введите координату x центра окружности: ");
                                    double firstX = double.Parse(Console.ReadLine());
                                    Console.Write("Введите координату y центра окружности: ");
                                    double firstY = double.Parse(Console.ReadLine());
                                    Console.Write("Введите координату x центра окружности: ");
                                    double secondX = double.Parse(Console.ReadLine());
                                    Console.Write("Введите координату y центра окружности: ");
                                    double secondY = double.Parse(Console.ReadLine());
                                    editor.Create(new Line(new Point(firstX, firstY), new Point(secondX, secondY)));
                                }
                                catch
                                {
                                    Console.WriteLine("Некорректный ввод");
                                }

                                break;
                            case '2':
                                Point point;
                                double radius;
                                try
                                {
                                    GetCircleInfo(out point, out radius);
                                    editor.Create(new Circle(point, radius));
                                }
                                catch
                                {
                                    Console.WriteLine("Некорректный ввод");
                                }

                                break;
                            case '3':
                                try
                                {
                                    GetCircleInfo(out point, out radius);
                                    editor.Create(new Round(point, radius));
                                }
                                catch
                                {
                                    Console.WriteLine("Некорректный ввод");
                                }

                                break;
                            case '4':
                                try
                                {
                                    GetCircleInfo(out point, out radius);
                                    double innerRadius;
                                    do
                                    {
                                        Console.Write("Введите внутренний радиус: ");
                                        innerRadius = double.Parse(Console.ReadLine());

                                        if (innerRadius <= 0)
                                        {
                                            Console.WriteLine("Некорректный ввод: радиус должен быть больше нуля");
                                        }
                                    }
                                    while (radius <= 0);

                                    editor.Create(new Ring(point, innerRadius, radius));
                                }
                                catch
                                {
                                    Console.WriteLine("Некорректный ввод");
                                }
                                
                                break;
                            case '5':
                                try
                                {
                                    Console.Write("Введите координату x левого верхнего угла прямоугольника: ");
                                    double firstX = double.Parse(Console.ReadLine());
                                    Console.Write("Введите координату y левого верхнего угла прямоугольника: ");
                                    double firstY = double.Parse(Console.ReadLine());
                                    double width, height;
                                    do
                                    {
                                        Console.Write("Введите ширину прямоугольника: ");
                                        width = double.Parse(Console.ReadLine());
                                        if (width <= 0)
                                        {
                                            Console.WriteLine("Некорректный ввод: ширина должна быть больше ноля");
                                        }
                                    }
                                    while (width <= 0);

                                    do
                                    {
                                        Console.Write("Введите высота прямоугольника: ");
                                        height = double.Parse(Console.ReadLine());
                                        if (height <= 0)
                                        {
                                            Console.WriteLine("Некорректный ввод: высота должна быть больше ноля");
                                        }
                                    }
                                    while (width <= 0);

                                    editor.Create(new Rectangle(new Point(firstX, firstY), width, height));
                                }
                                catch
                                {
                                    Console.WriteLine("Некорректный ввод");
                                }

                                break;
                            default:
                                Console.WriteLine("Некорректный ввод!");
                                break;
                        }

                        break;
                    case '2':
                        if (editor.CreatedFigures.Count == 0)
                        {
                            Console.WriteLine("Не создано ни одной фигуры");
                        }

                        foreach (Figure item in editor.CreatedFigures)
                        {
                            editor.Draw(item);
                        }

                        break;
                    default:
                        Console.WriteLine("Некорректный ввод!");
                        break;
                }
            }
        }
    }
}