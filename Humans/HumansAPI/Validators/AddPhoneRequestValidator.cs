using FluentValidation;
using HumansAPI.DTOs;
using HumansAPI.Models.Domain;
using HumansAPI.Repositories;

namespace HumansAPI.Validators
{
    public class AddPhoneRequestValidator:AbstractValidator<AddPhoneRequest>
    {
        private readonly IRepository<Human> humans;

        public AddPhoneRequestValidator(IRepository<Human> humans)
        {
            this.humans = humans;

            RuleFor(x => x.PhoneNumber).NotEmpty().Length(4, 50);
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.HumanId).Must(IfExistHuman);
            
        }

        private bool IfExistHuman(int humanId)
        {
            return humans.CheckAsync(x => x.Id == humanId).Result;
        }
    }
}
