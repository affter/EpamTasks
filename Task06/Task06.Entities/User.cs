using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06.Entities
{
    public class User
    {
        public User(string name, DateTime dateOfBirth)
        {
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age => this.CalculateYears(DateOfBirth, DateTime.Now);

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
