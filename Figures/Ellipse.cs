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
    class ClassEllipse : AbstractFigure
    {
        Ellipse rect;
        public override Point Draw()
        {
            rect = new Ellipse()
            {
                StrokeThickness = 2,
                Width = Math.Abs(prevPos.X - newPos.X),
                Height = Math.Abs(prevPos.Y - newPos.Y),
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round,
                Stroke = Brushes.Black

            };

            if (prevPos.Y < newPos.Y)
                Canvas.SetTop(rect, prevPos.Y);
            else
                Canvas.SetTop(rect, prevPos.Y - rect.Height);
            if (prevPos.X < newPos.X)
                Canvas.SetLeft(rect, prevPos.X);
            else
                Canvas.SetLeft(rect, prevPos.X - rect.Width);

            return new Point()
            {
                X = -1,
                Y = -1
            };
        }

        public ClassEllipse(Canvas Zone) : base(Zone)
        {

        }
    }
}
