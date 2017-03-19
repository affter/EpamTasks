using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_08
{
    internal abstract class MovableObject : GameObject
    {
        public virtual void Move(Direction direction)
        {
            if (direction.HasFlag(Direction.Up))
            {
                try
                {
                    this.Position.Row--;
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException("Невозможно двигаться в данном направлении");
                }
            }
            else if (direction.HasFlag(Direction.Down))
            {
                try
                {
                    this.Position.Row++;
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException("Невозможно двигаться в данном направлении");
                }
            }
            else if (direction.HasFlag(Direction.Left))
            {
                try
                {
                    this.Position.Column--;
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException("Невозможно двигаться в данном направлении");
                }
            }
            else if (direction.HasFlag(Direction.Right))
            {
                try
                {
                    this.Position.Column++;
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException("Невозможно двигаться в данном направлении");
                }
            }
        }

        public abstract void InteractWithObstacle(Obstacle obstacle);
    }
}
