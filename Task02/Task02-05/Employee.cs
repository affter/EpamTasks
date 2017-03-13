using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_05
{
    internal class Employee : Task02_03.User
    {
        private string position;
        private DateTime employmentDay;

        public Employee(string surname, string name, DateTime? birthdate, DateTime employmentDay, string position)
        {
            this.CheckNull(surname, name, this.Patronymic, position);
            this.CheckDates(birthdate, employmentDay);
            this.Birthdate = birthdate;
            this.EmploymentDay = employmentDay;
            this.Name = name;
            this.Position = position;
            this.Surname = surname;
        }

        public Employee(string surname, string name, string patronymic, DateTime? birthdate, DateTime employmentDay, string position)
        {
            this.CheckNull(surname, name, patronymic, position);
            this.CheckDates(birthdate, employmentDay);
            this.Birthdate = birthdate;
            this.EmploymentDay = employmentDay;
            this.Name = name;
            this.Position = position;
            this.Surname = surname;
            this.Patronymic = patronymic;
        }

        public string Position
        {
            get => this.position;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Должность не может быть пустой строкой или null");
                }

                this.position = value;
            }
        }

        public DateTime EmploymentDay
        {
            get => this.employmentDay;

            set
            {
                this.CheckDates(this.Birthdate, value);

                this.employmentDay = value;
            }
        }

        public int Experience
        {
            get
            {
                var today = DateTime.Now;
                var experience = today.Year - this.EmploymentDay.Year;

                if (this.EmploymentDay > today.AddYears(-experience))
                {
                    experience--;
                }

                return experience;
            }
        }

        private void CheckNull(string surname, string name, string patronymic, string position)
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

            if (string.IsNullOrEmpty(position))
            {
                throw new ArgumentException("Должность не может быть пустой строкой или null");
            }
        }

        private void CheckDates(DateTime? birthdate, DateTime employmentDay)
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

            difference = employmentDay.Year - birthdate.Value.Year;

            if (employmentDay > today.AddYears(-difference))
            {
                difference--;
            }

            if (difference < 14)
            {
                throw new ArgumentException("Человек не мог работать до 14 лет");
            }
        }
    }
}
