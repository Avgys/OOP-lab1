using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Figures
{
    class MyLine : AbstractFigure
    {
        Line line;

        public MyLine( double Thickness, Brush Fill, Brush Border) : base(Thickness, Fill, Border)
        {
        }

        //public override AbstractFigure GetNew()
        //{
        //    return new MyLine(AreaToDraw)
        //    {
        //        FigureArea = new Canvas()
        //    };
        //}

        public override Point Draw()
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
            return NullPos;
        }
    }
}
