using NopCommerceV1.Customers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerceV1.Customers.Domain_Services
{
    public interface ICustomerPasswordManager
    {
        string HashPassword(string password, PasswordFormat format, string salt);
        bool ValidatePassword(string plainPassword, CustomerPassword storedPassword);
    }
}
