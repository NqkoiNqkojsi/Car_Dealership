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
using Windows.Storage.Pickers;
using Windows.Storage;
using System.Threading.Tasks;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CarDealership.Views
{
    public sealed partial class MakeOffer : UserControl
    {
        public event RoutedEventHandler ClosePage;
        public List<StorageFile> storageFiles = new List<StorageFile>(); 
        private void MakeComboBoxes()
        {
            foreach (string brand in CarBrandController.GetBrands())
            {
                CarBrand.Items.Add(brand);
            }
            for(int i = 1; i < 13; i++)
            {
                ManMonth.Items.Add(i);
            }
            for(int i = 2022; i >= 1930; i--)
            {
                ManYear.Items.Add(i);
            }
            ManMonth.SelectedIndex = 0;
            ManYear.SelectedIndex = 0;
            CarBrand.SelectedIndex = 0;
        }
        public MakeOffer()
        {
            this.InitializeComponent();
            MakeComboBoxes();

        }

        private async void buttonMakeOffer_Click(object sender, RoutedEventArgs e)
        {
            if(Price.Text.Length>0 && HorsePower.Text.Length>0 && KmDriven.Text.Length>0 && Litres.Text.Length > 0)
            {
                try
                {
                    string date=ManMonth.Text+" "+ManYear.Text;
                    string offerID=CustomerController.CreateOffer(CarBrand.SelectedValue.ToString(), CarModel.SelectedValue.ToString(), Double.Parse(Price.Text), date,
                       Double.Parse(HorsePower.Text), Double.Parse(KmDriven.Text), Double.Parse(Litres.Text), Info.Text);
                    if (offerID != null)
                    {
                        CarController.MakeImgDir(offerID);
                        int counter = 0;
                        foreach (StorageFile file in storageFiles) {
                            await CarController.AddPhotoToDir(offerID, file, counter.ToString());  
                            counter++;
                        }
                        ClosePage.Invoke(this, null);
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void buttonAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            StorageFile storageFile = CarController.ImageUpload().Result;
            if (storageFile != null)
            {
                storageFiles.Add(storageFile);
                textBlockPhotos.Text = textBlockPhotos.Text + storageFile.Path + "\n";
            }
        }

        private void CarBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (string model in CarBrandController.GetModels(CarModel.SelectedValue.ToString()))
            {
                CarModel.Items.Add(model);
            }
        }
    }
}
