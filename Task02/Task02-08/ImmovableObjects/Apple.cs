using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_08
{
    internal class Apple : Bonus
    {
        public Apple(Position position)
        {
            this.Position = position;
        }

        public override void Affect(Hero hero)
        {
            hero.Hearts = 3;
        }
    }
}
