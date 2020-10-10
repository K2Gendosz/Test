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


namespace Test
{
    /// <summary>
    /// Logika interakcji dla klasy addPage.xaml
    /// </summary>
    public partial class addPage : Page
    {
        public addPage()
        {
            InitializeComponent();
        }

        private void textBoxInvalid(TextBox txtBox)
        {
            txtBox.Text = txtBox.Name;
            txtBox.Foreground = Brushes.Black;
            txtBox.Background = Brushes.Red;
        }

        private void textboxValid(TextBox txtBox)
        {
            txtBox.Background = Brushes.White;
        }

        private bool checkIfNull(TextBox txtBox)
        {
            if (String.IsNullOrEmpty(txtBox.Text) || txtBox.Text == "Invalid Value")
            {
                textBoxInvalid(txtBox);
                return true;
            }
            else
            {
                textboxValid(txtBox);
                return false;
            }
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

            if (validateForm())
            {
                string name = FirstName.Text;
                string surname = SecondName.Text;
                string city = City.Text;
                string postal = Postal.Text;
                string street = Street.Text;
                string sex = comboBox.Text;
                string houseNumber = HouseNumber.Text;
                int age = int.Parse(Age.Text);

                Model.Subscriber subscriber = new Model.Subscriber(name, surname, sex, city, postal, street, houseNumber, age);
                MainWindow.AddToList(subscriber);
                MainWindow.BackToList();
            }
        }

        private bool validateForm()
        {
            bool isValidated = true;
            int age = 0;
            if (!int.TryParse(Age.Text, out age) || age < 0 || age > 100)
            {
                textBoxInvalid(Age);
                isValidated = false;
            }
            else
            {
                textboxValid(Age);
            }
            if (!validateTextBox()) isValidated = false;

            return isValidated;
        }

        private bool validateTextBox()
        {
            bool isValidated = true;
            
            
            foreach(Control addGrid in AddGrid.Children)
            {
                if(addGrid.GetType() == typeof(TextBox))
                {
                    if (((TextBox)addGrid).Text == ((TextBox)addGrid).Name || checkIfNull(((TextBox)addGrid)))
                    {
                        textBoxInvalid(((TextBox)addGrid));
                        isValidated = false;
                    }
                    else textboxValid(((TextBox)addGrid));
                }
            }

            return isValidated;

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.BackToList();
        }
    }
}
