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
    public partial class FeedbackPage : ContentPage
    {
        ShopServices s_services = new ShopServices();
        FeedbackServices services = new FeedbackServices();

        public FeedbackPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            try
            {
                var stores = await s_services.GetShops();
                foreach (var v in stores)
                {
                    PickerStore.Items.Add(v.Name + " ," + v.City);
                }
            }
            catch
            {
                await DisplayAlert("Network error", "You are not cennected toh network.", "OK");
            }
            base.OnAppearing();
        }

        private void ButtonSubmitFeedback_Clicked(object sender, EventArgs e)
        {
            SendFeedback();
        }

        public async void SendFeedback()
        {
            try
            {
                var res = await services.AddFeedback(new FeedbackResource()
                {
                    VisitDate = datePicker.Date,
                    Name = nameEntry.Text,
                    PhoneNumber = phEntry.Text,
                    StoreName = PickerStore.SelectedItem.ToString(),
                    Text = feedBackeditor.Text,
                    RequiresCall = requestCallswitch.IsEnabled,
                    ServiceType = PickerServiceType.SelectedItem.ToString(),
                    Rating = PickerRating.SelectedIndex
                });

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await DisplayAlert("Response", "Your feedback has been submitted successfully", "Ok");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception e)
            {
                await DisplayAlert("Error", e.Message, "Ok");
            }
        }
    }
}