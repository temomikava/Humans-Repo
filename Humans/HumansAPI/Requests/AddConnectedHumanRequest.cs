using HumansAPI.Enums;

namespace HumansAPI.Requests
{
    public class AddConnectedHumanRequest
    {
        public int FirstHumanId { get; set; }
        public int SecondHumanId { get; set; }
        public ConnectionType Type { get; set; }
    }
}
