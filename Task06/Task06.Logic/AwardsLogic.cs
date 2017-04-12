using System;
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
    public class AwardsLogic : IAwardsLogic
    {
        private static IAwardsDao awardsDao;

        public AwardsLogic()
        {
            awardsDao = AwardsDao.GetInstance();
        }

        public bool Add(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым");
            }

            try
            {
                Award award = new Award { Title = title };
                awardsDao.Add(award);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Award> GetAll()
        {
            return awardsDao.GetAll();
        }

        public bool Remove(int id)
        {
            try
            {
                awardsDao.Remove(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
