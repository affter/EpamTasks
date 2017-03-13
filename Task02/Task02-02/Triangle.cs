using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_02
{
    internal class Triangle
    {
        // TODO: Dont store calculables
        private double a, b, c, perimeter, area;

        public Triangle(double a, double b, double c)
        {
            this.CheckExceptions(a, b, c);
            this.a = a;
            this.b = b;
            this.c = c;
            this.RecalcProperties();
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
                this.RecalcProperties();
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
                this.RecalcProperties();
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
                this.RecalcProperties();
            }
        }

        public double Perimeter { get => this.perimeter; }

        public double Area { get => this.area; }

        private void RecalcProperties()
        {
            this.perimeter = this.a + this.b + this.c;
            double halfper = this.perimeter / 2;
            this.area = Math.Sqrt(halfper * (halfper - this.a) * (halfper - this.b) * (halfper - this.c));
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
