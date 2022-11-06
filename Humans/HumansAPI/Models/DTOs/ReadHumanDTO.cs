using HumansAPI.Enums;

namespace HumansAPI.DTOs
{
    public class ReadHumanDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ReadCityDTO City { get; set; } = new();
        public List<ReadPhoneDTO>? Phones { get; set; } = new();
        public string? PhotoPath { get; set; }
        
        public List<ReadConnectedHumanDTO>? Connections { get; set; }= new();
    }
}
