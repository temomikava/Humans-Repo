using FluentValidation;
using HumansAPI.Models.Domain;
using HumansAPI.Repositories;
using HumansAPI.Requests;

namespace HumansAPI.Validators
{
    public class AddPhoneRequestValidator:AbstractValidator<AddPhoneRequest>
    {
        private readonly IRepository<Human> humans;
        private readonly IRepository<Phone> phones;

        public AddPhoneRequestValidator(IRepository<Human> humans,IRepository<Phone> phones)
        {
            this.humans = humans;
            this.phones = phones;
            RuleFor(x => x.PhoneNumber).NotEmpty().Length(4, 50)
                .Must(IfExistPhone).WithMessage("ნომერი უკვე დარეგისტრირებულია");
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.HumanId).NotEmpty().Must(IfExistHuman).WithMessage("ადამიანი ვერ მოიძებნა");
            
        }

        private bool IfExistHuman(int humanId) => humans.CheckAsync(x => x.Id == humanId).Result;

        private bool IfExistPhone(string number) => ! phones.CheckAsync(x => x.PhoneNumber == number).Result;
      
    }
}
