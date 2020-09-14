using System;
using System.Collections.Generic;

namespace ShoppingCart.Data.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            CardDetail = new HashSet<CardDetail>();
        }

        public int PayId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<CardDetail> CardDetail { get; set; }
    }
}
