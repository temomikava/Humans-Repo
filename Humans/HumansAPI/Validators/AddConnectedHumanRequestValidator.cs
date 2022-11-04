﻿using FluentValidation;
using HumansAPI.DTOs;
using HumansAPI.Models.Domain;
using HumansAPI.Repositories;

namespace HumansAPI.Validators
{
    public class AddConnectedHumanRequestValidator:AbstractValidator<AddConnectedHumanRequest>
    {
        private readonly IRepository<Human> humans;

        public AddConnectedHumanRequestValidator(IRepository<Human> humans)
        {
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
