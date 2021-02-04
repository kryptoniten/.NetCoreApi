using System;
using CustomerApp.Entities.Concrete;
using CustomerApp.Entities.Dtos;
using CustomerApp.Entities.Dtos.CustomerDtos;

namespace CustomerApp.Services.AutoMapper.Profiles
{
    public class CustomerProfile:global::AutoMapper.Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerAddDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}
