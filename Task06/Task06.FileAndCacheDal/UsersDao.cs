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
    public class UsersDao : IUsersDao
    {
        private static readonly string UsersFileName = Configuration.UsersFileName;
        private ICollection<User> usersCollection;
        private int maxId = 0;
        private static char separator = '†';
        private static UsersDao instance;

        private UsersDao()
        {
            this.usersCollection = new HashSet<User>();
            if (File.Exists(UsersFileName))
            {
                string[] users = File.ReadAllLines(UsersFileName);
                for (int i = 0; i < users.Length; i++)
                {
                    string[] userFields = users[i].Split(separator);
                    User user = new User(userFields[1], DateTime.Parse(userFields[2]));
                    user.Id = int.Parse(userFields[0]);
                    this.usersCollection.Add(user);
                }

                this.maxId = this.usersCollection.Count;
            }
        }

        public static UsersDao GetInstance()
        {
            if (instance == null)
                instance = new UsersDao();
            return instance;
        }

        public void Add(User user)
        {
            user.Id = ++instance.maxId;
            instance.usersCollection.Add(user);

            using (StreamWriter sw = new StreamWriter(UsersFileName, true))
            {
                sw.WriteLine(Serialize(user));
            }
        }

        public IEnumerable<User> GetAll()
        {
            return instance.usersCollection.Select(n => n);
        }

        public void Remove(int id)
        {
            User userForRemoving = instance.usersCollection.FirstOrDefault(n => n.Id == id);
            if (!instance.usersCollection.Remove(userForRemoving))
            {
                throw new ArgumentException("Пользователь с таким идентификатором не существует");
            }

            File.WriteAllLines(UsersFileName, instance.usersCollection.Select(Serialize));
        }

        private static string Serialize(User user)
        {
            return $"{user.Id.ToString()}{separator}{user.Name}{separator}{user.DateOfBirth.ToString("dd.MM.yyyy")}";
        }
    }
}
