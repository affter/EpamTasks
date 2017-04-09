using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.Entities;

namespace Task06.LogicContracts
{
    public interface IUserLogic
    {
        bool Add(string name, DateTime dateOfBirth);

        bool Remove(int id);

        IEnumerable<User> GetAll();
    }
}
