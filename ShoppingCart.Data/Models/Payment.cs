using System;
using System.Collections.Generic;

namespace ShoppingCart.Data.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DatePayment { get; set; }
        public int? PaymentType { get; set; }

        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}
