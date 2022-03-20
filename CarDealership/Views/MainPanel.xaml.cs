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
        /// <summary>
        /// Register page
        /// </summary>
        public MainPanel()
        {
            this.InitializeComponent();
            GenerateYear();
            GenerateMonths();
            Month.SelectedItem = Month.Items[0];
            Day.SelectedItem = Day.Items[0];
            Year.SelectedItem = Year.Items[0];
        }
        /// <summary>
        /// make the combo box data
        /// </summary>
        private void GenerateYear()
        {
            for (int i = 2022; i > 1900; i--)
            {
                Year.Items.Add(i);
            }
        }
        /// <summary>
        /// make monts combo box
        /// </summary>
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
        /// <summary>
        /// get the days in the month
        /// </summary>
        /// <param name="month"></param>
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
        /// <summary>
        /// On month change, update the days
        /// </summary>
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
                Popup p = new Popup();
                ErrorMessage errorMessage = new ErrorMessage(err.Message);
                p.Child = errorMessage;
            }
            
          
        }

        private void Month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GenerateDays(Month.SelectedIndex+1);
        }
        /// <summary>
        /// Button event to make new profile
        /// </summary>
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            //check if the fields are filled
            if (CustomerController.IsValidPassword(passwordSignin.Password) &&
                CustomerController.IsValidEmail(emailSignin.Text)&&
                usernameSignin.Text.Length>3 &&
                telnumberSignin.Text.Length>8)
            {
                //make the customer
                string date=Day.SelectedValue.ToString()+"."+Month.SelectedValue.ToString()+"."+Year.SelectedValue.ToString();
                CustomerController.CreateCustomer(usernameSignin.Text, date, passwordSignin.Password, telnumberSignin.Text, emailSignin.Text);
            }
            else
            {
                Popup p = new Popup();
                ErrorMessage errorMessage = new ErrorMessage("Can't sign up");
                p.Child = errorMessage;
            }
            ClosePage.Invoke(this, null);
        }
        /// <summary>
        /// button event to lig in a profile
        /// </summary>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (emailLogin.Text.Length>0 && passwordLogin.Password.Length>0)
            {
                string res=CustomerController.Login(emailLogin.Text, passwordLogin.Password);
            }
            ClosePage.Invoke(this, null);
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

        private void usernameSignin_TextChanged(object sender, TextChangedEventArgs e){
        
        }

        private void Year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
