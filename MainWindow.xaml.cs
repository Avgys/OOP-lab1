using Figures;
using System;
using System.Windows;
using System.Windows.Input;


namespace Paint_OOP_lab
{
    using DrawNamespace;
    public partial class MainWindow : Window
    {      
        Paint paint;
        public MainWindow()
        {
            InitializeComponent();
            paint = new Paint(Canva);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //paint..RemoveLastAdded();
            paint.rewind.Backward();
        }

        private void Canva_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            paint.SetPos(e.GetPosition(Canva));
        }


        private void Canva_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            paint.SetPos(e.GetPosition(Canva));
            paint.DrawCurrentFigure();
        }        

        private void Canva_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Int32.Parse(StrokeWidth.Text); 

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Escape))
            {
                //paint.EndDraw();
                //needToDraw = false;
                paint.ClearPos();
            }
        }

        private void Canva_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            paint.rewind.RemoveAll();
        }

        private void Re_Undo_Click(object sender, RoutedEventArgs e)
        {
            paint.rewind.Forward();
        }

        private void Polygon_Click(object sender, RoutedEventArgs e)
        {
            //paint.SetFigure(new ClassPolygon(Canva));
        }

        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            paint.SetFigure(new ClassRectangle(Canva));
        }

        private void Ellipes_Click(object sender, RoutedEventArgs e)
        {
            paint.SetFigure(new ClassEllipse(Canva));
        }

        private void Line_Click(object sender, RoutedEventArgs e)
        {
            paint.SetFigure(new ClassLine(Canva));
        }

        private void BrokenLine_Click(object sender, RoutedEventArgs e)
        {
            //paint.SetFigure("BrokenLine");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
           Program.Close();
        }
    }
}
