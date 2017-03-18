using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_08
{
    internal class Troll : Monster
    {
        public Troll(Position position)
        {
            this.Position = position;
            this.Damage = 3;
        }
    }
}
