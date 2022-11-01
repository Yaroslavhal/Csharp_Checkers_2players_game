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
    /// Interaction logic for result_page.xaml
    /// </summary>
    public partial class result_page : Page
    {
        public result_page(string r)
        {
            InitializeComponent();
            res.Content = r;
        }
    }
}
