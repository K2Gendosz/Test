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

        private void btnAddPage_Click(object sender, RoutedEventArgs e)
        {
            bool ageRedy = false;
            bool txtBoxRedy = false;
            bool sexRedy = false;
            int tmpAge = 0;
            string var = txtBoxAge.Text;

            if (!int.TryParse(var, out tmpAge) ||  tmpAge <= 0 || tmpAge > 100)  // warunek zmieniłem nie przepuszczał przy age == 20 nwm może ten && blokował
            {
                textBoxInvalid(txtBoxAge);
                ageRedy = false;
            }
            else
            {
                textboxValid(txtBoxAge);
                ageRedy = true;
            }

            if (checkIfNull(txtBoxName) || checkIfNull(txtBoxSurname) || checkIfNull(txtBoxCity) 
                || checkIfNull(txtBoxStreet) || checkIfNull(txtBoxPostal) || checkIfNull(txtBoxHouse))
            {
                MessageBox.Show("Invalid values in red colored boxes");
                txtBoxRedy = false;
            }
            else txtBoxRedy = true;

            if (string.IsNullOrEmpty(comboBoxSex.Text))
            {
                MessageBox.Show("Please select sex");
                sexRedy = false;
            }
            else sexRedy = true;

            if(sexRedy && ageRedy && txtBoxRedy)
            {
                string name = txtBoxName.Text;
                string surname = txtBoxSurname.Text;
                string city = txtBoxCity.Text;
                string postal = txtBoxPostal.Text;
                string street = txtBoxStreet.Text;
                string sex = comboBoxSex.Text;
                string houseNumber = txtBoxHouse.Text; // zmieniłem nazwe na txtBoxHouse bo mi wywalało że niema może za długie chu* wie 
                int age = int.Parse(txtBoxAge.Text);
                
                Model.Subscriber subscriber = new Model.Subscriber(name,surname,sex,city,postal,street,houseNumber,age);
                MainWindow.AddToList(subscriber);
                //Model.Manager.AddSubToList(subscriber);

                //Prostsze czyszczenie textboxow
                foreach(Control ctl in formContainer.Children)
                {
                    if (ctl.GetType() == typeof(TextBox))
                        ((TextBox)ctl).Text = string.Empty;
                }
                comboBoxSex.SelectedIndex = -1;
                //txtBoxName.Text = "";
                //txtBoxSurname.Text = "";
                //txtBoxCity.Text = "";
                //txtBoxPostal.Text = "";   // czyszczenie po dodaniu Suba do listy 
                //txtBoxStreet.Text = "";
                //txtBoxHouse.Text = "";
                //txtBoxAge.Text = "";

            }

        }
       

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

        
    }
}
