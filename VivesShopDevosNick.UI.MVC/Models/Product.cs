using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace VivesShopDevosNick.UI.MVC.Models
{
    [Table(nameof(Product))]
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        [Display(Name = "name")]
        public string Name { get; set; } = String.Empty;
        [Required]
        [Display(Name = "price")]
        public double Price { get; set; }
        [Display(Name = "quantity")]
        public int Quantity { get; set; } = 0;
    }
}