using System;
using CustomerApp.Entities.Dtos.CustomerDtos;
using FluentValidation;

namespace CustomerApp.Services.FluentValidation
{
    public class CustomerUpdateDtoValidator: AbstractValidator<CustomerUpdateDto>
    {
        public CustomerUpdateDtoValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id Alanı Zorunludur !");

            RuleFor(c => c.Id).GreaterThan(0).WithMessage("Id alanı 0'dan büyük olmalıdır !");

            RuleFor(c => c.FirstName).NotEmpty().WithMessage("İsim Alanı Zorunludur.");
            RuleFor(c => c.FirstName).Length(2, 200).WithMessage("İsim alanı minimum 2 maksimum 200 karakter olmalıdır");

            RuleFor(c => c.LastName).NotEmpty().WithMessage("İsim Alanı Zorunludur.");
            RuleFor(c => c.LastName).Length(2, 200).WithMessage("İsim alanı minimum 2 maksimum 200 karakter olmalıdır");


            RuleFor(c => c.Gender).NotNull().WithMessage("Cinsiyet Alanı Zorunludur.");

            RuleFor(c => c.EmailAddress).EmailAddress().WithMessage("Valid Bir E-Mail Adresi gir !");

            RuleFor(c => c.Age).InclusiveBetween(15, 100).WithMessage("Yaşınızın minimum 15, Maksimum 100 Olması gerekir!");
        }
    }
}
