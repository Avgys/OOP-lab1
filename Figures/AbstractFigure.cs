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
    public class AbstractFigure  {
        public static Canvas AreaToDraw;
        public Canvas FigureArea;
        public Point prevPos;
        public Point newPos;
        public double StrokeThickness;
        public Brush Stroke;      
        public virtual Point Draw()
        {
            return new Point()
            {
                X = -1,
                Y = -1
            }; 
        }

        public AbstractFigure(Canvas Zone)
        {
            AreaToDraw = Zone;
            FigureArea = new Canvas();
        }
    }
}
