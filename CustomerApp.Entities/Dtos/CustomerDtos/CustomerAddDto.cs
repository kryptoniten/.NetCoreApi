using System;
using CustomerApp.Entities.ComplexTypes;

namespace CustomerApp.Entities.Dtos.CustomerDtos
{
    public class CustomerAddDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Gender Gender { get; set; }
        public int? Age { get; set; }

    }
}
