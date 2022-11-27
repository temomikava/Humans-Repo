using FluentValidation;
using HumansAPI.Models.Domain;
using HumansAPI.Repositories;
using HumansAPI.Requests;

namespace HumansAPI.Validators
{
    public class AddConnectedHumanRequestValidator:AbstractValidator<AddConnectedHumanRequest>
    {
        private readonly IRepository<Human> humans;

        public AddConnectedHumanRequestValidator(IRepository<Human> humans)
        {
            this.humans = humans;
            RuleFor(x => x.FirstHumanId).NotEmpty().Must(IfExistHuman).WithMessage("ადამიანი ვერ მოიძებნა");
            RuleFor(x => x.SecondHumanId).NotEmpty().Must(IfExistHuman).WithMessage("ადამიანი ვერ მოიძებნა");
            RuleFor(x => x.Type).IsInEnum();
        }

        
        private bool IfExistHuman(int humanId)=> humans.CheckAsync(x => x.Id == humanId).Result;
        
    }
}
