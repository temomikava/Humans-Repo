using HumansAPI.Enums;

namespace HumansAPI.DTOs
{
    public class SetPhoneDto
    {
        public PhoneType Type { get; set; }
        public string PhoneNumber { get; set; }
    }
}
