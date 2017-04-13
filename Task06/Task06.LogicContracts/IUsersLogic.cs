using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.Entities;

namespace Task06.LogicContracts
{
    public interface IUsersLogic
    {
        bool Add(string name, DateTime dateOfBirth);

        bool Remove(int id);

        IEnumerable<User> GetAll();

        bool Award(int userID, int awardID);

        bool RemoveAward(int userID, int awardID);

        IEnumerable<int> GetUserAwards(int userID);
        IEnumerable<User> GetByNameLike(string searchString);
    }
}
