using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShopsAPI.Models
{
    public class Feedback
    {
        public int Id { get; set; }
 
        public DateTime FeedbackDate { get; set; } 
        public DateTime VisitDate { get; set; } 

        [Required]
        public int Rating { get; set; } 
        public string ServiceType { get; set; } 

        [MaxLength(255)]
        public string Name { get; set; } 

        [MaxLength(255)]
        public string PhoneNumber { get; set; } 

        public bool RequiresCall { get; set; } 

        [MaxLength(255)]
        public string StoreName { get; set; } 

        [MaxLength(255)]
        public string Text { get; set; }

    }
}
