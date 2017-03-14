using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLibrary
{
    public class Figure
    {
        private Point point;

        protected Point Point { get => this.point; set => this.point = value; }
    }
}
