﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.DalContracts;
using Task06.Entities;
using Task06.FileAndCacheDal;
using Task06.LogicContracts;

namespace Task06.Logic
{
    public class UsersLogic : IUsersLogic
    {
        private static IUsersDao usersDao;

        public UsersLogic()
        {
            usersDao = UsersDao.GetInstance();
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
                usersDao.Add(new User(name, dateOfBirth));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users = usersDao.GetAll();
            foreach (User user in users)
            {
                user.Age = CalculateYears(user.DateOfBirth, DateTime.Now);
            }

            return users;
        }

        public bool Remove(int id)
        {
            try
            {
                usersDao.Remove(id);
                var awardingDao = AwardingDao.GetInstance();
                awardingDao.RemoveUserAwardsList(id);
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
