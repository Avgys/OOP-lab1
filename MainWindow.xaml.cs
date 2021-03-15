using Figures;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
            paint.rewind.Backward();
        }

        private void Canva_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //paint.SetPos(e.GetPosition(Canva));
        }


        private void Canva_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            paint.SetPos(e.GetPosition(Canva));
            SolidColorBrush LineBrush;
            if (SelectedLineColor.SelectedColor == null)
            {
                LineBrush = Brushes.Black;
            }
            else
                LineBrush = new SolidColorBrush((Color)SelectedLineColor.SelectedColor);
            SolidColorBrush FillBrush;
            if (SelectedFillColor.SelectedColor == null)
            {
                FillBrush = Brushes.White;
            }
            else
                FillBrush = new SolidColorBrush((Color)SelectedFillColor.SelectedColor);
            paint.DrawCurrentFigure(Convert.ToDouble(StrokeWidth.Text), FillBrush, LineBrush);
        }

        private void Canva_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Escape))
            {
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
            paint.SetFigure(new MyPolygon(Canva));
        }

        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            paint.SetFigure(new MyRectangle(Canva));
        }

        private void Ellipes_Click(object sender, RoutedEventArgs e)
        {
            paint.SetFigure(new MyEllipse(Canva));
        }

        private void Line_Click(object sender, RoutedEventArgs e)
        {
            paint.SetFigure(new MyLine(Canva));
        }

        private void BrokenLine_Click(object sender, RoutedEventArgs e)
        {
            paint.SetFigure(new MyBrokenLine(Canva));
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Program.Close();
        }
    }
}
