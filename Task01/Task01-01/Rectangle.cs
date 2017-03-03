namespace Task01_01
{
    public class Rectangle
    {
        private int width, height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int Area => this.width * this.height;
    }
}