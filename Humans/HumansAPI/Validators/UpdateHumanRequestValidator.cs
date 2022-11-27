using FluentValidation;
using HumansAPI.Models.Domain;
using HumansAPI.Repositories;
using HumansAPI.Requests;

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

            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty().Length(2, 50)
                .Matches("^[a-zA-Z]*$|^[ა-ჰ]*$").WithMessage("სახელი უნდა შეიცავდეს მხოლოდ ქართულ ან მხოლოდ ლათინურ ასოებს");
            RuleFor(x => x.LastName).NotEmpty().Length(2, 50)
                .Matches("^[a-zA-Z]*$|^[ა-ჰ]*$").WithMessage("გვარი უნდა შეიცავდეს მხოლოდ ქართულ ან მხოლოდ ლათინურ ასოებს");
            RuleFor(x => x.Gender).IsInEnum();
            RuleFor(x => x.PersonalNumber).NotEmpty().Length(11)
                .Matches("^[0-9]*$").WithMessage("პირადი ნომერი უნდა შედგებოდეს მხოლოდ ციფრებისგან");
            RuleFor(x => x.DateOfBirth).NotEmpty()
                .Must(d => d.AddYears(18) < DateTime.Now).WithMessage("მინიმალური დასაშვები ასაკი არის 18 წელი");
            RuleFor(x => x.CityId).NotEmpty().Must(IfExistCity).WithMessage("ქალაქი ვერ მოიძებნა");          
        }
        private bool IfExistCity(int? cityId) => cities.CheckAsync(x => x.Id == cityId).Result;
            
    }
}
