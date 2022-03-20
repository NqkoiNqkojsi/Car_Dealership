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
    public sealed partial class ErrorMessage : UserControl
    {
        public event RoutedEventHandler ClosePage;
        /// <summary>
        /// used for error messages in popup
        /// </summary>
        /// <param name="text">error message</param>
        public ErrorMessage(string text)
        {
            this.InitializeComponent();
            ErrorMessageBody.Text = text;
        }
    }
}
