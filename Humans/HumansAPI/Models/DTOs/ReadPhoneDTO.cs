using HumansAPI.Enums;

namespace HumansAPI.DTOs
{
    public class ReadPhoneDTO
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int HumanId { get; set; }
        public string Type { get; set; }
    }
}
