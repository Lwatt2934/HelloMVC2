using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//

namespace HelloMVC2.Models
{
    public class Customer
    {
        public string ID { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Your string is too long!")]
        [DisplayName("Enter your name")]
        public string Name { get; set; }
        public string Telephone { get; set; }
    }
}