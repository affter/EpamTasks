using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_08
{
    internal class Rock : Obstacle
    {
        public Rock(Position position)
        {
            this.Position = position;
            this.Durability = 5;
        }
    }
}
