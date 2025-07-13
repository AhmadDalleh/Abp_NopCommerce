using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerceV1.Customers
{
    public enum PasswordFormat
    {
        /// <summary>
        /// Clear
        /// </summary>
        Clear = 0,

        /// <summary>
        /// Hashed
        /// </summary>
        Hashed = 1,

        /// <summary>
        /// Encrypted
        /// </summary>
        Encrypted = 2
    }
}
