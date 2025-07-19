using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerceV1.Addresses
{
    public class UpdateAddressDto
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string? Address1 { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(100)]
        public string? ZipPostalCode { get; set; }

        [MaxLength(100)]
        public string? PhoneNumber { get; set; }
    }
}
