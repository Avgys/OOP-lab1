using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Figures
{
    class MyBrokenLine : AbstractFigure
    {
        Line line;

        //public override AbstractFigure GetNew()
        //{
            //Canvas buff = FigureArea;
            //if (buff == null)
            //{
            //    return new MyBrokenLine(AreaToDraw)
            //    {
            //        FigureArea = new Canvas()
            //    };
            //}
            //else
            //    return new MyBrokenLine(AreaToDraw)
            //    {
            //        FigureArea = buff
            //    };
        //    return this;
        //}

        public override Point Draw()
        {
            if (NewPos.X > 0 && NewPos.Y > 0)
            {
                line = new Line()
                {
                    X1 = PrevPos.X,
                    X2 = NewPos.X,
                    Y1 = PrevPos.Y,
                    Y2 = NewPos.Y,
                    StrokeStartLineCap = PenLineCap.Round,
                    StrokeEndLineCap = PenLineCap.Round,
                    StrokeThickness = Thickness,
                    Stroke = BorderColor,
                    Fill = FillColor
                };
                FigureArea.Children.Add(line);
            }
            return NewPos;
        }
                

        public MyBrokenLine(Canvas Zone, double Thickness, Brush Fill, Brush Border) : base(Thickness, Fill, Border)
        {
        }
    }
}
