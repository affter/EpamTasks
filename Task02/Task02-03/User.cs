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
        private DateTime? birthdate;

        public User()
        {
        }

        public User(string surname, string name)
        {
            this.CheckNull(surname, name, this.patronymic);
            this.name = name;
            this.surname = surname;
        }

        public User(string surname, string name, string patronymic)
        {
            this.CheckNull(surname, name, patronymic);
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
        }

        public User(string surname, string name, DateTime? birthdate)
        {
            this.CheckNull(surname, name, this.patronymic);
            this.name = name;
            this.surname = surname;
            this.Birthdate = birthdate;
        }

        public User(string surname, string name, string patronymic, DateTime? birthdate)
        {
            this.CheckNull(surname, name, patronymic);
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
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

        public DateTime? Birthdate
        {
            get
            {
                return this.birthdate;
            }

            set
            {
                this.CheckDate(value);
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
                if (this.Birthdate == null)
                {
                    return null;
                }

                var today = DateTime.Now;
                var age = today.Year - this.Birthdate.Value.Year;

                if (this.Birthdate > today.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }

        private void CheckNull(string surname, string name, string patronymic)
        {
            if (string.IsNullOrEmpty(surname))
            {
                throw new ArgumentException("Фамилия не может быть пустой строкой или null");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Имя не может быть пустой строкой или null");
            }

            if (patronymic == string.Empty)
            {
                throw new ArgumentException("Отчество не может быть пустой строкой");
            }
        }

        private void CheckDate(DateTime? birthdate)
        {
            var today = DateTime.Now;
            var difference = today.Year - birthdate.Value.Year;

            if (birthdate > today.AddYears(-difference))
            {
                difference--;
            }

            if (difference >= 150)
            {
                throw new ArgumentException("Возраст не должен превышать 150 лет");
            }            
        }
    }
}
