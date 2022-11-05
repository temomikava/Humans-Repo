using FluentValidation;
using HumansAPI.DTOs;

namespace HumansAPI.Validators
{
    public class UpdateCityRequestValidator:AbstractValidator<UpdateCityRequest>
    {
        public UpdateCityRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(2, 20).Matches("^[a-zA-Z]*$|^[ა-ჰ]*$");
        }
    }
}
