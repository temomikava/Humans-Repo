using HumansAPI.Enums;

namespace HumansAPI.DTOs
{
    public class ReadPhoneRequest
    {
        public string PhoneNumber { get; set; }
        public PhoneType Type { get; set; }
    }
}
