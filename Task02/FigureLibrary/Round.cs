using System;

namespace FigureLibrary
{
    public class Round : RoundShape
    {
        public Round(Point center, double radius) : base(center, radius)
        {
        }

        public double Circumference { get => 2 * Math.PI * this.Radius; }

        public double Area => this.Radius * this.Radius * Math.PI; 
    }
}