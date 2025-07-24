using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace NopCommerceV1.Customers
{
    public class CustomerPasswordManager : DomainService
    {
        private const int SaltSize = 16; // 128-bit salt

        public Task<string> GenerateSaltAsync()
        {
            var saltBytes = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            string salt = Convert.ToBase64String(saltBytes);
            return Task.FromResult(salt);
        }

        public Task<string> HashPasswordAsync(string password, string salt)
        {
            var saltedPassword = password + salt;
            using (var sha512 = SHA512.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(saltedPassword);
                var hashBytes = sha512.ComputeHash(bytes);
                var hash = Convert.ToBase64String(hashBytes);
                return Task.FromResult(hash);
            }
        }

        public Task<bool> VerifyPasswordAsync(string plainPassword, string salt, string hashedPassword)
        {
            var hash = HashPasswordAsync(plainPassword, salt).Result;
            return Task.FromResult(hash == hashedPassword);
        }
    }
}
