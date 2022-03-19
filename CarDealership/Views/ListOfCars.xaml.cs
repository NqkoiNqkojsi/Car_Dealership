using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
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
        List<int> prevId=new List<int>();
        List<int> nextId=new List<int>();
        List<int> usedId=new List<int>();
        public event PointerEventHandler OpenCarPage;
        public void ManageImages()
        {
            //TO DO
        }
        public async void ShowCars()
        {
            try
            {
                ListCarPanel.Children.Clear();
                foreach (int id in usedId)
                {
                    CarShowCase carShowCase = new CarShowCase(id);
                    carShowCase.Name = id.ToString();
                    await Task.Delay(100);
                    carShowCase.PointerPressed += OpenCarPage;
                    ListCarPanel.Children.Add(carShowCase);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public ListOfCars(List<int> ids)
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
        public void GoPrev(object sender, RoutedEventArgs e)
        {
            Next.IsEnabled = true;
            if (prevId.Count > 5)
            {
                nextId.AddRange(usedId);
                usedId.Clear();
                usedId.AddRange(prevId.Take(5));
                prevId.RemoveRange(0, 5);
            }
            else
            {
                nextId.AddRange(usedId);
                usedId.Clear();
                usedId.AddRange(prevId);
                prevId.Clear();
                Prev.IsEnabled = false;
            }
            ShowCars();    
        }
        public void GoNext(object sender, RoutedEventArgs e)
        {
            Prev.IsEnabled = true;
            if (nextId.Count > 5)
            {
                prevId.AddRange(usedId);
                usedId.Clear();
                usedId.AddRange(nextId.Take(5));
                nextId.RemoveRange(0, 5);
            }
            else
            {
                prevId.AddRange(usedId);
                usedId.Clear();
                usedId.AddRange(nextId);
                nextId.Clear();
                Next.IsEnabled = false;
            }
            ShowCars();
        }
    }
    public class OpenCarPageEventArgs : EventArgs
    {
        public int id { get; set; }
    }
}
