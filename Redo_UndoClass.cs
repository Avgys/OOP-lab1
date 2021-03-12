using System.Collections.Generic;
using System.Windows.Controls;

namespace DrawNamespace
{
    public class Redo_UndoClass
    {
        private int CurrStep;
        private List<Canvas> FigureList;

        public void AddToFigureList()
        {

        }

        public void Backward()
        {
            if (FigureList.Count >= 1 && CurrStep >= 0)
            {
                Canva.Children.Remove(FigureList[CurrStep]);
                CurrStep--;
            }
        }

        public void Forward()
        {
            if (FigureList.Count - 1 > CurrStep)
            {
                Canva.Children.Add(FigureList[CurrStep + 1]);
                CurrStep++;
            }
        }

        public void RemoveAll()
        {
            while (FigureList.Count >= 1 && CurrStep >= 0)
            {
                Canva.Children.Remove(FigureList[CurrStep]);
                CurrStep--;
            }
        }

        Redo_UndoClass()
        {
            CurrStep = -1;
            FigureList.Clear();
        }
    }
}
