using System;
using System.Collections.Generic;
using System.IO;
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
        private static AwardingDao instance;
        private Dictionary<int, HashSet<int>> usersAwardsTable = new Dictionary<int, HashSet<int>>();

        private AwardingDao()
        {
            this.usersAwardsTable = new Dictionary<int, HashSet<int>>();
            if (File.Exists(UsersAwardsFileName))
            {
                string[] users = File.ReadAllLines(UsersAwardsFileName);
                for (int i = 0; i < users.Length; i++)
                {
                    string[] userAwardsFields = users[i].Split(separator);
                    int userID = int.Parse(userAwardsFields[0]);
                    this.usersAwardsTable.Add(userID, new HashSet<int>());
                    for (int j = 1; j < userAwardsFields.Length; j++)
                    {
                        this.usersAwardsTable[userID].Add(int.Parse(userAwardsFields[j]));
                    }
                }
            }
        }

        public static AwardingDao GetInstance()
        {
            if (instance == null)
            {
                instance = new AwardingDao();
            }

            return instance;
        }

        public void AwardUser(int userID, int awardID)
        {
            if (instance.usersAwardsTable.ContainsKey(userID))
            {
                instance.usersAwardsTable[userID].Add(awardID);
            }
            else
            {
                var awards = new HashSet<int>();
                awards.Add(awardID);
                instance.usersAwardsTable.Add(userID, awards);
            }

            using (StreamWriter sw = new StreamWriter(UsersAwardsFileName))
            {
                foreach (var pair in instance.usersAwardsTable)
                {
                    sw.WriteLine(Serialize(pair.Key, pair.Value));
                }
            }
        }

        public IEnumerable<int> GetUserAwards(int userID)
        {
            try
            {
                return instance.usersAwardsTable[userID].Select(n => n);
            }
            catch
            {
                return new HashSet<int>();
            }
        }

        public void RemoveAwardFromUser(int userID, int awardID)
        {
            instance.usersAwardsTable[userID].Remove(awardID);
            if (!instance.usersAwardsTable[userID].Any())
            {
                instance.usersAwardsTable.Remove(userID);
            }

            using (StreamWriter sw = new StreamWriter(UsersAwardsFileName))
            {
                foreach (var pair in instance.usersAwardsTable)
                {
                    sw.WriteLine(Serialize(pair.Key, pair.Value));
                }
            }
        }

        public void RemoveUserAwardsList(int userID)
        {
            instance.usersAwardsTable.Remove(userID);
            using (StreamWriter sw = new StreamWriter(UsersAwardsFileName))
            {
                foreach (var pair in instance.usersAwardsTable)
                {
                    sw.WriteLine(Serialize(pair.Key, pair.Value));
                }
            }
        }

        private static string Serialize(int key, HashSet<int> value)
        {
            StringBuilder sb = new StringBuilder((value.Count * 2) + 1);
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
