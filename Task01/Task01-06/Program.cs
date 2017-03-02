using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01_06
{
    class Program
    {
        [Flags]
        enum Types : byte
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4,
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo input;
            Types type = new Types();
            while (true)
            {
                Console.WriteLine($"Параметры надписи: {type}");
                Console.WriteLine($"Введите: ");
                Console.WriteLine("\t 1: Bold");
                Console.WriteLine("\t 2: Italic");
                Console.WriteLine("\t 3: Undeline");

                input = Console.ReadKey();
                Console.WriteLine();
                if (input.Key == ConsoleKey.Escape) break;

                switch (input.KeyChar)
                {
                    case '1':
                        type ^= Types.Bold;
                        break;
                    case '2':
                        type ^= Types.Italic;
                        break;
                    case '3':
                        type ^= Types.Underline;
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод!");
                        break;
                }           
            }
        }
    }
}
