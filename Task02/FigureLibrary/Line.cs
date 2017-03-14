using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLibrary
{
    public class Line : Figure
    {
        private Point end;

        public Line(Point start, Point end)
        {
            this.end = end;
            this.Point = start;
        }

        public Point Start { get => this.Point; set => this.Point = value; }

        public Point End { get => this.end; set => this.end = value; }
    }
}
