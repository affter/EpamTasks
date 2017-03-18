using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_08
{
    internal abstract class Monster : MovableObject
    {
        private int damage;

        public int Damage
        {
            get => this.damage;

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Урон монстра не может быть меньше или равен нулю");
                }

                this.damage = value;
            }
        }

        public void Attack(Hero hero)
        {
            hero.Hearts -= this.damage;
        }

        public override void InteractWithObstacle(Obstacle obstacle)
        {
            obstacle.Durability -= this.Damage;
        }
    }
}
