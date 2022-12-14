using HumansAPI.Enums;

namespace HumansAPI.Requests
{
    public class UpdateHumanRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType Gender { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? CityId { get; set; }

    }
}
