using System;
using Volo.Abp.Domain.Entities;

namespace NopCommerceV1.Customers
{
    public class Address : Entity<Guid>
    {
        public string FirstName {  get; set; }
        public string LastName {  get; set; }
        public string Email {  get; set; }
        public string Address1 {  get; set; }
        public string? Address2 {  get; set; }
        public string City {  get; set; }
        public string ZipPostalCode {  get; set; }
        public string PhoneNumber {  get; set; }
        public string? FaxNumber {  get; set; }
        public DateTime CreatedOnUtc {  get; set; }
    }
}