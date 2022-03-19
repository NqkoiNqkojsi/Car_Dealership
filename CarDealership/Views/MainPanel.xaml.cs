using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CarDealership.Controllers;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CarDealership.Views
{
    public sealed partial class MainPanel : UserControl
    {
        public event RoutedEventHandler ClosePage;
        public MainPanel()
        {
            this.InitializeComponent();
            GenerateYear();
            GenerateMonths();
            Month.SelectedItem = Month.Items[0];
            Day.SelectedItem = Day.Items[0];
            Year.SelectedItem = Year.Items[0];
        }
        private void GenerateYear()
        {
            for (int i = 2022; i > 1900; i--)
            {
                Year.Items.Add(i);
            }
        }
        private void GenerateMonths()
        {
            Month.Items.Add("January");
            Month.Items.Add("February");
            Month.Items.Add("March");
            Month.Items.Add("April");
            Month.Items.Add("May");
            Month.Items.Add("June");
            Month.Items.Add("July");
            Month.Items.Add("August");
            Month.Items.Add("September");
            Month.Items.Add("October");
            Month.Items.Add("November");
            Month.Items.Add("December");
        }

        private void GenerateDays(int month)
        { 
            Day.Items.Clear();
            if (month == 2)
            {
                for (int i = 1; i <= 28; i++)
                {
                    Day.Items.Add(i);
                }
            }
            else if(month % 2 != 0 || month == 7)
            {
                for (int i = 1; i <= 31; i++)
                {
                    Day.Items.Add(i);
                }
            }
            else
            {
                for (int i = 1; i <= 30; i++)
                {
                    Day.Items.Add(i);
                }
            }

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if(sender == Month)
                {  
                    GenerateDays(Month.SelectedIndex+1);  
                }
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
            }
            
          
        }

        private void Month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GenerateDays(Month.SelectedIndex+1);
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerController.IsValidPassword(passwordSignin.Password) &&
                CustomerController.IsValidEmail(emailSignin.Text)&&
                usernameSignin.Text.Length>3 &&
                telnumberSignin.Text.Length>8)
            {
                string date=Day.SelectedValue.ToString()+"."+Month.SelectedValue.ToString()+"."+Year.SelectedValue.ToString();
                DateTime dateTime = CustomerController.MakeBirthDate(date);
                CustomerController.CreateCustomer(usernameSignin.Text, dateTime, passwordSignin.Password, telnumberSignin.Text, emailSignin.Text);
            }
            ClosePage.Invoke(this, null);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void passwordSignin_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (CustomerController.IsValidPassword(passwordSignin.Password))
            {
                
            }
        }

        private void emailSignin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void usernameSignin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
