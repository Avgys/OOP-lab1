using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace Figures
{
    public class ClassRectangle : AbstractFigure
    {
        Rectangle rect;
        public override Point Draw()
        {
            Rectangle rect = new Rectangle()
            {
                Height = Math.Abs(prevPos.Y - newPos.Y),
                Width = Math.Abs(prevPos.X - newPos.X),
                StrokeThickness = 5,
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
            //groupItem.Children.Add(line);
            //FigureList.Add(rect);
            FigureArea = new Canvas();
            FigureArea.Children.Add(rect);
            //CurrStep++;
            AreaToDraw.Children.Add(FigureArea);
            return new Point()
            {
                X = -1,
                Y = -1
            };
        }

        public ClassRectangle(Canvas Zone) : base(Zone)
        {

        }
    }
}
