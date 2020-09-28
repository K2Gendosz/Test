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
    /// Logika interakcji dla klasy editPage.xaml
    /// </summary>
    public partial class editPage : Page
    {
        List<Test.Model.Subscriber> SubscribersList;

        public editPage(List<Test.Model.Subscriber> subscribersList)
        {
            InitializeComponent();
            this.SubscribersList = subscribersList;
            foreach (var item in subscribersList)  // ładowanie z listy do ComboBoxa
            {
                comboBoxItem.Items.Add($"{item.FirstName} {item.SecondName} {item.StreetAddress}");
            }
        }

        private void comboBoxItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // wyszukanie wybranego obiektu 
            string[] items = comboBoxItem.SelectedItem.ToString().Split(' ');
            foreach (var item in SubscribersList)
            {
                if(item.FirstName == items[0] && item.SecondName == items[1] && item.StreetAddress == items[2])
                {
                    txtBoxName.Text = item.FirstName;
                    txtBoxSurname.Text = item.SecondName;
                    txtBoxAge.Text = item.Age.ToString();
                    txtBoxCity.Text = item.City;
                    txtBoxStreet.Text = item.StreetAddress;
                    txtBoxHouse.Text = item.HouseNumber;
                    txtBoxPostal.Text = item.PostalCode;
                    comboBoxSex.SelectedItem = item.Sex;
                }
            }

        }
    }
}
