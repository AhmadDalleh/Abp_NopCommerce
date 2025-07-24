using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities.Caching;
using Volo.Abp.Domain.Repositories;

namespace NopCommerceV1.Customers
{
    public class CustomerPasswordAppService : CrudAppService<
        CustomerPassword,
        CustomerPasswordDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCustomerPasswordDto>,
        ICustomerPasswordAppService

    {

        #region Properties
        private readonly CustomerPasswordManager _passwordManager;

        #endregion

        #region Ctor
        public CustomerPasswordAppService(IRepository<CustomerPassword, Guid> repository, CustomerPasswordManager passwordManager) : base(repository)
        {
            _passwordManager = passwordManager;
        }
        #endregion


        public override async Task<CustomerPasswordDto> CreateAsync(CreateUpdateCustomerPasswordDto input)
        {
            var salt = await _passwordManager.GenerateSaltAsync();
            var hashed = await _passwordManager.HashPasswordAsync(input.Password, salt);
            var entity = new CustomerPassword(Guid.NewGuid(), input.CustomerId, hashed, input.PasswordFormatId, DateTime.UtcNow)
            {
                PasswordSalt = salt
            };

            await Repository.InsertAsync(entity);
            return ObjectMapper.Map<CustomerPassword, CustomerPasswordDto>(entity);
            
        }

        public override async Task<CustomerPasswordDto> UpdateAsync(Guid id,CreateUpdateCustomerPasswordDto input)
        {
            var entity = await Repository.GetAsync(c => c.Id == id);
            var salt = await _passwordManager.GenerateSaltAsync();
            var hashed = await _passwordManager.HashPasswordAsync(input.Password, salt);
            //var entity = new CustomerPassword(Guid.NewGuid(), input.CustomerId, hashed, input.PasswordFormatId, DateTime.UtcNow)
            //{
            //    PasswordSalt = salt
            //};
            entity.CustomerId = input.CustomerId;
            entity.PasswordSalt = input.PasswordSalt;
            entity.PasswordSalt = salt;
            entity.Password = hashed;
            entity.PasswordFormatId = input.PasswordFormatId;

            await Repository.UpdateAsync(entity);
            return ObjectMapper.Map<CustomerPassword, CustomerPasswordDto>(entity);
            
        }
    }
}

