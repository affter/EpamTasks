using System;

namespace Task02_01
{
    internal class Round
    {
        private double radius, circumference, area, centerX, centerY;

        public Round()
        {
        }

        public Round(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("Невозможно создать круг с отрицательным радиусом");
            }

            this.radius = radius;
            this.circumference = 2 * Math.PI * radius;
            this.area = Math.PI * radius * radius;
        }

        public Round(double centerX, double centerY, double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("Невозможно создать круг с отрицательным радиусом");
            }

            this.centerX = centerX;
            this.centerY = centerY;
            this.radius = radius;
            this.circumference = 2 * Math.PI * radius;
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
                    throw new ArgumentException("Невозможно создать круг с отрицательным радиусом");
                }

                this.radius = value;
                this.circumference = 2 * Math.PI * value;
                this.area = Math.PI * value * value;
            }
        }

        public double Circumference { get => this.circumference; }

        public double Area { get => this.area; }

        public double CenterY { get => this.centerY; set => this.centerY = value; }

        public double CenterX { get => this.centerX; set => this.centerX = value; }
    }
}
