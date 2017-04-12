using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.DalContracts;
using Task06.FileAndCacheDal;
using Task06.LogicContracts;

namespace Task06.Logic
{
    public class AwardingLogic : IAwardingLogic
    {
        private static IAwardsDao awardsDao;
        private static IUsersDao usersDao;
        private static IAwardingDao awardingDao;

        public AwardingLogic()
        {
            awardsDao = AwardsDao.GetInstance();
            usersDao = UsersDao.GetInstance();
            awardingDao = new AwardingDao();
        }

        public bool AwardUser(int userID, int awardID)
        {
            if (usersDao.GetAll().Any(n => n.Id == userID) && awardsDao.GetAll().Any(n => n.Id == awardID))
            {
                try
                {
                    awardingDao.AwardUser(userID, awardID);
                    return true;
                }
                catch 
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool RemoveAwardFromUser(int userID, int awardID)
        {
            if (usersDao.GetAll().Any(n => n.Id == userID) && awardsDao.GetAll().Any(n => n.Id == awardID))
            {
                try
                {
                    awardingDao.RemoveAwardFromUser(userID, awardID);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
