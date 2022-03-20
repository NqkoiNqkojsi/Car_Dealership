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
        //list to separate the ids to prev, current, next
        List<int> prevId=new List<int>();
        List<int> nextId=new List<int>();
        List<int> usedId=new List<int>();
        public event PointerEventHandler OpenCarPage;
        /// <summary>
        /// make the show cases and display them
        /// </summary>
        public async void ShowCars()
        {
            try
            {
                ListCarPanel.Children.Clear();
                foreach (int id in usedId)
                {
                    CarShowCase carShowCase = new CarShowCase(id);
                    carShowCase.Name = id.ToString();
                    //need delay so the event functions
                    await Task.Delay(100);
                    //event to open the car page from the main view
                    carShowCase.PointerPressed += OpenCarPage;
                    ListCarPanel.Children.Add(carShowCase);
                }
            }catch(Exception ex)
            {
                Popup p = new Popup();
                ErrorMessage errorMessage = new ErrorMessage(ex.Message);
                p.Child = errorMessage;
            }
        }
        /// <summary>
        /// list of car previews
        /// </summary>
        /// <param name="ids">ids of the cars to be shown</param>
        public ListOfCars(List<int> ids)
        {
            this.InitializeComponent();
            Prev.IsEnabled = false;
            //make the intial lists
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
        /// <summary>
        /// Get the previous 5 show case's ids
        /// </summary>
        public void GoPrev(object sender, RoutedEventArgs e)
        {
            Next.IsEnabled = true;
            //add the used to next and prev to used
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
        /// <summary>
        /// Get the next 5 show case's ids
        /// </summary>
        public void GoNext(object sender, RoutedEventArgs e)
        {
            Prev.IsEnabled = true;
            //add the used to prev and next to used
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
    
}
