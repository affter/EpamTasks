using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_08
{
    internal abstract class GameObject
    {
        private Position position;

        public Position Position { get => this.position; set => this.position = value; }
    }
}
