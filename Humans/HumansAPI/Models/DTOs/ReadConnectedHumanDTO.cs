using HumansAPI.Enums;

namespace HumansAPI.DTOs
{
    public class ReadConnectedHumanDTO
    {
        public int Id { get; set; }
        public int FirstHumanId { get; set; }
        public int SecondHumanId { get; set; }       
        public ConnectionType Type { get; set; }
    }
}
