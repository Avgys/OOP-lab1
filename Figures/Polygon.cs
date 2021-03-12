using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Figures
{
    class ClassPolygon : AbstractFigure
    {
        Polygon polygon;
        private PointCollection pointCollection;
        
        public ClassPolygon(Canvas Zone) : base(Zone)
        {

        }

        public override AbstractFigure GetNew()
        {
            Canvas buff = FigureArea;
            PointCollection buffCollection = pointCollection;
            if (buff == null)
            {
                return new ClassPolygon(AreaToDraw)
                {
                    FigureArea = new Canvas(),
                    pointCollection = new PointCollection()
                };
            }
            else
            {                
                return this;
            }
        }

        public override Point Draw()
        {
            if (pointCollection.Count < 1)
            {                
                polygon = new Polygon()
                {
                    Points = pointCollection,
                    StrokeStartLineCap = PenLineCap.Round,
                    StrokeEndLineCap = PenLineCap.Round,
                    StrokeThickness = Thickness,
                    Stroke = BorderColor,
                    Fill = FillColor
                };
                FigureArea.Children.Add(polygon);
                pointCollection.Add(PrevPos);
            }
            pointCollection.Add(NewPos);
            return NewPos;
        }       

        //public override Point Draw()
        //{
        //    if (NewPos.X > 0 && NewPos.Y > 0)
        //    {
        //        line = new Line()
        //        {
        //            X1 = PrevPos.X,
        //            X2 = NewPos.X,
        //            Y1 = PrevPos.Y,
        //            Y2 = NewPos.Y,
        //            StrokeStartLineCap = PenLineCap.Round,
        //            StrokeEndLineCap = PenLineCap.Round,
        //            StrokeThickness = Thickness,
        //            Stroke = BorderColor,
        //            Fill = FillColor
        //        };
        //    }
    }
}
