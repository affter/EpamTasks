using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.Entities;

namespace Task06.DalContracts
{
    public interface IAwardsDao
    {
        void Add(Award award);

        void Remove(int id);

        IEnumerable<Award> GetAll();
        IEnumerable<Award> GetByTitleLike(string searchString);
    }
}
