using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05_01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(WatcherChangeTypes.Changed);
            Backuper backuper = new Backuper(Configuration.WorkingDirectory);
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            DateTime date = DateTime.Now;
            while (true)
            {
                Console.WriteLine("Выберите режим работы программы:");
                Console.WriteLine("\t1. Наблюдение");
                Console.WriteLine("\t2. Откат изменений");
                Console.WriteLine("\t0. Выход");

                input = Console.ReadKey();
                Console.WriteLine();
                if (input.KeyChar == '0')
                {
                    break;
                }

                switch (input.KeyChar)
                {
                    case '1':
                        {
                            backuper.StartSupervising();
                            Console.WriteLine("Для выхода из режима наблюдения нажмите Esc");
                            while (Console.ReadKey().Key != ConsoleKey.Escape)
                            {
                                Console.WriteLine();
                            }

                            backuper.StopSupervising();
                            break;
                        }

                    case '2':
                        {
                            try
                            {
                                Console.WriteLine("Введите дату и время, на которую нужно откатиться, в формате DD.MM.YYYY hh:mm:ss");
                                DateTime rollbackDateTime = DateTime.Parse(Console.ReadLine());
                                backuper.Rollback(rollbackDateTime);
                                Console.WriteLine(
                                    "Скопируйте необходимые файлы. После нажатия клавиши Esc," + 
                                    "содержимое директории откатится на момент последнего изменения.");
                                while (Console.ReadKey().Key != ConsoleKey.Escape)
                                {
                                    Console.WriteLine();
                                }

                                backuper.Rollback(DateTime.Now);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Дата введена некорректно!");
                            }

                            break;
                        }

                    default:
                        Console.WriteLine("Некорректный ввод!");
                        break;
                }
            }
        }
    }
}
