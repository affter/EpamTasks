using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.Entities;
using Task06.Logic;
using Task06.LogicContracts;

namespace Task06.ConsoleUI
{
    internal class Program
    {
        private static readonly IUserLogic userLogic = new UserLogic();

        private static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                ConsoleKeyInfo input = GetUserChoise();
                Console.WriteLine();
                if (input.Key == ConsoleKey.Escape)
                {
                    break;
                }

                switch (input.KeyChar)
                {
                    case '1':
                        {
                            AddUser();
                            break;
                        }
                    case '2':
                        {
                            RemoveUser();
                            break;
                        }
                    case '3':
                        {
                            ShowAllUsers();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
        
        private static void AddUser()
        {
            Console.Write("Введите имя пользователя: ");
            string username = Console.ReadLine();
            Console.Write("Введите дату рождения пользователя в формате dd.mm.yyyy: ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
            {
                try
                {
                    if (userLogic.Add(username, birthDate))
                    {
                        Console.WriteLine("Пользователь успешно добавлен.");
                        PressAnyKey();
                    }
                    else
                    {
                        Console.WriteLine("Добавление пользователя прошло неудачно.");
                        PressAnyKey();
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Добавление пользователя прошло неудачно: один из аргументов имел некорректное значение");
                    PressAnyKey();
                }
            }
            else
            {
                Console.WriteLine("Дата введена некорректно.");
                PressAnyKey();
            }
            
        }

        private static void RemoveUser()
        {
            Console.WriteLine("Введите идентификатор удаляемого пользователя");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (userLogic.Remove(id))
                {
                    Console.WriteLine("Пользователь успешно удален.");
                    PressAnyKey();
                }
                else
                {
                    Console.WriteLine("Пользоавтеля с таким идентификатором не существует");
                    PressAnyKey();
                }
            }
            else
            {
                Console.WriteLine("Идентификатор введен некорректно");
                PressAnyKey();
            }
            
        }

        private static void ShowAllUsers()
        {
            IEnumerable<User> users = userLogic.GetAll();
            foreach (User user in users)
            {
                ShowUser(user);
            }
            PressAnyKey();
        }

        private static void ShowUser(User user)
        {
            Console.WriteLine($"Id: {user.Id}, Имя пользователя: {user.Name}, Дата рождения: {user.DateOfBirth.ToShortDateString()}, Возраст: {user.Age} ");
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("\t1) Создать пользователя");
            Console.WriteLine("\t2) Удалить пользователя");
            Console.WriteLine("\t3) Просмотреть список пользователей");
            Console.WriteLine("\tEsc для выхода из приложения");
        }

        private static ConsoleKeyInfo GetUserChoise() => Console.ReadKey();

        private static void PressAnyKey()
        {
            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
        }
    }
}
