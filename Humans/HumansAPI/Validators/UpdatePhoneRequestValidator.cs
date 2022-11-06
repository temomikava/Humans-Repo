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
            RuleFor(x => x.HumanId).NotEmpty().Must(IfExistHuman).WithMessage("ადამიანი ვერ მოიძებნა");
            RuleFor(x => x.Id).NotEmpty().Must(IfExistPhone).WithMessage("ნომერი უკვე დარეგისტრირებულია");
            RuleFor(x => x.Type).NotEmpty().IsInEnum();
            RuleFor(x => x.PhoneNumber).NotEmpty().Length(4, 50);
        }
        private bool IfExistPhone(int id)
        {
            if (phones.CheckAsync(x => x.Id == id).Result)
                return false;
            return true;
        }
        private bool IfExistHuman(int humanId)
        {
            return humans.CheckAsync(x => x.Id == humanId).Result;
        }
    }
}
