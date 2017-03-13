using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02_03;

namespace Task02_05
{
    internal class Employee : User
    {
        private string position;
        private DateTime employmentDay;

        public Employee(
            string surname,
            string name,
            DateTime birthdate,
            DateTime employmentDay,
            string position) : this(surname, name, null, birthdate, employmentDay, position)
        {
        }

        public Employee(
            string surname,
            string name,
            string patronymic,
            DateTime birthdate,
            DateTime employmentDay,
            string position) : base(surname, name, patronymic, birthdate)
        {
            this.Position = position;
            this.EmploymentDay = employmentDay;
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
                var today = DateTime.Now;
                var difference = value.Year - Birthdate.Year;

                if (value > today.AddYears(-difference))
                {
                    difference--;
                }

                if (difference < 14)
                {
                    throw new ArgumentException("Человек не мог работать до 14 лет");
                }

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
    }
}
