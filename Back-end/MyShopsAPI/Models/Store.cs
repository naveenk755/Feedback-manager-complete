using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopsAPI.Models
{
    public class Store
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string StreetAddress { get; set; }

        [Required]
        [MaxLength(255)]
        public string City { get; set; }

        [Required]
        [MaxLength(255)]
        public string State { get; set; }

        [Required]
        [MaxLength(255)]
        public string ZipCode { get; set; } 

        public string Image { get; set; }

        [MaxLength(255)]
        public string MondayOpen { get; set; }
        [MaxLength(255)]
        public string MondayClose { get; set; }
        [MaxLength(255)]
        public string TuesdayOpen { get; set; }
        [MaxLength(255)]
        public string TuesdayClose { get; set; }
        [MaxLength(255)]
        public string WednesdayOpen { get; set; }
        [MaxLength(255)]
        public string WednesdayClose { get; set; }
        [MaxLength(255)]
        public string ThursdayOpen { get; set; }
        [MaxLength(255)]
        public string ThursdayClose { get; set; }
        [MaxLength(255)]
        public string FridayOpen { get; set; }
        [MaxLength(255)]
        public string FridayClose { get; set; }
        [MaxLength(255)]
        public string SaturdayOpen { get; set; }
        [MaxLength(255)]
        public string SaturdayClose { get; set; }
        [MaxLength(255)]
        public string SundayOpen { get; set; }
        [MaxLength(255)]
        public string SundayClose { get; set; }

        [Required]
        [MaxLength(255)]
        public string PhoneNumber { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}
