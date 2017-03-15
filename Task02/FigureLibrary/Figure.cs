namespace FigureLibrary
{
    public abstract class Figure
    {
        private Point point;

        public Point Point { get => this.point; set => this.point = value; }
    }
}