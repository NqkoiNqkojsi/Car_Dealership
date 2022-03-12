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
    public sealed partial class CarShowCase : UserControl
    {
        public string id { get; set; }
        private void MakeContent()
        {
            List<string> components=new List<string>();

        }
        public CarShowCase(string id)
        {
            this.InitializeComponent();
            this.id = id;
            MakeContent();
        }
        private void OpenCarPage()
        {
            
        }
    }
}
