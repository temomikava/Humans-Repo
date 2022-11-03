using HumansAPI.Enums;

namespace HumansAPI.DTOs
{
    public class UpdateConnectedHumanRequest
    {
        public int Id { get; set; }
        public ConnectionType Type { get; set; }
    }
}
