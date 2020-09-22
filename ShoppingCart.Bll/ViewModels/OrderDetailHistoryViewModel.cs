using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Bll.ViewModels
{
    public class OrderDetailHistoryViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
