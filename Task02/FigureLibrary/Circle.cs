using System;

namespace FigureLibrary
{
    public class Circle : RoundShape
    {
        public Circle(Point center, double radius) : base(center, radius)
        {
        }

        public double Circumference => 2 * Math.PI * this.Radius; 
    }
}