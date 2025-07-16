using AutoMapper;
using NopCommerceV1.Addresses;
using NopCommerceV1.Customers;

namespace NopCommerceV1.Web;

public class NopCommerceV1WebAutoMapperProfile : Profile
{
    public NopCommerceV1WebAutoMapperProfile()
    {

        CreateMap<Address, CreateAddressDto>();
        CreateMap<Address, UpdateAddressDto>();
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<Customer, CreateCustomerDto>();
        CreateMap<Customer, UpdateCustomerDto>();
    }
}
