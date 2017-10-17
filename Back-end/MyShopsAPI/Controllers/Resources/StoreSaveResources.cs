using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopsAPI.Controllers.Resources
{
    public class StoreSaveResources
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


        [Required]
        [MaxLength(255)]
        public string PhoneNumber { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }
    }
}
