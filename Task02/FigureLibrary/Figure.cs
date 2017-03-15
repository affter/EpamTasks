namespace FigureLibrary
{
    public abstract class Figure
    {
        private Point point;

        protected Point Point { get => this.point; set => this.point = value; }
    }
}