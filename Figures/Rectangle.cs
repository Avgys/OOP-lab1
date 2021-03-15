﻿using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace Figures
{
    public class MyRectangle : AbstractFigure
    {
        Rectangle rect;

        //public override AbstractFigure GetNew()
        //{
        //    return new MyRectangle(AreaToDraw)
        //    {
        //        FigureArea = new Canvas()
        //    };
        //}

        public override Point Draw()
        {
            rect = new Rectangle()
            {
                Height = Math.Abs(PrevPos.Y - NewPos.Y),
                Width = Math.Abs(PrevPos.X - NewPos.X),
                StrokeThickness = Thickness,
                Stroke = BorderColor,
                Fill = FillColor
            };          
            if (PrevPos.Y < NewPos.Y)
                Canvas.SetTop(rect, PrevPos.Y);
            else
                Canvas.SetTop(rect, PrevPos.Y - rect.Height);
            if (PrevPos.X < NewPos.X)
                Canvas.SetLeft(rect, PrevPos.X);
            else
                Canvas.SetLeft(rect, PrevPos.X - rect.Width);
            FigureArea = new Canvas();
            FigureArea.Children.Add(rect);
            return NullPos;
        }

        public MyRectangle(Canvas Zone, double Thickness, Brush Fill, Brush Border) : base(Zone, Thickness, Fill, Border)
        {
        }
    }
}
