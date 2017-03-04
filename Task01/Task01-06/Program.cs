using System;

namespace Task01_06
{
    internal class Program
    {
        [Flags]
        private enum Types : byte
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4,
        }

        private enum Inputs : int
        {
            Bold = 1,
            Italic = 2,
            Underline = 3,
        }

        private static void Main(string[] args)
        {
            Types type = new Types();
            Inputs input = new Inputs();
            while (true)
            {
                Console.WriteLine($"Параметры надписи: {type}");
                Console.WriteLine($"Введите: ");
                Console.WriteLine("\t 1: Bold");
                Console.WriteLine("\t 2: Italic");
                Console.WriteLine("\t 3: Undeline");
                Console.WriteLine();
                input = (Inputs)Enum.Parse(typeof(Inputs), Console.ReadLine());
                type ^= (Types)Enum.Parse(typeof(Types), Enum.GetName(typeof(Inputs), input));
            }
        }
    }
}