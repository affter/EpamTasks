using System;
using FigureLibrary;

namespace Task02_07
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var editor = new VectorGraphicsEditor();
            ConsoleKeyInfo input;
            while (true)
            {
                input = ModeChoice();
                if (input.Key == ConsoleKey.Escape)
                {
                    break;
                }

                switch (input.KeyChar)
                {
                    case '1':
                        input = UserFigureChoice();
                        if (input.Key == ConsoleKey.Escape)
                        {
                            break;
                        }

                        switch (input.KeyChar)
                        {
                            case '1':
                                CreateLine(editor);

                                break;
                            case '2':
                                CreateCircle(editor);

                                break;
                            case '3':
                                CreateRound(editor);

                                break;
                            case '4':
                                CreateRing(editor);

                                break;
                            case '5':
                                CreateRectangle(editor);

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

                        editor.DrawAll();
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод!");
                        break;
                }
            }
        }

        private static ConsoleKeyInfo ModeChoice()
        {
            ConsoleKeyInfo input;
            Console.WriteLine("Выберите режим работы:");
            Console.WriteLine("Введите: ");
            Console.WriteLine("\t 1: Создать объект");
            Console.WriteLine("\t 2: Нарисовать все созданные объекты");
            Console.WriteLine("\t Esc: Выход");

            input = Console.ReadKey();
            Console.WriteLine();
            return input;
        }

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

        private static void CreateRectangle(VectorGraphicsEditor editor)
        {
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

                editor.Create(new DrawableRectangle(new Point(firstX, firstY), width, height));
            }
            catch
            {
                Console.WriteLine("Некорректный ввод");
            }
        }

        private static void CreateRing(VectorGraphicsEditor editor)
        {
            try
            {
                Point point;
                double radius;
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

                editor.Create(new DrawableRing(point, innerRadius, radius));
            }
            catch
            {
                Console.WriteLine("Некорректный ввод");
            }
        }

        private static void CreateRound(VectorGraphicsEditor editor)
        {
            Point point;
            double radius;
            try
            {
                GetCircleInfo(out point, out radius);
                editor.Create(new DrawableRound(point, radius));
            }
            catch
            {
                Console.WriteLine("Некорректный ввод");
            }
        }

        private static void CreateCircle(VectorGraphicsEditor editor)
        {
            Point point;
            double radius;
            try
            {
                GetCircleInfo(out point, out radius);
                editor.Create(new DrawableCircle(point, radius));
            }
            catch
            {
                Console.WriteLine("Некорректный ввод");
            }
        }

        private static void CreateLine(VectorGraphicsEditor editor)
        {
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
                editor.Create(new DrawableLine(new Point(firstX, firstY), new Point(secondX, secondY)));
            }
            catch
            {
                Console.WriteLine("Некорректный ввод");
            }
        }

        private static ConsoleKeyInfo UserFigureChoice()
        {
            ConsoleKeyInfo input;
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
            return input;
        }
    }
}