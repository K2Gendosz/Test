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
                string[] items = comboBoxItem.SelectedItem.ToString().Split(' ');
                foreach (var item in SubscribersList)
                {
                    if (item.FirstName == items[0] && item.SecondName == items[1] && item.Age.ToString() == items[2])
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
            // razem z walidacją ogarnąć :D 
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
                comboBoxItem.Items.Add($"{item.FirstName} {item.SecondName} {item.Age}");
            }
        }
    }
}
