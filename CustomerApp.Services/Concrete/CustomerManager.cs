using System;
using System.Threading.Tasks;
using CustomerApp.Entities.Dtos.CustomerDtos;
using CustomerApp.Services.Abstract;
using CustomerApp.Data.Concrete.EntityFramework.Contexts;
using AutoMapper;
using CustomerApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using CustomerApp.Shared.Utilities.Results.Abstract;
using CustomerApp.Shared.Utilities.Results.Concrete;
using CustomerApp.Shared.Utilities.Results.ComplexTypes;
using MakasApp.Shared.Utilities.Validation.FluentValidation;
using CustomerApp.Services.FluentValidation;
using CustomerApp.Shared.Entities.Concrete;
using System.Collections.Generic;

namespace CustomerApp.Services.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly CustomerDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerManager(CustomerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IDataResult<CustomerDto>> AddAsync(CustomerAddDto customerAddDto)
        {
            var result = ValidationTool.Validate(new CustomerAddDtoValidator(), customerAddDto);
            if(result.ResultStatus== ResultStatus.Error)
            {
                return new DataResult<CustomerDto>(ResultStatus.Error, $"Bir veya daha fazla validasyon hatası ile karşılaşıldı.", null, result.ValidationErrors);
            }
            var customer = _mapper.Map<Customer>(customerAddDto);
             customer.CreatedDate = DateTime.UtcNow;
                customer.ModifiedDate = DateTime.UtcNow;
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return new DataResult<CustomerDto>(ResultStatus.Success, $"{customer.FirstName} adlı kullanıcı başarıyla eklendi.", new CustomerDto
            {
                Customer = customer
            });

        }



        public async Task<IResult> DeleteAsync(int id)
        {
            var customer = await _dbContext.Customers.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id);
            if(customer != null)
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
                return new Result(ResultStatus.Success, $"{customer.FirstName} adlı kullanıcı başarıyla veritabanından silinmiştir.");

            }
            else
            {

                return new DataResult<CustomerDto>(ResultStatus.Error, $"Bir veya daha fazla validasyon hatası ile karşılaşıldı.", null, new List<ValidationError>(){new ValidationError
                {
                    
                    Message = $"{id}  koduna ait bir Kullancı bulunamadı."
                }});
            }
        }

        public async Task<IDataResult<CustomerListDto>> GetAllAsync()
        {
            try
            {
                var customers = await _dbContext.Customers.AsNoTracking().ToListAsync();
                return new DataResult<CustomerListDto>(ResultStatus.Success, new CustomerListDto
                {
                    Customers = customers
                });
            }
            catch (Exception ex)
            {
                return new DataResult<CustomerListDto>(ResultStatus.Error, ex.Message, null, ex);
            }

        }

        public async Task<IDataResult<CustomerDto>> GetCustomerById(int id)
        {
            var customer = await _dbContext.Customers.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id);
            if (customer != null)
            {
                return new DataResult<CustomerDto>(ResultStatus.Success, new CustomerDto()
                {
                    Customer = customer
                });
            }
            return new DataResult<CustomerDto>(ResultStatus.Error, $"Bir veya daha fazla validasyon hatası ile karşılaşıldı.", null, new List<ValidationError>(){new ValidationError
                {
                   
                    Message = $"{id}  koduna ait bir Kullancı bulunamadı."
                }});

        }



        public async Task<IDataResult<CustomerDto>> UpdateAsync(CustomerUpdateDto customerUpdateDto)
        {
            
            var result = ValidationTool.Validate(new CustomerUpdateDtoValidator(), customerUpdateDto);
            if(result.ResultStatus == ResultStatus.Error)
            {
                return new DataResult<CustomerDto>(ResultStatus.Error, $"Bir veya daha fazla validasyon hatası ile karşılaşıldı.", null, result.ValidationErrors);
            }
            var oldCustomer = await _dbContext.Customers.AsNoTracking().SingleOrDefaultAsync(c => c.Id == customerUpdateDto.Id);
            if(oldCustomer != null)
            {
                var newCustomer = _mapper.Map<CustomerUpdateDto, Customer>(customerUpdateDto, oldCustomer);
                newCustomer.ModifiedDate = DateTime.UtcNow;
                _dbContext.Customers.Update(newCustomer);
                await _dbContext.SaveChangesAsync();
                return new DataResult<CustomerDto>(ResultStatus.Success, $"{newCustomer.FirstName} adlı kullanıcı başarıyla güncellenmiştir.", new CustomerDto
                {
                    Customer = newCustomer
                });

            }
            else
            {
                return new DataResult<CustomerDto>(ResultStatus.Error, $"Bir veya daha fazla validasyon hatası ile karşılaşıldı.", null, new List<ValidationError>(){new ValidationError
                    {
                        
                        Message = $"{customerUpdateDto.Id}  koduna ait bir kullanıcı bulunamadı."
                    }});
            }
        }
    }
}
