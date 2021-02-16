using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP_lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Line []lineArr;
        List<Line> LineList = new List<Line>();
        Point firstPosition = new Point();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Draw_Rectangle()
        {
            Line line = new Line();
            
            //rect.Fill;
            Canva.Children.Add(line);

            //StrokeStartLineCap = PenLineCap.Round,
            //StrokeEndLineCap = PenLineCap.Round,
            //StrokeThickness = 1,
            //Stroke = Brushes.Black


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LineList.Count >= 0)
            {
                Canva.Children.Remove(LineList[LineList.Count - 1]);
                LineList.RemoveAt(LineList.Count - 1);
            }
        }

        private void Canva_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            firstPosition = e.GetPosition(Canva); 
        }

        private void Canva_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point secondPosition = new Point();
            secondPosition = e.GetPosition(Canva);
            Line line = new Line()
            {
                X1 = firstPosition.X,
                X2 = secondPosition.X,
                Y1 = firstPosition.Y,
                Y2 = secondPosition.Y,
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round,
                StrokeThickness = 1,
                Stroke = Brushes.Black
            };
            LineList.Add(line);
            Canva.Children.Add(line); 
        }

        bool needToDraw = false;
         
        private void Canva_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (needToDraw == true)
            {
                Canva.Children.Add(new Line
                {
                    X1 = firstPosition.X,
                    X2 = e.GetPosition(Canva).X,
                    Y1 = firstPosition.Y,
                    Y2 = e.GetPosition(Canva).Y,
                    StrokeStartLineCap = PenLineCap.Round,
                    StrokeEndLineCap = PenLineCap.Round,
                    StrokeThickness = 2,
                    Stroke = Brushes.Black
                }
                  );
                firstPosition = e.GetPosition(Canva);
            }
            else
            {
                firstPosition = e.GetPosition(Canva);
                needToDraw = true;
            }
        }       

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Escape))
            {
                needToDraw = false;
            }
        }

        private void Canva_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
