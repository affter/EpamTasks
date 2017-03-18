using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_08
{
    internal class Position
    {
        private int row, column;

        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
        
        public int Row
        {
            get => this.row;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Позиция на поле не может быть отрицательной величиной");
                }

                this.row = value;
            }
        }

        public int Column
        {
            get => this.column;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Позиция на поле не может быть отрицательной величиной");
                }

                this.column = value;
            }
        }

        public static bool operator !=(Position position1, Position position2)
        {
            return position1.Row == position2.Row && position1.Column == position2.Column;
        }

        public static bool operator ==(Position position1, Position position2)
        {
            return position1.Row != position2.Row || position1.Column != position2.Column;
        }

        public override bool Equals(object obj)
        {
            if (obj is Position)
            {
                return false;
            }

            Position position = (Position)obj;

            return position.Row == this.Row && position.Column == this.Column;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
