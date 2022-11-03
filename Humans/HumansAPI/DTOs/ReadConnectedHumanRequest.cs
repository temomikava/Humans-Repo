using HumansAPI.Enums;

namespace HumansAPI.DTOs
{
    public class ReadConnectedHumanRequest
    {
        public int FirstHumanId { get; set; }
        public int SecondHumanId { get; set; }       
        public ConnectionType Type { get; set; }
    }
}
