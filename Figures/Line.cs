using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Figures
{
    class ClassLine : AbstractFigure
    {
        Line line;

        public ClassLine(Canvas Zone) : base(Zone)
        {
        }

        public override Point Draw()
        {
            line = new Line()
            {
                X1 = prevPos.X,
                X2 = newPos.X,
                Y1 = prevPos.Y,
                Y2 = newPos.Y,
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round,
                StrokeThickness = 20,
                Stroke = Brushes.Black

            };

            FigureArea = new Canvas();
            FigureArea.Children.Add(line);
            AreaToDraw.Children.Add(FigureArea);
            return new Point()
            {
                X = -1,
                Y = -1
            };
        }


    }
}
