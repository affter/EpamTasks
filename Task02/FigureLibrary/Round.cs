using System;

namespace FigureLibrary
{
    public class Round : RoundShape, IHasArea
    {
        public Round(Point center, double radius) : base(center, radius)
        {
        }

        public double Area => this.Radius * this.Radius * Math.PI; 
    }
}