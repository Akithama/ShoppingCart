using System;
using System.Collections.Generic;

namespace ShoppingCart.Data.Models
{
    public partial class User
    {
        public User()
        {
            Address = new HashSet<Address>();
            CardDetail = new HashSet<CardDetail>();
            Order = new HashSet<Order>();
            Payment = new HashSet<Payment>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateRegister { get; set; }
        public bool? IsAdmin { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<CardDetail> CardDetail { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
