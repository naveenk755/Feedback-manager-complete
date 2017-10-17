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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            HeroImage.Source = ImageSource.FromResource("MyShopApp.Images.hp.jpg");
        }

        private async void ButtonFindStore_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShopsPage());
        }

        private async void ButtonLeaveFeedback_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FeedbackPage());
        }
    }
}