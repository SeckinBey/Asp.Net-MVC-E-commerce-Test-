using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.MvcWebUI.Models
{
    public class ShippingModel
    {
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter the address description.")]
        public string AddressTitle { get; set; }

        [Required(ErrorMessage = "Please enter a address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a city.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a district.")]
        public string District { get; set; }

        [Required(ErrorMessage = "Please enter a neighborhood.")]
        public string Neighborhood { get; set; }

        public string PostCode { get; set; }

    }
}