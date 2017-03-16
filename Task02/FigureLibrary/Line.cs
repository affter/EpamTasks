using System;

namespace FigureLibrary
{
    public class Line : Figure
    {
        private Point end;

        public Line(Point start, Point end)
        {
            this.End = end;
            this.Point = start;
        }

        public Point End { get => this.end; set => this.end = value; }

        public double Length
        {
            get
            {
                double difX = this.Point.X - this.End.X;
                double difY = this.Point.Y - this.End.Y;
                return Math.Sqrt((difX * difX) + (difY * difY));
            }
        }
    }
}