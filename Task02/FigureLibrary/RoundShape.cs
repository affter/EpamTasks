using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLibrary
{
    public class RoundShape
    {
        private Point center;
        private double radius;

        public Point Center { get => this.center; set => this.center = value; }

        public double Radius
        {
            get => this.radius;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Невозможно создать круглую фигуру с отрицательным радиусом");
                }

                this.radius = value;
            }
        }
    }
}
