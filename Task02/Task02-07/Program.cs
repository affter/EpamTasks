using FigureLibrary;

namespace Task02_07
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Drawer.Draw(new Line(new Point(1, 1), new Point(2, 2)));
            Drawer.Draw(new Circle(new Point(1, 1), 2));
            Drawer.Draw(new Round(new Point(1, 1), 2));
            Drawer.Draw(new Ring(new Point(1, 1), 2, 3));
            Drawer.Draw(new Rectangle(new Point(1, 1), 2, 3));
        }
    }
}