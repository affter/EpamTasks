using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06.Entities
{
    public class User
    {

        private string name;
        private DateTime dateOfBirth;

        public int Id { get; set; }

        public string Name
        {
            get => this.name;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Имя пользователя не может быть пустым");
                }

                this.name = value;
            }
        }

        public DateTime DateOfBirth
        {
            get => this.dateOfBirth;

            set
            {
                int difference = this.CalculateYears(value, DateTime.Now);

                if (difference >= 150)
                {
                    throw new ArgumentException("Возраст не должен превышать 150 лет");
                }

                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Невозможно создать пользователя с датой рождения позже сегодняшней");
                }

                this.dateOfBirth = value;
            }
        }

        public int Age => this.CalculateYears(this.DateOfBirth, DateTime.Now);

        private int CalculateYears(DateTime start, DateTime end)
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
