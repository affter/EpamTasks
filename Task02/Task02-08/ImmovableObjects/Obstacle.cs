using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_08
{
    internal abstract class Obstacle : GameObject
    {
        private int durability;

        public int Durability { get => this.durability; set => this.durability = value; }
    }
}
