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
    public partial class ShopPage : ContentPage
    {
        private int Id;
        ShopServices services;
        public ShopPage(Shop shop=null)
        {
            InitializeComponent();

            services = new ShopServices();

            if (shop != null)
                BindingContext = shop;

            Id=shop.Id;
        }

        public async void UpdateShop()
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

                var response = await services.UpdateShop(Id, saveShop);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    await DisplayAlert("Updated", "Youe store information has been updated", "Ok");

                await Navigation.PopAsync();
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            UpdateShop();   
        }
    }
}