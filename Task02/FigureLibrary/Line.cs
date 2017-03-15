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
    }
}