using System;

namespace Task02_03
{
    public class User
    {
        private string name, surname, patronymic;

        private DateTime birthdate;

        public User(
            string surname,
            string name,
            DateTime birthdate) : this(surname, name, null, birthdate)
        {
        }

        public User(
            string surname,
            string name,
            string patronymic,
            DateTime birthdate)
        {
            this.Name = name;
            this.Surname = surname;
            this.Patronymic = patronymic;
            this.Birthdate = birthdate;
        }

        public string Name
        {
            get => this.name;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Имя не может быть пустой строкой или null");
                }

                this.name = value;
            }
        }

        public string Surname
        {
            get => this.surname;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Фамилия не может быть пустой строкой или null");
                }

                this.surname = value;
            }
        }

        public string Patronymic
        {
            get => this.patronymic;

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Отчество не может быть пустой строкой");
                }

                this.patronymic = value;
            }
        }

        public DateTime Birthdate
        {
            get => this.birthdate;

            set
            {
                var today = DateTime.Now;
                var difference = today.Year - value.Year;

                if (this.birthdate > today.AddYears(-difference))
                {
                    difference--;
                }

                if (difference >= 150)
                {
                    throw new ArgumentException("Возраст не должен превышать 150 лет");
                }

                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Невозможно создать пользователя с датой рождения позже сегодняшней");
                }

                this.birthdate = value;
            }
        }

        public int Age => CalculateYears(this.Birthdate, DateTime.Now);
        
        protected int CalculateYears(DateTime start, DateTime end)
        {
            var today = DateTime.Now;
            var difference = end.Year - start.Year;

            if (start > today.AddYears(-difference))
            {
                difference--;
            }

            return difference;
        }
    }
}