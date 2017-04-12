using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.Entities;

namespace Task06.DalContracts
{
    public interface IUsersDao
    {
        void Add(User user);

        void Remove(int id);

        IEnumerable<User> GetAll();
    }
}
