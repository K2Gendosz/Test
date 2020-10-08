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
    /// Logika interakcji dla klasy editPage.xaml
    /// </summary>
    public partial class editPage : Page
    {
        
        private Subscriber SelectedItem;
        //public editPage(List<Test.Model.Subscriber> subscribersList)
        //{
        //    InitializeComponent();
        //    this.SubscribersList = subscribersList;
        //    resetComboList();

        //}

        public editPage(Subscriber sub)
        {
            InitializeComponent();
            foreach (Control tbForm in container.Children)
            {
                tbForm.Foreground = Brushes.Black;
            }
                SelectedItem = sub;
            FirstName.Text = sub.FirstName;
            SecondName.Text = sub.SecondName;
            Age.Text = sub.Age.ToString();
            if (sub.Sex == "Female")
            {
                comboBox.SelectedIndex = 1;
            }
            else
            {
                comboBox.SelectedIndex = 0;
            }
            City.Text = sub.City;
            Postal.Text = sub.PostalCode;
            Street.Text = sub.StreetAddress;
            HouseNumber.Text = sub.HouseNumber;
        }

        //Wypełnia dane z wybranego elementu listy
        

        
        private bool validateEditForm()
        {
            bool isValidated = true;
            int age;


            if (int.TryParse(Age.Text,out age))
            {

           
                foreach (Control tbForm in container.Children)
                {
                    if (tbForm.GetType() == typeof(TextBox))
                    {
                        if (string.IsNullOrEmpty(((TextBox)tbForm).Text))
                        {
                            ((TextBox)tbForm).Background = Brushes.Red;
                            isValidated = false;
                        }
                        else
                        {
                            ((TextBox)tbForm).Background = Brushes.White;

                        }
                    }
                }
                if (!int.TryParse(Age.Text, out age) && age < 0 || age > 100)
                {
                    Age.Background = Brushes.Red;
                    isValidated = false;
                }
            }
            else
            {
                isValidated = false;
            }
            return isValidated;
            
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text == (sender as TextBox).Name || (sender as TextBox).Text == "Invalid Value")
            {
                (sender as TextBox).Foreground = new SolidColorBrush(Color.FromRgb(1, 1, 1));
                (sender as TextBox).Text = "";
            }
        }

        private void TextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Foreground = new SolidColorBrush(Color.FromRgb(128, 128, 128));
                (sender as TextBox).Text = (sender as TextBox).Name;

            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (validateEditForm())
            {
                SelectedItem.FirstName = FirstName.Text;
                SelectedItem.SecondName = SecondName.Text;
                SelectedItem.Age = int.Parse(Age.Text);
                SelectedItem.Sex = comboBox.Text;
                SelectedItem.City = City.Text;
                SelectedItem.PostalCode = Postal.Text;
                SelectedItem.StreetAddress = Street.Text;
                SelectedItem.HouseNumber = HouseNumber.Text;
                MainWindow.BackToList();
            }
            else
            {
                MessageBox.Show("There Is some empty textBox or age is not a number. ");
            }
            
        }

            private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.BackToList();
        }


    }
}
