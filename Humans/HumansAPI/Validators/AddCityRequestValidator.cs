using FluentValidation;
using HumansAPI.Models.Domain;
using HumansAPI.Repositories;
using HumansAPI.Requests;

namespace HumansAPI.Validators
{
    public class AddCityRequestValidator:AbstractValidator<AddCityRequest>
    {
        private readonly IRepository<City> cities;

        public AddCityRequestValidator(IRepository<City> cities)
        {
            this.cities = cities;
            RuleFor(x => x.Name).NotEmpty().Length(2, 20)
                .Matches("^[a-zA-Z]*$|^[ა-ჰ]*$").WithMessage("ქალაქის სახელი უნდა შედგემოდეს მხოლოდ ქართული ან მხოლოდ ლათინური სიმბოლოებისგან.")
                .Must(IfExistCity).WithMessage("ქალაქი იგივე სახელით უკვე არსებობს.");
        }
        private bool IfExistCity(string? name) => !cities.CheckAsync(x => x.Name == name).Result;
      
    }
}
