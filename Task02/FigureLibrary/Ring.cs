using System;

namespace FigureLibrary
{
    public class Ring : RoundShape
    {
        private double innerRadius;

        public Ring(Point center, double innerRadius, double outerRadius) : base(center, outerRadius)
        {
            this.InnerRadius = innerRadius;
        }

        public double InnerRadius
        {
            get => this.innerRadius;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "Невозможно создать круглый объект с отрицательным радиусом");
                }

                if (value >= this.Radius)
                {
                    throw new ArgumentException("Внешний радиус не может быть меньше внутреннего");
                }

                this.innerRadius = value;
            }
        }

        public new double Radius
        {
            get => base.Radius;

            set
            {
                if (value < this.InnerRadius)
                {
                    throw new ArgumentException("Внешний радиус не может быть меньше внутреннего");
                }

                base.Radius = value;
            }
        }

        public double Area
        {
            get => Math.PI * ((this.Radius * this.Radius) - (this.InnerRadius * this.InnerRadius));
        }

        public double SumOfCircumferences
        {
            get => (2 * Math.PI) * (this.InnerRadius + this.Radius);
        }
    }
}