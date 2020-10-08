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
using Test.Model;

namespace Test
{
    // Przerobione a w zasadzie całe napisane od nowa :D



    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Manager manager = new Manager();
        static showPage ShowPage = new showPage();
        static object thisWindow; 

        public MainWindow()
        {

            InitializeComponent();
            ReadFromFile();

            ContentFrame.Content = ShowPage;
            thisWindow = this;
        }

       //testowane
        private static void ReadFromFile()
        {
            if (File.Exists(@"SubscribersList.json"))
            {
                string jsonStringContract = File.ReadAllText("SubscribersList.json");
                manager.setSubscriberList(JsonConvert.DeserializeObject<List<Subscriber>>(jsonStringContract));
            }
            else
            {
                File.Create("SubscribersList.json");
                manager.setSubscriberList(new List<Subscriber>());
            }
        }
        //testowane
        public static void SaveToFile()
        {

            if (File.Exists(@"SubscribersList.json"))
            {
                File.Delete(@"SubscribersList.json");
            }

            string jsonString = JsonConvert.SerializeObject(manager.getSubscribersList(), Formatting.Indented);

            File.WriteAllText("SubscribersList.json", jsonString);
        }

        public static void AddToList(Subscriber obj)
        {
            manager.AddSubToList(obj);
        }

        public static void RemoveFromList(Subscriber sub)
        {
            
        }

        public static void EditFromList(int index, Subscriber sub)
        {
            manager.EditSub(index, sub);
        }

        private void Main_Navigated(object sender, NavigationEventArgs e)
        {
            //Main.Content = new addPage();
        }

        public static List<Subscriber> getManagerSubList()
        {
            List<Subscriber> actualList = manager.getSubscribersList();
            return actualList;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void exitLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            
            exitLabel.Foreground = new SolidColorBrush(Color.FromRgb(255,0,0));
        }

        private void exitLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            
            exitLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        

        private void Minimalize_MouseEnter(object sender, MouseEventArgs e)
        {
           minimalizeLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        }

        private void Minimalize_MouseLeave(object sender, MouseEventArgs e)
        {
            minimalizeLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void Minimalize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        static public void BackToList()
        {
            (thisWindow as MainWindow).ContentFrame.Content = new showPage();
        }
        static public void OpenAddPage()
        {
            (thisWindow as MainWindow).ContentFrame.Content = new addPage();
        }

        static public void OpenEditPage(Subscriber sub)
        {
            (thisWindow as MainWindow).ContentFrame.Content = new editPage(sub);
        }


    }
}


