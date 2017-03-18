using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_08
{
    internal class Potion : Bonus
    {
        public Potion(Position position)
        {
            this.Position = position;
        }

        public override void Affect(Hero hero)
        {
            hero.Lives++;
        }
    }
}
