using FluentValidation;
using HumansAPI.Requests;

namespace HumansAPI.Validators
{
    public class GetAllHumanRequestValidator:AbstractValidator<GetAllHumanRequest>
    {
        public GetAllHumanRequestValidator()
        {
            RuleFor(x => x.PageIndex).GreaterThan(0).LessThan(100);
            RuleFor(x=>x.PageSize).GreaterThan(0).LessThan(100);
            RuleFor(x => x.FirstName).Length(1, 10)
                .Matches("^[a-zA-Z]*$|^[ა-ჰ]*$").WithMessage("სახელი უნდა შეიცავდეს მხოლოდ ქართულ ან მხოლოდ ლათინურ ასოებს");
            RuleFor(x => x.LastName).Length(1, 10)
                .Matches("^[a-zA-Z]*$|^[ა-ჰ]*$").WithMessage("გვარი უნდა შეიცავდეს მხოლოდ ქართულ ან მხოლოდ ლათინურ ასოებს");
            RuleFor(x => x.PersonalNo).Matches("^[0-9]*$").WithMessage("პირადი ნომერი უნდა შედგებოდეს მხოლოდ ციფრებისგან");

        }
    }
}
