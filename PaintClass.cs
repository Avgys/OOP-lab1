using Figures;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawNamespace
{
    public class Paint
    {
        //private SortedSet<AbstractFigure> AvailableFigures;

        private List<AbstractFigure> FigureList;
        static Canvas Canva;

        public Point prevPos;
        public Point newPos;
        private PointCollection pointCollection;

        AbstractFigure ChosenFigure;
        public Redo_UndoClass rewind;        

        public void SetPos(Point pos)
        {
            prevPos = newPos;
            newPos = pos;
        }       

        public void ClearPos()
        {
            prevPos.X = -1;
            prevPos.Y = -1;
            newPos.X = -1;
            newPos.Y = -1;
        }

        public void SetFigure(AbstractFigure figure)
        {
            ChosenFigure = figure;
        }

        public void DrawCurrentFigure()
        {
            if (prevPos.X >= 0 && prevPos.Y >= 0)
            {
                ChosenFigure.newPos = newPos;
                ChosenFigure.prevPos = prevPos;
                newPos = ChosenFigure.Draw();
            }
        }

        public Paint(Canvas canvaToDraw)
        {
            AbstractFigure.AreaToDraw = canvaToDraw;
            Canva = canvaToDraw;
            //pointCollection = new PointCollection();
            newPos = new Point() { X = -1, Y = -1 };
            prevPos = new Point() { X = -1, Y = -1 };
            ChosenFigure = new ClassLine(Canva);
        }
        //~Paint();
    }
}
