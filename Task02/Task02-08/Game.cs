using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_08
{
    internal class Game
    {
        private int width, heigth;
        private Hero hero;
        private LinkedList<Monster> monsters;
        private LinkedList<Obstacle> obstacles;
        private LinkedList<Bonus> bonuses;

        public Game(int width, int heigth)
        {
            this.Width = width;
            this.Heigth = heigth;
        }

        public Game(int width, int heigth, Hero hero, LinkedList<Monster> monsters, LinkedList<Obstacle> obstacles, LinkedList<Bonus> bonuses)
        {
            this.Width = width;
            this.Heigth = heigth;
            this.hero = hero;
            this.monsters = monsters;
            this.obstacles = obstacles;
            this.bonuses = bonuses;
        }

        public int Width
        {
            get => this.width;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Ширина поля не может быть отрицательной");
                }

                this.width = value;
            }
        }

        public int Heigth
        {
            get => this.heigth;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Ширина поля не может быть отрицательной");
                }

                this.heigth = value;
            }
        }

        public void Initialize(Hero hero, LinkedList<Monster> monsters, LinkedList<Obstacle> obstacles, LinkedList<Bonus> bonuses)
        {
            this.obstacles = obstacles;
            foreach (var obstacle in obstacles)
            {
                foreach (var monster in monsters)
                {
                    if (monster.Position == obstacle.Position)
                    {
                        throw new ArgumentException("Монстр не может находиться на препятствии");
                    }
                }

                foreach (var bonus in bonuses)
                {
                    if (bonus.Position == obstacle.Position)
                    {
                        throw new ArgumentException("Бонус не может находиться на препятствии");
                    }
                }

                if (hero.Position == obstacle.Position)
                {
                    throw new ArgumentException("Герой не может находиться на препятствии");
                }
            }
        }

        public bool CheckObstacles(int row, int column, out Obstacle obstacle)
        {
            foreach (var obs in this.obstacles)
            {
                if (obs.Position.Row == row && obs.Position.Column == column)
                {
                    obstacle = obs;
                    return true;
                }
            }

            obstacle = null;
            return false;
        }

        public bool CheckMonsters(Position position, out Monster monster)
        {
            {
                foreach (var mons in this.monsters)
                {
                    if (mons.Position == position)
                    {
                        monster = mons;
                        return true;
                    }
                }

                monster = null;
                return false;
            }
        }

        public bool CheckBonuses(Position position, out Bonus bonus)
        {
            {
                foreach (var bon in this.bonuses)
                {
                    if (bon.Position == position)
                    {
                        bonus = bon;
                        return true;
                    }
                }

                bonus = null;
                return false;
            }
        }

        public bool CheckHero(Position position)
        {
            if (this.hero.Position == position)
            {
                return true;
            }

            return false;
        }

        public void Move(MovableObject movable, Direction direction)
        {
            int row = movable.Position.Row;
            int column = movable.Position.Column;
            Obstacle obs;

            if (direction.HasFlag(Direction.Up))
            {
                if (this.CheckObstacles(row - 1, column, out obs))
                {
                    movable.InteractWithObstacle(obs);
                }
                else
                {
                    movable.Move(Direction.Up);
                }
            }
            else if (direction.HasFlag(Direction.Down))
            {
                if (this.CheckObstacles(row + 1, column, out obs))
                {
                    movable.InteractWithObstacle(obs);
                }
                else if (row + 1 >= this.Heigth)
                {
                    throw new ArgumentException("Невозможно двигаться в данном направлении");
                }
                else
                {
                    movable.Move(Direction.Down);
                }
            }
            else if (direction.HasFlag(Direction.Left))
            {
                if (this.CheckObstacles(row, column - 1, out obs))
                {
                    movable.InteractWithObstacle(obs);
                }
                else
                {
                    movable.Move(Direction.Left);
                }
            }
            else if (direction.HasFlag(Direction.Right))
            {
                if (this.CheckObstacles(row, column + 1, out obs))
                {
                    movable.InteractWithObstacle(obs);
                }
                else if (column + 1 >= this.Width)
                {
                    throw new ArgumentException("Невозможно двигаться в данном направлении");
                }
                else
                {
                    movable.Move(Direction.Right);
                }
            }
        }

        public void PlayerTurn(Direction direction)
        {
            Monster monster;
            Bonus bonus;
            this.Move(this.hero, direction);
            if (this.CheckMonsters(this.hero.Position, out monster))
            {
                monster.Attack(this.hero);
            }

            if (this.hero.Hearts <= 0)
            {
                this.hero.Respawn(new Position(0, 0));
            }

            if (this.CheckBonuses(this.hero.Position, out bonus))
            {
                bonus.Affect(this.hero);
            }
        }

        public void MonstersTurn(Monster monster, Direction direction)
        {
            this.Move(monster, direction);
            if (this.CheckHero(monster.Position))
            {
                monster.Attack(this.hero);
            }
        }
    }
}
