using System;
using System.Collections.Generic;
using FigureLibrary;

namespace Task02_07
{
    internal class VectorGraphicsEditor
    {
        private HashSet<FigureUI> createdFigures = new HashSet<FigureUI>();

        public HashSet<FigureUI> CreatedFigures => this.createdFigures;
        
        public void Create(FigureUI figure)
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