using MyShopApp.Models;
using MyShopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopsPage : ContentPage
    {
        ShopServices s_services;

        public ShopsPage()
        {
            InitializeComponent();
            s_services = new ShopServices();
        }

        protected override async void OnAppearing()
        {
            try
            {
                indication.IsRunning = true;
                var shops = await s_services.GetShops();
                storesListView.ItemsSource = shops;
                indication.IsRunning = shops.Any();
            }
            catch
            {
                await DisplayAlert("Error", "Couldn't retreive the stores", "Ok");
            }
            finally
            {
                indication.IsRunning = false;
                indication.IsVisible = false;
            }
            base.OnAppearing();
        }

        private void StoresListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            storesListView.SelectedItem = null;
        }

        private async void StoresListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var store = e.Item as Shops;
            await Navigation.PushAsync(new ShopPage(store));
        }
    }
}