using AutoMapper;
using NopCommerceV1.Addresses;
using NopCommerceV1.Customers;

namespace NopCommerceV1;

public class NopCommerceV1ApplicationAutoMapperProfile : Profile
{
    public NopCommerceV1ApplicationAutoMapperProfile()
    {

        CreateMap<Address, AddressDto>();
        CreateMap<CreateAddressDto, Address>();
        CreateMap<UpdateAddressDto, Address>();

        CreateMap<Customer,CustomerDto >();
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<UpdateCustomerDto, CustomerDto>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
