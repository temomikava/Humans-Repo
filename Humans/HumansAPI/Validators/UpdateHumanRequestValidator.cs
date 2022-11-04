using FluentValidation;
using HumansAPI.DTOs;
using HumansAPI.Models.Domain;
using HumansAPI.Repositories;

namespace HumansAPI.Validators
{
    public class UpdateHumanRequestValidator:AbstractValidator<UpdateHumanRequest>
    {
        private readonly IRepository<City> cities;
        private readonly IRepository<Human> humans;

        public UpdateHumanRequestValidator(IRepository<City> cities, IRepository<Human> humans)
        {
            this.cities = cities;
            this.humans = humans;

            RuleFor(x => x.Id).Must(IfExistHuman);
            RuleFor(x => x.FirstName).NotEmpty().Length(2, 50).Matches("^[a-zA-Z]*$|^[ა-ჰ]*$");
            RuleFor(x => x.LastName).NotEmpty().Length(2, 50).Matches("^[a-zA-Z]*$|^[ა-ჰ]*$");
            RuleFor(x => x.Gender).IsInEnum();
            RuleFor(x => x.PersonalNumber).NotEmpty().Length(11).Matches("^[0-9]*$").Must(IfExistPersonalNumber);
            RuleFor(x => x.DateOfBirth).NotEmpty().Must(d => d.AddYears(18) < DateTime.Now);
            RuleFor(x => x.CityId).Must(IfExistCity);          
        }
        private bool IfExistCity(int? cityId)
        {
            return cities.CheckAsync(x => x.Id == cityId).Result;
        }

        private bool IfExistHuman(int humanId)
        {
            return humans.CheckAsync(x => x.Id == humanId).Result;
        }

        private bool IfExistPersonalNumber(string? personalNumber)
        {
            if (humans.CountAsync(x => x.PersonalNumber == personalNumber).Result > 1)
                return false;
            return true;                     
        }
    }
}
