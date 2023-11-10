
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace VivesShopDevosNick.UI.MVC.Models
{
    [Table(nameof(Order))]
    public class Order
	{

            
            public int OrderID { get; set; }
            public ICollection<CartItem> Items { get; set; } = new List<CartItem>();

            [Required]
            [Display(Name = "Name" )]
			public string? Name { get; set; }

            [Required]
            [Display(Name = "Email")]
            public string? Email { get; set; }

            [Required]
            [Display(Name = "Address")]
            public string? Address { get; set; }
            
            [Required]
            [Display(Name = "Zipcode")]
            public string? Zip { get; set; }

            [Required]
            [Display(Name = "City")]
			public string? City { get; set;}

            [Required]
            [Display(Name = "Country")]
            public string? Country { get; set; }



    }
	
}

