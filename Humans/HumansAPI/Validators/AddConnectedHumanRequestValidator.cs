using FluentValidation;
using HumansAPI.DTOs;
using HumansAPI.Models.Domain;
using HumansAPI.Repositories;

namespace HumansAPI.Validators
{
    public class AddConnectedHumanRequestValidator:AbstractValidator<AddConnectedHumanRequest>
    {
        private readonly IRepository<HumanConnection> humanConnections;
        private readonly IRepository<Human> humans;

        public AddConnectedHumanRequestValidator(IRepository<HumanConnection> humanConnections,IRepository<Human> humans)
        {
            this.humanConnections = humanConnections;
            this.humans = humans;
            RuleFor(x => x.FirstHumanId).NotEmpty().Must(IfExistHuman);
            RuleFor(x => x.SecondHumanId).NotEmpty().Must(IfExistHuman);
            RuleFor(x => x.Type).IsInEnum();
        }

        
        private bool IfExistHuman(int humanId)
        {
            return humans.CheckAsync(x => x.Id == humanId).Result;
        }
    }
}
