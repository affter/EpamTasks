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