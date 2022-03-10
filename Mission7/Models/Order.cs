using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//The order model contains information about the customer as well as a list of cart item objects

namespace Mission7.Models
{
    public class Order
    {
        [Key]
        [BindNever]
        public int OrderID { get; set; }
        
        [BindNever]
        public ICollection<CartItem> Items { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your address.")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter the city.")]
        public string City { get; set; }


        [Required(ErrorMessage = "Please enter the state.")]
        public string State { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter the country.")]
        public string Country { get; set; }
        public bool Anonymous { get; set; }
        [BindNever]
        public bool OrderDelivered { get; set; }
    }
}
