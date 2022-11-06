using HumansAPI.Enums;

namespace HumansAPI.Requests
{
    public class UpdatePhoneRequest
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneType Type { get; set; }
        public int HumanId { get; set; }
    }
}
