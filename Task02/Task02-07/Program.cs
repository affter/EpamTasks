using FigureLibrary;

namespace Task02_07
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            VectorGraphicsEditor.Draw(new Line(new Point(1, 1), new Point(2, 2)));
            VectorGraphicsEditor.Draw(new Circle(new Point(1, 1), 2));
            VectorGraphicsEditor.Draw(new Round(new Point(1, 1), 2));
            VectorGraphicsEditor.Draw(new Ring(new Point(1, 1), 2, 3));
            VectorGraphicsEditor.Draw(new Rectangle(new Point(1, 1), 2, 3));
        }
    }
}