using System;

namespace FigureLibrary
{
    public abstract class RoundShape : Figure
    {
        private double radius;

        protected RoundShape(Point center, double radius)
        {
            this.Point = center;
            this.Radius = radius;
        }

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