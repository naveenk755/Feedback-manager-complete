using MyShopApp.Models;
using Plugin.ExternalMaps;
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
    public partial class ShopPage : ContentPage
    {
        public ShopViewModel svm;
        public ShopPage(Shops shop)
        {
            InitializeComponent();
            svm = new ShopViewModel(shop);
            BindingContext = svm;
        }

        private void ButtonFindStore_Clicked(object sender, EventArgs e)
        {
            var phoneDialer = Plugin.Messaging.CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall(svm.Store.PhoneNumber);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var success = await CrossExternalMaps.Current.NavigateTo(svm.Store.Name, svm.Store.Latitude, svm.Store.Longitude);
        }
    }
}