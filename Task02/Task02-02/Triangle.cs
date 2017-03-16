using System;
using FigureLibrary;

namespace Task02_02
{
    internal class Triangle : IHasArea
    {
        private double a, b, c;

        public Triangle(double a, double b, double c)
        {
            this.CheckExceptions(a, b, c);
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double A
        {
            get
            {
                return this.a;
            }

            set
            {
                this.CheckExceptions(value, this.b, this.c);
                this.a = value;
            }
        }

        public double B
        {
            get
            {
                return this.b;
            }

            set
            {
                this.CheckExceptions(value, this.b, this.c);
                this.b = value;
            }
        }

        public double C
        {
            get
            {
                return this.c;
            }

            set
            {
                this.CheckExceptions(value, this.b, this.c);
                this.c = value;
            }
        }

        public double Perimeter => this.a + this.b + this.c;

        public double Area
        {
            get
            {
                double halfper = this.Perimeter / 2;
                return Math.Sqrt(halfper * (halfper - this.a) * (halfper - this.b) * (halfper - this.c));
            }
        }

        private void CheckExceptions(double a, double b, double c)
        {
            if (a + b < c || a + c < b || b + c < a)
            {
                throw new ArgumentException("Сумма двух сторон должна быть больше третьей");
            }
        }
    }
}