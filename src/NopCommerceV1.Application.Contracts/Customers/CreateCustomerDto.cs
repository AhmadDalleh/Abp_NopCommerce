﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace NopCommerceV1.Customers
{
    public class CreateCustomerDto 
    {
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string? Username { get; set; }

        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(100)]
        public string? PhoneNumber {  get; set; }
        public bool Active { get; set; } = true;

        //public Guid? BillingAddressId { get; set; }

        //public Guid? ShippingAddressId { get; set; }

        //public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;

    }
}
