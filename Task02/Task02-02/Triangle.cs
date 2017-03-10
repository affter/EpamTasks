using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_02
{
    internal class Triangle
    {
        private double a, b, c, perimeter, area;

        public Triangle()
        {
        }

        public Triangle(double a, double b, double c)
        {
            this.CheckExceptions(a, b, c);
            this.a = a;
            this.b = b;
            this.c = c;
            this.perimeter = this.a + this.b + this.c;
            double halfper = this.perimeter / 2;
            this.area = Math.Sqrt(halfper * (halfper - a) * (halfper - b) * (halfper - c));
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
                if (this.b != 0 && this.c != 0)
                {
                    this.perimeter = this.a + this.b + this.c;
                    double halfper = this.perimeter / 2;
                    this.area = Math.Sqrt(halfper * (halfper - this.a) * (halfper - this.b) * (halfper - this.c));
                }
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
                if (this.a != 0 && this.c != 0)
                {
                    this.perimeter = this.a + this.b + this.c;
                    double halfper = this.perimeter / 2;
                    this.area = Math.Sqrt(halfper * (halfper - this.a) * (halfper - this.b) * (halfper - this.c));
                }
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
                if (this.a != 0 && this.b != 0)
                {
                    this.perimeter = this.a + this.b + this.c;
                    double halfper = this.perimeter / 2;
                    this.area = Math.Sqrt(halfper * (halfper - this.a) * (halfper - this.b) * (halfper - this.c));
                }
            }
        }

        public double Perimeter { get => this.perimeter; }

        public double Area { get => this.area; }

        private void CheckExceptions(double a, double b, double c)
        {
            if (a < 0)
            {
                throw new ArgumentException("Невозможно создать треугольник с отрицательным ребром");
            }

            if (b < 0)
            {
                throw new ArgumentException("Невозможно создать треугольник с отрицательным ребром");
            }

            if (c < 0)
            {
                throw new ArgumentException("Невозможно создать треугольник с отрицательным ребром");
            }

            if (a + b < c || a + c < b || b + c < a)
            {
                throw new ArgumentException("Сумма двух сторон должна быть больше третьей");
            }
        }
    }
}
