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
    class MyEllipse : AbstractFigure
    {
        Ellipse ellipse;

        //public override AbstractFigure GetNew()
        //{
        //    return new MyEllipse(AreaToDraw)
        //    {
        //        FigureArea = new Canvas()
        //    }; 
        //}

        public override Point Draw()
        {
            ellipse = new Ellipse()
            {
                Width = Math.Abs(PrevPos.X - NewPos.X),
                Height = Math.Abs(PrevPos.Y - NewPos.Y),                
                StrokeThickness = Thickness,
                Stroke = BorderColor,
                Fill = FillColor
            };

            if (PrevPos.Y < NewPos.Y)
                Canvas.SetTop(ellipse, PrevPos.Y);
            else
                Canvas.SetTop(ellipse, PrevPos.Y - ellipse.Height);
            if (PrevPos.X < NewPos.X)
                Canvas.SetLeft(ellipse, PrevPos.X);
            else
                Canvas.SetLeft(ellipse, PrevPos.X - ellipse.Width);
            
            FigureArea.Children.Add(ellipse);
            return NullPos;
        }

        public MyEllipse(double Thickness, Brush Fill, Brush Border) : base(Thickness, Fill, Border)
        {
        }
    }
}
