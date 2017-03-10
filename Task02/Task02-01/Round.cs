using System;

namespace Task02_01
{
    internal class Round
    {
        private double radius, perimeter, area;
        
        public Round(double radius)
        {
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
                this.radius = value;
                this.perimeter = 2 * Math.PI * value;
                this.area = Math.PI * value * value;
            }
        }

        public double Perimeter { get => perimeter; }

        public double Area { get => area; }
    }
}
