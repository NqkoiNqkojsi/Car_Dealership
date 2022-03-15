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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CarDealership.Views
{
    public sealed partial class MainPanel : UserControl
    {
        public MainPanel()
        {
            this.InitializeComponent();
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
    }
}
