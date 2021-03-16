using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintProgram
{
    using Figures;
    class FiguresFactory
    {
        private List<AbstractFigure> AvailableFigures;
        AbstractFigure CurrentFigure;
    }
}
