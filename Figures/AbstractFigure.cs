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

    
    public abstract class AbstractFigure : object
    {
        public Canvas FigureArea { get;  }
        public Point PrevPos;
        public Point NewPos;
        protected double Thickness;
        protected Brush BorderColor;
        protected Brush FillColor;
        protected Point NullPos;

        public virtual Point Draw()
        {
            return NullPos;
        }

        //public virtual AbstractFigure GetNew()
        //{
        //    //FigureArea = new Canvas();
        //    return this;
        //}

        public virtual AbstractFigure Clone()
        {
            return (AbstractFigure)this.MemberwiseClone();
        }
        //{
        //    //FigureArea = new Canvas();
        //    return this;
        //}


        //public AbstractFigure(Canvas Zone)
        //{
        //    NullPos.X = -1;
        //    NullPos.Y = -1;
        //    BorderColor = Brushes.Black;
        //    FillColor = Brushes.White;
        //}

        public AbstractFigure(double Width = 2, Brush Fill = null, Brush Border = null)
        {
            if (Border == null)
            {
                BorderColor = Brushes.Black;
            }
            if (Fill == null)
            {
                FillColor = Brushes.White;
            }
            
            NullPos.X = -1;
            NullPos.Y = -1;
            BorderColor = Brushes.Black;
            FillColor = Brushes.White;            
            //FigureArea.Width = Zone.Width;
            //FigureArea.Height = Zone.Height;
        }
    }
}
