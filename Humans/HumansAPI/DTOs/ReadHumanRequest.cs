using HumansAPI.Enums;

namespace HumansAPI.DTOs
{
    public class ReadHumanRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType Gender { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? CityId { get; set; }
        public List<SetPhoneDto>? Phones { get; set; } = new();
        public string? PhotoPath { get; set; }
        
        public List<ReadConnectedHumanRequest>? Connections { get; set; }= new();
    }
}
