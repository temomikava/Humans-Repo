﻿using HumansAPI.Enums;

namespace HumansAPI.DTOs
{
    public class CreateHumanRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType Gender { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? CityId { get; set; }     
        public string? PhotoPath { get; set; }       
    }
}
