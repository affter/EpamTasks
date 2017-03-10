using System;

namespace Task02_01
{
    internal class Round
    {
        private double radius, perimeter, area;

        public Round()
        {

        }

        public Round(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("Невозможно создать круг с отрицательным радиусом", nameof(radius));
            }

            this.radius = radius;
            this.perimeter = 2 * Math.PI * radius;
            this.area = Math.PI * radius * radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Невозможно создать круг с отрицательным радиусом", nameof(this.radius));
                }

                this.radius = value;
                this.perimeter = 2 * Math.PI * value;
                this.area = Math.PI * value * value;
            }
        }

        public double Perimeter { get => this.perimeter; }

        public double Area { get => this.area; }
    }
}
