using ShopAdmin.Models;
using ShopAdmin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAdmin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopsPage : ContentPage
    {
        ShopServices s_services;
        ObservableCollection<Shop> shopsCollection;

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
                shopsCollection = new ObservableCollection<Shop>(shops);
                storesListView.ItemsSource = shopsCollection;
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

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var shop = menuItem.CommandParameter as Shop;
            await Navigation.PushAsync(new ShopPage(shop));
        }

        private async void storesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new ShopViewPage(e.Item as Shop));
        }

        private void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            DeleteShop(sender);
        }

        async void DeleteShop(object sender)
        {
            try
            {
                var menuItem = sender as MenuItem;
                var shop = menuItem.CommandParameter as Shop;
                var response = await s_services.DeleteShop(shop.Id);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    shopsCollection.Remove(shop);
                    await DisplayAlert("Done", "Selected item has been deleted Successfully", "Ok");
                }
                    
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateShopPage());
        }
    }
}