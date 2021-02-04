using System;
using CustomerApp.Entities.Dtos.CustomerDtos;
using FluentValidation;


namespace CustomerApp.Services.FluentValidation
{
    public class CustomerAddDtoValidator: AbstractValidator<CustomerAddDto>
    {
        public CustomerAddDtoValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("İsim Alanı Zorunludur.");
            RuleFor(c => c.FirstName).Length(2, 200).WithMessage("İsim alanı minimum 2 maksimum 200 karakter olmalıdır");

            RuleFor(c => c.LastName).NotEmpty().WithMessage("İsim Alanı Zorunludur.");
            RuleFor(c => c.LastName).Length(2, 200).WithMessage("Soyisim alanı minimum 2 maksimum 200 karakter olmalıdır");


            RuleFor(c => c.Gender).NotEmpty().WithMessage("Cinsiyet Alanı Zorunludur.");

            RuleFor(c => c.EmailAddress).EmailAddress().WithMessage("Geçerli Bir E-Mail Adresi gir !");

            RuleFor(c => c.Age).InclusiveBetween(15, 100).WithMessage("Yaşınızın minimum 15, Maksimum 100 Olması gerekir, veletler giremez !");

            
        }
    }
}
