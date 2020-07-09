using System;
using System.Collections.Generic;

namespace ShoppingCart.Data.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
            Payment = new HashSet<Payment>();
        }

        public int OrderId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateShipped { get; set; }
        public string Status { get; set; }
        public decimal? TotalAmount { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
