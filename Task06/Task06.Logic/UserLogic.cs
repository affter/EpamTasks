using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.LogicContracts;
using Task06.Entities;
using Task06.DalContracts;
using Task06.FileAndCacheDal;

namespace Task06.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao userDao;

        public UserLogic()
        {
            userDao = new UserDao();
        }

        public bool Add(string name, DateTime dateOfBirth)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым");
            }

            int difference = this.CalculateYears(dateOfBirth, DateTime.Now);

            if (difference >= 150)
            {
                throw new ArgumentException("Возраст не должен превышать 150 лет");
            }

            if (dateOfBirth > DateTime.Now)
            {
                throw new ArgumentException("Невозможно создать пользователя с датой рождения позже сегодняшней");
            }

            try
            {
                userDao.Add(new User(name, dateOfBirth));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<User> GetAll()
        {
            return userDao.GetAll();
        }

        public bool Remove(int id)
        {
            try
            {
                userDao.Remove(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
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
