using System;
using System.Collections.Generic;

namespace ShoppingCart.Data.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public bool? IsDelivery { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
