using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task06.Entities;

namespace Task06.LogicContracts
{
    public interface IAwardsLogic
    {
        bool Add(string title);

        bool Remove(int id);

        IEnumerable<Award> GetAll();
    }
}
