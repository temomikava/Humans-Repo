using HumansAPI.Enums;

namespace HumansAPI.DTOs
{
    public class UpdatePhoneRequest
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneType Type { get; set; }
    }
}
