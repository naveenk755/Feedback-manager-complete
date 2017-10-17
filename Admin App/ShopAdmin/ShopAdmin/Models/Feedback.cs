﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopAdmin.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public DateTime VisitDate { get; set; }

        public int Rating { get; set; }

        public string ServiceType { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public bool RequiresCall { get; set; }

        public string StoreName { get; set; }

        public string Text { get; set; }
    }
}
