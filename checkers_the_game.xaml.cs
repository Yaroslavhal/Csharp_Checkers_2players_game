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
using System.Windows.Shapes;

namespace Checkers_demo_2._0
{
    /// <summary>
    /// Interaction logic for checkers_the_game.xaml
    /// </summary>
    public partial class checkers_the_game : Window
    {
        Page1 desk_game;
        public checkers_the_game()
        {
            desk_game = new Page1();
            InitializeComponent();
            desk.Content = desk_game;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            desk_game = new Page1();
            desk.Content = desk_game;
        }

        private void Rotate()
        {
            if (desk_game.firstMove == false)
            {
                RotateTransform rotate = new RotateTransform(180,550,400);
                desk.RenderTransform = rotate;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (rot.Content == "off")
            {
                desk_game.rotation = false;
                rot.Content = "on";
            }
            else 
            {
                desk_game.rotation = true;
                rot.Content = "off";
            }
        }
    }
}
