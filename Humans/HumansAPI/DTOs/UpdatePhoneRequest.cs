using HumansAPI.Enums;

namespace HumansAPI.DTOs
{
    public class UpdatePhoneRequest
    {
        public string PhoneNumber { get; set; }
        public PhoneType Type { get; set; }
        public int HumanId { get; set; }
    }
}
