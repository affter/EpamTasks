using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_03
{
    public class User
    {
        // TODO: Delete constructors
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
            get
            {
                return this.name;
            }

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
            get
            {
                return this.surname;
            }

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
            get
            {
                return this.patronymic;
            }

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
            get
            {
                return this.birthdate;
            }

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

        public int? Age
        {
            get
            {
                var today = DateTime.Now;
                var age = today.Year - this.Birthdate.Year;

                if (this.Birthdate > today.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }
    }
}
