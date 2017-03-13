using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02_01;

namespace Task02_06
{
    internal class Ring
    {
        private Round innerRound;
        private Round outerRound;
        private double area, sumOfCircumferences;

        public Ring(double centerX, double centerY, double innerRadius, double outerRadius)
        {
            if (innerRadius < 0)
            {
                throw new ArgumentException("Невозможно создать кольцо с отрицательным внутренним радиусом");
            }

            if (innerRadius < 0)
            {
                throw new ArgumentException("Невозможно создать кольцо с отрицательным внешним радиусом");
            }

            if (innerRadius > outerRadius)
            {
                throw new ArgumentException("Невозможно создать кольцо, у которого внутренний радиус больше внешнего");
            }

            this.innerRound = new Round(centerX, centerY, innerRadius);
            this.outerRound = new Round(centerX, centerY, outerRadius);
            this.area = this.outerRound.Area - this.innerRound.Area;
            this.sumOfCircumferences = this.outerRound.Circumference + this.innerRound.Circumference;
        }

        public double InnerRadius
        {
            get => this.innerRound.Radius;

            set
            {
                if (value > this.OuterRadius)
                {
                    throw new ArgumentException("Невозможно создать кольцо, у которого внутренний радиус больше внешнего");
                }

                this.innerRound.Radius = value;
                this.area = this.outerRound.Area - this.innerRound.Area;
                this.sumOfCircumferences = this.outerRound.Circumference + this.innerRound.Circumference;
            }
        }

        public double OuterRadius
        {
            get => this.outerRound.Radius;

            set
            {
                if (value < this.InnerRadius)
                {
                    throw new ArgumentException("Невозможно создать кольцо, у которого внутренний радиус больше внешнего");
                }

                this.outerRound.Radius = value;
                this.area = this.outerRound.Area - this.innerRound.Area;
                this.sumOfCircumferences = this.outerRound.Circumference + this.innerRound.Circumference;
            }
        }

        public double CenterX
        {
            get => this.outerRound.CenterX;

            set
            {
                this.outerRound.CenterX = value;
                this.innerRound.CenterX = value;
            }
        }

        public double CenterY
        {
            get => this.outerRound.CenterY;

            set
            {
                this.outerRound.CenterY = value;
                this.innerRound.CenterY = value;
            }
        }

        public double Area { get => this.area; }

        public double SumOfCircumferences { get => this.sumOfCircumferences; }
    }
}
