using ShopAdmin.Models;
using ShopAdmin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopAdmin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedbacksPage : ContentPage
    {
        FeedbackServices services;
        ObservableCollection<FeedbackColor> feedbackCollection;
        public FeedbacksPage()
        {
            InitializeComponent();
            services = new FeedbackServices();
        }

        protected override async void OnAppearing()
        {
            try
            {
                indication.IsRunning = true;
                var feedbacks = await services.GetFeedbacks();
                feedbackCollection = new ObservableCollection<FeedbackColor>(feedbacks);
                FeedbackList.ItemsSource = feedbackCollection;
                indication.IsRunning = feedbacks.Any();
                indication.IsVisible = feedbacks.Any();
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                indication.IsRunning = false;
                indication.IsVisible = false;
            }
            base.OnAppearing();
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            DeleteFeedback(sender);
        }

        async void DeleteFeedback(object sender)
        {
            try
            {
                var menuItem = sender as MenuItem;
                var feedback = menuItem.CommandParameter as FeedbackColor;
                var response = await services.DeleteFeedback(feedback.Feedback.Id);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    feedbackCollection.Remove(feedback);
                    await DisplayAlert("Done", "Selected feedback has been removed successfully!!", "Ok");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private void FeedbackList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            FeedbackList.SelectedItem = null;
        }

        private async void FeedbackList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var feedback = e.Item as FeedbackColor;
            await Navigation.PushAsync(new FeedbackPage(feedback.Feedback));
        }
    }
}