using System;
using System.Collections;
using System.Collections.Generic;
using CustomerApp.Entities.Concrete;

namespace CustomerApp.Entities.Dtos.CustomerDtos
{
    public class CustomerListDto
    {

        public IList<Customer> Customers { get; set; }

    }
}
