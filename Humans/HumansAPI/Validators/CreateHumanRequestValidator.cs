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
        private readonly IRepository<Human> humans;

        public CreateHumanRequestValidator(IRepository<City> cities,IRepository<Human> humans)
        {
            this.cities = cities;
            this.humans = humans;
            RuleFor(x => x.FirstName).NotEmpty().Length(2, 50).Matches("^[a-zA-Z]*$|^[ა-ჰ]*$");
            RuleFor(x=>x.LastName).NotEmpty().Length(2,50).Matches("^[a-zA-Z]*$|^[ა-ჰ]*$");
            RuleFor(x => x.Gender).IsInEnum();
            RuleFor(x => x.PersonalNumber).NotEmpty().Length(11).Matches("^[0-9]*$").Must(IfExistPersonalNumber);
            RuleFor(x => x.DateOfBirth).Must(d => d.AddYears(18) < DateTime.Now);
            RuleFor(x => x.CityId).Must(IfExistCity);
        }

        private bool IfExistCity(int? cityId)
        {
            return cities.CheckAsync(x => x.Id == cityId).Result;
        }
        private bool IfExistPersonalNumber(string? personalNumber)
        {
            if (humans.CheckAsync(x => x.PersonalNumber == personalNumber).Result)
                return false;
            return true;
        }
    }


}
