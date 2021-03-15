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
        static Canvas Canva;
        public Point PrevPos;
        public Point NewPos;


        AbstractFigure ChosenFigure;
        public RedoUndoClass rewind;

        public void SetPos(Point pos)
        {
            PrevPos = NewPos;
            NewPos = pos;
        }

        public void ClearPos()
        {
            PrevPos.X = -1;
            PrevPos.Y = -1;
            NewPos.X = -1;
            NewPos.Y = -1;
            //ChosenFigure = ChosenFigure.GetNew();
        }

        public void SetFigure(AbstractFigure figure)
        {
            ChosenFigure = figure;
        }

        public void DrawCurrentFigure(double Thickness, Brush Fill, Brush Border)
        {
            if (PrevPos.X >= 0 && PrevPos.Y >= 0)
            {
                ChosenFigure = ChosenFigure.Clone() ;
                //ChosenFigure = new (ChosenFigure.GetType());
                //typeof(ChosenFigure);

                //ChosenFigure.BorderColor = Border;
                //ChosenFigure.FillColor = Fill;
                //ChosenFigure.Thickness = Thickness;
                ChosenFigure.NewPos = NewPos;
                ChosenFigure.PrevPos = PrevPos;
                NewPos = ChosenFigure.Draw();
                if (!Canva.Children.Contains(ChosenFigure.FigureArea))
                {
                    Canva.Children.Add(ChosenFigure.FigureArea);
                    rewind.AddToFigureList(ChosenFigure);
                }
            }
        }

        public Paint(Canvas canvaToDraw)
        {
            ChosenFigure = new MyLine(Canva,2,Brushes.Black,Brushes.White);
            //AbstractFigure.AreaToDraw = canvaToDraw;
            Canva = canvaToDraw;
            NewPos = new Point() { X = -1, Y = -1 };
            PrevPos = new Point() { X = -1, Y = -1 };
            rewind = new RedoUndoClass(Canva);
        }
    }
}
