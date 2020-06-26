using System;
using System.Collections.Generic;

namespace ShoppingCart.Data.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public string BillingAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
