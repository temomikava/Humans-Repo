using HumansAPI.Enums;

namespace HumansAPI.Models.Domain
{
    public class Phone : BaseEntity
    {
        public string PhoneNumber { get; set; }
        public PhoneType Type { get; set; }
        public int HumanId { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public Human Human { get; set; }
    }
}
