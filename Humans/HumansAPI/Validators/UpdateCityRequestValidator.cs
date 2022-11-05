﻿using FluentValidation;
using HumansAPI.DTOs;
using HumansAPI.Models.Domain;
using HumansAPI.Repositories;

namespace HumansAPI.Validators
{
    public class UpdateCityRequestValidator:AbstractValidator<UpdateCityRequest>
    {
        private readonly IRepository<City> cities;

        public UpdateCityRequestValidator(IRepository<City> cities)
        {
            RuleFor(x => x.Name).NotEmpty().Length(2, 20).Matches("^[a-zA-Z]*$|^[ა-ჰ]*$").Must(IfExistCity);
            this.cities = cities;
        }
        private bool IfExistCity(string? name)
        {
            if (cities.CheckAsync(x => x.Name == name).Result == true)
                return false;
            return true;
        }
    }
}