using System;

namespace Task02_05
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Employee user = new Employee("Поляков", "Вячеслав", "Андреевич", new DateTime(1995, 1, 25), new DateTime(2012, 9, 1), "Developer");
            Console.WriteLine("Создан пользователь со следующими данными:");
            Console.WriteLine($"Имя: {user.Name}");
            Console.WriteLine($"Фамилия: {user.Surname}");
            Console.WriteLine($"Отчество: {user.Patronymic}");
            Console.WriteLine($"Дата рождения: {user.Birthdate.ToShortDateString()}");
            Console.WriteLine($"Возраст: {user.Age.ToString()}");
            Console.WriteLine($"Стаж: {user.Experience.ToString()}");
            Console.WriteLine($"Должность: {user.Position.ToString()}");
        }
    }
}