using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Figures
{
    class MyPolygon : AbstractFigure
    {
        Polygon polygon;
        private PointCollection pointCollection;
        
        public MyPolygon(double Thickness, Brush Fill, Brush Border) : base(Thickness, Fill, Border)
        {

        }

        //public override AbstractFigure GetNew()
        //{
        //    Canvas buff = FigureArea;
        //    PointCollection buffCollection = pointCollection;
        //    //if (buff == null)
        //    //{
        //    //    return new MyPolygon(AreaToDraw)
        //    //    {
        //    //        FigureArea = new Canvas(),
        //    //        pointCollection = new PointCollection()
        //    //    };
        //    //}
        //    //else
        //    //{                
        //        return this;
        //    //}
        //}

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
    }
}
