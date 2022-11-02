using HumansAPI.Enums;

namespace HumansAPI.Models.Domain
{
    public class HumanConnection : BaseEntity
    {
        public int FirstHumanId { get; set; }
        public int SecondHumanId { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public Human FirstHuman { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public Human SecondHuman { get; set; }
        public ConnectionType Type { get; set; }
    }

    
}
