using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.Config;
using Task06.DalContracts;
using Task06.Entities;

namespace Task06.FileAndCacheDal
{
    public class AwardingDao : IAwardingDao
    {
        private static readonly string UsersAwardsFileName = Configuration.UsersAwardsFileName;
        private static char separator = '†';
        private Dictionary<int, HashSet<int>> usersAwardsTable = new Dictionary<int, HashSet<int>>();

        public void AwardUser(int userID, int awardID)
        {

        }

        public HashSet<int> GetUserAwards(int userId)
        {
            return new HashSet<int>();
        }

        public void RemoveAwardFromUser(int userID, int awardID)
        {

        }

        private static string Serialize(int key, HashSet<int> value)
        {
            StringBuilder sb = new StringBuilder(value.Count * 2 + 1);
            sb.Append(key.ToString());
            foreach (int awardId in value)
            {
                sb.Append(separator);
                sb.Append(awardId.ToString());
            }

            return sb.ToString();
        }
    }
}
