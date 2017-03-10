﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_03
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            User user = new User("Поляков", "Вячеслав", "Андреевич", new DateTime(1995, 1, 25));
            Console.WriteLine("Создан пользователь со следующими данными:");
            Console.WriteLine($"Имя: {user.Name}");
            Console.WriteLine($"Фамилия: {user.Surname}");
            Console.WriteLine($"Отчество: {user.Patronymic}");
            Console.WriteLine($"Дата рождения: {user.Birthdate.Value.ToShortDateString()}");
            Console.WriteLine($"Возраст: {user.Age.ToString()}");
        }
    }
}
