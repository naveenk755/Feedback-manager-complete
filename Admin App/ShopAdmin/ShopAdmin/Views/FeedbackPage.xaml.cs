using Plugin.Messaging;
using ShopAdmin.Models;
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
    public partial class FeedbackPage : ContentPage
    {
        private Feedback feedback;

        public FeedbackPage(Feedback feedback)
        {
            InitializeComponent();
            BindingContext = feedback;
            this.feedback = feedback;
        }

        private void ButtonCall_Clicked(object sender, EventArgs e)
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall(feedback.PhoneNumber, feedback.Name);
        }
    }
}