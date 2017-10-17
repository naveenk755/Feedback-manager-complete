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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            homeImage.Source = ImageSource.FromResource("ShopAdmin.Images.hp.jpg");
        }

        private async void ButtonManage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShopsPage());
        }

        private async void ButtonFeedback_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FeedbacksPage());
        }
    }
}