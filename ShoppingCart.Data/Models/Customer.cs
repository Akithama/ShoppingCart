using System;
using System.Collections.Generic;

namespace ShoppingCart.Data.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Address = new HashSet<Address>();
            Payment = new HashSet<Payment>();
        }

        public int CustomerId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateRegister { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
