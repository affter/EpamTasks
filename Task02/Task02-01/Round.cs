using System;
using FigureLibrary;

namespace Task02_01
{
    public class Round : RoundShape
    {

        public Round(Point center, double radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        public double Circumference { get => 2 * Math.PI * this.Radius; }

        public double Area { get => this.Radius * this.Radius * Math.PI; }

    }
}
