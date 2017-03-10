using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_03
{
    internal class User
    {
        private string name, surname, patronymic;
        private DateTime? birthdate;
        private int age;

        public User()
        {
        }

        public User(string surname, string name, string patronymic)
        {
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
        }

        public User(string surname, string name, string patronymic, DateTime? birthdate)
        {
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.Birthdate = birthdate;
        }

        public User(string surname, string name, string patronymic, int age)
        {
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.age = age;
        }

        public string Name
        {
            get
            {
                if (this.name == string.Empty)
                {
                    return "Unknown";
                }

                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public string Surname
        {
            get
            {
                if (this.surname == string.Empty)
                {
                    return "Unknown";
                }

                return this.surname;
            }

            set
            {
                this.surname = value;
            }
        }

        public string Patronymic
        {
            get
            {
                if (this.patronymic == string.Empty)
                {
                    return "Unknown";
                }

                return this.patronymic;
            }

            set
            {
                this.patronymic = value;
            }
        }

        public DateTime? Birthdate
        {
            get
            {
                return this.birthdate;
            }

            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Невозможно создать пользователя с датой рождения позже сегодняшней");
                }

                this.birthdate = value;
                this.age = (int)(DateTime.Now - value).Value.TotalDays / 365;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (this.birthdate.HasValue)
                {
                    this.birthdate = new DateTime(
                        DateTime.Now.Year - value,
                        this.birthdate.GetValueOrDefault().Month,
                        this.birthdate.GetValueOrDefault().Day);
                    this.age = value;
                }
                else
                {
                    this.age = value;
                }
            }
        }
    }
}
