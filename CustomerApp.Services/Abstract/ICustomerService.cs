using System;
using System.Threading.Tasks;
using CustomerApp.Entities.Dtos.CustomerDtos;
using CustomerApp.Shared.Utilities.Results.Abstract;

namespace CustomerApp.Services.Abstract
{
    public interface ICustomerService
    {
        Task<IDataResult<CustomerDto>> AddAsync(CustomerAddDto customerAddDto);

        Task<IDataResult<CustomerListDto>> GetAllAsync();

        Task<IDataResult<CustomerDto>> GetCustomerById(int id);

        Task<IDataResult<CustomerDto>> UpdateAsync(CustomerUpdateDto customerUpdateDto);

        Task<IResult> DeleteAsync(int categoryId);

    }
}
