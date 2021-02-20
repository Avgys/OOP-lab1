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


    public class Paint
    {
        private SortedSet<string> AvailableFigures;
        private string ChosenFigure;
        private List<Shape> FigureList;
        private int CurrStep;
        private Canvas Canva;
        private GeometryGroup groupItem;
        public Point firstPosition;
        public Point secondPosition;
        private PointCollection pointCollection;

        public void Set1Pos(Point pos)
        {
            if (ChosenFigure == "Polygon")
            {
                pointCollection.Add(pos);
            }
            else
            {
                if (ChosenFigure != "BrokenLine" || (firstPosition.X == -1))
                    firstPosition = pos;
            }
        }
        public void Set2Pos(Point pos)
        {
            secondPosition = pos;
        }

        private void DrawLine()
        {
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
            
            //groupItem.Children.Add(line);
            FigureList.Add(line);
            Canva.Children.Add(line);
            CurrStep++;
        }

        public void SetFigure(string figure)
        {
            ChosenFigure = figure;
        }

        public void EndDraw()
        {
            if (ChosenFigure == "Polygon")
                pointCollection = new PointCollection();
               DrawPolygon();
        }

        public void ClearPos()
        {

        }        

        private void DrawBrokenLine()
        {            
            if (secondPosition.X > 0 && secondPosition.Y > 0)
            {
                Line line = new Line()
                {
                    X1 = firstPosition.X,
                    X2 = secondPosition.X,
                    Y1 = firstPosition.Y,
                    Y2 = secondPosition.Y,
                    StrokeStartLineCap = PenLineCap.Round,
                    StrokeEndLineCap = PenLineCap.Round,
                    StrokeThickness = 2,
                    Stroke = Brushes.Black
                };
                Canva.Children.Add(line);
                FigureList.Add(line);
                CurrStep++;
                firstPosition = secondPosition;
                secondPosition.X = -1;
                secondPosition.Y = -1;
            }            
        }

        private void DrawPolygon()
        {
            Polygon polygon = new Polygon()
            {
                Points = pointCollection,
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round,
                StrokeThickness = 1,
                Stroke = Brushes.Black
            };
            int old_Count = FigureList.Count();
            FigureList.Add(polygon);
            CurrStep += (FigureList.Count() - old_Count);
            Canva.Children.Add(polygon);
        }

        private void DrawRectangle()
        {
            Rectangle rect = new Rectangle()
            {
                //X1 = firstPosition.X,
                //X2 = secondPosition.X,
                //Y1 = firstPosition.Y,
                //Y2 = secondPosition.Y,
                Height = Math.Abs(firstPosition.Y - secondPosition.Y),
                Width = Math.Abs(firstPosition.X - secondPosition.X),
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round,
                StrokeThickness = 1,
                Stroke = Brushes.Black
            };

            if (firstPosition.Y < secondPosition.Y)
                Canvas.SetTop(rect, firstPosition.Y);
            else
                Canvas.SetTop(rect, firstPosition.Y - rect.Height);
            if (firstPosition.X < secondPosition.X)
                Canvas.SetLeft(rect, firstPosition.X);
            else
                Canvas.SetLeft(rect, firstPosition.X - rect.Width);
            //groupItem.Children.Add(line);
            FigureList.Add(rect);
            Canva.Children.Add(rect);
            CurrStep++;
        }

        public void DrawEllipse()
        {           
            Ellipse rect = new Ellipse()
            {                   
                StrokeThickness = 2,
                //X1 = firstPosition.X,
                //X2 = secondPosition.X,
                //Y1 = firstPosition.Y,
                //Y2 = secondPosition.Y,
                Width = Math.Abs(firstPosition.X - secondPosition.X),
                Height = Math.Abs(firstPosition.Y - secondPosition.Y),
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round,
                Stroke = Brushes.Black
                
            };
            
            if (firstPosition.Y < secondPosition.Y)
                Canvas.SetTop(rect, firstPosition.Y);
            else
                Canvas.SetTop(rect, firstPosition.Y - rect.Height);
            if (firstPosition.X < secondPosition.X)
                Canvas.SetLeft(rect, firstPosition.X);
            else
                Canvas.SetLeft(rect, firstPosition.X - rect.Width);
            //rect.Fill;
            FigureList.Add(rect);
            Canva.Children.Add(rect);
            CurrStep++;
        }

        public void DrawCurrentFigure()
        {
            while ((FigureList.Count - 1) > CurrStep)
            {
                FigureList.RemoveAt(FigureList.Count - 1);
            }
            if (ChosenFigure == "Line") DrawLine();
            if (ChosenFigure == "Rectangle") DrawRectangle();
            if (ChosenFigure == "Ellipse") DrawEllipse();
            //if (ChosenFigure == "Polygon") DrawPolygon();
            if (ChosenFigure == "BrokenLine") DrawBrokenLine();
            
        }

        public void RemoveLastAdded()
        {
            if (FigureList.Count >= 1 && CurrStep >= 0)
            {
                Canva.Children.Remove(FigureList[CurrStep]);
                CurrStep--;
            }
        }

        public void BackLastRemoved()
        {
            if (FigureList.Count-1 > CurrStep)
            {
                Canva.Children.Add(FigureList[CurrStep+1]);
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

        public Paint(Canvas canvaToDraw)
        {
            pointCollection = new PointCollection();
            secondPosition = new Point() { X = -1, Y = -1 };
            firstPosition = new Point() { X = -1, Y = -1 };
            FigureList = new List<Shape>();
            groupItem = new GeometryGroup();
            Canva = canvaToDraw;
            CurrStep = -1;

            ChosenFigure = "Line";
            AvailableFigures = new SortedSet<string>();
            AvailableFigures.Add("Line");
            AvailableFigures.Add("Broken Line");
            AvailableFigures.Add("Rectangle");
            AvailableFigures.Add("Ellipse");
            AvailableFigures.Add("Polygon");
            AvailableFigures.Add("BrokenLine");
            //figure = new GroupItem();
        }
        //~Paint();
    }

    public partial class MainWindow : Window
    {

        List<Line> LineList = new List<Line>();
        Point firstPosition = new Point();
        Point secondPosition = new Point();
        Paint area;
        public MainWindow()
        {   
            InitializeComponent();
            area = new Paint(Canva);
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            area.RemoveLastAdded();
        }

        private void Canva_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {   
            area.Set1Pos(e.GetPosition(Canva)); 
        }


        private void Canva_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            area.Set2Pos(e.GetPosition(Canva));
            area.DrawCurrentFigure();
            //DrawLine(e);
            
        }

        bool needToDraw = false;
         
        private void Canva_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }       

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Escape))
            {
                area.EndDraw();
                needToDraw = false;
                area.secondPosition.X = -1;
                area.secondPosition.Y = -1;
                area.firstPosition.X = -1;
                area.firstPosition.Y = -1;
            }
        }

        private void Canva_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            area.RemoveAll();
            //while (LineList.Count >= 1)
            //{
            //    Canva.Children.Remove(LineList[LineList.Count - 1]);
            //    LineList.RemoveAt(LineList.Count - 1);
            //}
        }

        private void Re_Undo_Click(object sender, RoutedEventArgs e)
        {
            area.BackLastRemoved();
        }

        private void Polygon_Click(object sender, RoutedEventArgs e)
        {
            area.SetFigure("Polygon");
        }
    }
}
