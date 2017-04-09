using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.DalContracts;
using Task06.Entities;
using Task06.Config;

namespace Task06.FileAndCacheDal
{
    public class UserDao : IUserDao
    {
        private ICollection<User> userCollection;
        private int maxId = 0;
        private static readonly string usersFilePath = Configuration.UserFileName;

        public UserDao()
        {
            userCollection = new HashSet<User>();
            if (File.Exists(usersFilePath))
            {
                string[] users = File.ReadAllLines(usersFilePath);
                for (int i = 0; i < users.Length; i++)
                {
                    string[] userFields = users[i].Split(';');
                    User user = new User(userFields[1], DateTime.Parse(userFields[2]));
                    user.Id = int.Parse(userFields[0]);
                    userCollection.Add(user);
                }
                this.maxId = userCollection.Count;
            }
        }

        public void Add(User user)
        {
            user.Id = ++maxId;
            this.userCollection.Add(user);

            using (StreamWriter sw = new StreamWriter(usersFilePath, true))
            {
                sw.WriteLine(SerializeUser(user));
            }
        }

        public IEnumerable<User> GetAll()
        {
            return this.userCollection.Select(n => n);
        }

        public void Remove(int id)
        {
            User userForRemoving = userCollection.FirstOrDefault(n => n.Id == id);
            if (!userCollection.Remove(userForRemoving))
            {
                throw new ArgumentException("Пользователь с таким идентификатором не существует");
            }

            File.WriteAllLines(usersFilePath, userCollection.Select(SerializeUser));
        }

        private static string SerializeUser(User user)
        {
            return $"{user.Id.ToString()};{user.Name};{user.DateOfBirth.ToString("dd.MM.yyyy")}";
        }
    }
}
