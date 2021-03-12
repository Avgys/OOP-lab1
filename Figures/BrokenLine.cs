using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Figures
{
    class ClassBrokenLine : AbstractFigure
    {
        public override Point Draw()
        {
            if (newPos.X > 0 && newPos.Y > 0)
            {
                Line line = new Line()
                {
                    X1 = prevPos.X,
                    X2 = newPos.X,
                    Y1 = prevPos.Y,
                    Y2 = newPos.Y,
                    StrokeStartLineCap = PenLineCap.Round,
                    StrokeEndLineCap = PenLineCap.Round,
                    StrokeThickness = 2,
                    Stroke = Brushes.Black
                };
                //Canva.Children.Add(line);
                //FigureList.Add(line);
                //CurrStep++;                
            }
            return newPos;
        }
        public ClassBrokenLine(Canvas Zone) : base(Zone)
        {
        }
    }
}
