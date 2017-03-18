using System;

namespace FigureLibrary
{
    public class Rectangle : Figure, IHasArea
    {
        private double width, height;

        public Rectangle(Point upperLeftCorner, double width, double height)
        {
            this.Point = upperLeftCorner;
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get => this.width;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Невозможно создать прямоугольник с отрцательной шириной");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Невозможно создать прямоугольник с отрцательной высотой");
                }

                this.height = value;
            }
        }

        public double Area => this.Width * this.Height;

        public double Perimeter => (this.Width + this.Height) * 2;
    }
}