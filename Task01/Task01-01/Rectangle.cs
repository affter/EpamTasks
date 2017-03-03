using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01_01
{
    public class Rectangle
    {
        int width, height;
        public int Area => width * height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }
}
