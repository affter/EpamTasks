using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.DalContracts;
using Task06.Entities;

namespace Task06.InMemoryDal
{
    public class UserDao : IUserDao
    {
        private ICollection<User> userCollection;
        private int maxId = 0;

        public UserDao()
        {
            userCollection = new HashSet<User>();
        }

        public void Add(User user)
        {
            user.Id = ++maxId;
            this.userCollection.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return this.userCollection.Select(n => n);
        }

        public void Remove(int id)
        {
            User user = userCollection.FirstOrDefault(n => n.Id == id);
            if (!userCollection.Remove(user))
            {
                throw new ArgumentException("Пользователь с таким идентификатором не существует");
            }
        }
    }
}
