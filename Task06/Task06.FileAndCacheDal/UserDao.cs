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
    public class UserDao : IUserDao
    {
        private static readonly string UsersFilePath = Configuration.UsersFileName;
        private ICollection<User> userCollection;
        private int maxId = 0;

        public UserDao()
        {
            this.userCollection = new HashSet<User>();
            if (File.Exists(UsersFilePath))
            {
                string[] users = File.ReadAllLines(UsersFilePath);
                for (int i = 0; i < users.Length; i++)
                {
                    string[] userFields = users[i].Split(';');
                    User user = new User(userFields[1], DateTime.Parse(userFields[2]));
                    user.Id = int.Parse(userFields[0]);
                    this.userCollection.Add(user);
                }

                this.maxId = this.userCollection.Count;
            }
        }

        public void Add(User user)
        {
            user.Id = ++this.maxId;
            this.userCollection.Add(user);

            using (StreamWriter sw = new StreamWriter(UsersFilePath, true))
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
            User userForRemoving = this.userCollection.FirstOrDefault(n => n.Id == id);
            if (!this.userCollection.Remove(userForRemoving))
            {
                throw new ArgumentException("Пользователь с таким идентификатором не существует");
            }

            File.WriteAllLines(UsersFilePath, this.userCollection.Select(SerializeUser));
        }

        private static string SerializeUser(User user)
        {
            return $"{user.Id.ToString()};{user.Name};{user.DateOfBirth.ToString("dd.MM.yyyy")}";
        }
    }
}
