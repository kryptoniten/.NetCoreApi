using System;
using CustomerApp.Entities.ComplexTypes;

namespace CustomerApp.Entities.Dtos.CustomerDtos
{
    public class CustomerUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string EmailAddress { get; set; }
        public Gender Gender { get; set; }
        
    }
}
