using HumansAPI.Enums;

namespace HumansAPI.Requests
{
    public class AddPhoneRequest
    {
        public string PhoneNumber { get; set; }
        public PhoneType Type { get; set; }
        public int HumanId { get; set; }
    }
}
