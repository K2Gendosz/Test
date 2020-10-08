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

        //private void btnAddPage_Click(object sender, RoutedEventArgs e)
        //{
        //    bool ageRedy = false;
        //    bool txtBoxRedy = false;
        //    bool sexRedy = false;
        //    int tmpAge;
        //    string var = Age.Text;

        //    if (!int.TryParse(var, out tmpAge) || tmpAge <= 0 || tmpAge > 100)  // warunek zmieniłem nie przepuszczał przy age == 20 nwm może ten && blokował
        //    {
        //        textBoxInvalid(Age);
        //        ageRedy = false;
        //    }
        //    else
        //    {
        //        textboxValid(Age);
        //        ageRedy = true;
        //    }

        //    if (checkIfNull(FirstName) || checkIfNull(SecondName) || checkIfNull(City)
        //        || checkIfNull(Street) || checkIfNull(Postal) || checkIfNull(HouseNumber))
        //    {
        //        MessageBox.Show("Invalid values in red colored boxes");
        //        txtBoxRedy = false;
        //    }
        //    else txtBoxRedy = true;

        //    if (string.IsNullOrEmpty(comboBox.Text))
        //    {
        //        MessageBox.Show("Please select sex");
        //        sexRedy = false;
        //    }
        //    else sexRedy = true;

        //    if (sexRedy && ageRedy && txtBoxRedy)
        //    {
        //        string name = FirstName.Text;
        //        string surname = SecondName.Text;
        //        string city = City.Text;
        //        string postal = Postal.Text;
        //        string street = Street.Text;
        //        string sex = comboBox.Text;
        //        string houseNumber = HouseNumber.Text;
        //        int age = int.Parse(Age.Text);

        //        Model.Subscriber subscriber = new Model.Subscriber(name, surname, sex, city, postal, street, houseNumber, age);
        //        MainWindow.AddToList(subscriber);
        //        //Model.Manager.AddSubToList(subscriber);

        //        //Prostsze czyszczenie textboxow
        //        //foreach(Control ctl in formContainer.Children)
        //        //{
        //        //    if (ctl.GetType() == typeof(TextBox))
        //        //        ((TextBox)ctl).Text = string.Empty;
        //        //}
        //        //comboBoxSex.SelectedIndex = -1;
        //    }
        //}

        private void textBoxInvalid(TextBox txtBox)
        {
            txtBox.Text = "Invalid Value";
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
            bool ageRedy = false;
            bool txtBoxRedy = false;
            bool sexRedy = false;
            int tmpAge;
            string var = Age.Text;

            if (!int.TryParse(var, out tmpAge) || tmpAge <= 0 || tmpAge > 100)  // warunek zmieniłem nie przepuszczał przy age == 20 nwm może ten && blokował
            {
                textBoxInvalid(Age);
                ageRedy = false;
            }
            else
            {
                textboxValid(Age);
                ageRedy = true;
            }

            if (checkIfNull(FirstName) || checkIfNull(SecondName) || checkIfNull(City)
                || checkIfNull(Street) || checkIfNull(Postal) || checkIfNull(HouseNumber))
            {
                MessageBox.Show("Invalid values in red colored boxes");
                txtBoxRedy = false;
            }
            else txtBoxRedy = true;

            if (string.IsNullOrEmpty(comboBox.Text))
            {
                MessageBox.Show("Please select sex");
                sexRedy = false;
            }
            else sexRedy = true;

            if (sexRedy && ageRedy && txtBoxRedy)
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

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.BackToList();
        }
    }
}
