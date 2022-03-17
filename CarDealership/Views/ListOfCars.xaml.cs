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
    public sealed partial class ListOfCars : UserControl
    {
        List<string> prevId=new List<string>();
        List<string> nextId=new List<string>();
        List<string> usedId=new List<string>();
        public event PointerEventHandler OpenCarPage;
        public void ManageImages()
        {
            //TO DO
        }
        public void ShowCars()
        {
            ListCar.Children.Clear();
            foreach(string id in usedId)
            {
                CarShowCase carShowCase = new CarShowCase(id);
                carShowCase.Name = id;
                carShowCase.PointerPressed += OpenCarPage;
                ListCarPanel.Children.Add(carShowCase);
            }
        }
        public ListOfCars(List<string> ids)
        {
            this.InitializeComponent();
            Prev.IsEnabled = false;
            if (ids.Count > 5)
            {
                usedId.AddRange(ids.Take(5));
                ids.RemoveRange(0, 5);
                nextId.AddRange(ids);
                Next.IsEnabled = true;
            }
            else
            {
                usedId.AddRange(ids);
                Next.IsEnabled=false;
            }
            ShowCars();
        }
        public void GoPrev()
        {
            Next.IsEnabled = true;
            if (prevId.Count > 5)
            {
                nextId.AddRange(usedId);
                usedId.AddRange(prevId.Take(5));
                prevId.RemoveRange(0, 5);
            }
            else
            {
                nextId.AddRange(usedId);
                usedId.AddRange(prevId);
                prevId.Clear();
                Prev.IsEnabled = false;
            }
            ShowCars();    
        }
        public void GoNext()
        {
            Prev.IsEnabled = true;
            if (nextId.Count > 5)
            {
                prevId.AddRange(usedId);
                usedId.AddRange(nextId.Take(5));
                nextId.RemoveRange(0, 5);
            }
            else
            {
                prevId.AddRange(usedId);
                usedId.AddRange(nextId);
                nextId.Clear();
                Next.IsEnabled = false;
            }
            ShowCars();
        }
    }
    public class OpenCarPageEventArgs : EventArgs
    {
        public string id { get; set; }
    }
}
