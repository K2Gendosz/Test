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
using Test.Model;

namespace Test
{
    /// <summary>
    /// Logika interakcji dla klasy showPage.xaml
    /// </summary>
    public partial class showPage : Page
    {
        public showPage()
        {

            InitializeComponent();
        }
        
        public showPage(List<Subscriber> subList)
        {
           

            InitializeComponent();
        }

        private void DataGridSubscribers_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridSubscribers.ItemsSource = MainWindow.getManagerSubList();
        }
    }
}
