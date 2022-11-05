using FluentValidation;
using HumansAPI.DTOs;
using HumansAPI.Models.Domain;
using HumansAPI.Repositories;

namespace HumansAPI.Validators
{
    public class UpdatePhoneRequestValidator:AbstractValidator<UpdatePhoneRequest>
    {
        private readonly IRepository<Phone> phones;
        private readonly IRepository<Human> humans;

        public UpdatePhoneRequestValidator(IRepository<Phone> phones,IRepository<Human> humans)
        {
            this.phones = phones;
            this.humans = humans;
            RuleFor(x => x.HumanId).Must(IfExistHuman);
            RuleFor(x => x.Id).Must(IfExistPhone);
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.PhoneNumber).NotEmpty().Length(4, 50);
        }
        private bool IfExistPhone(int id)
        {
            return phones.CheckAsync(x => x.Id == id).Result;
        }
        private bool IfExistHuman(int humanId)
        {
            return humans.CheckAsync(x => x.Id == humanId).Result;
        }
    }
}
