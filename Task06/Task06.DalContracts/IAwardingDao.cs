using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.Entities;

namespace Task06.DalContracts
{
    public interface IAwardingDao
    {
        void AwardUser(int userID, int awardID);
        void RemoveAwardFromUser(int userID, int awardID);
        IEnumerable<int> GetUserAwards(int id);
        void RemoveUserAwardsList(int userID);
    }
}
