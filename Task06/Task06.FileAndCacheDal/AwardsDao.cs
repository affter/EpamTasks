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
    public class AwardsDao : IAwardsDao
    {
        private static readonly string AwardsFileName = Configuration.AwardsFileName;
        private ICollection<Award> awardsCollection;
        private int maxId = 0;
        private static char separator = '†';
        private static AwardsDao instance;

        private AwardsDao()
        {
            this.awardsCollection = new HashSet<Award>();
            if (File.Exists(AwardsFileName))
            {
                string[] users = File.ReadAllLines(AwardsFileName);
                for (int i = 0; i < users.Length; i++)
                {
                    string[] awardFields = users[i].Split('†');
                    Award award = new Award { Id = int.Parse(awardFields[0]), Title = awardFields[1] };
                    this.awardsCollection.Add(award);
                }

                this.maxId = this.awardsCollection.Count;
            }
        }

        public void Add(Award award)
        {
            award.Id = ++instance.maxId;
            instance.awardsCollection.Add(award);

            using (StreamWriter sw = new StreamWriter(AwardsFileName, true))
            {
                sw.WriteLine(Serialize(award));
            }
        }

        public static AwardsDao GetInstance()
        {
            if (instance == null)
                instance = new AwardsDao();
            return instance;
        }

        public IEnumerable<Award> GetAll()
        {
            return instance.awardsCollection.Select(n => n);
        }

        public void Remove(int id)
        {
            Award awardForRemoving = instance.awardsCollection.FirstOrDefault(n => n.Id == id);
            if (!instance.awardsCollection.Remove(awardForRemoving))
            {
                throw new ArgumentException("Пользователь с таким идентификатором не существует");
            }

            File.WriteAllLines(AwardsFileName, instance.awardsCollection.Select(Serialize));
        }

        private static string Serialize(Award award)
        {
            return $"{award.Id.ToString()}{separator}{award.Title}";
        }
    }
}
