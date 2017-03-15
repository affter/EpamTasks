using System;

namespace FigureLibrary
{
    public abstract class RoundShape : Figure
    {
        private double radius;

        public RoundShape(Point center, double radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        public Point Center { get => this.Point; set => this.Point = value; }

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