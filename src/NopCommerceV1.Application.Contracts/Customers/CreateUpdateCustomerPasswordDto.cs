using NopCommerceV1.Customers.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerceV1.Customers
{
    public class CreateUpdateCustomerPasswordDto
    {
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public PasswordFormat PasswordFormatId { get; set; } // Optional: you can turn this into enum

        public string PasswordSalt { get; set; }
    }
}
