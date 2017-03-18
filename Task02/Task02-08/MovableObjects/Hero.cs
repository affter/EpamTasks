using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_08
{
    internal class Hero : MovableObject
    {
        private int lives = 3, hearts = 3;

        public Hero(Position position)
        {
            this.Position = position;
        }

        public int Lives { get => this.lives; set => this.lives = value; }

        public int Hearts { get => this.hearts; set => this.hearts = value; }

        public override void InteractWithObstacle(Obstacle obstacle)
        {
            obstacle.Durability--;
        }

        public void Respawn(Position position)
        {
            if (this.Lives <= 0)
            {
                throw new Exception("Жизни закончились, игра окончена");
            }

            this.Position = position;
        }
    }
}
