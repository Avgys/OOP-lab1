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
    public class AbstractFigure : Object
    {
        public static Canvas AreaToDraw;
        public Canvas FigureArea;
        public Point PrevPos;
        public Point NewPos;
        public double Thickness;
        public Brush BorderColor;
        public Brush FillColor;
        static protected Point NullPos;

        
        public virtual Point Draw()
        {
            return NullPos; 
        }

        public virtual AbstractFigure GetNew()
        {
            FigureArea = new Canvas();
            return new AbstractFigure(AreaToDraw);
        }

        public AbstractFigure(Canvas Zone)
        {
            NullPos.X = -1;
            NullPos.Y = -1;
            AreaToDraw = Zone;
            //FigureArea.Width = Zone.Width;
            //FigureArea.Height = Zone.Height;
        }
    }
}
