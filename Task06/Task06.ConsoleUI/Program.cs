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
        private static IUsersLogic usersLogic = new UsersLogic();
        private static IAwardsLogic awardsLogic = new AwardsLogic();

        private static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                ConsoleKeyInfo input = GetUserChoise();
                Console.WriteLine();
                switch (input.KeyChar)
                {
                    case '1':
                        {
                            AddUser();
                            break;
                        }

                    case '2':
                        {
                            AddAward();
                            break;
                        }

                    case '3':
                        {
                            RemoveUser();
                            break;
                        }

                    case '4':
                        {
                            RemoveAward();
                            break;
                        }

                    case '5':
                        {
                            ShowAllUsers();
                            break;
                        }

                    case '6':
                        {
                            ShowAllAwards();
                            break;
                        }

                    case '7':
                        {
                            AwardUser();
                            break;
                        }

                    case '8':
                        {
                            RemoveAwardFromUser();
                            break;
                        }

                    case '0':
                        {
                            return;
                        }

                    default:
                        {
                            break;
                        }
                }
            }
        }

        private static void RemoveAwardFromUser()
        {
            int userID, awardID;

            try
            {
                Console.Write("Введите имя или часть имени пользователя: ");
                string searchString = Console.ReadLine();
                var users = usersLogic.GetByNameLike(searchString);
                if (!users.Any())
                {
                    Console.WriteLine("Не найдено ни одного пользователя");
                    PressAnyKey();
                    return;
                }
                else
                {
                    foreach (User user in users)
                    {
                        ShowUser(user);
                    }
                }

                Console.Write("Введите идентификатор пользователя, которого нужно лишить награды: ");
                userID = int.Parse(Console.ReadLine());
                if (!users.Any(n => n.Id == userID))
                {
                    Console.WriteLine("Идентификатор введен некорректно");
                    PressAnyKey();
                    return;
                }

                if (!TryShowUserAwards(usersLogic.GetAll().First(n => n.Id == userID)))
                {
                    Console.WriteLine("Не получено ни одной награды");
                    PressAnyKey();
                    return;
                }

                Console.Write("Введите идентификатор награды, которую нужно забрать у пользователя: ");
                awardID = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Идентификатор введен некорректно");
                PressAnyKey();
                return;
            }

            if (usersLogic.RemoveAward(userID, awardID))
            {
                Console.WriteLine("Награда успешно отозвана");
                PressAnyKey();
            }
            else
            {
                Console.WriteLine("Ошибка при отзыве награды");
                PressAnyKey();
            }
        }

        private static void AwardUser()
        {
            int userID, awardID;

            try
            {
                Console.Write("Введите имя или часть имени пользователя: ");
                string searchString = Console.ReadLine();
                var users = usersLogic.GetByNameLike(searchString);
                if (!users.Any())
                {
                    Console.WriteLine("Не найдено ни одного пользователя");
                    PressAnyKey();
                    return;
                }
                else
                {
                    foreach (User user in users)
                    {
                        ShowUser(user);
                    }
                }

                Console.Write("Введите идентификатор пользователя, которого нужно наградить: ");
                userID = int.Parse(Console.ReadLine());
                if (!users.Any(n => n.Id == userID))
                {
                    Console.WriteLine("Идентификатор введен некорректно");
                    PressAnyKey();
                    return;
                }

                Console.Write("Введите название или часть названия награды: ");
                searchString = Console.ReadLine();
                var awards = awardsLogic.GetByTitleLike(searchString);
                if (!awards.Any())
                {
                    Console.WriteLine("Не найдено ни одной награды");
                    PressAnyKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Найденные награды:");
                    foreach (Award award in awards)
                    {
                        ShowAward(award);
                    }
                }

                Console.Write("Введите идентификатор награды, которой нужно наградить пользователя: ");
                awardID = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Идентификатор введен некорректно");
                PressAnyKey();
                return;
            }

            if (usersLogic.Award(userID, awardID))
            {
                Console.WriteLine("Награждение пользователя прошло успешно");
                PressAnyKey();
            }
            else
            {
                Console.WriteLine("Ошибка при награждении пользователя");
                PressAnyKey();
            }
        }

        private static void RemoveAward()
        {
            Console.WriteLine("Введите идентификатор удаляемой награды");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (awardsLogic.Remove(id))
                {
                    Console.WriteLine("Награда успешно удалена");
                    PressAnyKey();
                }
                else
                {
                    Console.WriteLine("Награды с таким идентификатором не существует");
                    PressAnyKey();
                }
            }
            else
            {
                Console.WriteLine("Идентификатор введен некорректно");
                PressAnyKey();
            }
        }

        private static void AddAward()
        {
            Console.Write("Введите название награды: ");
            string title = Console.ReadLine();
            try
            {
                if (awardsLogic.Add(title))
                {
                    Console.WriteLine("Награда успешно добавлена");
                    PressAnyKey();
                }
                else
                {
                    Console.WriteLine("Ошибка при добавлении награды");
                    PressAnyKey();
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Добавление награды прошло неудачно: некорректное название");
                PressAnyKey();
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
                    if (usersLogic.Add(username, birthDate))
                    {
                        Console.WriteLine("Пользователь успешно добавлен");
                        PressAnyKey();
                    }
                    else
                    {
                        Console.WriteLine("Ошибка при добавлении пользователя");
                        PressAnyKey();
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Ошибка при добавлении пользователя: один из аргументов имел некорректное значение");
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
                if (usersLogic.Remove(id))
                {
                    Console.WriteLine("Пользователь успешно удален");
                    PressAnyKey();
                }
                else
                {
                    Console.WriteLine("Пользователя с таким идентификатором не существует");
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
            IEnumerable<User> users = usersLogic.GetAll();
            foreach (User user in users)
            {
                ShowUser(user);
                if (!TryShowUserAwards(user))
                {
                    Console.WriteLine("Не получено ни одной награды");
                }
            }

            PressAnyKey();
        }

        private static bool TryShowUserAwards(User user)
        {
            IEnumerable<Award> awards = awardsLogic.GetAll();
            var userAwards = usersLogic.GetAwards(user.Id);
            if (userAwards.Any())
            {
                Console.WriteLine("Список наград:");
                foreach (var award in awards.Where(n => userAwards.Contains(n.Id)))
                {
                    ShowAward(award);
                }

                return true;
            }

            return false;
        }

        private static void ShowAllAwards()
        {
            IEnumerable<Award> awards = awardsLogic.GetAll();
            foreach (Award award in awards)
            {
                ShowAward(award);
            }

            PressAnyKey();
        }

        private static void ShowAward(Award award)
        {
            Console.WriteLine($"Id: {award.Id}, Название: {award.Title}");
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
            Console.WriteLine("\t2) Создать награду");
            Console.WriteLine("\t3) Удалить пользователя");
            Console.WriteLine("\t4) Удалить награду");
            Console.WriteLine("\t5) Просмотреть список пользователей");
            Console.WriteLine("\t6) Просмотреть список наград");
            Console.WriteLine("\t7) Наградить пользователя");
            Console.WriteLine("\t8) Отозвать награду");

            Console.WriteLine("\t0) Выход");
        }

        private static ConsoleKeyInfo GetUserChoise() => Console.ReadKey();

        private static void PressAnyKey()
        {
            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
        }
    }
}
