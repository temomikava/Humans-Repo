using FluentValidation;
using HumansAPI.DTOs;
using HumansAPI.Enums;
using HumansAPI.Models.Domain;
using HumansAPI.Repositories;
using System.Text.RegularExpressions;

namespace HumansAPI.Validators
{
    public class CreateHumanRequestValidator:AbstractValidator<CreateHumanRequest>
    {
        private readonly IRepository<City> cities;

        public CreateHumanRequestValidator(IRepository<City> cities)
        {
            this.cities = cities;
            RuleFor(x => x.FirstName).NotEmpty().Length(2, 50).Matches("^[a-zA-Z]*$|^[ა-ჰ]*$");
            RuleFor(x=>x.LastName).NotEmpty().Length(2,50).Matches("^[a-zA-Z]*$|^[ა-ჰ]*$");
            RuleFor(x => x.Gender).IsInEnum();
            RuleFor(x => x.PersonalNumber).NotEmpty().Length(11).Matches("^[0-9]*$");
            RuleFor(x => x.DateOfBirth).Must(d => d.AddYears(18) < DateTime.Now);
            RuleFor(x => x.CityId).Must(IfExistCity);
        }

        private bool IfExistCity(int? cityId)
        {
            return cities.CheckAsync(x => x.Id == cityId).Result;
        }      
    }


}
