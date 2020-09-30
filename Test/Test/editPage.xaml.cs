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
        List<Subscriber> SubscribersList;
        private Subscriber SelectedItem;
        //public editPage(List<Test.Model.Subscriber> subscribersList)
        //{
        //    InitializeComponent();
        //    this.SubscribersList = subscribersList;
        //    resetComboList();

        //}

        public editPage(List<Subscriber> subList)
        {
            InitializeComponent();
            this.SubscribersList = subList;
            resetAndReloadComboList(subList);
        }

        //Wypełnia dane z wybranego elementu listy
        private void comboBoxItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // wyszukanie wybranego obiektu 
            if (comboBoxItem.SelectedIndex != -1)
            {
                int id = comboBoxItem.SelectedIndex;

                foreach (var item in SubscribersList)
                {
                    if (SubscribersList.IndexOf(item) == id) // zmienilem na ywszukiwanie po ID
                    {
                        txtBoxName.Text = item.FirstName;
                        txtBoxSurname.Text = item.SecondName;
                        txtBoxAge.Text = item.Age.ToString();
                        txtBoxCity.Text = item.City;
                        txtBoxStreet.Text = item.StreetAddress;
                        txtBoxHouse.Text = item.HouseNumber;
                        txtBoxPostal.Text = item.PostalCode;
                        switch (item.Sex)
                        {
                            case "Male":
                                comboBoxSex.SelectedItem = male;
                                break;
                            case "Female":
                                comboBoxSex.SelectedItem = female;
                                break;
                            default:
                                break;
                        }
                        SelectedItem = item;
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {


            if (validateEditForm())
            {
                Subscriber newSubscrober;
                string name = txtBoxName.Text;
                string surname = txtBoxSurname.Text;
                string age = txtBoxAge.Text;
                string city = txtBoxCity.Text;
                string street = txtBoxStreet.Text;
                string postal = txtBoxPostal.Text;
                string sex = comboBoxSex.SelectedItem.ToString();
                string houseNumber = txtBoxHouse.Text;
                newSubscrober = new Subscriber(name, surname, sex, city, postal, street, houseNumber, int.Parse(age));
                MainWindow.EditFromList(comboBoxItem.SelectedIndex, newSubscrober);
            }
            else
            {
                MessageBox.Show("You have to fill fields");
            }
        }

        private bool validateEditForm()
        {
            bool isValidated = true;
            int age;
            if (comboBoxItem.SelectedIndex == -1)
            {
                MessageBox.Show("Subscriber to edit not selected");
                return false;
            }
            else
            {


                foreach (Control tbForm in formContainer.Children)
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
                if (!int.TryParse(txtBoxAge.Text, out age) && age < 0 || age > 100)
                {
                    txtBoxAge.Background = Brushes.Red;
                    isValidated = false;
                }
                return isValidated;
            }
        }

        private void btnDell_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItem != null)
            {
                //Usuwa po indexie, było najprościej
                int removeIndex = comboBoxItem.SelectedIndex;
                MainWindow.RemoveFromList(removeIndex);

                //Znowu ulepszone czyszczenie textBoxow
                foreach (Control ctl in formContainer.Children)
                {
                    if (ctl.GetType() == typeof(TextBox))
                        ((TextBox)ctl).Text = string.Empty;
                }
                comboBoxSex.SelectedIndex = -1;
                comboBoxItem.SelectedIndex = -1;

                resetAndReloadComboList(MainWindow.getManagerSubList());
                SelectedItem = null;
            }
        }

        private void resetAndReloadComboList(List<Subscriber> subList)
        {
            comboBoxItem.Items.Clear(); // czyszczenie listy 
            loadSubscribers(subList);
        }

        private void loadSubscribers(List<Subscriber> subList)
        {
            foreach (var item in subList)
            {
                comboBoxItem.Items.Add($"{subList.IndexOf(item) + 1}. {item.FirstName} {item.SecondName}");
            }
        }
    }
}
