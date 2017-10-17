using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdmin.Models
{
    public class SaveShop
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Image { get; set; }

        public string PhoneNumber { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}
