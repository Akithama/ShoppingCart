using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Bll.ViewModels
{
    public class OrderHistoryViewModel
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public int NoOfProducts { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
        public string DateAdded { get; set; }
        public List<OrderDetailHistoryViewModel> OrderDetail { get; set; }
    }
}
