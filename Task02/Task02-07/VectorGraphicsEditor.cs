using System;
using System.Collections.Generic;
using FigureLibrary;

namespace Task02_07
{
    internal class VectorGraphicsEditor
    {
        private HashSet<IDrawable> createdFigures = new HashSet<IDrawable>();

        public HashSet<IDrawable> CreatedFigures => this.createdFigures;
        
        public void Create(IDrawable figure)
        {
            this.createdFigures.Add(figure);
        }

        public void DrawAll()
        {
            foreach (var item in this.CreatedFigures)
            {
                item.Draw();
            }
        }
    }
}