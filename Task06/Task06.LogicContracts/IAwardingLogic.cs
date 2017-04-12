﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06.LogicContracts
{
    public interface IAwardingLogic
    {
        bool RemoveAwardFromUser(int userID, int awardID);
        bool AwardUser(int userID, int awardID);
        IEnumerable<int> GetUserAwards(int userID);
    }
}
