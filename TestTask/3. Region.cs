using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask
{
    class Region
    {
        public static bool Contains(double x, double y)
        {
            if (x < 1 || x > 8 || y < 1 || y > 8)
            {
                return false;
            }
            else
            {
                if (y <= (int)x + 1)
                    return true;
                else return false;
            }
        }
    }
}
