using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyShopApp.Models
{
    public class Shops
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("mondayOpen")]
        public string MondayOpen { get; set; }

        [JsonProperty("mondayClose")]
        public string MondayClose { get; set; }

        [JsonProperty("tuesdayOpen")]
        public string TuesdayOpen { get; set; }

        [JsonProperty("tuesdayClose")]
        public string TuesdayClose { get; set; }
    
        [JsonProperty("wednesdayOpen")]
        public string WednesdayOpen { get; set; }
        
        [JsonProperty("wednesdayClose")]
        public string WednesdayClose { get; set; }
        
        [JsonProperty("thursdayOpen")]
        public string ThursdayOpen { get; set; }
        
        [JsonProperty("thursdayClose")]
        public string ThursdayClose { get; set; }
        
        [JsonProperty("fridayOpen")]
        public string FridayOpen { get; set; }
        
        [JsonProperty("fridayClose")]
        public string FridayClose { get; set; }
        
        [JsonProperty("saturdayOpen")]
        public string SaturdayOpen { get; set; }
        
        [JsonProperty("saturdayClose")]
        public string SaturdayClose { get; set; }
        
        [JsonProperty("sundayOpen")]
        public string SundayOpen { get; set; }
        
        [JsonProperty("sundayClose")]
        public string SundayClose { get; set; }
              
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }
    }
}
