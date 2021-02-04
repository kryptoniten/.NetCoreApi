using System;
using CustomerApp.Entities.Abstract;
using CustomerApp.Entities.ComplexTypes;


namespace CustomerApp.Entities.Concrete
{
    public class Customer:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string EmailAddress { get; set; }
        public Gender Gender { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        



    }
}
