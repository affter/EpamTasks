namespace FigureLibrary
{
    public class Point
    {
        private double x, y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X { get => this.x; set => this.x = value; }

        public double Y { get => this.y; set => this.y = value; }
    }
}