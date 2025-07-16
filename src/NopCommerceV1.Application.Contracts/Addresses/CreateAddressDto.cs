using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerceV1.Addresses
{
    public class CreateAddressDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }

    }
}
