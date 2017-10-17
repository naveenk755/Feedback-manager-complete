using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopAdmin.Models
{
    public class FeedbackColor
    {
        public Feedback Feedback { get; set; }
        public Color BoxColor { get; set; }
        public string Call { get; set; }

        public FeedbackColor(Feedback feedback)
        {
            this.Feedback = feedback;
            Call = "No";
            SetColor();
        }

        void SetColor()
        {
            if (Feedback.RequiresCall == true)
                Call = "Yes";

            if (Feedback.Rating < 4)
                BoxColor = Color.Red;

            else if (Feedback.Rating < 8 && Feedback.Rating>3)
                BoxColor = Color.Orange;

            else
              BoxColor = Color.Green;
        }
    }
}
