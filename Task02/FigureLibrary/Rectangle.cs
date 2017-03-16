﻿using System;

namespace FigureLibrary
{
    public class Rectangle : Figure, IHasArea
    {
        private double width, height;

        public Rectangle(Point upperLeftCorner, double width, double height)
        {
            this.Point = upperLeftCorner;
            this.Width = width;
            this.Heigth = height;
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

        public double Heigth
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

        public double Area => this.Width * this.Heigth;

        public double Perimeter => (this.Width + this.Heigth) * 2;
    }
}