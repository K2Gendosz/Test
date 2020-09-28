﻿using System;
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
            int age = 0;
            string var = txtBoxAge.Text;
            if (!int.TryParse(var, out age)) textBoxInvalid(txtBoxAge);
            else if (age < 0 || age > 100) textBoxInvalid(txtBoxAge);
            else textboxValid(txtBoxAge);
            if(checkIfNull(txtBoxName) || checkIfNull(txtBoxSurname) || checkIfNull(txtBoxCity) || checkIfNull(txtBoxStreet) || checkIfNull(txtBoxPostal))
            {
                MessageBox.Show("Invalid values in red colored boxes");
            }
            if(string.IsNullOrEmpty(comboBoxSex.Text))
            {
                MessageBox.Show("Please select sex");
            }
            //Test.MainWindow.AddToList(objekt); TU MOSZ FUNKCYJE ŁOD DODAWANIA STWORZONEGO ŁOBIEKTA DO LISTY NA  MAJN PAJDŻU

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
