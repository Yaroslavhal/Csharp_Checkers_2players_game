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

namespace Checkers_demo_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool gameOver;
        public int whiteCounter = 12;
        public int blackCounter = 12;
        bool change;
        Ellipse damka;
        bool firstMove;
        Image lastClicked;
        Button move1;
        Button move2;
        Button move3;
        Button move4;
        string whiteFigureImageWay = $"https://github.com/YuraMihailov123/CheckersGame/blob/master/CheckersGame/Sprites/w.png?raw=true";
        string blackFigureImageWay = $"https://github.com/YuraMihailov123/CheckersGame/blob/master/CheckersGame/Sprites/b.png?raw=true";
        Image beaten1;
        Image beaten2;
        Image beaten3;
        Image beaten4;
        public MainWindow()
        {
            gameOver = false;
            change = false;
            InitializeComponent();
            firstMove = true;
        }
        private void ResultCheck()
        {
            int counterBlack = 0;
            int counterWhite = 0;
            foreach(Image item in mainGrid.Children)
            {
                if (item.Source.ToString() == whiteFigureImageWay)
                    counterWhite++;
                if (item.Source.ToString() == blackFigureImageWay)
                    counterBlack++;
            }
            if (counterBlack == 0)
            {
                result.Background = Brushes.Brown;
                result.Content = "White wins";
                
            }
            if (counterWhite == 0)
            {
                result.Background = Brushes.Brown;
                result.Content = "Black wins";
            }
        }
        private void FigureMove_Click(object sender, RoutedEventArgs e)/////
        {
            var row = Grid.GetRow(sender as Button);
            var column = Grid.GetColumn(sender as Button);

            var row1 = Grid.GetRow(lastClicked);
            var column1 = Grid.GetColumn(lastClicked);
            mainGrid.Children.Remove(move1);
            mainGrid.Children.Remove(move2);
            mainGrid.Children.Remove(move3);
            mainGrid.Children.Remove(move4);
            mainGrid.Children.Remove(lastClicked);
            mainGrid.Children.Add(lastClicked);
            Grid.SetRow(lastClicked, row);
            Grid.SetColumn(lastClicked, column);
            if (beaten1 != null || beaten2 != null || beaten3 != null || beaten4 != null)
            {
                if (column < column1)
                {
                    if (firstMove == true)
                    {
                        if (row < row1)
                            mainGrid.Children.Remove(beaten1); 
                        else
                            mainGrid.Children.Remove(beaten3);
                    }
                    else
                    {
                        if (row > row1)
                            mainGrid.Children.Remove(beaten1);
                        else
                            mainGrid.Children.Remove(beaten3);
                    }
                }
                if (column > column1)
                {
                    if (firstMove == true)
                    {
                        if (row < row1)
                            mainGrid.Children.Remove(beaten2);
                        else
                            mainGrid.Children.Remove(beaten4);
                    }
                    else
                    {
                        if (row > row1)
                            mainGrid.Children.Remove(beaten2);
                        else
                            mainGrid.Children.Remove(beaten4);
                    }
                
                }
                if (firstMove == true)
                {
                    change = false;
                    whiteFigureClick(lastClicked);
                }
                else
                {
                    change = false;
                    blackFigureClick(lastClicked);
                }
            }
            else
            {
                if (firstMove == false)
                    firstMove = true;
                else
                    firstMove = false;
                beaten1 = null;
                beaten2 = null;

            }
        }
        private void queenCheck()// ДАМКА
        {
            foreach(Image item in mainGrid.Children)
            {
                if (Grid.GetRow(item) == 7 && item.Source.ToString() == blackFigureImageWay)
                {
                    MessageBox.Show("worked");
                    var column = Grid.GetColumn(item);
                    var row = Grid.GetRow(item);
                    mainGrid.Children.Remove(item);
                    damka = new Ellipse() { Fill = Brushes.Yellow, Margin = new Thickness(13) };
                    mainGrid.Children.Add(damka);
                    Grid.SetColumn(damka, column);
                    Grid.SetRow(damka, row);
                }
                if (Grid.GetRow(item) == 0 && item.Source.ToString() == whiteFigureImageWay)
                {
                    mainGrid.Children.Remove(item);
                    var column = Grid.GetColumn(item);
                    var row = Grid.GetRow(item);
                    damka = new Ellipse() { Fill = Brushes.Yellow, Margin = new Thickness(13) };
                    mainGrid.Children.Add(damka);
                    Grid.SetColumn(damka, column);
                    Grid.SetRow(damka, row);
                }
            }
        }

        private void whiteFigureClick(object sender)
        {
            beaten1 = null;
            beaten2 = null;
            beaten3 = null;
            beaten4 = null;
            if (firstMove == true)
            {
                bool beat1 = false;
                bool beat2 = false;
                bool beat3 = false;
                bool beat4 = false;
                bool move1active = true;
                bool move2active = true;
                lastClicked = (Image)sender;
                mainGrid.Children.Remove(move1);
                mainGrid.Children.Remove(move2);
                mainGrid.Children.Remove(move3);
                mainGrid.Children.Remove(move4);
                var row = Grid.GetRow(lastClicked);
                var column = Grid.GetColumn(lastClicked);
                foreach (Image item in mainGrid.Children)
                {
                    if (Grid.GetRow(item) == row - 1 && Grid.GetColumn(item) == column - 1)
                    {
                        if (item.Source.ToString() == blackFigureImageWay && Grid.GetColumn(item) != 0 && Grid.GetRow(item) != 0)
                        {
                            beat1 = true;
                            beaten1 = item;
                        }
                        move1active = false;
                    }
                    if (Grid.GetRow(item) == row - 1 && Grid.GetColumn(item) == column + 1)
                    {
                        
                        if (item.Source.ToString() == blackFigureImageWay && Grid.GetColumn(item) != 7 && Grid.GetRow(item) != 0)
                        {
                            beat2 = true;
                            beaten2 = item;
                        }
                        //MessageBox.Show(Grid.GetColumn(item).ToString());
                        move2active = false;
                    }

                    if (Grid.GetRow(item) == row + 1 && Grid.GetColumn(item) == column - 1)
                    {
                        if (item.Source.ToString() == blackFigureImageWay && Grid.GetColumn(item) != 0 && Grid.GetRow(item) != 0)
                        {
                            beat3 = true;
                            beaten3 = item;
                        }
                    }

                    if (Grid.GetRow(item) == row + 1 && Grid.GetColumn(item) == column + 1)
                    {
                        if (item.Source.ToString() == blackFigureImageWay && Grid.GetColumn(item) != 0 && Grid.GetRow(item) != 0)
                        {
                            beat4 = true;
                            beaten4 = item;
                        }
                    }
                }
                if (beat1 == true)
                {
                    foreach (Image item in mainGrid.Children)
                    {
                        if (Grid.GetRow(item) == row - 2 && Grid.GetColumn(item) == column - 2)
                        {
                            beat1 = false;
                            beaten1 = null;
                        }
                    }
                }
                if (beat2 == true)
                {
                    foreach (Image item in mainGrid.Children)
                    {
                        if (Grid.GetRow(item) == row - 2 && Grid.GetColumn(item) == column + 2)
                        {
                            beat2 = false;
                            beaten2 = null;
                        }
                    }
                }

                if (beat3 == true)
                {
                    foreach (Image item in mainGrid.Children)
                    {
                        if (Grid.GetRow(item) == row + 2 && Grid.GetColumn(item) == column - 2)
                        {
                            beat3 = false;
                            beaten3 = null;
                        }
                    }
                }

                if (beat4 == true)
                {
                    foreach (Image item in mainGrid.Children)
                    {
                        if (Grid.GetRow(item) == row + 2 && Grid.GetColumn(item) == column + 2)
                        {
                            beat4 = false;
                            beaten4 = null;
                        }
                    }
                }
                if (beat1 == true && column != 1 && row != 1)
                {
                    move1active = false;
                    move2active = false;
                    move1 = new Button() { Background = Brushes.Red, Opacity = 10 };
                    move1.AddHandler(Button.ClickEvent, new RoutedEventHandler(FigureMove_Click));
                    mainGrid.Children.Add(move1);
                    Grid.SetColumn(move1, column - 2);
                    Grid.SetRow(move1, row - 2);
                }
                if (beat2 == true && column != 6 && row != 1)
                {
                    move1active = false;
                    move2active = false;
                    move2 = new Button() { Background = Brushes.Red, Opacity = 10 };
                    move2.AddHandler(Button.ClickEvent, new RoutedEventHandler(FigureMove_Click));
                    mainGrid.Children.Add(move2);
                    Grid.SetColumn(move2, column + 2);
                    Grid.SetRow(move2, row - 2);
                }
                if (beat3 == true && column != 1 && row != 6) 
                {
                    move1active = false;
                    move2active = false;
                    move3 = new Button() { Background = Brushes.Red, Opacity = 10 };
                    move3.AddHandler(Button.ClickEvent, new RoutedEventHandler(FigureMove_Click));
                    mainGrid.Children.Add(move3);
                    Grid.SetColumn(move3, column - 2);
                    Grid.SetRow(move3, row + 2);
                }
                if (beat4 == true && column != 6 && row != 6)
                {
                    move1active = false;
                    move2active = false;
                    move4 = new Button() { Background = Brushes.Red, Opacity = 10 };
                    move4.AddHandler(Button.ClickEvent, new RoutedEventHandler(FigureMove_Click));
                    mainGrid.Children.Add(move4);
                    Grid.SetColumn(move4, column + 2);
                    Grid.SetRow(move4, row + 2);
                }
                if (change == true && move1active == true || change == true && move2active == true )
                {
                    if (column != 7 && column != 0)
                    {
                        if (move1active == true)
                        {
                            move1 = new Button() { Background = Brushes.Red, Opacity = 10 };
                            move1.AddHandler(Button.ClickEvent, new RoutedEventHandler(FigureMove_Click));
                            mainGrid.Children.Add(move1);
                            Grid.SetColumn(move1, column - 1);
                            Grid.SetRow(move1, row - 1);
                        }
                        if (move2active == true)
                        {
                            move2 = new Button() { Background = Brushes.Red, Opacity = 10 };
                            move2.AddHandler(Button.ClickEvent, new RoutedEventHandler(FigureMove_Click));
                            mainGrid.Children.Add(move2);
                            Grid.SetColumn(move2, column + 1);
                            Grid.SetRow(move2, row - 1);
                        }
                    }
                    else if (column == 7)
                    {
                        if (move1active == true)
                        {
                            move1 = new Button() { Background = Brushes.Red, Opacity = 10 };
                            move1.AddHandler(Button.ClickEvent, new RoutedEventHandler(FigureMove_Click));
                            mainGrid.Children.Add(move1);
                            Grid.SetColumn(move1, column - 1);
                            Grid.SetRow(move1, row - 1);
                        }
                    }
                    else if (column == 0)
                    {
                        if (move2active == true)
                        {
                            move1 = new Button() { Background = Brushes.Red, Opacity = 10 };
                            move1.AddHandler(Button.ClickEvent, new RoutedEventHandler(FigureMove_Click));
                            mainGrid.Children.Add(move1);
                            Grid.SetColumn(move1, column + 1);
                            Grid.SetRow(move1, row - 1);
                        }
                    }
                }
                else if (beaten1 == null && beaten2 == null && beaten3 == null && beaten4 == null)
                {
                    firstMove = false;
                }
            }
        }
        private void Image_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)// WHITE FIGURE CLICK
        {
            if (gameOver == false)
            {
                change = true;
                whiteFigureClick(sender);
            }      
        }
        private void blackFigureClick(object sender)
        {
            beaten1 = null;
            beaten2 = null;
            beaten3 = null;
            beaten4 = null;
            if (firstMove == false)
            {
                bool beat1 = false;
                bool beat2 = false;
                bool beat3 = false;
                bool beat4 = false;
                bool move1active = true;
                bool move2active = true;
                lastClicked = (Image)sender;
                mainGrid.Children.Remove(move1);
                mainGrid.Children.Remove(move2);
                mainGrid.Children.Remove(move3);
                mainGrid.Children.Remove(move4);
                var row = Grid.GetRow(lastClicked);
                var column = Grid.GetColumn(lastClicked);
                foreach (Image item in mainGrid.Children)
                {
                    if (Grid.GetRow(item) == row + 1 && Grid.GetColumn(item) == column - 1)
                    {
                        if (item.Source.ToString() == whiteFigureImageWay && Grid.GetColumn(item) != 0 && Grid.GetRow(item) != 0)
                        {
                            beat1 = true;
                            beaten1 = item;
                        }
                        move1active = false;
                    }
                    if (Grid.GetRow(item) == row + 1 && Grid.GetColumn(item) == column + 1)
                    {

                        if (item.Source.ToString() == whiteFigureImageWay && Grid.GetColumn(item) != 7 && Grid.GetRow(item) != 0)
                        {
                            beat2 = true;
                            beaten2 = item;
                        }
                        //MessageBox.Show(Grid.GetColumn(item).ToString());
                        move2active = false;
                    }

                    if (Grid.GetRow(item) == row - 1 && Grid.GetColumn(item) == column - 1)
                    {
                        if (item.Source.ToString() == whiteFigureImageWay && Grid.GetColumn(item) != 0 && Grid.GetRow(item) != 0)
                        {
                            beat3 = true;
                            beaten3 = item;
                        }
                    }

                    if (Grid.GetRow(item) == row - 1 && Grid.GetColumn(item) == column + 1)
                    {
                        if (item.Source.ToString() == whiteFigureImageWay && Grid.GetColumn(item) != 0 && Grid.GetRow(item) != 0)
                        {
                            beat4 = true;
                            beaten4 = item;
                        }
                    }
                }
                if (beat1 == true)
                {
                    foreach (Image item in mainGrid.Children)
                    {
                        if (Grid.GetRow(item) == row + 2 && Grid.GetColumn(item) == column - 2)
                        {
                            beat1 = false;
                            beaten1 = null;
                        }
                    }
                }
                if (beat2 == true)
                {
                    foreach (Image item in mainGrid.Children)
                    {
                        if (Grid.GetRow(item) == row + 2 && Grid.GetColumn(item) == column + 2)
                        {
                            beat2 = false;
                            beaten2 = null;
                        }
                    }
                }

                if (beat3 == true)
                {
                    foreach (Image item in mainGrid.Children)
                    {
                        if (Grid.GetRow(item) == row - 2 && Grid.GetColumn(item) == column - 2)
                        {
                            beat3 = false;
                            beaten3 = null;
                        }
                    }
                }

                if (beat4 == true)
                {
                    foreach (Image item in mainGrid.Children)
                    {
                        if (Grid.GetRow(item) == row - 2 && Grid.GetColumn(item) == column + 2)
                        {
                            beat4 = false;
                            beaten4 = null;
                        }
                    }
                }
                if (beat1 == true && column != 1 && row != 6)
                {
                    move1active = false;
                    move2active = false;
                    move1 = new Button() { Background = Brushes.Red, Opacity = 10 };
                    move1.AddHandler(Button.ClickEvent, new RoutedEventHandler(FigureMove_Click));
                    mainGrid.Children.Add(move1);
                    Grid.SetColumn(move1, column - 2);
                    Grid.SetRow(move1, row + 2);
                }
                else
                {
                    beaten1 = null;
                }
                if (beat2 == true && column != 6 && row != 6)
                {
                    move1active = false;
                    move2active = false;
                    move2 = new Button() { Background = Brushes.Red, Opacity = 10 };
                    move2.AddHandler(Button.ClickEvent, new RoutedEventHandler(FigureMove_Click));
                    mainGrid.Children.Add(move2);
                    Grid.SetColumn(move2, column + 2);
                    Grid.SetRow(move2, row + 2);
                }
                else
                {
                    beaten2 = null;
                }
                if (beat3 == true && column != 1 && row != 1)
                {
                    move1active = false;
                    move2active = false;
                    move3 = new Button() { Background = Brushes.Red, Opacity = 10 };
                    move3.AddHandler(Button.ClickEvent, new RoutedEventHandler(FigureMove_Click));
                    mainGrid.Children.Add(move3);
                    Grid.SetColumn(move3, column - 2);
                    Grid.SetRow(move3, row - 2);
                }
                else
                {
                    beaten3 = null;
                }
                if (beat4 == true && column != 6 && row != 1)
                {
                    move1active = false;
                    move2active = false;
                    move4 = new Button() { Background = Brushes.Red, Opacity = 10 };
                    move4.AddHandler(Button.ClickEvent, new RoutedEventHandler(FigureMove_Click));
                    mainGrid.Children.Add(move4);
                    Grid.SetColumn(move4, column + 2);
                    Grid.SetRow(move4, row - 2);
                }
                else
                {
                    beaten4 = null;
                }
                if (change == true && move1active == true || change == true && move2active == true)
                {
                    if (column != 7 && column != 0)
                    {
                        if (move1active == true)
                        {
                            move1 = new Button() { Background = Brushes.Red, Opacity = 10 };
                            move1.AddHandler(Button.ClickEvent, new RoutedEventHandler(FigureMove_Click));
                            mainGrid.Children.Add(move1);
                            Grid.SetColumn(move1, column - 1);
                            Grid.SetRow(move1, row + 1);
                        }
                        if (move2active == true)
                        {
                            move2 = new Button() { Background = Brushes.Red, Opacity = 10 };
                            move2.AddHandler(Button.ClickEvent, new RoutedEventHandler(FigureMove_Click));
                            mainGrid.Children.Add(move2);
                            Grid.SetColumn(move2, column + 1);
                            Grid.SetRow(move2, row + 1);
                        }
                    }
                    else if (column == 7)
                    {
                        if (move1active == true)
                        {
                            move1 = new Button() { Background = Brushes.Red, Opacity = 10 };
                            move1.AddHandler(Button.ClickEvent, new RoutedEventHandler(FigureMove_Click));
                            mainGrid.Children.Add(move1);
                            Grid.SetColumn(move1, column - 1);
                            Grid.SetRow(move1, row + 1);
                        }
                    }
                    else if (column == 0)
                    {
                        if (move2active == true)
                        {
                            move1 = new Button() { Background = Brushes.Red, Opacity = 10 };
                            move1.AddHandler(Button.ClickEvent, new RoutedEventHandler(FigureMove_Click));
                            mainGrid.Children.Add(move1);
                            Grid.SetColumn(move1, column + 1);
                            Grid.SetRow(move1, row + 1);
                        }
                    }
                }
                else if (beaten1 == null && beaten2 == null && beaten3 == null && beaten4 == null)
                {
                    firstMove = true;
                }
            }
        }
        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)//BLACK FIGURE CLICK
        {
            if (gameOver == false)
            {
                change = true;
                blackFigureClick(sender);
            }
        }
    }
}
