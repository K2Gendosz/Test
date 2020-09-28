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
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;

namespace Test
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Test.Model.Subscriber> SubscribersList;

        public MainWindow()
        {

            InitializeComponent();
            ReadFromFile();




        }

        private static void ReadFromFile()
        {
            if (File.Exists(@"SubscribersList.json"))
            {
                string jsonStringContract = File.ReadAllText("SubscribersList.json");
                SubscribersList = JsonConvert.DeserializeObject<List<Test.Model.Subscriber>>(jsonStringContract);
            }
            else
            {
                File.Create("SubscribersList.json");
                SubscribersList = new List<Model.Subscriber>();
            }
        }

        public static void SaveToFile()
        {



            if (File.Exists(@"SubscribersList.json"))
            {
                File.Delete(@"SubscribersList.json");
            }

            string jsonString = JsonConvert.SerializeObject(SubscribersList, Formatting.Indented);

            File.WriteAllText("SubscribersList.json", jsonString);


        }

        public void AddToList(Model.Subscriber obj)
        {
            SubscribersList.Add(obj);
        }
        

        private void Main_Navigated(object sender, NavigationEventArgs e)
        {
            Main.Content = new addPage();
        }

       

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new addPage();
        }
    }
}
