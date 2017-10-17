using ShopAdmin.Models;
using ShopAdmin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAdmin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateShopPage : ContentPage
    {
        ShopServices services;

        public CreateShopPage()
        {
            InitializeComponent();
            services = new ShopServices();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            CreateShop();
        }

        async void CreateShop()
        {
            try
            {
                var saveShop = new SaveShop()
                {
                    Name = nameEntryCell.Text,
                    StreetAddress = streeAddressEntry.Text,
                    City = cityEntryCell.Text,
                    State = stateEntryCell.Text,
                    ZipCode = zipcodeEntryCell.Text,
                    Image = imageEntryCell.Text,
                    PhoneNumber = phoneEntryCell.Text,
                    Longitude = double.Parse(longitudeEntryCell.Text),
                    Latitude = double.Parse(latitudeEntryCell.Text)
                };

                var response = await services.CreateShop(saveShop);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    await DisplayAlert("Updated", "New Store has been added successfully", "Ok");

                await Navigation.PopAsync();
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}