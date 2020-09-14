using System;
using System.Collections.Generic;

namespace ShoppingCart.Data.Models
{
    public partial class CardDetail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public DateTime? DateExpire { get; set; }
        public string PayPalAddress { get; set; }
        public int PayId { get; set; }

        public virtual PaymentMethod Pay { get; set; }
        public virtual User User { get; set; }
    }
}
