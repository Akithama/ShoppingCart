using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Bll.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int Items { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
