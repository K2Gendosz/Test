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

        public void getSubsList(List<Subscriber> subsList)
        {
            DataGridSubscribers.ItemsSource = subsList;
           
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (searchBox.Text != "" || searchBox.Text != "Search")
            {
                getSubsList(MainWindow.manager.Search(searchBox.Text));
            }



        }

        private void searchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text == "Search")
            {
                searchBox.Foreground = new SolidColorBrush(Color.FromRgb(1, 1, 1));
                searchBox.Text = "";
            }


        }

        private void searchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text == "")
            {
                searchBox.Foreground = new SolidColorBrush(Color.FromRgb(128, 128, 128));
                searchBox.Text = "Search";
                getSubsList(MainWindow.manager.getSubscribersList());
            }
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
                EditBtn.IsEnabled = true;
                DelBtn.IsEnabled = true;

            
        }

        private void DataGridSubscribers_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DataGridSubscribers.SelectedItem == null)
            {
                EditBtn.IsEnabled = false;
                DelBtn.IsEnabled = false;
            }
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridSubscribers.SelectedItem != null )
            {
                MainWindow.manager.RemoveFromList(DataGridSubscribers.SelectedItem as Subscriber);
                DataGridSubscribers.SelectedItem = null;
                DataGridSubscribers.ItemsSource = MainWindow.getManagerSubList();
                MainWindow.BackToList();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenAddPage();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridSubscribers.SelectedItem != null)
            {
                MainWindow.OpenEditPage(DataGridSubscribers.SelectedItem as Subscriber);
            }
        }
    }
}
